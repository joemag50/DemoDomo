using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Agregados para que jale la Base de Datos
//using Mono.Data.Sqlite;
using System;
using System.IO;
using System.Text;
using System.Data;
using Mono.Data.SqliteClient;

public class BaseDatos : MonoBehaviour
{
    public static string conn;
    public static IDbConnection dbconn;
    public static IDbCommand dbcmd;
    public string connection;
    
    public void OpenDB()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            string p = "DemoDomo.db";
            string filepath = Application.persistentDataPath + "/" + p;
            if (!File.Exists(filepath))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
            }
            
            connection = "URI=file:" + filepath;
            Connect(connection);
        }
        else
        {
            conn = "URI=file:" + Application.dataPath + "/StreamingAssets/DemoDomo.db"; //Path to database.
            Connect(conn);
        }
    }
    
    // Use this for initialization
    void Start ()
    {
        OpenDB();
    }
    
    public static void Connect(string connection)
    {
        dbconn = (IDbConnection)new SqliteConnection(connection);
        dbconn.Open(); //Open connection to the database.
        Debug.Log("CONECTADO");
    }
    
    public static void CloseDB()
    {
        if (dbcmd != null)
        {
            dbcmd.Dispose();
            dbcmd = null;
        }
        
        if (dbconn != null)
        {
            dbconn.Close();
            dbconn = null;
        }
    }
    
    public static IDataReader SqlCommand(string sqlQuery)
    {
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        return reader;
        
        //Ejemplo de uso
        /*
        IDataReader reader = SqlCommand("SELECT * FROM perfil");
        
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);
            string rand = reader.GetString(2);

            Debug.Log("value= " + value + "  name =" + name + "  random =" + rand);
        }
        */
    }
}
