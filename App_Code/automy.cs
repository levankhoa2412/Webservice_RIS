using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for automy
/// </summary>
public class automy
{
    public automy()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private Connect conn = new Connect();

    private const string all_pdbs = "all_pdbs";
    private const string find_pdb = "find_pdb";

    private const string find_dvtt = "find_dvtt_lis";

    private const string find_dvtt_ris = "find_dvtt_ris";

    public DataTable list_pdbs()
    {
        DataSet ds = new DataSet();
        MySqlConnectionStringBuilder connBuilder = conn.Conn_buildder();
        MySqlConnection connection = conn.Connection_db(connBuilder);

        // thực hiện thao tác
        MySqlCommand cmd = new MySqlCommand(all_pdbs, connection);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Connection.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = cmd;
        adapter.Fill(ds);

        connection.Close();
        return ds.Tables[0];
    }

    public DataTable findpdb(String _tenpdb)
    {
        DataSet ds = new DataSet();
        MySqlConnectionStringBuilder connBuilder = conn.Conn_buildder();
        MySqlConnection connection = conn.Connection_db(connBuilder);

        // thực hiện thao tác
        MySqlCommand cmd = new MySqlCommand(find_pdb, connection);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new MySqlParameter("_tenpdb", _tenpdb));
        cmd.Parameters["@_tenpdb"].Direction = ParameterDirection.Input;

        cmd.Connection.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = cmd;
        adapter.Fill(ds);

        connection.Close();
        return ds.Tables[0];
    }

    public DataTable finddvtt_ris(String _dvtt)
    {
        DataSet ds = new DataSet();
        MySqlConnectionStringBuilder connBuilder = conn.Conn_buildder();
        MySqlConnection connection = conn.Connection_db(connBuilder);

        // thực hiện thao tác
        MySqlCommand cmd = new MySqlCommand(find_dvtt_ris, connection);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new MySqlParameter("_dvtt", _dvtt));
        cmd.Parameters["@_dvtt"].Direction = ParameterDirection.Input;

        cmd.Connection.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = cmd;
        adapter.Fill(ds);

        connection.Close();
        return ds.Tables[0];
    }

    public DataTable finddvtt(String _dvtt)
    {
        DataSet ds = new DataSet();
        MySqlConnectionStringBuilder connBuilder = conn.Conn_buildder();
        MySqlConnection connection = conn.Connection_db(connBuilder);

        // thực hiện thao tác
        MySqlCommand cmd = new MySqlCommand(find_dvtt, connection);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new MySqlParameter("_dvtt", _dvtt));
        cmd.Parameters["@_dvtt"].Direction = ParameterDirection.Input;

        cmd.Connection.Open();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = cmd;
        adapter.Fill(ds);

        connection.Close();
        return ds.Tables[0];
    }

}