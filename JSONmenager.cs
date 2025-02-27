using System;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WydatkiMiesieczne
{
    internal class JSONmenager
    {
        private const string jsonPath = "bilans.json";
        public List<bilans> miesieczneKoszta { get; private set; }

        public JSONmenager()
        {
            miesieczneKoszta = new List<bilans>();

            createJsonFile();
            updateBilans();
        }

        private void createJsonFile()
        {
            if (File.Exists(jsonPath))
                return;

            List<bilans> tempBiln = new List<bilans>();
            for (int i = 1; i < 13; i++)
            {
                tempBiln.Add(new bilans
                {
                    Month = i,
                    Salary = 0,
                    ConstExp = 0,
                });
            }

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(tempBiln, jsonOptions);
            File.WriteAllText(jsonPath, jsonString);
        }

        public bilans returnActMonth(int Month)
        {
            updateBilans();

            for (int i = 0; i < miesieczneKoszta.Count; i++)
            {
                if (miesieczneKoszta[i].Month == Month)
                {
                    return miesieczneKoszta[i];
                }
            }

            return new bilans();
        }

        public void updateBilans()
        {
            try
            {
                string jsonString = File.ReadAllText(jsonPath);

                miesieczneKoszta.Clear();
                miesieczneKoszta = JsonSerializer.Deserialize<List<bilans>>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    internal class bilans
    {
        public int Month { get; set; }
        public float Salary { get; set; }
        public float ConstExp { get; set; }
    }
}
