using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]

public class dskhoa
{
    #region Constructor
    public dskhoa()
    {

    }
    #endregion

    #region Attributes

    private string _ma_phongban;
    private string _ten_phongban;
   
    #endregion

    #region MA_PHONGBAN
    [DataMemberAttribute]
    public string MA_PHONGBAN
    {
        get { return _ma_phongban; }
        set { _ma_phongban = value; }
    }
    #endregion

    #region TEN_PHONGBAN
    [DataMemberAttribute]
    public string TEN_PHONGBAN
    {
        get { return _ten_phongban; }
        set { _ten_phongban = value; }
    }
    #endregion

}
