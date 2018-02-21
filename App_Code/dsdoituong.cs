using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]

public class dsdoituong
{
    #region Constructor
    public dsdoituong()
    {

    }
    #endregion

    #region Attributes

    private string _id_doituong;
    private string _ten_doituong;

    #endregion

    #region ID_DOITUONG
    [DataMemberAttribute]
    public string ID_DOITUONG
    {
        get { return _id_doituong; }
        set { _id_doituong = value; }
    }
    #endregion

    #region TEN_DOITUONG
    [DataMemberAttribute]
    public string TEN_DOITUONG
    {
        get { return _ten_doituong; }
        set { _ten_doituong = value; }
    }
    #endregion

}
