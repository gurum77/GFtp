using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFtp
{
    public partial class ProgressForm : Form
    {
        public string Message {set {messageLabel.Text = value;}}
        public int ProgressValue { set { progressBar.Value = value; } }    
        public event EventHandler<EventArgs> Canceled;

        public ProgressForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea  = Canceled;
            if(ea != null)
            {
                ea(this, e);
            }
        }
    }
}
