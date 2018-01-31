using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]

public class dsbenhnhan
{
    #region Constructor
    public dsbenhnhan()
    {

    }
    #endregion

    #region Attributes

    private string _SoPhieuYeuCau;
    private string _MaBenhNhan;
    private string _TenBenhNhan;
    private string _NamSinh;
    private string _DiaChi;
    private string _GioiTinh;
    private string _MaDoiTuong;
    private string _MaBacSi;
    private string _MaKhoaPhong;
    private string _MaChanDoan;
    private string _ChanDoan;

    #endregion

    #region SoPhieuYeuCau
    [DataMemberAttribute]
    public string SoPhieuYeuCau
    {
        get { return _SoPhieuYeuCau; }
        set { _SoPhieuYeuCau = value; }
    }
    #endregion

    #region MaBenhNhan
    [DataMemberAttribute]
    public string MaBenhNhan
    {
        get { return _MaBenhNhan; }
        set { _MaBenhNhan = value; }
    }
    #endregion

    #region TenBenhNhan
    [DataMemberAttribute]
    public string TenBenhNhan
    {
        get { return _TenBenhNhan; }
        set { _TenBenhNhan = value; }
    }
    #endregion

    #region NamSinh
    [DataMemberAttribute]
    public string NamSinh
    {
        get { return _NamSinh; }
        set { _NamSinh = value; }
    }
    #endregion

    #region DiaChi
    [DataMemberAttribute]
    public string DiaChi
    {
        get { return _DiaChi; }
        set { _DiaChi = value; }
    }
    #endregion

    #region GioiTinh
    [DataMemberAttribute]
    public string GioiTinh
    {
        get { return _GioiTinh; }
        set { _GioiTinh = value; }
    }
    #endregion

    #region MaDoiTuong
    [DataMemberAttribute]
    public string MaDoiTuong
    {
        get { return _MaDoiTuong; }
        set { _MaDoiTuong = value; }
    }
    #endregion

    #region MaBacSi
    [DataMemberAttribute]
    public string MaBacSi
    {
        get { return _MaBacSi; }
        set { _MaBacSi = value; }
    }
    #endregion

    #region MaKhoaPhong
    [DataMemberAttribute]
    public string MaKhoaPhong
    {
        get { return _MaKhoaPhong; }
        set { _MaKhoaPhong = value; }
    }
    #endregion

    #region MaChanDoan
    [DataMemberAttribute]
    public string MaChanDoan
    {
        get { return _MaChanDoan; }
        set { _MaChanDoan = value; }
    }
    #endregion

    #region ChanDoan
    [DataMemberAttribute]
    public string ChanDoan
    {
        get { return _ChanDoan; }
        set { _ChanDoan = value; }
    }
    #endregion
}
