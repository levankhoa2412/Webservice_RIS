using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Donvi
/// </summary>
public class Quyen
{
    public Quyen()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Attributes
        private string _USERNAME;
        private string _TENNHANVIEN;
        private string _TENPHONGBAN;
        private string _TENDONVI;
        private string _QUYENADMIN;
    #endregion

    #region USERNAME
    [DataMemberAttribute]
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
    #endregion

    #region TENNHANVIEN
    [DataMemberAttribute]
    public string TENNHANVIEN
    {
        get { return _TENNHANVIEN; }
        set { _TENNHANVIEN = value; }
    }
    #endregion

    #region TENPHONGBAN
    [DataMemberAttribute]
    public string TENPHONGBAN
    {
        get { return _TENPHONGBAN; }
        set { _TENPHONGBAN = value; }
    }
    #endregion

    #region TENDONVI
    [DataMemberAttribute]
    public string TENDONVI
    {
        get { return _TENDONVI; }
        set { _TENDONVI = value; }
    }
    #endregion

    #region QUYENADMIN
    [DataMemberAttribute]
    public string QUYENADMIN
    {
        get { return _QUYENADMIN; }
        set { _QUYENADMIN = value; }
    }
    #endregion
}