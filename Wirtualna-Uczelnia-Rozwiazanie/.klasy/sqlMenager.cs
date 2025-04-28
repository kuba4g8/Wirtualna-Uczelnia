using System;
using System.Collections.Generic;
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
    public class sqlMenager
    {
        private MySqlConnection _conn; // obiekt klasy umozliwiajacy laczenie sie z baza danych.

        // info do poleczenia do DataBase
        private protected readonly string connIP = "sql.freedb.tech";
        private protected readonly string dataBaseName = "freedb_wirtualna_uczelnia";
        private protected readonly string username = "freedb_KubaH";
        private protected readonly string PWD = "w6#csh$?cW!TDhz";
        // info do poleczenia do DataBase

        private readonly string connString; // string laczeniowy z baza danych (wynikajace z konstrukcji klasy idk)


        //konstruktor klasy sqlMenager -> dzieje sie na poczatku stworzenia obiektu.
        public sqlMenager()
        {
            connString = getConnString();

            //utworzony obiekt mysqlconnection
            _conn = new MySqlConnection(connString);
        }

        //wpisanie do bazy danych dynamicznego obiektu typu T, majac na uwadze ze nazwy tabel musza byc takie same jak nazwy wlasciwosci.
        // niech zwraca jesli inser id jest false niech zwraca przypisany userID.
        public bool loadObjectToDataBase<T>(T objToInsert, string tableName, bool insertUSERID) where T : new()
        {
            if (!tryConnect())
            {
                MessageBox.Show("Błąd podczas łączenia");
                return false;
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

                // Pojedyncze entry dla DB
                string sqlCommand = $"INSERT INTO {tableName} ({string.Join(", ", nazwyKolumn)}) VALUES ({string.Join(", ", wlasciwosciLista)});";

                //wykonanie komendy oraz faktycznie wprowadzenie do bazy danych
                using (MySqlCommand cmd = new MySqlCommand(sqlCommand, _conn))
                {
                    // Dodaj parametry
                    foreach (PropertyInfo prop in properties)
                    {
                        if (!insertUSERID && prop.Name == "userID")
                            continue;

                        object value = prop.GetValue(objToInsert, null);
                        cmd.Parameters.AddWithValue($"@{prop.Name}", value ?? DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }

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

        //zczytanie danych z bazy danych sql przy podaniu dokladnej komendy
        //szczytuje kazdy rekord jako jeden element dynamicznego typu T
        //Podajesz obiekt on sam sie sczyta lol
        public List<T> loadDataToList<T>(MySqlCommand querryCommand) where T : new()
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
                    //obiekt o wlasciwosciach T -> obiekt ktory zostnie podany
                    T tempObj = new T();

                    // przelatujemy przez kazdy property w obiekcie np:
                    // student.id, student.imie, student.nazwisko itd
                    // i przypisujemy te wlasciwosci do obiektu ktory ma te same wlasciowisci
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
                            MessageBox.Show(ex.Message);
                        }
                        
                    }

                    list.Add(tempObj);
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
        private bool tryConnect()
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
        private bool tryDissconect()
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
        private string getConnString()
        {
            return $"DATA SOURCE={connIP};INITIAL CATALOG={dataBaseName};USER ID={username};PWD={PWD}";
        }
    }
}
