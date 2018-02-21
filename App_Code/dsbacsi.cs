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
    private string _username;
    private string _chucdanh;
    private string _gioitinh;
    private string _diachi;
    private string _ngaysinh;
    private string _sodienthoai;

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

    #region USERNAME
    [DataMemberAttribute]
    public string USERNAME
    {
        get { return _username; }
        set { _username = value; }
    }
    #endregion

    #region CHUCDANH
    [DataMemberAttribute]
    public string CHUCDANH
    {
        get { return _chucdanh; }
        set { _chucdanh = value; }
    }
    #endregion

    #region GIOITINH
    [DataMemberAttribute]
    public string GIOITINH
    {
        get { return _gioitinh; }
        set { _gioitinh = value; }
    }
    #endregion

    #region DIACHI
    [DataMemberAttribute]
    public string DIACHI
    {
        get { return _diachi; }
        set { _diachi = value; }
    }
    #endregion

    #region NGAYSINH
    [DataMemberAttribute]
    public string NGAYSINH
    {
        get { return _ngaysinh; }
        set { _ngaysinh = value; }
    }
    #endregion

    #region SODIENTHOAI
    [DataMemberAttribute]
    public string SODIENTHOAI
    {
        get { return _sodienthoai; }
        set { _sodienthoai = value; }
    }
    #endregion

}
