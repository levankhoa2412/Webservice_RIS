using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]

public class dscdha
{
    #region Constructor
    public dscdha()
    {

    }
    #endregion

    #region Attributes

    private string _ma_cdha;
    private string _ten_cdha;
    private string _gia_cdha;
    private string _ten_loaicdha;
    #endregion

    #region MA_CDHA
    [DataMemberAttribute]
    public string MA_CDHA
    {
        get { return _ma_cdha; }
        set { _ma_cdha = value; }
    }
    #endregion

    #region TEN_CDHA
    [DataMemberAttribute]
    public string TEN_CDHA
    {
        get { return _ten_cdha; }
        set { _ten_cdha = value; }
    }
    #endregion

    #region GIA_CDHA
    [DataMemberAttribute]
    public string GIA_CDHA
    {
        get { return _gia_cdha; }
        set { _gia_cdha = value; }
    }
    #endregion

    #region TEN_LOAI_CDHA
    [DataMemberAttribute]
    public string TEN_LOAI_CDHA
    {
        get { return _ten_loaicdha; }
        set { _ten_loaicdha = value; }
    }
    #endregion

}
