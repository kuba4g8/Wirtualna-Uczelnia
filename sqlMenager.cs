using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WydatkiMiesieczne
{
    internal class sqlMenager
    {
        public List<WydatkiHolder> expHolder = new List<WydatkiHolder>();

        private MySqlConnection conn;

        private const string connectionIp = "localhost";
        private const string dataBaseName = "wydatkiapp";
        private const string usernameID = "root";
        private const string password = "";

        private readonly string connString;
        public sqlMenager()
        {
            connString = $"DATA SOURCE={connectionIp};INITIAL CATALOG={dataBaseName};USER ID={usernameID};PWD={password}";

            conn = new MySqlConnection(connString);
        }

        //laczenie i rozlaczanie sie z baza danych SQL -> bezpieczne
        private bool openConnection()
        {
            try
            {
                conn.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private bool closeConnection()
        {
            try
            {
                conn.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //laczenie i rozlaczanie sie z baza danych SQL -> bezpieczne

        
        public List<ListViewItem> addRow()
        {
            List<ListViewItem> items = new List<ListViewItem>();

            for (int i = 0; i < expHolder.Count; i++)
            {
                ListViewItem item = new ListViewItem(expHolder[i].idW.ToString());
                item.SubItems.Add(expHolder[i].ileZl.ToString());
                item.SubItems.Add(expHolder[i].data.ToString());
                item.SubItems.Add(expHolder[i].naCo.ToString());
                items.Add(item);
            }

            return items;
        }

        //zaladowanie danych z sql -> lista
        public List<WydatkiHolder> loadSqlDataToList(bool SeeAllRecrods, int Month)
        {
            try
            {
                List<WydatkiHolder> tempWydatki = new List<WydatkiHolder>();

                string querry = "SELECT * FROM `wydatki`";


                MySqlCommand cmd = new MySqlCommand(querry, conn);
                if (!SeeAllRecrods)
                {
                    cmd.CommandText += "\nWHERE MONTH(data) = " + Month.ToString();
                }


                if (!openConnection())
                    return new List<WydatkiHolder>();

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    WydatkiHolder tempHolder = new WydatkiHolder
                    {
                        idW = reader.GetInt32("idW"),
                        ileZl = reader.GetFloat("ileZl"),
                        data = DateOnly.FromDateTime(reader.GetDateTime("data")),
                        naCo = reader.GetString("naCo")
                    };

                    tempWydatki.Add(tempHolder);
                }
                expHolder = tempWydatki;
                return tempWydatki;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return new List<WydatkiHolder>();
            }
            finally
            {
                closeConnection();
            }
        }

        public bool appendItemToSql(WydatkiHolder toAppHolder)
        {
            try
            {
                string querry = "INSERT INTO wydatki (ileZl, data, naCo) VALUES (@ileZl, @data, @naCo)";

                MySqlCommand cmd = new MySqlCommand(querry, conn);

                cmd.Parameters.AddWithValue("@ileZl", toAppHolder.ileZl);
                cmd.Parameters.AddWithValue("@data", toAppHolder.data);
                cmd.Parameters.AddWithValue("@naCo", toAppHolder.naCo);

                if (!openConnection())
                    return false;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                closeConnection();
            }
        }

        public bool deleteRecord(int idWydatku)
        {
            string querry = "DELETE FROM wydatki\nWHERE idW = " + idWydatku.ToString();

            MySqlCommand cmd = new MySqlCommand(querry, conn);

            if (!openConnection())
                return false;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                closeConnection();
            }
        }

    }
    internal class WydatkiHolder
    {
        public int idW { get; set; }
        public float ileZl { get; set; }
        public DateOnly data { get; set; }
        public string naCo { get; set; }

    }
}
