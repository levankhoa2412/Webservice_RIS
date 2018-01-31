using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]



public class dschidinh
{
    #region Constructor
    public dschidinh()
    {

    }
    #endregion

    #region Attributes
    private string _SoPhieuYeuCau;
    private string _MaBenhNhan;
    private string _TenBenhNhan;
    private string _NamSinh;
    private string _GioiTinh;
    private string _CO_BHYT;
    private string _DiaChi;
    private string _MaBacSi;
    private string _MaChanDoan;
    private string _ChanDoan;

    private string _MaPhongChiDinh;
    private string _TenPhongChiDinh;
    private string _MaPhongban;
    private string _KhoaChiDinh;
    private string _SotheBHYT;
    private string _SO_DIEN_THOAI;
    private string _BSCHIDINH;
    private string _noitru;
    private string _capcuu;
    private string _NgaySinh;
    private string _SoBenhAn;
    private string _ChanDoanPhu;
    private string _XacNhanCLS;


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
    
    #region GioiTinh
    [DataMemberAttribute]
    public string GioiTinh
    {
        get { return _GioiTinh; }
        set { _GioiTinh = value; }
    }
    #endregion

    #region CO_BHYT
    [DataMemberAttribute]
    public string CO_BHYT
    {
        get { return _CO_BHYT; }
        set { _CO_BHYT = value; }
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

    #region MaBacSi

    [DataMemberAttribute]
    public string MaBacSi
    {
        get { return _MaBacSi; }
        set { _MaBacSi = value; }
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

    #region MaPhongChiDinh

    [DataMemberAttribute]
    public string MaPhongChiDinh
    {
        get { return _MaPhongChiDinh; }
        set { _MaPhongChiDinh = value; }
    }
    #endregion

    #region TenPhongChiDinh

    [DataMemberAttribute]
    public string TenPhongChiDinh
    {
        get { return _TenPhongChiDinh; }
        set { _TenPhongChiDinh = value; }
    }
    #endregion

    #region MaPhongban

    [DataMemberAttribute]
    public string MaPhongban
    {
        get { return _MaPhongban; }
        set { _MaPhongban = value; }
    }
    #endregion

    #region KhoaChiDinh

    [DataMemberAttribute]
    public string KhoaChiDinh
    {
        get { return _KhoaChiDinh; }
        set { _KhoaChiDinh = value; }
    }
    #endregion

    #region SotheBHYT

    [DataMemberAttribute]
    public string SotheBHYT
    {
        get { return _SotheBHYT; }
        set { _SotheBHYT = value; }
    }
    #endregion

    #region SO_DIEN_THOAI

    [DataMemberAttribute]
    public string SO_DIEN_THOAI
    {
        get { return _SO_DIEN_THOAI; }
        set { _SO_DIEN_THOAI = value; }
    }
    #endregion

    #region BSCHIDINH

    [DataMemberAttribute]
    public string BSCHIDINH
    {
        get { return _BSCHIDINH; }
        set { _BSCHIDINH = value; }
    }
    #endregion

    #region noitru

    [DataMemberAttribute]
    public string noitru
    {
        get { return _noitru; }
        set { _noitru = value; }
    }
    #endregion

    #region capcuu

    [DataMemberAttribute]
    public string capcuu
    {
        get { return _capcuu; }
        set { _capcuu = value; }
    }
    #endregion

    #region NgaySinh

    [DataMemberAttribute]
    public string NgaySinh
    {
        get { return _NgaySinh; }
        set { _NgaySinh = value; }
    }
    #endregion

    #region SoBenhAn

    [DataMemberAttribute]
    public string SoBenhAn
    {
        get { return _SoBenhAn; }
        set { _SoBenhAn = value; }
    }
    #endregion

    #region ChanDoanPhu

    [DataMemberAttribute]
    public string ChanDoanPhu
    {
        get { return _ChanDoanPhu; }
        set { _ChanDoanPhu = value; }
    }
    #endregion

    #region XacNhanCLS

    [DataMemberAttribute]
    public string XacNhanCLS
    {
        get { return _XacNhanCLS; }
        set { _XacNhanCLS = value; }
    }
    #endregion
}
