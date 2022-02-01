using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FolderNotify
{
    public partial class Form1 : Form
    {
        private AddPath m_addPathForm = new AddPath();
        private Verify m_verifyRemove = new Verify();
        private DataSet m_watchPaths = new DataSet();
        private Dictionary<string, FileSystemWatcher> m_activeWatchers = new Dictionary<string, FileSystemWatcher>();
        private int m_currentRow = -1;

        public Form1()
        {
            InitializeComponent();
            dgvPathDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            loadWatchPaths();
        }

        private void loadWatchPaths()
        {            
            if(File.Exists("watchPathData.xml"))
            {
                try
                {
                    m_watchPaths.ReadXml("watchPathData.xml");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to read saved match paths : " + ex.Message, "Error Reading Saved Paths");
                }
                displayWatchedPaths();
                startPathWatches();
            }
        }

        private void displayWatchedPaths()
        {
            // show currently defined path watches
            dgvPathDisplay.DataSource = m_watchPaths.Tables["paths"];
        }

        private void startPathWatches()
        {
            // start currently enabled path watches
            foreach(DataRow row in m_watchPaths.Tables["paths"].Rows)
            {
                string targetPath = row["path"].ToString();
                bool enabled = bool.Parse(row["enabled"].ToString());
                if(enabled)
                {
                    if(!m_activeWatchers.ContainsKey(targetPath))
                    {
                        FileSystemWatcher watch = createWatcher(targetPath);
                        if (watch != null)
                            m_activeWatchers.Add(targetPath, watch);
                    }
                }
            }
        }

        private FileSystemWatcher createWatcher(string targetPath)
        {
            try
            {
                string filter = "*";
                if(!string.IsNullOrEmpty(Properties.Settings.Default.FileFilter))
                    filter = Properties.Settings.Default.FileFilter;
        FileSystemWatcher watcher = new FileSystemWatcher(targetPath, filter);
                watcher.Created += Watcher_Created;
                watcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;
                watcher.Filter = "*";
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                return watcher;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unablel to watch path " + targetPath + Environment.NewLine + ex.Message);
            }
            return null;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
                return;
            updateTextbox(string.Format("{0} - Created : {1}", DateTime.Now.ToString(), e.FullPath));
        }

        public void updateTextbox(string text)
        {
            if (tbxPathChangeLog.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { updateTextbox($"{text}"); };
                tbxPathChangeLog.Invoke(safeWrite);
            }
            else
            {
                tbxPathChangeLog.AppendText(text + Environment.NewLine);
                niTrayIcon.ShowBalloonTip(1500, "Path Created", text, ToolTipIcon.Info);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void niTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            m_addPathForm.SelectedPath = "";
            if(m_addPathForm.ShowDialog() == DialogResult.OK)
            {
                string path = m_addPathForm.SelectedPath;
                if (Directory.Exists(path))
                {
                    bool dirty = false;
                    if(!m_watchPaths.Tables.Contains("paths"))
                    {
                        DataTable table = new DataTable("paths");
                        DataColumn col = new DataColumn("path", typeof(string));
                        table.Columns.Add(col);
                        col = new DataColumn("enabled", typeof(bool));
                        table.Columns.Add(col);
                        m_watchPaths.Tables.Add(table);
                        dirty = true;
                    }
                    string query = string.Format("path = '{0}'", path);
                    DataRow[] res = m_watchPaths.Tables["paths"].Select(query);
                    if(res.Length < 1)
                    {
                        DataRow row = m_watchPaths.Tables["paths"].NewRow();
                        row["path"] = path;
                        row["enabled"] = true;
                        m_watchPaths.Tables["paths"].Rows.Add(row);
                        dirty = true;
                    }
                    if(dirty)
                    {
                        try
                        {
                            m_watchPaths.WriteXml("watchPathData.xml");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error writing watched paths : " + ex.Message);
                        }
                    }
                }
            }
            displayWatchedPaths();
            startPathWatches();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvPathDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // If the user pressed something else than mouse right click, return
            if (e.Button != System.Windows.Forms.MouseButtons.Right) { return; }

            DataGridView dgv = (DataGridView)sender;

            // Use HitTest to resolve the row under the cursor
            m_currentRow = dgv.HitTest(e.X, e.Y).RowIndex;

            // If there was no DataGridViewRow under the cursor, return
            if (m_currentRow == -1) { return; }
            if(m_currentRow > dgvPathDisplay.Rows.Count - 2) { return; }

            // Clear all other selections before making a new selection
            dgv.ClearSelection();

            // Select the found DataGridViewRow
            dgv.Rows[m_currentRow].Selected = true;
            cmsPathMenu.Show(Cursor.Position);
        }

        private void toggleEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dgvPathDisplay.Rows[m_currentRow];
            string path = row.Cells[0].Value.ToString();
            bool enabled = bool.Parse(row.Cells[1].Value.ToString());
            enabled = !enabled;
            m_watchPaths.Tables["paths"].Rows[m_currentRow]["enabled"] = enabled;
            try
            {
                if (!enabled)
                {
                    if (m_activeWatchers.ContainsKey(path))
                    {
                        m_activeWatchers[path].Dispose();
                        m_activeWatchers.Remove(path);
                    }
                }
                else
                {
                    if (!m_activeWatchers.ContainsKey(path))
                    {
                        FileSystemWatcher watch = createWatcher(path);
                        if (watch != null)
                            m_activeWatchers.Add(path, watch);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error setting watcher {0} to {1} : {2}", path, enabled, ex.Message), "Error Updating Watchers");
            }
            try
            {
                m_watchPaths.WriteXml("watchPathData.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing stored paths : " + ex.Message, "Error Writing XML");
            }
            displayWatchedPaths();
        }

        private void removeWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = dgvPathDisplay.Rows[m_currentRow];
            m_verifyRemove.WatchPath = row.Cells[0].Value.ToString();
            if(m_verifyRemove.ShowDialog() == DialogResult.OK)
            {
                m_watchPaths.Tables["paths"].Rows.RemoveAt(m_currentRow);
            }
            try
            {
                m_watchPaths.WriteXml("watchPathData.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing stored paths : " + ex.Message, "Error Writing XML");
            }
            displayWatchedPaths();
        }
    }
}
