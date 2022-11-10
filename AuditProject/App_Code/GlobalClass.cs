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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



/// <summary>
/// Summary description for GlobalClass
/// </summary>
public class GlobalClass
{
    SqlConnection con;
    SqlCommand cmd;
    
    SqlDataAdapter adp;
    public string serverName;
    static string conString = ConfigurationManager.AppSettings["Audit"];

    public static string ConString
    {
        get { return conString; }
        set { conString = value; }
    }


    public SqlConnection GetConnection() //For connection
    {

        SqlConnection con = new SqlConnection(ConString);
        con.Open();
        return con;
    }
    

    public DataSet FillData(string spname, CommandType cType)//For select operaion
    {
        DataSet ds;
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
        DataSet ds;
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
   

    public void FillCombo(DropDownList comboname, DataSet ds, int selectedColumn)
    {
        comboname.Items.Clear();
        if (ds.Tables[0].Rows.Count > 0)
        {
            comboname.Items.Add(new ListItem("< Select >", "0"));
            for (int rw = 0; rw < ds.Tables[0].Rows.Count; rw++)
            {
                comboname.Items.Add(new ListItem(ds.Tables[0].Rows[rw].ItemArray[selectedColumn].ToString(), ds.Tables[0].Rows[rw].ItemArray[0].ToString()));
            }
        }
        else
        {
            comboname.Items.Add(new ListItem("-------", "0"));


        }

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
    public void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).SelectedIndex = 0;
                        break;

                }
            }
        }
    }

    public DataTable SetGridDefaultfill(Repeater gdv, ArrayList arr,int cut)
    {
        DataTable dt = new DataTable();
        DataRow dr;
      
            for (int j = 0; j < arr.Count; j++)
            {
                DataColumn dcol = new DataColumn(arr[j].ToString(), typeof(System.Int32));
                //dcol.AutoIncrement = true;
                dt.Columns.Add(dcol);
            }
            for (int i = 0; i < cut; i++)
            {
                dr = dt.NewRow();
                //dr[arr[0].ToString()] = i + 1;
                //dr[arr[0].ToString()] = i + 1;
                dr["SLNO"] = i + 1;
                dt.Rows.Add(dr);
            }
        
        gdv.DataSource = dt;
        gdv.DataBind();
        // gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
        return dt;
    }


    public void SetGridDefault(Repeater gdv, ArrayList arr)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        for (int j = 0; j < arr.Count; j++)
        {
            DataColumn dcol = new DataColumn(arr[j].ToString(), typeof(System.Int32));
            dcol.AutoIncrement = true;
            dt.Columns.Add(dcol);
        }
        for (int i = 0; i < 1; i++)
        {
            dr = dt.NewRow();
            dr[arr[0].ToString()] = i + 1;
            //dr["intSlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
       // gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
    }

    public void SetRepeaterDefault(Repeater  gdv, ArrayList arr)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        for (int j = 0; j < arr.Count; j++)
        {
            DataColumn dcol = new DataColumn(arr[j].ToString(), typeof(System.Int32));
            dcol.AutoIncrement = true;
            dt.Columns.Add(dcol);
        }
        for (int i = 0; i < 1; i++)
        {
            dr = dt.NewRow();
            dr[arr[0].ToString()] = i + 1;
            //dr["intSlNo"] = i + 1;
            dt.Rows.Add(dr);
        }
        gdv.DataSource = dt;
        gdv.DataBind();
        //gdv.FooterStyle.BackColor = System.Drawing.Color.CornflowerBlue;
    }
    public void MsgBoxOk(string msg, Page strPg)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("alert('");
        sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
        sb.Append("');");
        ScriptManager.RegisterStartupScript(strPg.Page, strPg.GetType(), "showalert", sb.ToString(), true);
    }
    public void setFocus(Control ctrl, Page pg)
    {
        ScriptManager sm = ScriptManager.GetCurrent(pg);
        sm.SetFocus(ctrl);
    }

   
}
