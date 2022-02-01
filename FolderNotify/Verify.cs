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
    public partial class Verify : Form
    {
        /* The WatchPath property is used to pass the path to remove
           through the verification process, displaying it for the user
           when the form is shown.                                      */
        public string WatchPath
        {
            get { return lblWatchPath.Text; }
            set { lblWatchPath.Text = value; }
        }

        public Verify()
        {
            InitializeComponent();
        }
    }
}
