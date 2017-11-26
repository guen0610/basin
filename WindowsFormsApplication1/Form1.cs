﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using ReadWriteCsv;
using System.Threading;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SQLiteConnection m_dbConnection;
        static SerialPort mySerial;
        private delegate void displayDelegate(string card, string lname, string name, string phone, string uld);
        displayDelegate displayFunc;
        public Form1()
        {
            InitializeComponent();
            displayFunc = displayText;

            m_dbConnection = new SQLiteConnection(@"Data Source=C:\Users\user\auto.db; Version=3;");
            m_dbConnection.Open();

            string sql = "INSERT INTO users (card_id, lname, name, phone, uld) VALUES ('8jjjk213', 'boldbaatar', 'bold', 89383399, 1)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            listViewShow();

            mySerial = new SerialPort("COM4", 9600);
            mySerial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                mySerial.Open();
                Console.WriteLine("Serial opened");
            }
            catch
            {
                System.Threading.Thread.Sleep(3000);
                //RestartApp();
                Console.WriteLine("Serial cant open");
            }

            
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            cardLabel.Text = "wwwwwww";
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            ReadTest("data");   
        }

        void WriteTest()
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter("WriteTest.csv"))
            {
                for (int i = 0; i < 100; i++)
                {
                    CsvRow row = new CsvRow();
                    for (int j = 0; j < 5; j++)
                        row.Add(String.Format("Column{0}", j));
                    writer.WriteRow(row);
                }
            }
        }

        void ReadTest(string id)
        {
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader("WriteTest.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    if (row[1] != id)
                        continue;
                    displayFunc(row[0], row[1], row[2], row[3], row[4]);
                    //listViewShow();
                    //Thread demoThread =
                    //new Thread(new ThreadStart(this.ThreadProcSafe));

                    //demoThread.Start();

                    //Console.WriteLine();
                }
            }
        }

        void listViewShow()
        {
            listView1.Items.Clear();
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader("WriteTest.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    ListViewItem lvi = new ListViewItem(row[0]);
                    lvi.SubItems.Add(row[1]);
                    lvi.SubItems.Add(row[2]);
                    lvi.SubItems.Add(row[3]);
                    lvi.SubItems.Add(row[4]);
                    listView1.Items.Add(lvi);
                    //Thread demoThread =
                    //new Thread(new ThreadStart(this.ThreadProcSafe));

                    //demoThread.Start();

                    //Console.WriteLine();
                }
            }
        }

        void displayText(string card, string lname, string name, string phone, string uld)
        {
            if (cardLabel.InvokeRequired)
                cardLabel.Invoke(displayFunc, new object[] { card, lname, name, phone, uld });
            else
            {
                cardLabel.Text = card;
                lnameLabel.Text = lname;
                nameLabel.Text = name;
                phoneLabel.Text = phone;
                uldLabel.Text = uld;
            }
        }// end fu

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
