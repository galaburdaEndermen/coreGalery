using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBFiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static byte[] imageData;
        private static string shortFileName;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            fileNameTB.Text = filename;

            shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1);


            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
        }


        //private const string connectionString = @"Host=localhost;Port=5432;Database=paintingsdb;Username=postgres;Password=enderant007A";
        private const string connectionString = @"Host=localhost;Port=5432;Database=paintingsdb;Username=postgres;Password=enderant007A";

        private void button2_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                // command.CommandText = "INSERT INTO \"Paintings\" VALUES (@FileName, @PictureName, @Description, @ImageData)";
                command.CommandText = "INSERT INTO \"Paintings\" (\"ImageData\", \"FileName\", \"PictureName\", \"Description\") VALUES (@ImageData, @FileName, @PictureName, @Description)";
                command.Parameters.Add("@FileName", NpgsqlTypes.NpgsqlDbType.Char, 50);
                command.Parameters.Add("@PictureName", NpgsqlTypes.NpgsqlDbType.Char, 50);
                command.Parameters.Add("@Description", NpgsqlTypes.NpgsqlDbType.Char, 10000);
                command.Parameters.Add("@ImageData", NpgsqlTypes.NpgsqlDbType.Bytea, 100000000);


                // передаем данные в команду через параметры
                command.Parameters["@FileName"].Value = shortFileName;
                command.Parameters["@PictureName"].Value = pictureNameTB.Text;
                command.Parameters["@Description"].Value = pictureDescTB.Text;
                command.Parameters["@ImageData"].Value = imageData;

                command.ExecuteNonQuery();
            }
        }
    }
}
