using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ClassGlobal
/// </summary>
public class ClassGlobal
{
	public ClassGlobal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private static double _UserLogID = 0;
    private static int intlbid = 0;
    public int Intlbid { get { return intlbid; } set { intlbid = value; } }
    public double UserLogID { get { return _UserLogID; } set { _UserLogID = value; } }
       

}
