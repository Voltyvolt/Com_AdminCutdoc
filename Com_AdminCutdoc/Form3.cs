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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void fncGetCaneType()
        {
            DataTable DT = new DataTable();
            string SQL = "Select Q_No, Q_BillingNo, Q_CaneType, C_CaneType From Queue_Diary INNER JOIN Cane_QueueData ON Queue_Diary.Q_No = Cane_QueueData.C_Queue WHERE C_CaneType is null AND Q_Year = '' ";
            DT = GsysSQL.fncGetQueryData(SQL, DT);

            fpSpread1.ActiveSheet.Rows.Count = DT.Rows.Count;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                fpSpread1.ActiveSheet.Cells[i, 0].Text = DT.Rows[i]["Q_No"].ToString();
                fpSpread1.ActiveSheet.Cells[i, 1].Text = DT.Rows[i]["Q_BillingNo"].ToString();
                fpSpread1.ActiveSheet.Cells[i, 2].Text = DT.Rows[i]["Q_CaneType"].ToString();
                fpSpread1.ActiveSheet.Cells[i, 3].Text = DT.Rows[i]["C_CaneType"].ToString();
            }
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fncGetCaneType();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                string Q_No = fpSpread1.ActiveSheet.Cells[i, 0].Text;
                string canetype = fpSpread1.ActiveSheet.Cells[i, 2].Text;

                string SQL = "Update Cane_QueueData SET C_CaneType = '" + canetype + "' WHERE C_Queue = '" + Q_No + "' ";
                string result = GsysSQL.fncExecuteQueryData(SQL);
            }
            
           

        }
    }
}
