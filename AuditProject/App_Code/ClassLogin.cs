using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using AuditClassLibrary;
/// <summary>
/// Summary description for ClassLogin
/// </summary>
public class ClassLogin
{

    public DataSet CheckLogin(String username, String password)
    {
        CommonClass objCommon = new CommonClass();
        DataSet ds = new DataSet();
        ArrayList Arrin = new ArrayList();
        Arrin.Add(username);
        Arrin.Add(password);
        ds = objCommon.Fetch("Sp_CheckLogin", CommandType.StoredProcedure, Arrin);
        return ds;
    }

    public Double SaveUserLog(ArrayList Arrin)
    {
        CommonClass objCommon = new CommonClass();
        DataSet ds = new DataSet();
        ds = objCommon.Fetch("SP_SaveUserLog", CommandType.StoredProcedure, Arrin);
        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    }
    public Double SaveLogout(ArrayList Arrin)   //Mode 1 for logout(successfull)
    {
        //CommonClass objCommon = new CommonClass();
        //int i = objCommon.update("update UserLog set dtLastUpdate=getdate(),tnystatus=" + Mode + " where numSessionId=" + UserLogID, CommandType.Text);
        ////
        CommonClass objCommon = new CommonClass();
        DataSet ds = new DataSet();
        ds = objCommon.FillData("SP_SaveUserLogLOGOUT", Arrin, CommandType.StoredProcedure);
        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
        //return ds;
    }

    public Double SavelastupdatedTime(ArrayList Arrin)
    {
        //CommonClass objCommon = new CommonClass();
        //int i = objCommon.update("update UserLog set dtLastUpdate=getdate(),tnystatus=" + Mode + " where numSessionId=" + UserLogID, CommandType.Text);
        ////
        CommonClass objCommon = new CommonClass();
        DataSet ds = new DataSet();
        ds = objCommon.FillData("SP_SaveUserTimeUpdate", Arrin, CommandType.StoredProcedure);
        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    }
    //public Double SaveLogout(ArrayList Arrin)   //Mode 1 for logout(successfull)
    //{
    //    ////CommonClass objCommon = new CommonClass();
    //    ////int i = objCommon.update("update UserLog set dtLastUpdate=getdate(),tnystatus=" + Mode + " where numSessionId=" + UserLogID, CommandType.Text);
    //    //
    //    CommonClass objCommon = new CommonClass();
    //    DataSet ds = new DataSet();
    //    ds = objCommon.FillData("SP_SaveUserLogLOGOUT", Arrin, CommandType.StoredProcedure);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    //    }
    //    else
    //    {
    //        return Convert.ToDouble("0".ToString());
    //    }
    //}

    //public Double SavelastupdatedTime(ArrayList Arrin)
    //{
    //    ////CommonClass objCommon = new CommonClass();
    //    ////int i = objCommon.update("update UserLog set dtLastUpdate=getdate(),tnystatus=" + Mode + " where numSessionId=" + UserLogID, CommandType.Text);
    //    //
    //    CommonClass objCommon = new CommonClass();
    //    DataSet ds = new DataSet();
    //    ds = objCommon.FillData("SP_SaveUserTimeUpdate", Arrin, CommandType.StoredProcedure);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        return Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    //    }
    //    else
    //    {
    //        return Convert.ToDouble("0".ToString());
    //    }
    //}


}
