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

    private string  _MABENHNHAN;
    private string  _TENBENHNHAN;
    private string  _DATHANHTOAN;
    private string	_NGAYSINH;
    private string	_DIACHI;
    private string	_GIOITINH;
    private string	_SOTHEBHYT;
    private string	_NOITRU;
    private string _SOPHIEU;
    private string	_MAKHAMBENH;
    private string	_NGUOICHIDINH;
    private string	_PHONGCHIDINH;
    private string	_MAPHONGCDHA;
    private string	_KETQUACDHA;
    private string	_STTHANGNGAY;
    private string	_STTBENHAN;
    private string	_STTDOTDIEUTRI;
    private string	_STTDIEUTRI;
    private string	_CAPCUU;
    private string	_DACHANDOAN;
    private string _MACHANDOAN;
    private string _CHANDOAN;
    private string _MABACSI;
    private string _MADOITUONG;
    private string _MAKHOAPHONG;
    private string _MAPHONGBENH;
    private string _TENPHONGBENH;
    private string _MAGIUONGBENH;
    private string _TENGIUONGBENH;
    private string _LOIDAN;
    private string _TRANGTHAIPHIEU;
    private string _LYDO;
    private string _MAPHONGCHIDINH;
    private string _TENPHONGCHIDINH;
    private string _NGAYCHIDINH;

    #endregion

    #region MABENHNHAN
    [DataMemberAttribute]
    public string MABENHNHAN
    {
        get { return _MABENHNHAN; }
        set { _MABENHNHAN = value; }
    }
    #endregion

    #region TENBENHNHAN
    [DataMemberAttribute]
    public string TENBENHNHAN
    {
        get { return _TENBENHNHAN; }
        set { _TENBENHNHAN = value; }
    }
    #endregion

    #region DATHANHTOAN
    [DataMemberAttribute]
    public string DATHANHTOAN
    {
        get { return _DATHANHTOAN; }
        set { _DATHANHTOAN = value; }
    }
    #endregion

    #region NGAYSINH
    [DataMemberAttribute]
    public string NGAYSINH
    {
        get { return _NGAYSINH; }
        set { _NGAYSINH = value; }
    }
    #endregion

    #region DIACHI
    [DataMemberAttribute]
    public string DIACHI
    {
        get { return _DIACHI; }
        set { _DIACHI = value; }
    }
    #endregion

    #region GIOITINH
    [DataMemberAttribute]
    public string GIOITINH
    {
        get { return _GIOITINH; }
        set { _GIOITINH = value; }
    }
    #endregion

    #region SOTHEBHYT
    [DataMemberAttribute]
    public string SOTHEBHYT
    {
        get { return _SOTHEBHYT; }
        set { _SOTHEBHYT = value; }
    }
    #endregion

    #region NOITRU
    [DataMemberAttribute]
    public string NOITRU
    {
        get { return _NOITRU; }
        set { _NOITRU = value; }
    }
    #endregion

    #region SOPHIEU
    [DataMemberAttribute]
    public string SOPHIEU
    {
        get { return _SOPHIEU; }
        set { _SOPHIEU = value; }
    }
    #endregion

    #region MAKHAMBENH
    [DataMemberAttribute]
    public string MAKHAMBENH
    {
        get { return _MAKHAMBENH; }
        set { _MAKHAMBENH = value; }
    }
    #endregion

    #region NGUOICHIDINH
    [DataMemberAttribute]
    public string NGUOICHIDINH
    {
        get { return _NGUOICHIDINH; }
        set { _NGUOICHIDINH = value; }
    }
    #endregion

    /*
    #region PHONGCHIDINH
    [DataMemberAttribute]
    public string PHONGCHIDINH
    {
        get { return _PHONGCHIDINH; }
        set { _PHONGCHIDINH = value; }
    }
    #endregion
    
    #region MAPHONGCDHA
    [DataMemberAttribute]
    public string MAPHONGCDHA
    {
        get { return _MAPHONGCDHA; }
        set { _MAPHONGCDHA = value; }
    }
    #endregion
    */
    #region KETQUACDHA
    [DataMemberAttribute]
    public string KETQUACDHA
    {
        get { return _KETQUACDHA; }
        set { _KETQUACDHA = value; }
    }
    #endregion

    #region STTHANGNGAY
    [DataMemberAttribute]
    public string STTHANGNGAY
    {
        get { return _STTHANGNGAY; }
        set { _STTHANGNGAY = value; }
    }
    #endregion

    #region STTBENHAN
    [DataMemberAttribute]
    public string STTBENHAN
    {
        get { return _STTBENHAN; }
        set { _STTBENHAN = value; }
    }
    #endregion

    #region STTDOTDIEUTRI
    [DataMemberAttribute]
    public string STTDOTDIEUTRI
    {
        get { return _STTDOTDIEUTRI; }
        set { _STTDOTDIEUTRI = value; }
    }
    #endregion

    #region STTDIEUTRI
    [DataMemberAttribute]
    public string STTDIEUTRI
    {
        get { return _STTDIEUTRI; }
        set { _STTDIEUTRI = value; }
    }
    #endregion

    #region CAPCUU
    [DataMemberAttribute]
    public string CAPCUU
    {
        get { return _CAPCUU; }
        set { _CAPCUU = value; }
    }
    #endregion

    #region DACHANDOAN
    [DataMemberAttribute]
    public string DACHANDOAN
    {
        get { return _DACHANDOAN; }
        set { _DACHANDOAN = value; }
    }
    #endregion

    #region MACHANDOAN
    [DataMemberAttribute]
    public string MACHANDOAN
    {
        get { return _MACHANDOAN; }
        set { _MACHANDOAN = value; }
    }
    #endregion

    #region CHANDOAN
    [DataMemberAttribute]
    public string CHANDOAN
    {
        get { return _CHANDOAN; }
        set { _CHANDOAN = value; }
    }
    #endregion

    #region MABACSI
    [DataMemberAttribute]
    public string MABACSI
    {
        get { return _MABACSI; }
        set { _MABACSI = value; }
    }
    #endregion

    #region MADOITUONG
    [DataMemberAttribute]
    public string MADOITUONG
    {
        get { return _MADOITUONG; }
        set { _MADOITUONG = value; }
    }
    #endregion

    #region MAKHOAPHONG
    [DataMemberAttribute]
    public string MAKHOAPHONG
    {
        get { return _MAKHOAPHONG; }
        set { _MAKHOAPHONG = value; }
    }
    #endregion

    #region MAPHONGBENH
    [DataMemberAttribute]
    public string MAPHONGBENH
    {
        get { return _MAPHONGBENH; }
        set { _MAPHONGBENH = value; }
    }
    #endregion

    #region TENPHONGBENH
    [DataMemberAttribute]
    public string TENPHONGBENH
    {
        get { return _TENPHONGBENH; }
        set { _TENPHONGBENH = value; }
    }
    #endregion

    #region MAGIUONGBENH
    [DataMemberAttribute]
    public string MAGIUONGBENH
    {
        get { return _MAGIUONGBENH; }
        set { _MAGIUONGBENH = value; }
    }
    #endregion

    #region TENGIUONGBENH
    [DataMemberAttribute]
    public string TENGIUONGBENH
    {
        get { return _TENGIUONGBENH; }
        set { _TENGIUONGBENH = value; }
    }
    #endregion

    #region LOIDAN
    [DataMemberAttribute]
    public string LOIDAN
    {
        get { return _LOIDAN; }
        set { _LOIDAN = value; }
    }
    #endregion


    #region TRANGTHAIPHIEU
    [DataMemberAttribute]
    public string TRANGTHAIPHIEU
    {
        get { return _TRANGTHAIPHIEU; }
        set { _TRANGTHAIPHIEU = value; }
    }
    #endregion

    #region LYDO
    [DataMemberAttribute]
    public string LYDO
    {
        get { return _LYDO; }
        set { _LYDO = value; }
    }
    #endregion

    #region MAPHONGCHIDINH
    [DataMemberAttribute]
    public string MAPHONGCHIDINH
    {
        get { return _MAPHONGCHIDINH; }
        set { _MAPHONGCHIDINH = value; }
    }
    #endregion
    #region TENPHONGCHIDINH
    [DataMemberAttribute]
    public string TENPHONGCHIDINH
    {
        get { return _TENPHONGCHIDINH; }
        set { _TENPHONGCHIDINH = value; }
    }
    #endregion

    #region NGAYCHIDINH
    [DataMemberAttribute]
    public string NGAYCHIDINH
    {
        get { return _NGAYCHIDINH; }
        set { _NGAYCHIDINH = value; }
    }
    #endregion
}
