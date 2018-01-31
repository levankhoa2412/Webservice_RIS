using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Connect

{
    public Connect()
    {
    }

    public MySqlConnectionStringBuilder Conn_buildder()
    {


        MySqlConnectionStringBuilder connBuilder =
           new MySqlConnectionStringBuilder();

        connBuilder.Add("Database", "pdbsoral");
        // connBuilder.Add("Data Source", "10.95.14.153");
        connBuilder.Add("Data Source", "10.82.14.237");
        connBuilder.Add("User Id", "khoamap");
        connBuilder.Add("Password", "123456");
        connBuilder.Add("Charset", "utf8");

        return connBuilder;
    }
    

    public MySqlConnection Connection_db(MySqlConnectionStringBuilder connBuilder)
    {
        MySqlConnection connection =
           new MySqlConnection(connBuilder.ConnectionString);
        return connection;
    }


    public void open_connect_db(MySqlConnection connection)
    {
        connection.Open();
    }
    public void close_db(MySqlConnection connection)
    {
        connection.Close();
    }

}