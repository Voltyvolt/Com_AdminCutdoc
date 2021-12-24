using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com_AdminCutdoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fncLoadDataHukang();

            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ConnectionString;
            label1.Text = connection;
        }

        private void fncLoadDataHukang()
        {
            DataTable DT = new DataTable();
            string lvSQL = "Select * From Cane_QueueData Where C_UserId = '" + txt_Userid.Text + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            int lvNumrow = DT.Rows.Count;
            fpSpread1.ActiveSheet.Rows.Count = lvNumrow;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                fpSpread1.ActiveSheet.Cells[i, 0].Text = DT.Rows[i]["C_ID"].ToString(); //ใบนำตัด
                fpSpread1.ActiveSheet.Cells[i, 1].Text = DT.Rows[i]["C_PlanId"].ToString(); //เลขแปลง
                fpSpread1.ActiveSheet.Cells[i, 2].Text = DT.Rows[i]["C_Quota"].ToString(); //โควต้า
                fpSpread1.ActiveSheet.Cells[i, 3].Text = DT.Rows[i]["C_FullName"].ToString(); //ชื่อ
                fpSpread1.ActiveSheet.Cells[i, 4].Text = DT.Rows[i]["C_CutContactorId"].ToString(); //รับเหมาตัด
                fpSpread1.ActiveSheet.Cells[i, 5].Text = DT.Rows[i]["C_Price"].ToString(); //ราคารับเหมาตัด
                fpSpread1.ActiveSheet.Cells[i, 6].Text = DT.Rows[i]["C_ContractorId"].ToString(); //รับเหมาบรรทุก
                fpSpread1.ActiveSheet.Cells[i, 7].Text = DT.Rows[i]["C_TruckPrice"].ToString(); //ราคารับเหมาบรรทุก
                fpSpread1.ActiveSheet.Cells[i, 8].Text = DT.Rows[i]["C_KeebContractorID"].ToString(); //รับเหมาคีบ
                fpSpread1.ActiveSheet.Cells[i, 9].Text = DT.Rows[i]["C_KeebContractorPrice"].ToString(); //ราคารับเหมาคีบ
                fpSpread1.ActiveSheet.Cells[i, 10].Text = DT.Rows[i]["C_AllContractor"].ToString(); //รับเหมารวม
                fpSpread1.ActiveSheet.Cells[i, 11].Text = DT.Rows[i]["C_AllPrice"].ToString(); //ราคารับเหมารวม
                fpSpread1.ActiveSheet.Cells[i, 12].Text = DT.Rows[i]["C_TruckCarnum"].ToString(); //ทะเบียน
                fpSpread1.ActiveSheet.Cells[i, 13].Text = DT.Rows[i]["C_TruckCarnum2"].ToString(); //พ่วง
                fpSpread1.ActiveSheet.Cells[i, 14].Text = DT.Rows[i]["C_Queue"].ToString(); //คิว
                fpSpread1.ActiveSheet.Cells[i, 15].Text = DT.Rows[i]["C_CaneType"].ToString(); //ชนิดอ้อย
                fpSpread1.ActiveSheet.Cells[i, 16].Text = DT.Rows[i]["C_Date"].ToString(); //วันที่
                fpSpread1.ActiveSheet.Cells[i, 17].Text = DT.Rows[i]["C_Time"].ToString(); //เวลา
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fpSpread2.ActiveSheet.Rows.Count; i++)
            {
                if(fpSpread2.ActiveSheet.Cells[i,1].Text == "")
                {
                    break;
                }
                string quota = fpSpread2.ActiveSheet.Cells[i, 1].Text; //โควต้า
                fpSpread2.ActiveSheet.Cells[i, 2].Text = fncCheckQuotaName(quota); //ชื่อ
                string carcutcode = fpSpread2.ActiveSheet.Cells[i, 3].Text; //รับเหมาตัด
                fpSpread2.ActiveSheet.Cells[i, 4].Text = fncCheckCarcutNum(carcutcode); //เลขรถตัด
                fpSpread2.ActiveSheet.Cells[i, 5].Text = fncCheckCarcutDriver(carcutcode); //คนขับรถตัด
                string carcutprice = fncCheckCarcutPrice(carcutcode);
                if(carcutprice != "") fpSpread2.ActiveSheet.Cells[i, 6].Text = fncCheckCarcutPrice(carcutcode);

                string truckcontract = fpSpread2.ActiveSheet.Cells[i, 7].Text; //รับเหมาบรรทุก
                string keebcontract = fpSpread2.ActiveSheet.Cells[i, 9].Text; //รับเหมาคีบ
                fpSpread2.ActiveSheet.Cells[i, 10].Text = fncCheckkeebPrice(keebcontract); //ราคาคีบ
                string allcontract = fpSpread2.ActiveSheet.Cells[i, 11].Text; //รับเหมารวม
                fpSpread2.ActiveSheet.Cells[i, 12].Text = fncCheckkeebPrice(allcontract); //ราคารวม
                string canename = fpSpread2.ActiveSheet.Cells[i, 16].Text;
                fpSpread2.ActiveSheet.Cells[i, 17].Text = fncCheckCanetype(canename); //เลขประเภท
                string car1 = fpSpread2.ActiveSheet.Cells[i, 13].Text; //ทะเบียนรถ
                fpSpread2.ActiveSheet.Cells[i, 18].Text = fncCheckCartype(car1); //ประเภทรถ

                if(canename == "อ้อยสดรถตัดนอก")
                {
                    fpSpread2.ActiveSheet.Cells[i, 19].Text = "รถตัดนอก"; //ประเภทรถตัด
                }
                else if (canename == "อ้อยสดรถตัด")
                {
                    fpSpread2.ActiveSheet.Cells[i, 19].Text = "รถตัดใน"; //ประเภทรถตัด
                }
                else
                {
                    fpSpread2.ActiveSheet.Cells[i, 19].Text = "คนตัด";
                }

                if(fpSpread2.ActiveSheet.Cells[i, 8].Text != "")
                {
                    fpSpread2.ActiveSheet.Cells[i, 20].Text = "ชำระ";
                }
                else
                {
                    fpSpread2.ActiveSheet.Cells[i, 20].Text = "ไม่ชำระ";
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ข้อมูล
            string C_PlanId = ""; //1
            string C_PlanName = ""; //2
            string C_Quota = ""; //3
            string C_FullName = ""; //4
            string C_GisRai = ""; //5
            string C_UserId = txt_Userid.Text; //6
            string C_CutContactorId = ""; //7
            string C_CarcutNumber = ""; //8
            string C_DriverId = ""; //9
            string C_Price = ""; //10
            string C_BoxTruckId = ""; //11
            string C_ContractorId = ""; //12
            string C_TruckPrice = ""; //13
            string C_PayStatus = "";
            string C_TruckCarnum = "";
            string C_TruckDistance = "";
            string C_CaneType = "";
            string C_TruckCarnum2 = "";
            string C_Date = "";
            string C_Time = "";
            string C_Queue = "";
            string C_QueueStatus = "รับข้อมูลเข้า";
            string C_KeebContractorId = "";
            string C_KeebContractorPrice = "";
            string C_DriverId2 = "";
            string C_bonsucro = "";
            string C_QuotaChild = "";
            string C_TruckType = "";
            string C_ContracType = "";
            string C_AllContractor = "";
            string C_AllPrice = "";
            string C_SuccessStatus = "";
            string Q_WeightINTimeDate = "";
            string Q_WeightTimeOUTDate = "";
            string Q_QueueTimeDate = "";
            string Q_BillingNos = ""; //35
            string result = "";

            int sheetrows = fpSpread2.ActiveSheet.Rows.Count;

            for (int i = 0; i < sheetrows; i++)
            {
                
                if(fpSpread2.ActiveSheet.Cells[i, 1].Text == "")
                {
                    break;
                }
                else
                {
                    C_Quota = fpSpread2.ActiveSheet.Cells[i, 1].Text;
                    C_FullName = fpSpread2.ActiveSheet.Cells[i, 2].Text;
                    C_CutContactorId = fpSpread2.ActiveSheet.Cells[i, 3].Text;
                    C_CarcutNumber = fpSpread2.ActiveSheet.Cells[i, 4].Text;
                    C_DriverId = fpSpread2.ActiveSheet.Cells[i, 5].Text;
                    C_Price = fpSpread2.ActiveSheet.Cells[i, 6].Text;
                    C_ContractorId = fpSpread2.ActiveSheet.Cells[i, 7].Text;
                    C_TruckPrice = fpSpread2.ActiveSheet.Cells[i, 8].Text;
                    if (C_ContractorId != "")
                    {
                        C_BoxTruckId = fpSpread2.ActiveSheet.Cells[i, 13].Text;
                    }
                    C_PayStatus = fpSpread2.ActiveSheet.Cells[i, 20].Text;
                    C_TruckCarnum = fpSpread2.ActiveSheet.Cells[i, 13].Text;
                    C_TruckCarnum2 = fpSpread2.ActiveSheet.Cells[i, 14].Text;
                    C_Date = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
                    C_Time = DateTime.Now.ToString("HH:mm:ss").ToString();
                    C_KeebContractorId = fpSpread2.ActiveSheet.Cells[i, 9].Text;
                    C_KeebContractorPrice = fpSpread2.ActiveSheet.Cells[i, 10].Text;
                    C_AllContractor = fpSpread2.ActiveSheet.Cells[i, 11].Text;
                    C_AllPrice = fpSpread2.ActiveSheet.Cells[i, 12].Text;
                    C_TruckType = fpSpread2.ActiveSheet.Cells[i, 18].Text;
                    C_Queue = fpSpread2.ActiveSheet.Cells[i, 15].Text;


                    string SQL = "INSERT INTO Cane_QueueData (C_PlanId,C_PlanName,C_Quota,C_FullName,C_GisRai,C_UserId,C_CarcutNumber,C_DriverId,C_Price,C_BoxTruckId, C_ContractorId,C_TruckPrice,C_PayStatus,C_TruckCarnum, ";
                    SQL += "C_TruckDistance,C_CaneType, C_TruckCarnum2,C_Date,C_Time,C_Queue,C_QueueStatus,C_CutContactorId,C_KeebContractorId,C_KeebContractorPrice,C_DriverId2, ";
                    SQL += "C_bonsucro,C_QuotaChild,C_TruckType,C_ContracType,C_AllContractor,C_AllPrice,C_SuccessStatus,Q_WeightINTimeDate,Q_WeightTimeOUTDate,Q_QueueTimeDate,Q_BillingNos) ";
                    SQL += "VALUES ('" + C_PlanId + "','" + C_PlanName + "','" + C_Quota + "','" + C_FullName + "','" + C_GisRai + "','" + C_UserId + "','" + C_CarcutNumber + "','" + C_DriverId + "', '" + C_Price + "', ";
                    SQL += "'" + C_BoxTruckId + "','" + C_ContractorId + "','" + C_TruckPrice + "','" + C_PayStatus + "','" + C_TruckCarnum + "','" + C_TruckDistance + "','" + C_CaneType + "','" + C_TruckCarnum2 + "', ";
                    SQL += "'" + C_Date + "','" + C_Time + "','" + C_Queue + "','" + C_QueueStatus + "','" + C_CutContactorId + "','" + C_KeebContractorId + "','" + C_KeebContractorPrice + "', ";
                    SQL += "'" + C_DriverId2 + "','" + C_bonsucro + "','" + C_QuotaChild + "','" + C_TruckType + "','" + C_ContracType + "','" + C_AllContractor + "','" + C_AllPrice + "', ";
                    SQL += "'" + C_SuccessStatus + "','" + Q_WeightINTimeDate + "','" + Q_WeightTimeOUTDate + "','" + Q_QueueTimeDate + "','" + Q_BillingNos + "' )";
                    result = GsysSQL.fncExecuteQueryData(SQL);
                }
            }

            if(result == "Success")
            {
                fncLoadDataHukang();
            }
        }

        public static string fncCheckQuotaName(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnectionMCSS"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT FirstNameTH, LastNameTH FROM Quotas WHERE Code = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["FirstNameTH"].ToString() + " " + dr["LastNameTH"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCarcutNum(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT C_Code FROM Cane_Carcutbase WHERE C_OwnedCode = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["C_Code"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCarcutDriver(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT C_DriverCode FROM Cane_Carcutbase WHERE C_OwnedCode = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["C_DriverCode"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCarcutPrice(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT C_Price FROM Cane_CarCut WHERE C_Code = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["C_Price"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckTruckPrice(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT T_TruckPrice FROM Cane_TruckPrice WHERE T_Quota = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["T_TruckPrice"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckkeebPrice(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT P_Price FROM Cane_CarContractor WHERE P_CarContractorID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["P_Price"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCanetype(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT C_ID FROM Cane_CaneType WHERE C_Name = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["C_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCartype(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT T_TruckType FROM Cane_Truck WHERE T_TruckCarRegistration = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["T_TruckType"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
