using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace Com_AdminCutdoc
{
    public class GsysSQL
    {
        //Execute Data
        public static DataTable fncGetQueryData(string lvSQL,DataTable dt)
        {
            string query = lvSQL;
            DataTable DTReturn = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(query, System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            DA.Fill(DTReturn);

            return DTReturn;
        }

        public static string fncExecuteQueryData(string lvSQL)
        {
            string lvReturn = "";
            try
            {
                string query = lvSQL;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();

                lvReturn = "Success";
                return lvReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string fncExecuteQueryDataAccess(string lvSQL)
        {
            string lvReturn = "";
            try
            {
                string query = lvSQL;
                OleDbConnection MyConn = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSAccess"].ToString());
                MyConn.Open();
                OleDbCommand Cmd = new OleDbCommand(lvSQL, MyConn);
                Cmd.ExecuteNonQuery();

                lvReturn = "Success";
                MyConn.Close();
                Cmd.Dispose();

                return lvReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        

        public static string fncCheckEmpType(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT EmpType_ID FROM Emp_Type WHERE EmpType_ID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["EmpType_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckCancel(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT O_Status FROM Cane_OilBillHD WHERE O_CaneNo = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["O_Status"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckEmpPrefix(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT PrefixID FROM Emp_Prefix WHERE PrefixID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["PrefixID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckEmpFaction(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Faction_ID FROM Emp_Faction WHERE Faction_ID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Faction_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckEmpSection(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Section_ID FROM Emp_Section WHERE Section_ID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Section_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckEmpPosition(string lvSearch)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Position_ID FROM Emp_Position WHERE Position_ID = '" + lvSearch + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Position_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckDocNo(string lvDocS,string lvDocNo)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT O_DocNo FROM Cane_OilBillHD WHERE O_DocNo = '"+ lvDocNo +"' And O_Status = '' ";//O_DocS = '" + lvDocS + "' And
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["O_DocNo"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckBillNo(string lvSearch, string lvDocNo)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT O_DocNo FROM Cane_OilBillHD WHERE O_DocNo <> '"+ lvDocNo +"' And O_CaneNo = '" + lvSearch + "' And O_Status = '' And O_Year = '' ";//
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["O_DocNo"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        //Function Find

        public static string fncFindFactionName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Faction_Name FROM Emp_Faction WHERE Faction_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Faction_Name"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindSectionName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Section_Name FROM Emp_Section WHERE Section_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Section_Name"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindSectionID(string lvName)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Section_ID FROM Emp_Section WHERE Section_Name = '" + lvName + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Section_ID"].ToString();
                }
            }
            else
            {
                lvReturn = lvName;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindFactionID(string lvName)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Faction_ID FROM Emp_Faction WHERE Faction_Name = '" + lvName + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Faction_ID"].ToString();
                }
            }
            else
            {
                lvReturn = lvName;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindPositionName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Position_Name FROM Emp_Position WHERE Position_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Position_Name"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindPrefixName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT PrefixName FROM Emp_Prefix WHERE PrefixID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["PrefixName"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindEmpTypeName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT EmpType_Name FROM Emp_Type WHERE EmpType_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["EmpType_Name"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindEmpName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Employee_Name FROM Employee WHERE Employee_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Employee_Name"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindEmpFullName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Employee_NTitle, Employee_Name, Employee_LName FROM Employee WHERE Employee_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Employee_NTitle"].ToString() + " " + dr["Employee_Name"].ToString() + " " + dr["Employee_LName"].ToString();
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindEmpIDByUser(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT us_EmpID FROM SysUser WHERE us_UserID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["us_EmpID"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindEmpLName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Employee_LName FROM Employee WHERE Employee_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Employee_LName"].ToString();
                }
            }
            else
            {
                lvReturn = lvID;
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }
        
        public static string FindSectionByEmpID(string lvEmpID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Section_Name FROM Employee Inner Join Emp_Section On Section_ID = Employee_Section WHERE Employee_ID = '" + lvEmpID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Section_Name"].ToString();
                }
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindQuotaName(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Q_Prefix, Q_FirstName, Q_LastName FROM Cane_Quota WHERE Q_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Q_Prefix"].ToString() + " " + dr["Q_FirstName"].ToString() + " " + dr["Q_LastName"].ToString();
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindOilPrice(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT C_ItemPrice FROM Cane_OillItem WHERE C_Item = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["C_ItemPrice"].ToString();
                }
            }
            else
            {
                lvReturn = "0.00";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }
        
        public static string fncFindMeterOil(string lvID)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            //cmd.CommandText = "SELECT Top 1 O_MeterE FROM Cane_OilBillHD WHERE O_CarFront = '" + lvID + "' And O_Status = '' And O_MeterActive = '1' Order by O_MeterE Desc ";
            cmd.CommandText = "SELECT M_RunMetter FROM Cane_OilMeter WHERE M_ID = '" + lvID + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //lvReturn = dr["O_MeterE"].ToString();
                    lvReturn = dr["M_RunMetter"].ToString();
                }
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindCarryStatus(string lvBill)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT Q_CarryPriceStatus FROM Queue_Diary WHERE Q_BillingNo = '" + lvBill + "' and Q_BillingNo <> '' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["Q_CarryPriceStatus"].ToString();
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncFindDue(string lvDate)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT M_Due FROM MiniCane_Due WHERE '" + lvDate + "' >= M_DateS and '" + lvDate + "' <= M_DateE ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["M_Due"].ToString();
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        //Document
        public static string fncGenDocNo(string lvDocCode)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";
            DateTime lvTimeChk = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy 15:00:00")); // 20/08/2562 15:00:00
            DateTime lvTimeNow = DateTime.Now;

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM SysDocNo WHERE S_MCode = '" + lvDocCode + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //GenDoc
                    string lvShort = dr["S_ShortCode"].ToString();
                    int lvYearChk = DateTime.Now.Year;
                    if (lvYearChk < 2500) lvYearChk += 543;
                    string lvYear = (lvYearChk - 2500).ToString();
                    int lvMonth = DateTime.Now.Month;
                    int lvDay = 0;
                    if (lvTimeNow > lvTimeChk)
                    {
                        lvDay = DateTime.Now.Day + 1;
                    }
                    else
                    {
                        lvDay = DateTime.Now.Day;
                    }
                    string lvSection = "121";
                    string lvTypeGen = dr["S_TypeGen"].ToString();
                    int lvRunDoc = Gstr.fncToInt(dr["S_RunNo"].ToString());

                    if (lvRunDoc == 0)
                        lvRunDoc = 1;
                    else
                        lvRunDoc += 1;

                    string lvDocID = "";
                    if (lvTypeGen == "YYMMDept")
                        lvDocID = lvShort + lvYear.ToString() + lvMonth.ToString("00") + lvSection + lvRunDoc.ToString(dr["S_Format"].ToString());
                    else if (lvTypeGen == "YYMMdd")
                        lvDocID = lvShort + lvYear.ToString() + lvMonth.ToString("00") + lvDay.ToString("00") + lvRunDoc.ToString(dr["S_Format"].ToString());
                    else
                        lvDocID = lvShort + lvRunDoc.ToString(dr["S_Format"].ToString());

                    lvReturn = lvDocID;
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        //
        public static string fncGenDocNoX(string lvDocCode)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT * FROM SysDocNo WHERE S_MCode = '" + lvDocCode + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //GenDoc
                    string lvShort = dr["S_ShortCode"].ToString();
                    int lvYearChk = DateTime.Now.Year;
                    if (lvYearChk < 2500) lvYearChk += 543;
                    string lvYear = (lvYearChk - 2500).ToString();
                    int lvMonth = DateTime.Now.Month;
                    int lvDay = DateTime.Now.Day;
                    string lvSection = "121";
                    int lvRunDoc = Gstr.fncToInt(dr["S_RunNo"].ToString());
                    if (lvRunDoc == 0)
                        lvRunDoc = 1;
                    else
                        lvRunDoc += 1;

                    string lvDocID = "";
                    if (dr["S_TypeGen"].ToString() == "YYMMDept")
                        lvDocID = lvShort + lvYear.ToString() + lvMonth.ToString("00") + lvSection + lvRunDoc.ToString(dr["S_Format"].ToString());
                    else if (dr["S_TypeGen"].ToString() == "YYMMdd")
                        lvDocID = lvShort + lvYear.ToString() + lvMonth.ToString("00") + lvDay.ToString("00") + lvRunDoc.ToString(dr["S_Format"].ToString());
                    else if (lvDocID == "")
                    {
                        lvDocID = (lvRunDoc + 1).ToString(dr["S_Format"].ToString());
                    }

                    lvReturn = lvDocID;
                }
            }
            else
            {
                lvReturn = "";
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        //
        public static string fncGetLastDocNo(string lvDocCode)
        {
            string lvReturn = "";
            try
            {
                #region ONLINE
                #region //Connect Database 
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                #endregion

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT Top 1 O_DocNo FROM Cane_OilBillHD Where O_CloseStatus = '' and O_DocType = '"+ lvDocCode +"' Order by O_DocNo Desc  ";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       //GenDoc
                       string lvQNo = dr["O_DocNo"].ToString();
                       if (lvQNo == "")
                       {
                                lvReturn = "000001";
                            }
                            else
                            {
                                lvReturn = (Gstr.fncToInt(lvQNo) + 1).ToString("000000");
                            }
                        }
                    }
                    else
                    {
                        lvReturn = "000001";
                    }

                    dr.Close();
                    con.Close();

                    return lvReturn;
                    #endregion
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        public static string fncGetLastDocNoX(string lvDate2)

        {
            string lvReturn = "";
            try
            {
                #region ONLINE
                #region //Connect Database 
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                #endregion

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT Top 1 O_DocNo FROM Cane_OilBillHD Where O_CloseStatus = '' and O_Date = '" + lvDate2 + "' Order by O_DocNo Desc  ";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //GenDoc
                        string lvQNo = dr["O_DocNo"].ToString();
                        if (lvQNo == "")
                        {
                            lvReturn = "000001";
                        }
                        else
                        {
                            string[] lvArr = lvQNo.Split('-');
                            //string lvnewQ = (Gstr.fncToInt(lvArr[1]) + 1).ToString();
                            lvReturn = /*lvArr[0] + " - " + */ lvArr[1];
                        }
                    }
                }
                else
                {
                    lvReturn = "0";
                }

                dr.Close();
                con.Close();

                return lvReturn;
                #endregion
            }
            catch
            {
                return "";
            }
        }

        //Log
        public static string fncKeepLogData(string lvUser, string lvDisplay, string lvActivity)
        {
            string lvReturn = "";
            try
            {
                string lvDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

                string lvSQL = "insert into Log_History (Log_UserID, Log_Display, Log_Activity, Log_DateTime) ";
                lvSQL += "Values ('" + lvUser + "', '" + lvDisplay + "', '" + lvActivity + "', '" + lvDate + "')";

                string query = lvSQL;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PS_LogConnection"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                lvReturn = "Success";
                return lvReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string fncGetStat(string lvDocCode)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT S_ResetStatus FROM SysDocNo WHERE S_MCode = '" + lvDocCode + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["S_ResetStatus"].ToString();
                }
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncGetQlock(string lvDocCode)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "SELECT S_RunNo FROM SysDocNo WHERE S_MCode = '" + lvDocCode + "' ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["S_RunNo"].ToString();
                }
            }

            dr.Close();
            con.Close();

            return lvReturn;
        }
    }
}