using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using WebService_syn.BUS;
using System.Data;

/// <summary>
/// Summary description for JsonWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class JsonWebService : System.Web.Services.WebService 
{

    private automy auto_my = new automy();

    private Con_dv dv = new Con_dv();

    private WebService_syn.BUS.lab_auto auto = new WebService_syn.BUS.lab_auto();

   

    public JsonWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public List<Cls_TT> trangthai_result(DataTable dtInput)
    {
        List<Cls_TT> objectList = new List<Cls_TT>();

        foreach (DataRow dr in dtInput.Rows)
        {

            Cls_TT newObj = new Cls_TT();
            newObj.TT = dr["TT"].ToString();  // Beware of the possible conversion errors due to type mismatches
            objectList.Add(newObj);
        }

        return objectList;
    }
    
    public List<Quyen> QuyenConvert(DataTable dtInput)
    {
        List<Quyen> objectList = new List<Quyen>();

        foreach (DataRow dr in dtInput.Rows)
        {
            Quyen newObj = new Quyen();
            newObj.USERNAME = dr["USERNAME"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TENNHANVIEN = dr["TENNHANVIEN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TENPHONGBAN = dr["TENPHONGBAN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TENDONVI = dr["TENDONVI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.QUYENADMIN = dr["QUYENADMIN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            objectList.Add(newObj);
        }
        return objectList;
    }

    //B: DANG NHAP
    [WebMethod]
    public string Dangnhap(string dvtt, string cmnd_nv, string pass_nv, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.dangnhap(dvtt, cmnd_nv, pass_nv, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    //E: DANG NHAP


    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string kiemtraquyen(string dvtt, string u_en, string p_en)
    {
        List<Cls_TT> dsdv = new List<Cls_TT>();


        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc.Columns.Add(new DataColumn("TT", typeof(Int32)));
                DataRow dr = bc.NewRow();
                dr["TT"] = 1;
                bc.Rows.Add(dr);
                int i = bc.Rows.Count;
                dsdv = trangthai_result(bc);
            }
            else {
                DataTable bc = new DataTable();
                bc.Columns.Add(new DataColumn("TT", typeof(Int32)));
                DataRow dr = bc.NewRow();
                dr["TT"] = 0;
                bc.Rows.Add(dr);
                int i = bc.Rows.Count;
                dsdv = trangthai_result(bc);
            }

        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsdv.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsdv);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    public List<dskhoa> dskhoa_obj(DataTable dtInput)
    {
        List<dskhoa> objectList = new List<dskhoa>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dskhoa newObj = new dskhoa();
            newObj.MA_PHONGBAN = dr["MA_PHONGBAN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TEN_PHONGBAN = dr["TEN_PHONGBAN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dskhoa(string dvtt, string u_en, string p_en)
    {
        List<dskhoa> dskhoa = new List<dskhoa>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dskhoa(dvtt, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dskhoa = dskhoa_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dskhoa.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dskhoa);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    public List<dsbacsi> dsbacsi_obj(DataTable dtInput)
    {
        List<dsbacsi> objectList = new List<dsbacsi>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsbacsi newObj = new dsbacsi();
            newObj.MABACSI = dr["MABACSI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TENBACSI = dr["TENBACSI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.USERNAME = dr["USERNAME"].ToString();
            newObj.CHUCDANH = dr["CHUCDANH"].ToString();
            newObj.GIOITINH = dr["GIOITINH"].ToString();
            newObj.NGAYSINH = dr["NGAYSINH"].ToString();
            newObj.DIACHI = dr["DIACHI"].ToString();
            newObj.SODIENTHOAI = dr["SODIENTHOAI"].ToString(); 
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dsbacsi(string dvtt, string u_en, string p_en)
    {
        List<dsbacsi> dsbacsi = new List<dsbacsi>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dsbacsi(dvtt, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsbacsi = dsbacsi_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsbacsi.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsbacsi);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    public List<dscdha> dscdha_obj(DataTable dtInput)
    {
        List<dscdha> objectList = new List<dscdha>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dscdha newObj = new dscdha();
            newObj.MA_CDHA = dr["MA_CDHA"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TEN_CDHA = dr["TEN_CDHA"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.GIA_CDHA = dr["GIA_CDHA"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TEN_LOAI_CDHA = dr["TEN_LOAI_CDHA"].ToString();
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dscdha(string dvtt, string u_en, string p_en)
    {
        List<dscdha> dscdha = new List<dscdha>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dscdha(dvtt, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dscdha = dscdha_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dscdha.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dscdha);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    public List<dsbenhnhan> dsbenhnhan_obj(DataTable dtInput)
    {
        List<dsbenhnhan> objectList = new List<dsbenhnhan>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsbenhnhan newObj = new dsbenhnhan();
            newObj.SOPHIEU = dr["SOPHIEU"].ToString();
            newObj.MABENHNHAN = dr["MABENHNHAN"].ToString();
            newObj.TENBENHNHAN = dr["TENBENHNHAN"].ToString();
            newObj.DATHANHTOAN = dr["DATHANHTOAN"].ToString();
            newObj.NGAYSINH = dr["NGAYSINH"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.DIACHI = dr["DIACHI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.GIOITINH = dr["GIOITINH"].ToString();
            newObj.SOTHEBHYT = dr["SOTHEBHYT"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.NOITRU = dr["NOITRU"].ToString();
            newObj.MAKHAMBENH = dr["MAKHAMBENH"].ToString();
            newObj.NGUOICHIDINH = dr["NGUOICHIDINH"].ToString();
            //newObj.PHONGCHIDINH = dr["PHONGCHIDINH"].ToString();
            //newObj.MAPHONGCDHA = dr["MAPHONGCDHA"].ToString();
            newObj.KETQUACDHA = dr["KETQUACDHA"].ToString();
            newObj.STTHANGNGAY = dr["STTHANGNGAY"].ToString();
            newObj.STTBENHAN = dr["STTBENHAN"].ToString();
            newObj.STTDIEUTRI = dr["STTDIEUTRI"].ToString();
            newObj.CAPCUU = dr["CAPCUU"].ToString();
            newObj.DACHANDOAN = dr["DACHANDOAN"].ToString();
            newObj.MACHANDOAN = dr["MACHANDOAN"].ToString();
            newObj.CHANDOAN = dr["CHANDOAN"].ToString();
            newObj.MABACSI = dr["MABACSI"].ToString();
            newObj.MADOITUONG = dr["MADOITUONG"].ToString();
            newObj.MAKHOAPHONG = dr["MAKHOAPHONG"].ToString();
            newObj.MAPHONGBENH = dr["MAPHONGBENH"].ToString();
            newObj.TENPHONGBENH = dr["TENPHONGBENH"].ToString();
            newObj.MAGIUONGBENH = dr["MAGIUONGBENH"].ToString();
            newObj.TENGIUONGBENH = dr["TENGIUONGBENH"].ToString();
            newObj.LOIDAN = dr["LOIDAN"].ToString();
            newObj.TRANGTHAIPHIEU = dr["TRANGTHAIPHIEU"].ToString();
            newObj.LYDO = dr["LYDO"].ToString();
            newObj.MAPHONGCHIDINH = dr["MAPHONGCHIDINH"].ToString();
            newObj.TENPHONGCHIDINH = dr["TENPHONGCHIDINH"].ToString();
            newObj.NGAYCHIDINH = dr["NGAYCHIDINH"].ToString();
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dsbenhnhan(string dvtt, DateTime tungay, DateTime denngay, string u_en, string p_en)
    {
        List<dsbenhnhan> dsbenhnhan = new List<dsbenhnhan>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dsbenhnhan(dvtt, tungay, denngay, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsbenhnhan = dsbenhnhan_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsbenhnhan.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsbenhnhan);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    public List<dsorder> dsorder_obj(DataTable dtInput)
    {
        List<dsorder> objectList = new List<dsorder>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsorder newObj = new dsorder();
            newObj.SoPhieuYeuCau = dr["SOPHIEUYEUCAU"].ToString();
            newObj.MaBenhNhan = dr["MaBenhNhan"].ToString();
            /*
            newObj.TenBenhNhan = dr["TenBenhNhan"].ToString();
            newObj.DiaChi = dr["DiaChi"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.GioiTinh = dr["GioiTinh"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.NamSinh = dr["NamSinh"].ToString();
            newObj.ChanDoan = dr["ChanDoan"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.MaBacSi = dr["MaBacSi"].ToString();
            newObj.MaChanDoan = dr["MaChanDoan"].ToString();
            newObj.MaDoiTuong = dr["MaDoiTuong"].ToString();
            newObj.MaKhoaPhong = dr["MaKhoaPhong"].ToString();
             */
            newObj.MaDichVu = dr["MaDichVu"].ToString();
            newObj.TenDichVu = dr["TenDichVu"].ToString();
            //newObj.NgayChiDinh = dr["NgayChiDinh"].ToString();
            newObj.DaThucHien = dr["DaThucHien"].ToString();
            newObj.DaThanhToan = dr["DaThanhToan"].ToString();
            newObj.TENLOAICDHA = dr["TENLOAICDHA"].ToString();
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dsorder(string dvtt, string sophieu, string u_en, string p_en)
    {
        List<dsorder> dsorder = new List<dsorder>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dsorder(dvtt, sophieu, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsorder = dsorder_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsorder.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsorder);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    

    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_kb_cdha(string dvtt, string sophieu, string thuchien, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_kb_cdha(dvtt, sophieu, thuchien, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_kb_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_kb_cdha_ct(dvtt, sophieu, madv, ketqua, ketluan, loidan, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_notru_cdha(string dvtt, string sophieu, string thuchien, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_notru_cdha(dvtt, sophieu, thuchien, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_noitru_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_noitru_cdha_ct(dvtt, sophieu, madv, ketqua, ketluan, loidan, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    //ds doituong
    public List<dsdoituong> dsdoituong_obj(DataTable dtInput)
    {
        List<dsdoituong> objectList = new List<dsdoituong>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsdoituong newObj = new dsdoituong();
            newObj.ID_DOITUONG = dr["ID_DOITUONG"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TEN_DOITUONG = dr["TENDOITUONG"].ToString();  // Beware of the possible conversion errors due to type mismatches
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string dsdoituong( string madoituong, string dvtt, string u_en, string p_en)
    {
        List<dsdoituong> dsdoituong = new List<dsdoituong>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.dsdoituong(madoituong, dvtt, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsdoituong = dsdoituong_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsdoituong.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsdoituong);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string huy_ketqua_cdha_ct(string dvtt, string sophieu, string madv, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.huy_ketqua_cdha_ct(dvtt, sophieu, madv, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_trangthai_phieu(string dvtt, string sophieu, string trangthai, string lydo, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_trangthai_phieu(dvtt, sophieu, trangthai, lydo, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    /*

    public List<dsbacsi> dsbacsi_find_obj(DataTable dtInput)
    {
        List<dsbacsi> objectList = new List<dsbacsi>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsbacsi newObj = new dsbacsi();
            newObj.MABACSI = dr["MABACSI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TENBACSI = dr["TENBACSI"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.USERNAME = dr["USERNAME"].ToString();
            //newObj.CHUCDANH = dr["CHUCDANH"].ToString();
            newObj.GIOITINH = dr["GIOITINH"].ToString();
            newObj.NGAYSINH = dr["NGAYSINH"].ToString();
            newObj.SODIENTHOAI = dr["SODIENTHOAI"].ToString();
            newObj.DIACHI = dr["DIACHI"].ToString();

            objectList.Add(newObj);
        }
        return objectList;
    }

     * */
    [WebMethod]
    public string find_bacsi(string dvtt, string mabacsi, string u_en, string p_en)
    {
        List<dsbacsi> dsbacsi = new List<dsbacsi>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.find_bacsi(dvtt, mabacsi, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsbacsi = dsbacsi_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsbacsi.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsbacsi);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }


    [WebMethod]
    public string find_cdha(string dvtt, string macdha, string u_en, string p_en)
    {
        List<dscdha> dscdha = new List<dscdha>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.find_cdha(dvtt, macdha, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dscdha = dscdha_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dscdha.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dscdha);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    [WebMethod]
    public string find_khoaphong(string dvtt, string maphongban, string u_en, string p_en)
    {
        List<dskhoa> dskhoa = new List<dskhoa>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.find_khoa(dvtt, maphongban, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dskhoa = dskhoa_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dskhoa.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dskhoa);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    public List<dsphong> dsphongbenh_obj(DataTable dtInput)
    {
        List<dsphong> objectList = new List<dsphong>();

        foreach (DataRow dr in dtInput.Rows)
        {

            dsphong newObj = new dsphong();
            newObj.MA_PHONG_BAN = dr["MA_PHONG_BAN"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.MA_PHONG_BENH = dr["MA_PHONG_BENH"].ToString();  // Beware of the possible conversion errors due to type mismatches
            newObj.TEN_PHONG_BENH = dr["TEN_PHONG_BENH"].ToString();
            objectList.Add(newObj);
        }
        return objectList;
    }

    [WebMethod]
    public string find_phongbenh(string dvtt, string maphongbenh, string u_en, string p_en)
    {
        List<dsphong> dsphong = new List<dsphong>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());
        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());


            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();


                DataTable bc = new DataTable();
                bc = auto.find_phongbenh(dvtt, maphongbenh, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                dsphong = dsphongbenh_obj(bc);

            }


        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(dsphong.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, dsphong);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    public int RowNumber { get; set; }

    //---------------------- MCAP RIS -----------------------
    // II.4.3.3.8.  Cập nhật hình ảnh ca chụp (service update_hinhanh_cachup)
    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_hinhanh_cachup(string dvtt, string sophieu, string madv, string[] hinhanh, int noitru, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                for (int k = 0; k < hinhanh.Length; k++)
                {
                    bc = auto.update_hinhanh_cachup(dvtt, sophieu, madv, hinhanh[k], noitru, tenpdb, ip_server, ports, user, matkhau);
                }
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    // II.4.3.3.5.  Cập nhật kết quả chẩn đoán hình ảnh ca chụp phiếu nội/ ngoại trú (service update_ketqua_cdha_ct)
    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_ketqua_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, int noitru, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_ketqua_cdha_ct(dvtt, sophieu, madv, ketqua, ketluan, loidan, noitru, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }

    // II.4.3.3.7.  Cập nhật trạng thái ca chụp (service update_trangthai_cachup)
    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string update_trangthai_cachup(string dvtt, string sophieu, string madv, string trangthai, string thoigian, int noitru, string u_en, string p_en)
    {
        List<Cls_TT> result = new List<Cls_TT>();

        DataTable kiemtradonvi = auto_my.finddvtt_ris(dvtt);

        int kiemtra = Convert.ToInt32(kiemtradonvi.Rows[0]["kt"].ToString());

        if (u_en == dv.u_en && p_en == dv.p_en && kiemtra > 0)
        {

            //dataTable1.Merge(dataTable2);
            DataTable dtb_canlam = new DataTable();
            dtb_canlam = auto_my.findpdb(kiemtradonvi.Rows[0]["PDB"].ToString());

            //for (int i = 0; i < dtb_all.Rows.Count; i++)
            if (dtb_canlam.Rows.Count > 0)
            {

                String tenpdb, user, matkhau, ip_server, hoatdong, tencum, ports;
                tenpdb = dtb_canlam.Rows[0]["tenpdb"].ToString();
                user = dtb_canlam.Rows[0]["user"].ToString();
                matkhau = dtb_canlam.Rows[0]["matkhau"].ToString();
                ip_server = dtb_canlam.Rows[0]["ip_server"].ToString();
                hoatdong = dtb_canlam.Rows[0]["hoatdong"].ToString();
                tencum = dtb_canlam.Rows[0]["tencum"].ToString();
                ports = dtb_canlam.Rows[0]["cong"].ToString();

                DataTable bc = new DataTable();
                bc = auto.update_trangthai_cachup(dvtt, sophieu, madv, trangthai, thoigian, noitru, tenpdb, ip_server, ports, user, matkhau);
                int i = bc.Rows.Count;
                result = trangthai_result(bc);
            }
        }
        //yourobject is your actula object (may be collection) you want to serialize to json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(result.GetType());
        //create a memory stream
        MemoryStream ms = new MemoryStream();
        //serialize the object to memory stream
        serializer.WriteObject(ms, result);
        //convert the serizlized object to string
        string jsonString = Encoding.UTF8.GetString(ms.ToArray());
        //close the memory stream
        ms.Close();

        return jsonString;
    }
}

