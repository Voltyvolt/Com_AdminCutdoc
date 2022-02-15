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
            for (int i = 0; i < fpSpread1.ActiveSheet.Rows.Count; i++)
            {
                if (fpSpread1.ActiveSheet.Cells[i, 0].Text == "")
                {
                    break;
                }

                string lvBillNo = "0" + fpSpread1.ActiveSheet.Cells[i, 0].Text;
                DataTable DT = new DataTable();
                string lvSQL = "Select * From Queue_Diary INNER JOIN Cane_QueueData ON Queue_Diary.Q_Cutdoc = Cane_QueueData.C_ID INNER JOIN Cane_Quota ON Queue_Diary.Q_Quota = Cane_Quota.Q_ID INNER JOIN Cane_CaneType ON Cane_CaneType.C_ID = Queue_Diary.Q_CaneType WHERE Q_BillingNo LIKE '%" + lvBillNo + "%' AND Q_Year = '' ";
                DT = GsysSQL.fncGetQueryData(lvSQL, DT);

                for (int j = 0; j < DT.Rows.Count; j++)
                {
                    fpSpread1.ActiveSheet.Cells[i, 0].Text = DT.Rows[j]["Q_BillingNo"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 1].Text = DT.Rows[j]["Q_Quota"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 2].Text = DT.Rows[j]["Q_FirstName"].ToString() + " " + DT.Rows[j]["Q_LastName"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 3].Text = DT.Rows[j]["Q_CarNum"].ToString();
                    if (DT.Rows[j]["Q_CarNum2"].ToString() != "")
                    {
                        fpSpread1.ActiveSheet.Cells[i, 3].Text += "/" + DT.Rows[j]["Q_CarNum2"].ToString();
                    }
                    fpSpread1.ActiveSheet.Cells[i, 4].Text = DT.Rows[j]["Q_No"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 5].Text = DT.Rows[j]["C_CutContactorId"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 6].Text = DT.Rows[j]["C_Price"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 7].Text = DT.Rows[j]["C_ContractorId"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 8].Text = DT.Rows[j]["C_TruckPrice"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 9].Text = DT.Rows[j]["C_KeebContractorId"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 10].Text = DT.Rows[j]["C_KeebContractorPrice"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 11].Text = DT.Rows[j]["C_AllContractor"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 12].Text = DT.Rows[j]["C_AllPrice"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 13].Text = DT.Rows[j]["C_Name"].ToString();
                    fpSpread1.ActiveSheet.Cells[i, 14].Text = DT.Rows[j]["Q_WeightAllStatus"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int lvNumrow = fpSpread1.ActiveSheet.Rows.Count;
            int i = 0;

            for (i = 0; i < lvNumrow; i++)
            {
                this.Cursor = Cursors.WaitCursor;
                if (fpSpread1.ActiveSheet.Cells[i, 0].Text == "")
                {
                    break;
                }

                //เก็บข้อมูล
                string lvBillingNo = fpSpread1.ActiveSheet.Cells[i, 0].Text;
                string lvQuota = fpSpread1.ActiveSheet.Cells[i, 1].Text;
                string lvQNo = fpSpread1.ActiveSheet.Cells[i, 4].Text;
                string lvCutContactorId = fpSpread1.ActiveSheet.Cells[i, 5].Text;
                string lvCutPrice = fpSpread1.ActiveSheet.Cells[i, 6].Text;
                string lvTruckContractor = fpSpread1.ActiveSheet.Cells[i, 7].Text;
                string lvTruckPrice = fpSpread1.ActiveSheet.Cells[i, 8].Text;
                string lvKeebContractorId = fpSpread1.ActiveSheet.Cells[i, 9].Text;
                string lvKeebPrice = fpSpread1.ActiveSheet.Cells[i, 10].Text;
                string lvAllContractor = fpSpread1.ActiveSheet.Cells[i, 11].Text;
                string lvAllPrice = fpSpread1.ActiveSheet.Cells[i, 12].Text;
                string lvWeightAllstatus = fpSpread1.ActiveSheet.Cells[i, 13].Text;
                string lvBillIn = "0" + lvBillingNo;

                string lvCarryPriceStatus = "";
                string lvPayStauts = "";
                if (lvTruckPrice != "")
                {
                    lvCarryPriceStatus = "1";
                    lvPayStauts = "ชำระ";
                }
                else
                {
                    lvCarryPriceStatus = "";
                    lvPayStauts = "ไม่ชำระ";
                }

                string lvQNo2 = lvQNo + ".1"; //คิวลูก

                if(lvBillingNo != "")
                {
                    //บันทึกลงตาราง Queue_Online
                    string lvSQL = "Update Cane_QueueData SET C_CutContactorId = '" + lvCutContactorId + "', C_Price = '" + lvCutPrice + "', C_ContractorId = '" + lvTruckContractor + "', " +
                        "C_TruckPrice = '" + lvTruckPrice + "', C_KeebContractorId = '" + lvKeebContractorId + "', C_KeebContractorPrice = '" + lvKeebPrice + "', C_AllContractor = '" + lvAllContractor + "', " +
                        "C_AllPrice = '" + lvAllPrice + "', C_PayStatus = '" + lvPayStauts + "' WHERE C_Queue = '" + lvQNo + "' ";
                    string lvResult = GsysSQL.fncExecuteQueryData(lvSQL);

                    //บันทึกลงตาราง Queue_Diary ตัวแม่
                    lvSQL = "Update Queue_Diary SET Q_CutCar = '" + lvCutContactorId + "', Q_CutPrice = '" + lvCutPrice + "', Q_CarryPrice = '" + lvTruckPrice + "', Q_CarryPriceStatus = '" + lvCarryPriceStatus + "' " +
                        "WHERE Q_No = '" + lvQNo + "' AND Q_Year = '' ";
                    lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                }

                if(lvQNo2 != "" && lvWeightAllstatus == "1")
                {
                    //บันทึกลงตาราง Queue_Diary ตัวลูก
                    string lvSQL = "Update Queue_Diary SET Q_CutCar = '" + lvCutContactorId + "', Q_CutPrice = '" + lvCutPrice + "', Q_CarryPrice = '" + lvTruckPrice + "', Q_CarryPriceStatus = '" + lvCarryPriceStatus + "' " +
                        "WHERE Q_No = '" + lvQNo2 + "' And Q_Year = '' ";
                    string lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                }
                else
                {
                    //ไม่ต้องทำอะไร
                }
            }

            MessageBox.Show("บันทึกข้อมูล : " + i + " บรรทัด สำเร็จ...", "แจ้งเตือน!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
        }

        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                FarPoint.Win.Spread.Model.CellRange cr;
                cr = fpSpread1.ActiveSheet.GetSelection(0);
                fpSpread1.ActiveSheet.ClearRange(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount, true);
            }
        }
    }
}
