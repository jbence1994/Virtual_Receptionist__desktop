﻿using MySql.Data.MySqlClient;
using System;
using System.Xml;
using System.Diagnostics;
using System.Data;

namespace virtual_receptionist.Model
{
    /// <summary>
    /// Adatbázis kapcsolódást és CRUD műveleteket megvalósító osztály
    /// </summary>
    public class Database
    {
        #region Adattagok

        /// <summary>
        /// Adatbázis kapcsolatot létrehozó mező
        /// </summary>
        private MySqlConnection mySqlConnection;
        /// <summary>
        /// SQL utasítást vágrehajtó mező
        /// </summary>
        private MySqlCommand mySqlCommand;
        /// <summary>
        /// Adatbázis adatot olvasó mező
        /// </summary>
        private MySqlDataReader mySqlDataReader;
        /// <summary>
        /// Adatszerkezeteket adattal feltöltő osztály egy példánya
        /// </summary>
        private MySqlDataAdapter mySqlDataAdapter;
        /// <summary>
        /// SQL DML és DDL parancsokat végrehajtó osztály egy példánya
        /// </summary>
        private MySqlCommandBuilder mySqlCommandBuilder;
        /// <summary>
        /// Adatbázis szerver neve
        /// </summary>
        private string server;
        /// <summary>
        /// Adatbázis neve
        /// </summary>
        private string database;
        /// <summary>
        /// Adatbázis szerver felhasználóneve
        /// </summary>
        private string username;
        /// <summary>
        /// Adatbázis szerver jelszava
        /// </summary>
        private string password;
        /// <summary>
        /// Adatbázis szerver elérésére szolgáló hálózati port
        /// </summary>
        private string port;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Database()
        {
            mySqlConnection = new MySqlConnection()
            {
                ConnectionString = $"SERVER={server}; DATABASE={database}; UID={username}; PASSWORD={password}; PORT={port}; SslMode=None;"
            };
        }

        #endregion

        #region Metódusok

        /// <summary>
        /// 
        /// </summary>
        private void InitializeConnection(string server, string database, string username, string password, string port)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
            this.port = port;
        }
        /// <summary>
        /// Adatbázis kapcsolatot megnyitó metódus
        /// </summary>
        public void OpenConnection()
        {
            if (mySqlConnection.State == ConnectionState.Closed)
            {
                mySqlConnection.Open();
                Debug.WriteLine("Sikeres adatbázis kapcsolódás...");
            }
        }
        /// <summary>
        /// Adatbázis kapcsolatot lezáró metódus
        /// </summary>
        public void CloseConnection()
        {
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
                Debug.WriteLine("Adatbázis kapcsolat sikeresen lezárult...");
            }
        }
        /// <summary>
        /// Adatbázistáblából adatokat DataTable (adattábla/adatkonténerbe) leolvasó metódus 
        /// </summary>
        /// <param name="sql">SQL lekérdezés</param>
        /// <returns>A feltöltött DataTable-el tér vissza a függvény</returns>
        public DataTable GetDataToDataTable(string sql)
        {
            DataTable dataTable = new DataTable();

            try
            {
                mySqlCommand = new MySqlCommand()
                {
                    CommandText = sql,
                    Connection = mySqlConnection
                };

                mySqlDataAdapter = new MySqlDataAdapter()
                {
                    SelectCommand = mySqlCommand
                };

                mySqlCommandBuilder = new MySqlCommandBuilder()
                {
                    DataAdapter = mySqlDataAdapter
                };

                mySqlDataAdapter.Fill(dataTable);
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return dataTable;
        }

        #endregion
    }
}
