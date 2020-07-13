﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        private const string connectionString = @"Host=localhost;Port=5432;Database=paintingsdb;Username=postgres;Password=enderant007A";

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Paintings VALUES (@FileName, @PictureName, @Description, @ImageData)";
                command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@PictureName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@FileDesc", SqlDbType.NVarChar, 10000);
                command.Parameters.Add("@Image", SqlDbType.Image, 100000000);


                // передаем данные в команду через параметры
                command.Parameters["@FileName"].Value = shortFileName;
                command.Parameters["@PictureName"].Value = pictureNameTB.Text;
                command.Parameters["@FileDesc"].Value = pictureDescTB.Text;
                command.Parameters["@Image"].Value = imageData;

                command.ExecuteNonQuery();
            }
        }
    }
}
