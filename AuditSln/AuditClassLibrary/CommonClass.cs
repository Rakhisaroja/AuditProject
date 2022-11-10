using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Text;
using System.Reflection;

namespace AuditClassLibrary
{
    public class CommonClass
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adp;
        SqlDataReader rdp;
        public string serverName;
        static string conString = System.Configuration.ConfigurationSettings.AppSettings["Audit"].ToString();
        public static string ConString
        {
            get { return conString; }
            set { conString = value; }
        }
        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection GetConnection() //For connection
        {
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            return con;
        }
        public int Delete(string spname, ArrayList arrlist)
        {
            int RowsAffected;
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            if (con.State == ConnectionState.Open)
                con.Close();
            cmd = new SqlCommand(spname, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < arrlist.Count; i++)
            {
                cmd.Parameters[i + 1].Value = arrlist[i];
            }
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return RowsAffected;
        }
        public int update(string spname, ArrayList arr)
        {
            int RowsAffected = 0;
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < arr.Count; i++)
            {
                cmd.Parameters[i + 1].Value = arr[i];
            }
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @Fetch " + ex.Message);
            }
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return RowsAffected;
        }


        public DataSet FillData(string spname, CommandType cType)//For select operaion
        {
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            //con.Open();
            cmd.CommandTimeout = 10000;
            cmd.CommandType = cType;
            adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adp.Fill(ds);
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return ds;
        }
        public DataSet FillData(string spname, ArrayList ary1, CommandType cType)
        {
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            cmd.CommandType = cType;
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < ary1.Count; i++)
            {
                cmd.Parameters[i + 1].Value = ary1[i];
            }
            adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adp.Fill(ds);
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return ds;
        }
        public int update(string spname)
        {
            int RowsAffected;
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return RowsAffected;
        }
        public int update(string spname, CommandType ctype)
        {
            int RowsAffected;
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            //con.Open();
            cmd.CommandType = ctype;
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return RowsAffected;
        }



        public DataSet Fetch(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                sqlCmd.CommandTimeout = 10000;

                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @Fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
            }
        }

        public DataSet Fetch(string sqlQuery, CommandType cmdtype)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                sqlCmd.CommandTimeout = 10000;
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
            }
        }

        public int update1(string spname, ArrayList arr)
        {
            int RowsAffected;
            con = GetConnection();
            cmd = new SqlCommand(spname, con);
            cmd.CommandTimeout = 10000;
            //con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            string s = "";
            for (int i = 0; i < arr.Count; i++)
            {
                cmd.Parameters[i + 1].Value = arr[i];
                s = s + "," + arr[i];

            }
            try
            {
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            cmd.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return RowsAffected;
        }



        public int update1(string p, ArrayList arrIn, CommandType commandType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public SqlDataReader ImData(string spname, ArrayList arrIN, CommandType cType)
        {

            SqlConnection con = GetConnection();
            SqlCommand sqlCmd = new SqlCommand();
            //con = GetConnection();
            try
            {
                sqlCmd = new SqlCommand(spname, con);
                sqlCmd.CommandTimeout = 10000;
                sqlCmd.CommandType = cType;
                // 
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                //
                // SqlCommandBuilder.DeriveParameters(sqlCmd);       
                // DataSet d1 = new DataSet();
                rdp = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                //con.Close();

                return rdp;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                //rdp.Close();


                //con.Dispose();
            }
        }

    }
}
