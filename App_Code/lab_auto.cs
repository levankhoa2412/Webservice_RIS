using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace WebService_syn.BUS
{
    public class lab_auto
    {
        //public string pdb = "PDBLAPTRINH";
        // public string pass = "xetnghiem";
        // public string ip = "10.82.14.170";
        // public string port = "1521";
        // public string userid = "HIS_XETNGHIEM";

        public static string oradb1 = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=";

        public static string oradb1_1 = ")(PORT=";
        public static string oradb1_2 = ")))(CONNECT_DATA=(SERVICE_NAME=";

        public static string oradb2 = ")));User Id=";

        public static string oradb2_1 = ";Password=";
        public static string oradb3 = ";";

        //B: ĐĂNG NHẬP

        public DataTable dangnhap(string dvtt, string username, string password, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DANGNHAP";
                cmd.CommandType = CommandType.StoredProcedure;


                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);


                //// outParam Error Code
                OracleParameter p_username = new OracleParameter();
                p_username.OracleDbType = OracleDbType.Varchar2;
                p_username.Direction = ParameterDirection.Input;
                p_username.Value = username;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_username);

                //// outParam Error Code
                OracleParameter p_password = new OracleParameter();
                p_password.OracleDbType = OracleDbType.Varchar2;
                p_password.Direction = ParameterDirection.Input;
                p_password.Value = password;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_password);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DANGNHAP");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable kiemtraquyen(string username, string password, string dvtt, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_KIEMTRAQUYEN";
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter p_username = new OracleParameter();
                p_username.OracleDbType = OracleDbType.Varchar2;
                p_username.Direction = ParameterDirection.Input;
                p_username.Value = username;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_username);

                OracleParameter p_password = new OracleParameter();
                p_password.OracleDbType = OracleDbType.Varchar2;
                p_password.Direction = ParameterDirection.Input;
                p_password.Value = password;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_password);

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);


                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_KIEMTRAQUYEN");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable dskhoa(string dvtt, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DS_KHOA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DS_KHOA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable dsbacsi(string dvtt, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DS_BACSI";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DS_BACSI");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable dscdha(string dvtt, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DS_CDHA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DS_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable dsbenhnhan(string dvtt, DateTime tungay, DateTime denngay, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DS_BENHNHAN_CDHA_FF";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                // outParam Error tungay
                OracleParameter p_tungay = new OracleParameter();
                p_tungay.OracleDbType = OracleDbType.Date;
                p_tungay.Direction = ParameterDirection.Input;
                p_tungay.Value = tungay;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_tungay);

                // outParam Error denngay
                OracleParameter p_denngay = new OracleParameter();
                p_denngay.OracleDbType = OracleDbType.Date;
                p_denngay.Direction = ParameterDirection.Input;
                p_denngay.Value = denngay;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_denngay);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DS_BENHNHAN_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable dsorder(string dvtt, string sophieu, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_ORDER_CDHA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_ORDER_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable update_kb_cdha(string dvtt, string sophieu, string ketluan, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_KB_CDHA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_ketluan = new OracleParameter();
                p_ketluan.OracleDbType = OracleDbType.Varchar2;
                p_ketluan.Direction = ParameterDirection.Input;
                p_ketluan.Value = ketluan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketluan);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_KB_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable update_kb_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_KB_CDHA_CT";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                //// outParam Error Code
                OracleParameter p_ketqua = new OracleParameter();
                p_ketqua.OracleDbType = OracleDbType.Varchar2;
                p_ketqua.Direction = ParameterDirection.Input;
                p_ketqua.Value = ketqua;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketqua);

                //// outParam Error Code
                OracleParameter p_ketluan = new OracleParameter();
                p_ketluan.OracleDbType = OracleDbType.Varchar2;
                p_ketluan.Direction = ParameterDirection.Input;
                p_ketluan.Value = ketluan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketluan);

                //// outParam Error Code
                OracleParameter p_loidan = new OracleParameter();
                p_loidan.OracleDbType = OracleDbType.Varchar2;
                p_loidan.Direction = ParameterDirection.Input;
                p_loidan.Value = loidan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_loidan);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_KB_CDHA_CT");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable update_notru_cdha(string dvtt, string sophieu, string ketluan, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_NOITRU_CDHA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_ketluan = new OracleParameter();
                p_ketluan.OracleDbType = OracleDbType.Varchar2;
                p_ketluan.Direction = ParameterDirection.Input;
                p_ketluan.Value = ketluan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketluan);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_NOITRU_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable update_noitru_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_NOITRU_CDHA_CT";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                //// outParam Error Code
                OracleParameter p_ketqua = new OracleParameter();
                p_ketqua.OracleDbType = OracleDbType.Varchar2;
                p_ketqua.Direction = ParameterDirection.Input;
                p_ketqua.Value = ketqua;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketqua);

                //// outParam Error Code
                OracleParameter p_ketluan = new OracleParameter();
                p_ketluan.OracleDbType = OracleDbType.Varchar2;
                p_ketluan.Direction = ParameterDirection.Input;
                p_ketluan.Value = ketluan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketluan);

                //// outParam Error Code
                OracleParameter p_loidan = new OracleParameter();
                p_loidan.OracleDbType = OracleDbType.Varchar2;
                p_loidan.Direction = ParameterDirection.Input;
                p_loidan.Value = loidan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_loidan);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_NOITRU_CDHA_CT");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable dsdoituong(string iddoituong, string dvtt, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_DS_DOITUONG";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_iddoituong = new OracleParameter();
                p_iddoituong.OracleDbType = OracleDbType.Varchar2;
                p_iddoituong.Direction = ParameterDirection.Input;
                p_iddoituong.Value = iddoituong;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_iddoituong);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_DS_DOITUONG");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable huy_ketqua_cdha_ct(string dvtt, string sophieu, string madv, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_HUY_KETQUA_CDHA_CT";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_HUY_KETQUA_CDHA_CT");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataTable update_trangthai_phieu(string dvtt, string sophieu, string trangthai, string lydo, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_TRANGTHAI_PHIEU";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_trangthai = new OracleParameter();
                p_trangthai.OracleDbType = OracleDbType.Varchar2;
                p_trangthai.Direction = ParameterDirection.Input;
                p_trangthai.Value = trangthai;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_trangthai);

                //// outParam Error Code
                OracleParameter p_lydo = new OracleParameter();
                p_lydo.OracleDbType = OracleDbType.Varchar2;
                p_lydo.Direction = ParameterDirection.Input;
                p_lydo.Value = lydo;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_lydo);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_TRANGTHAI_PHIEU");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable find_bacsi(string dvtt, string mabacsi, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_FIND_BACSI";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_mabacsi = new OracleParameter();
                p_mabacsi.OracleDbType = OracleDbType.Varchar2;
                p_mabacsi.Direction = ParameterDirection.Input;
                p_mabacsi.Value = mabacsi;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_mabacsi);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_FIND_BACSI");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable find_cdha(string dvtt, string macdha, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_FIND_CDHA";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_macdha = new OracleParameter();
                p_macdha.OracleDbType = OracleDbType.Varchar2;
                p_macdha.Direction = ParameterDirection.Input;
                p_macdha.Value = macdha;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_macdha);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_FIND_CDHA");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable find_khoa(string dvtt, string maphongban, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_FIND_KHOAPHONG";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_maphongban = new OracleParameter();
                p_maphongban.OracleDbType = OracleDbType.Varchar2;
                p_maphongban.Direction = ParameterDirection.Input;
                p_maphongban.Value = maphongban;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_maphongban);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_FIND_KHOAPHONG");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable find_phongbenh(string dvtt, string maphongbenh, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_FIND_PHONGBENH";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_maphongbenh = new OracleParameter();
                p_maphongbenh.OracleDbType = OracleDbType.Varchar2;
                p_maphongbenh.Direction = ParameterDirection.Input;
                p_maphongbenh.Value = maphongbenh;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_maphongbenh);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_FIND_PHONGBENH");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------- MCAP RIS ----------------------------
        public DataTable update_hinhanh_cachup(string dvtt, string sophieu, string madv, string hinhanh, int noitru, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_HINHANH_CACHUP";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                //// outParam Error Code
                OracleParameter p_hinhanh = new OracleParameter();
                p_hinhanh.OracleDbType = OracleDbType.Clob;
                p_hinhanh.Direction = ParameterDirection.Input;
                p_hinhanh.Value = hinhanh;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_hinhanh);

                //// outParam Error Code
                OracleParameter p_noitru = new OracleParameter();
                p_noitru.OracleDbType = OracleDbType.Varchar2;
                p_noitru.Direction = ParameterDirection.Input;
                p_noitru.Value = noitru;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_noitru);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_HINHANH_CACHUP");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable update_ketqua_cdha_ct(string dvtt, string sophieu, string madv, string ketqua, string ketluan, string loidan, int noitru, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_KETQUA_CDHA_CT";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                //// outParam Error Code
                OracleParameter p_ketqua = new OracleParameter();
                p_ketqua.OracleDbType = OracleDbType.Varchar2;
                p_ketqua.Direction = ParameterDirection.Input;
                p_ketqua.Value = ketqua;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketqua);

                //// outParam Error Code
                OracleParameter p_ketluan = new OracleParameter();
                p_ketluan.OracleDbType = OracleDbType.Varchar2;
                p_ketluan.Direction = ParameterDirection.Input;
                p_ketluan.Value = ketluan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_ketluan);

                //// outParam Error Code
                OracleParameter p_loidan = new OracleParameter();
                p_loidan.OracleDbType = OracleDbType.Varchar2;
                p_loidan.Direction = ParameterDirection.Input;
                p_loidan.Value = loidan;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_loidan);

                //// outParam Error Code
                OracleParameter p_noitru = new OracleParameter();
                p_noitru.OracleDbType = OracleDbType.Varchar2;
                p_noitru.Direction = ParameterDirection.Input;
                p_noitru.Value = noitru;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_noitru);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_KETQUA_CDHA_CT");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable update_trangthai_cachup(string dvtt, string sophieu, string madv, string trangthai, string thoigian, int noitru, string pdb, string ip, string port, string userid, string pass)
        {
            try
            {

                string chuoi = "";
                chuoi = oradb1 + ip + oradb1_1 + port + oradb1_2 + pdb + oradb2 + userid + oradb2_1 + pass + oradb3;

                OracleConnection connpdbs = new OracleConnection(chuoi);

                connpdbs.Open();
                OracleCommand cmd = connpdbs.CreateCommand();

                cmd.CommandText = "HIS_MANAGER.RIS_UPDATE_TRANGTHAI_CACHUP";
                cmd.CommandType = CommandType.StoredProcedure;

                //// outParam Error Code
                OracleParameter p_sophieu = new OracleParameter();
                p_sophieu.OracleDbType = OracleDbType.Varchar2;
                p_sophieu.Direction = ParameterDirection.Input;
                p_sophieu.Value = sophieu;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_sophieu);

                //// outParam Error Code
                OracleParameter p_dvtt = new OracleParameter();
                p_dvtt.OracleDbType = OracleDbType.Varchar2;
                p_dvtt.Direction = ParameterDirection.Input;
                p_dvtt.Value = dvtt;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_dvtt);

                //// outParam Error Code
                OracleParameter p_madv = new OracleParameter();
                p_madv.OracleDbType = OracleDbType.Varchar2;
                p_madv.Direction = ParameterDirection.Input;
                p_madv.Value = madv;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_madv);

                //// outParam Error Code
                OracleParameter p_trangthai = new OracleParameter();
                p_trangthai.OracleDbType = OracleDbType.Varchar2;
                p_trangthai.Direction = ParameterDirection.Input;
                p_trangthai.Value = trangthai;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_trangthai);

                //// outParam Error Code
                OracleParameter p_thoigian = new OracleParameter();
                p_thoigian.OracleDbType = OracleDbType.Varchar2;
                p_thoigian.Direction = ParameterDirection.Input;
                p_thoigian.Value = thoigian;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_thoigian);

                //// outParam Error Code
                OracleParameter p_noitru = new OracleParameter();
                p_noitru.OracleDbType = OracleDbType.Varchar2;
                p_noitru.Direction = ParameterDirection.Input;
                p_noitru.Value = noitru;
                //param5.IsNullable = true;
                cmd.Parameters.Add(p_noitru);

                OracleParameter cur = new OracleParameter();
                cur.ParameterName = "RefCursor";
                cur.OracleDbType = OracleDbType.RefCursor;
                cur.Direction = ParameterDirection.Output;
                //param6.IsNullable = false;
                cmd.Parameters.Add(cur);

                DataSet ds = new DataSet("RIS_UPDATE_TRANGTHAI_CACHUP");

                new OracleDataAdapter(cmd).Fill(ds);

                connpdbs.Close();
                connpdbs.Dispose();
                return ds.Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}