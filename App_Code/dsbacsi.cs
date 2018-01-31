using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]


public class dsbacsi
{
    #region Constructor
    public dsbacsi()
    {

    }
    #endregion

    #region Attributes

    private string _ma_bacsi;
    private string _ten_bacsi;
   
    #endregion

    #region MABACSI
    [DataMemberAttribute]
    public string MABACSI
    {
        get { return _ma_bacsi; }
        set { _ma_bacsi = value; }
    }
    #endregion

    #region TENBACSI
    [DataMemberAttribute]
    public string TENBACSI
    {
        get { return _ten_bacsi; }
        set { _ten_bacsi = value; }
    }
    #endregion
}
