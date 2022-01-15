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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadDataHukang1();
            LoadDataHukang2();
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ConnectionString;
            label3.Text = connection;
        }

        private void LoadDataHukang1()
        {
            DataTable DT = new DataTable();
            string lvSQL = "Select * From Cane_QueueData Where C_UserId = '" + txtUserid.Text + "' AND C_Date = '" + Gstr.fncChangeTDate(txtDate.Text) + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            int lvNumrow = DT.Rows.Count;
            fpSpread1.ActiveSheet.Rows.Count = lvNumrow;

           
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                fpSpread1.ActiveSheet.Cells[i, 0].Text = DT.Rows[i]["C_ID"].ToString(); //ใบนำตัด
                fpSpread1.ActiveSheet.Cells[i, 1].Text = DT.Rows[i]["C_Queue"].ToString(); //โควต้า
                fpSpread1.ActiveSheet.Cells[i, 2].Text = DT.Rows[i]["C_CarcutNumber"].ToString(); //ชื่อ
                fpSpread1.ActiveSheet.Cells[i, 3].Text = DT.Rows[i]["C_Price"].ToString(); //รับเหมาตัด
                fpSpread1.ActiveSheet.Cells[i, 4].Text = DT.Rows[i]["C_TruckPrice"].ToString(); //ราคารับเหมาตัด
                fpSpread1.ActiveSheet.Cells[i, 5].Text = DT.Rows[i]["C_TruckCarnum"].ToString(); //ราคารับเหมาตัด
                fpSpread1.ActiveSheet.Cells[i, 6].Text = DT.Rows[i]["C_TruckCarnum2"].ToString(); //ราคารับเหมาตัด
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadDataHukang2()
        {
            DataTable DT = new DataTable();
            string lvSQL = "Select * From Cane_QueueData Where C_UserId = '" + txtUserid.Text + "' And C_TruckCarNum2 != '' AND C_Date = '" + Gstr.fncChangeTDate(txtDate.Text) + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            int lvNumrow = DT.Rows.Count;
            fpSpread2.ActiveSheet.Rows.Count = lvNumrow;

           
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                fpSpread2.ActiveSheet.Cells[i, 0].Text = DT.Rows[i]["C_ID"].ToString(); //ใบนำตัด
                fpSpread2.ActiveSheet.Cells[i, 1].Text = DT.Rows[i]["C_Queue"].ToString() + ".1"; //โควต้า
                fpSpread2.ActiveSheet.Cells[i, 2].Text = DT.Rows[i]["C_CarcutNumber"].ToString(); //ชื่อ
                fpSpread2.ActiveSheet.Cells[i, 3].Text = DT.Rows[i]["C_Price"].ToString(); //รับเหมาตัด
                fpSpread2.ActiveSheet.Cells[i, 4].Text = DT.Rows[i]["C_TruckPrice"].ToString(); //ราคารับเหมาตัด
                fpSpread2.ActiveSheet.Cells[i, 5].Text = DT.Rows[i]["C_TruckCarnum"].ToString(); //ราคารับเหมาตัด
                fpSpread2.ActiveSheet.Cells[i, 6].Text = DT.Rows[i]["C_TruckCarnum2"].ToString(); //ราคารับเหมาตัด
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Q_CutDoc = "";
            string Q_CutCar = "";
            string Q_CutPrice = "";
            string Q_CarryPrice = "";
            string Q_No = "";
            string result = "";

            progressBar1.Maximum = fpSpread1.ActiveSheet.Rows.Count;
            progressBar1.Step = 1;

            for (int i = 0; i < fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (fpSpread1.ActiveSheet.Cells[i,0].Text == "")
                {
                    break;
                }
                else
                {
                    Q_CutDoc = fpSpread1.ActiveSheet.Cells[i, 0].Text;
                    Q_CutCar = fpSpread1.ActiveSheet.Cells[i, 2].Text;
                    Q_CutPrice = fpSpread1.ActiveSheet.Cells[i, 3].Text;
                    Q_CarryPrice = fpSpread1.ActiveSheet.Cells[i, 4].Text;
                    Q_No = fpSpread1.ActiveSheet.Cells[i, 1].Text;

                    string SQL = "Update Queue_Diary SET Q_CutDoc = '" + Q_CutDoc + "', Q_CutCar = '" + Q_CutCar + "', Q_CutPrice = '" + Q_CutPrice + "', " +
                        "Q_CarryPrice = '" + Q_CarryPrice + "' WHERE Q_No = '" + Q_No + "' AND Q_YEAR = '' ";
                    if(Q_No != "") result = GsysSQL.fncExecuteQueryData(SQL);

                    progressBar1.PerformStep();
                }
            }

            progressBar1.Value = fpSpread1.ActiveSheet.Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Q_CutDoc = "";
            string Q_CutCar = "";
            string Q_CutPrice = "";
            string Q_CarryPrice = "";
            string Q_No = "";
            string result = "";

            progressBar1.Maximum = fpSpread2.ActiveSheet.Rows.Count;
            progressBar1.Step = 1;

            for (int i = 0; i < fpSpread2.ActiveSheet.Rows.Count; i++)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (fpSpread2.ActiveSheet.Cells[i, 0].Text == "")
                {
                    break;
                }
                else
                {
                    Q_CutDoc = fpSpread2.ActiveSheet.Cells[i, 0].Text;
                    Q_CutCar = fpSpread2.ActiveSheet.Cells[i, 2].Text;
                    Q_CutPrice = fpSpread2.ActiveSheet.Cells[i, 3].Text;
                    Q_CarryPrice = fpSpread2.ActiveSheet.Cells[i, 4].Text;
                    Q_No = fpSpread2.ActiveSheet.Cells[i, 1].Text;

                    string SQL = "Update Queue_Diary SET Q_CutDoc = '" + Q_CutDoc + "' WHERE Q_No = '" + Q_No + "' AND Q_YEAR = '' ";
                    if (Q_No != "0.1") result = GsysSQL.fncExecuteQueryData(SQL);

                    progressBar1.PerformStep();

                }
            }
            progressBar1.Value = fpSpread2.ActiveSheet.Rows.Count;
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
