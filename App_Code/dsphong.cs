using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

[System.Runtime.Serialization.DataContractAttribute]



public class dsphong
{
    #region Constructor
    public dsphong()
    {

    }
    #endregion

    #region Attributes

    private string _MA_PHONG_BENH;
    private string _TEN_PHONG_BENH;
    private string _MA_PHONG_BAN;
    /*private string _KYNHIEUNHOM;
    private string _SO_DUOC_SET;
    private string _APDUNG_INDAM_SO;
    private string _TEN_PHIA_TRUOC;
    private string _TEN_PHIA_SAU;
    private string _CO_QUYEN_TIEP_NHAN;
    private string _SO_DANG_KHAM;
    private string _PHONG_TTPT_VLTL;
    private string _KYHIEU_PHONG_BAOCAO;
    private string _CANHBAO;
    */
    #endregion

    #region MA_PHONG_BENH
    [DataMemberAttribute]
    public string MA_PHONG_BENH
    {
        get { return _MA_PHONG_BENH; }
        set { _MA_PHONG_BENH = value; }
    }
    #endregion

    #region TEN_PHONG_BENH
    [DataMemberAttribute]
    public string TEN_PHONG_BENH
    {
        get { return _TEN_PHONG_BENH; }
        set { _TEN_PHONG_BENH = value; }
    }
    #endregion

    #region MA_PHONG_BAN
    [DataMemberAttribute]
    public string MA_PHONG_BAN
    {
        get { return _MA_PHONG_BAN; }
        set { _MA_PHONG_BAN = value; }
    }
    #endregion
    /*
    #region KYNHIEUNHOM
    [DataMemberAttribute]
    public string KYNHIEUNHOM
    {
        get { return _KYNHIEUNHOM; }
        set { _KYNHIEUNHOM = value; }
    }
    #endregion

    #region SO_DUOC_SET
    [DataMemberAttribute]
    public string SO_DUOC_SET
    {
        get { return _SO_DUOC_SET; }
        set { _SO_DUOC_SET = value; }
    }
    #endregion

    #region APDUNG_INDAM_SO
    [DataMemberAttribute]
    public string APDUNG_INDAM_SO
    {
        get { return _APDUNG_INDAM_SO; }
        set { _APDUNG_INDAM_SO = value; }
    }
    #endregion

    #region TEN_PHIA_TRUOC
    [DataMemberAttribute]
    public string TEN_PHIA_TRUOC
    {
        get { return _TEN_PHIA_TRUOC; }
        set { _TEN_PHIA_TRUOC = value; }
    }
    #endregion

    #region TEN_PHIA_SAU
    [DataMemberAttribute]
    public string TEN_PHIA_SAU
    {
        get { return _TEN_PHIA_SAU; }
        set { _TEN_PHIA_SAU = value; }
    }
    #endregion

    #region CO_QUYEN_TIEP_NHAN
    [DataMemberAttribute]
    public string CO_QUYEN_TIEP_NHAN
    {
        get { return _CO_QUYEN_TIEP_NHAN; }
        set { _CO_QUYEN_TIEP_NHAN = value; }
    }
    #endregion

    #region SO_DANG_KHAM
    [DataMemberAttribute]
    public string SO_DANG_KHAM
    {
        get { return _SO_DANG_KHAM; }
        set { _SO_DANG_KHAM = value; }
    }
    #endregion

    #region PHONG_TTPT_VLTL
    [DataMemberAttribute]
    public string PHONG_TTPT_VLTL
    {
        get { return _PHONG_TTPT_VLTL; }
        set { _PHONG_TTPT_VLTL = value; }
    }
    #endregion

    #region KYHIEU_PHONG_BAOCAO
    [DataMemberAttribute]
    public string KYHIEU_PHONG_BAOCAO
    {
        get { return _KYHIEU_PHONG_BAOCAO; }
        set { _KYHIEU_PHONG_BAOCAO = value; }
    }
    #endregion

    #region CANHBAO
    [DataMemberAttribute]
    public string CANHBAO
    {
        get { return _CANHBAO; }
        set { _CANHBAO = value; }
    }
    #endregion
    */
}
