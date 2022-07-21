using System;
using System.IO;
using MySqlConnector;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace ArorDataSolutions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Pasta do programa criada no drive do sistema
            string folder = @"C:\\Aror";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //Chamada da caixa de dialogo para escolher dataset
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            Nullable<bool> result = openFileDialog1.ShowDialog();

            if (result == true)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);

                if (ext != ".csv")
                {
                    Console.WriteLine("Arquivo não suportado. ");
                    Console.WriteLine();
                }
            }
            //Fazer uma copia do arquivo selecionado na pasta do programa
            string sourceFileName = Path.GetFileName(openFileDialog1.FileName);
            string targetFileName = "Dataset.csv";
            string sourcePath = @Path.GetFullPath(openFileDialog1.FileName);
            string targetPath = @"C:\\Aror";
            string sourceFile = Path.Combine(sourcePath, sourceFileName); ;
            string destFile = Path.Combine(targetPath, targetFileName);

            File.Copy(sourceFile, destFile, true);

            // Conectar com banco de dados
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "MariaDB",
                UserID = "root@localhost",
                Password = "1234",
                Database = "aror",
            };

            // Abrir conexao assincrona
            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            //Conversao de arquivo csv para datatable
            var path = @"C:\\Aror\Dataset.csv";
            System.Data.DataTable dt = ConvertCSVtoDataTable(path);

            using var insArorComm = connection.CreateCommand();
            insArorComm.CommandText = @"INSERT INTO aror;";
            insArorComm.Parameters.Insert(0, dt);

            connection.Close();
        }

        //Classe de conversao csv>datatable
        public static System.Data.DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            System.Data.DataTable dt = new System.Data.DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = System.Text.RegularExpressions.Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                System.Data.DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
