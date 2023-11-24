using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public static class DBManager
{
    private static string path = Application.dataPath + "/StreamingAssets/elements.bytes"; // путь к БД
    public static SqliteConnection dbconnection;
    private static SqliteCommand cmd;
    
    // Этот метод открывает подключение к БД.
    private static void OpenConnection(){
        dbconnection = new SqliteConnection("Data Source=" + path); // установка соединения
        dbconnection.Open(); // открытие соединения
        if(dbconnection.State == ConnectionState.Open){ // проверка на открытость
            cmd = new SqliteCommand(dbconnection); // новая команда
        }
    }

    // Этот метод закрывает подключение к БД.
    public static void CloseConnection(){
        dbconnection.Close();
        cmd.Dispose();
    }


    // Этот метод выполняет запрос query и возвращает ответ.
    public static string ExecuteQuery(string query){
        OpenConnection();
        cmd.CommandText = query;
        var res = cmd.ExecuteScalar();
        CloseConnection();

        if (res != null) return res.ToString();
        else return null;
    }
    // Этот метод возвращает ответ таблицу, являющаяся результатом выборки запроса.
    public static DataTable GetTable(string query){
        OpenConnection();
        cmd.CommandText = query;

        SqliteDataAdapter adapter = new SqliteDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        adapter.Dispose();

        CloseConnection();

        return ds.Tables[0];
        
    }

}
