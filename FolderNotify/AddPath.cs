using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderNotify
{
    public partial class AddPath : Form
    {
        /* This property is used as a vehicle to gather the target path
           to watch from the user.                                      */
        public string SelectedPath
        {
            get { return tbxPath.Text; }
            set { tbxPath.Text = value; }
        }

        public AddPath()
        {
            InitializeComponent();
        }

        /* This method simply updates the variable for the set value
           shared with the host, Form1.                              */
        private void tbxPath_TextChanged(object sender, EventArgs e)
        {
            SelectedPath = tbxPath.Text;
        }
    }
}
