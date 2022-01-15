using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com_AdminCutdoc
{
    public partial class EditCutdoc : Form
    {
        public EditCutdoc()
        {
            InitializeComponent();
        }

        private void EditCutdoc_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();

        }
    }
}
