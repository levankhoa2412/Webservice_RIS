using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]



public class nhanvien
{
    #region Constructor
    public nhanvien()
    {

    }
    #endregion

    #region Attributes
    private string _MA_NHANVIEN;
    private string _TEN_NHANVIEN;
    private string _DIACHI_NHANVIEN;
    private string _SODIENTHOAI_NHANVIEN;
    private string _SOCMT_NHANVIEN;
    private string _NGAYSINH_NHANVIEN;
    private string _CHUCDANH_NHANVIEN;
    private string _TRINHDO_NHANVIEN;

    #endregion

    #region MA_NHANVIEN
    [DataMemberAttribute]
    public string MA_NHANVIEN
    {
        get { return _MA_NHANVIEN; }
        set { _MA_NHANVIEN = value; }
    }
    #endregion

    #region TEN_NHANVIEN
    [DataMemberAttribute]
    public string TEN_NHANVIEN
    {
        get { return _TEN_NHANVIEN; }
        set { _TEN_NHANVIEN = value; }
    }
    #endregion

    #region DIACHI_NHANVIEN
    [DataMemberAttribute]
    public string DIACHI_NHANVIEN
    {
        get { return _DIACHI_NHANVIEN; }
        set { _DIACHI_NHANVIEN = value; }
    }
    #endregion

    #region SODIENTHOAI_NHANVIEN
    [DataMemberAttribute]
    public string SODIENTHOAI_NHANVIEN
    {
        get { return _SODIENTHOAI_NHANVIEN; }
        set { _SODIENTHOAI_NHANVIEN = value; }
    }
    #endregion

    #region SOCMT_NHANVIEN
    [DataMemberAttribute]
    public string SOCMT_NHANVIEN
    {
        get { return _SOCMT_NHANVIEN; }
        set { _SOCMT_NHANVIEN = value; }
    }
    #endregion

    #region NGAYSINH_NHANVIEN
    [DataMemberAttribute]
    public string NGAYSINH_NHANVIEN
    {
        get { return _NGAYSINH_NHANVIEN; }
        set { _NGAYSINH_NHANVIEN = value; }
    }
    #endregion

    #region CHUCDANH_NHANVIEN
    [DataMemberAttribute]
    public string CHUCDANH_NHANVIEN
    {
        get { return _CHUCDANH_NHANVIEN; }
        set { _CHUCDANH_NHANVIEN = value; }
    }
    #endregion

    #region TRINHDO_NHANVIEN
    [DataMemberAttribute]
    public string TRINHDO_NHANVIEN
    {
        get { return _TRINHDO_NHANVIEN; }
        set { _TRINHDO_NHANVIEN = value; }
    }
    #endregion

}
