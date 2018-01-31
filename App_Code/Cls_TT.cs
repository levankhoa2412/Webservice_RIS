using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]

/// <summary>
/// Summary description for Cls_TT
/// </summary>
public class Cls_TT
{

    #region "Khai báo hàm"
    public Cls_TT()
    {

    }
    #endregion

    #region Attributes

    private string c_TT;

    #endregion

    #region TT
    [DataMemberAttribute]
    public string TT
    {
        get { return c_TT; }
        set { c_TT = value; }
    }
    #endregion
}