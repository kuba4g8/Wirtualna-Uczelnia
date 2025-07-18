﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia
{
    public class SqlMenager
    {
        private MySqlConnection _conn; // obiekt klasy umozliwiajacy laczenie sie z baza danych.

        private bool cloudConnect = true;


        public MySqlConnection Connection 
        { 
            get 
            {
                return _conn; 
            } 
        }

        // info do poleczenia do DataBase
        private static class cloudConnInfo
        {
            public static readonly string connIP = "sql.freedb.tech";
            public static readonly string dataBaseName = "freedb_wirtualna_uczelnia";
            public static readonly string username = "freedb_lolix";
            public static readonly string PWD = "a!Gz*5Hz4Ud8VeZ";
        }
        private static class remoteConnInfo
        {
            public static readonly string connIP = "127.0.0.1";
            public static readonly string dataBaseName = "wirtualna_uczelnia";
            public static readonly string username = "root";
            public static readonly string PWD = "";
        }
        // info do poleczenia do DataBase



        private readonly string connString; // string laczeniowy z baza danych (wynikajace z konstrukcji klasy idk)


        //konstruktor klasy sqlMenager -> dzieje sie na poczatku stworzenia obiektu.
        public SqlMenager()
        {
            // zmienic jak wydupcy baze danych w chmurze aby moc pracowac dalej!
            
            //connString = getCloudConnInfo();
            connString = getRemoteConnInfo();

            //utworzony obiekt mysqlconnection
            _conn = new MySqlConnection(connString);
        }

        // executuje komende w sql -> glownie uzywane do usuwania rekordow w tabeli
        // zwraca boolean: true -> udalo sie, false -> error
        public bool executeRawCommand(MySqlCommand cmd)
        {
            if (!tryConnect())
            {
                MessageBox.Show("Błąd podczas łączenia do bazy");
                return false;
            }

            cmd.Connection = _conn;

            try
            {
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
                return false;
            }
            finally
            {
                tryDissconect();
            }
        }

        //wpisanie do bazy danych dynamicznego obiektu typu T, majac na uwadze ze nazwy tabel musza byc takie same jak nazwy wlasciwosci.
        // Zwraca osattni userID dodany jako int
        // zmienna insertUSERID -> czy wpisac userID do bazy danych, jesli nie to pomija wpisywanie userID i robi to samemu
        public int loadObjectToDataBase<T>(T objToInsert, string tableName, bool insertUSERID) where T : new()
        {
            if (!tryConnect())
            {
                MessageBox.Show("Błąd podczas łączenia do bazy");
                return -1;
            }

            try
            {
                // lista wszystkich propertisow z obiektu dynamicznego t
                var properties = typeof(T).GetProperties();
                // nazwy tych kolumn tego obiektu T
                List<string> nazwyKolumn = new List<string>();
                // lista wszystkich wlasciwosci jako wartosci obiektu
                List<string> wlasciwosciLista = new List<string>();

                foreach (PropertyInfo prop in properties)
                {
                    // jezeli inserUSERID = false to pomijamy wpisywanie reczne userID
                    if (!insertUSERID && prop.Name == "userID")
                        continue;

                    object tempValue = prop.GetValue(objToInsert, null);

                    // Dodaj nazwę kolumny
                    nazwyKolumn.Add(prop.Name);

                    // Dodawanie parametrow aby nie bylo sqlInjection
                    string paramName = $"@{prop.Name}";
                    wlasciwosciLista.Add(paramName);
                }

                object userID;
                // Pojedyncze entry dla DB
                string sqlCommand = $"INSERT INTO {tableName} ({string.Join(", ", nazwyKolumn)}) VALUES ({string.Join(", ", wlasciwosciLista)});SELECT LAST_INSERT_ID();";

                //wykonanie komendy oraz faktycznie wprowadzenie do bazy danych
                using (MySqlCommand cmd = new MySqlCommand(sqlCommand, _conn))
                {
                    // Dodaj parametry
                    foreach (PropertyInfo prop in properties)
                    {
                        if (!insertUSERID && prop.Name.Equals("userID"))
                            continue;

                        object value = prop.GetValue(objToInsert, null);
                        cmd.Parameters.AddWithValue($"@{prop.Name}", value ?? DBNull.Value);
                    }

                    userID = cmd.ExecuteScalar();
                }

                return Convert.ToInt32(userID);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
                return -1;
            }
            finally
            {
                tryDissconect();
            }
          }

        // funkcja updatujaca rekord w bazie danych.
        // przyjmuje jako argumenty obiekt -> ktory podmieniamy (nazwy musza sie zgadzac)
        // string tableName nazwa tabeli
        // whereCond np id_prowadzacego = whereCondValue
        // whereCondValue no chyba do domyslenia 
        public int updateObjectRecordInDataBase<T>(T objToUpdate, string tableName, string whereCond, int whereCondValue) where T : new()
        {
            if (!tryConnect())
            {
                MessageBox.Show("Błąd podczas łączenia do bazy");
                return -1;
            }

            try
            {
                var properties = typeof(T).GetProperties();
                List<string> setClauses = new List<string>();

                foreach (PropertyInfo prop in properties)
                {
                    if (prop.Name == whereCond) // pominiecie kolumny ktora ma where warunek
                        continue;

                    setClauses.Add($"{prop.Name} = @{prop.Name}");
                }

                string sqlCommand = $"UPDATE {tableName} SET {string.Join(", ", setClauses)} WHERE {whereCond} = @whereValue";

                using (MySqlCommand cmd = new MySqlCommand(sqlCommand, _conn))
                {
                    foreach (PropertyInfo prop in properties)
                    {
                        if (prop.Name == whereCond)
                            continue;

                        object value = prop.GetValue(objToUpdate, null);
                        cmd.Parameters.AddWithValue($"@{prop.Name}", value ?? DBNull.Value);
                    }

                    // dodaj parametr warunku WHERE
                    cmd.Parameters.AddWithValue("@whereValue", whereCondValue);

                    return cmd.ExecuteNonQuery(); // Zwraca liczbę zmienionych wierszy
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
                return -1;
            }
            finally
            {
                tryDissconect();
            }
        }


        //zczytanie danych z bazy danych sql przy podaniu dokladnej komendy
        //szczytuje kazdy rekord jako jeden element dynamicznego typu T
        //Podajesz obiekt on sam sie sczyta lol
        public List<T> loadDataToList<T>(MySqlCommand querryCommand, bool safeDebugMsgOff = false) where T : new()
        {
            //tworzenie listy obiektow z Typem T jakiegos obiektu podanego przy wywolaniu
            var list = new List<T>();

            //nie udalo sie polaczyc
            if (!tryConnect())
            {
                return list;
            }
            try
            {
                // MySqlCommand -> komenda do wysylania w sql
                MySqlCommand cmd = querryCommand;
                cmd.Connection = _conn;

                //stworzenie obiektu readera ktory szczytuje wszystkie rowy pokolei.
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (typeof(T).IsPrimitive || typeof(T) == typeof(string) || typeof(T) == typeof(decimal))
                    {
                        if (!reader.IsDBNull(0))
                        {
                            list.Add((T)Convert.ChangeType(reader[0], typeof(T)));
                        }
                    }
                    else
                    {
                        //obiekt o wlasciwosciach T -> obiekt ktory zostnie podany
                        T tempObj = new T();

                        // przelatujemy przez kazdy property w obiekcie np:
                        // student.id, student.imie, student.nazwisko itd
                        // i przypisujemy te wlasciwosci do obiektu ktory ma te same wlasciowosci
                        // nastepnie po kazdym foreachu kiedy wszystko bedzie przypisane dodajemy do listy
                        // obiekt aby wszystkie byly trzymane w jednym miejscu
                        foreach (PropertyInfo info in typeof(T).GetProperties())
                        {
                            try
                            {
                                //jezeli w bazie danych rekord bedzie null to pomijamy i nic nie przypisujemy
                                if (reader[info.Name] != DBNull.Value)
                                {
                                    //MessageBox.Show(info.Name + " " + info.PropertyType);
                                    info.SetValue(tempObj, reader[info.Name]);
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("Generalnie jezeli czytasz ta wiadomosc to chujowow");
                                if (!safeDebugMsgOff)
                                    MessageBox.Show(ex.Message);
                            }

                        }

                        list.Add(tempObj);
                    }
                }
                tryDissconect();

                return list;
            }
            catch (MySqlException ex) // TODO i to tak must have to ze nie ma isAdmin przetrzymywanego w bazie danych co oznacza ze za kazzdym razem sie wywala program i wylapuje exception tylko. Trzeba usunac wszystkie zaleznosci!!!!!
            {
                //hujowo (XDD - Lysy, no i mi sie udalo)
                // 2 - Licznik ile razy ktos wyjebal ten komentarz
                MessageBox.Show(ex.Message + " i koniec:(");
                return list;
            }
            finally
            {
                tryDissconect();
            }
        }

        //sprobuj sie polaczyc 
        public bool tryConnect()
        {
            try
            {
                _conn.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //sprobuj sie rozlaczyc
        public bool tryDissconect()
        {
            try
            {
                _conn.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //zwraca stringConnection
        private string getCloudConnInfo()
        {
            return $"DATA SOURCE={cloudConnInfo.connIP};INITIAL CATALOG={cloudConnInfo.dataBaseName};USER ID={cloudConnInfo.username};PWD={cloudConnInfo.PWD}";
        }
        private string getRemoteConnInfo()
        {
            return $"DATA SOURCE={remoteConnInfo.connIP};INITIAL CATALOG={remoteConnInfo.dataBaseName};USER ID={remoteConnInfo.username};PWD={remoteConnInfo.PWD}";
        }
    }
}
