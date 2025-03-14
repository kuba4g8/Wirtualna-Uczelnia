using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Wirtualna_Uczelnia
{
    public class sqlMenager
    {
        private MySqlConnection _conn; // obiekt klasy umozliwiajacy laczenie sie z baza danych.

        // info do poleczenia do DataBase
        private protected readonly string connIP = "127.0.0.1";
        private protected readonly string dataBaseName = "wirtualna_uczelnia";
        private protected readonly string username = "root";
        private protected readonly string PWD = "";
        // info do poleczenia do DataBase

        private readonly string connString; // string laczeniowy z baza danych (wynikajace z konstrukcji klasy idk)


        //konstruktor klasy sqlMenager -> dzieje sie na poczatku stworzenia obiektu.
        public sqlMenager()
        {
            connString = getConnString();

            //utworzony obiekt mysqlconnection
            _conn = new MySqlConnection(connString);
        }

        //zczytanie danych z bazy danych sql przy podaniu dokladnej komendy
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
                            //MessageBox.Show(ex.Message);
                        }
                        
                    }

                    list.Add(tempObj);
                }
                tryDissconect();

                return list;
            }
            catch (MySqlException ex)
            {
                //hujowo (XDD - Lysy)
                MessageBox.Show(ex.Message + " i koniec:(");
                return list;
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
