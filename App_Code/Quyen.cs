using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Donvi
/// </summary>
public class Quyen
{
    public Quyen()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Attributes
    private string c_Quyen;
    #endregion

    #region c_Quyen
    [DataMemberAttribute]
    public string cQuyen
    {
        get { return c_Quyen; }
        set { c_Quyen = value; }
    }
    #endregion
}