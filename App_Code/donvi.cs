using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Donvi
/// </summary>
public class Donvi
{
	public Donvi()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Attributes
    private string c_DVTT;
    private string c_TENDV;
    private string c_MANV;
    #endregion

    #region c_MANV
    [DataMemberAttribute]
    public string MANV
    {
        get { return c_MANV; }
        set { c_MANV = value; }
    }
    #endregion


    #region c_TENDV
    [DataMemberAttribute]
    public string TENDV
    {
        get { return c_TENDV; }
        set { c_TENDV = value; }
    }
    #endregion

    //----1
    #region DVTT
    [DataMemberAttribute]
    public string DVTT
    {
        get { return c_DVTT; }
        set { c_DVTT = value; }
    }
    #endregion

}