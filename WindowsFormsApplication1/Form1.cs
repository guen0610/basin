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
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    { 
        SQLiteConnection m_dbConnection;
        static SerialPort mySerial;
        delegate void displayUserDelegate(User user);
        delegate void populateLVDelegate();

        public Form1()
        {
            InitializeComponent();

            m_dbConnection = new SQLiteConnection(@"Data Source=C:\Users\Guen\Documents\WindowsFormsApplication1\basin.db; Version=3;");
            m_dbConnection.Open();

            populateLV();

            mySerial = new SerialPort("COM9", 9600);
           
            mySerial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            SerialOpen();
        }


        private void displayUser(User user)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.cardLabel.InvokeRequired)
            {
                displayUserDelegate d = new displayUserDelegate(displayUser);
                this.Invoke(d, new object[] { user });
            }
            else
            {
                this.cardLabel.Text = user.CardId;
                this.lnameLabel.Text = user.LastName;
                this.nameLabel.Text = user.Name;
                this.phoneLabel.Text = user.Phone.ToString();
                this.uldLabel.Text = user.Uld.ToString();
            }
        }

        public static void RestartApp()
        {
            try
            {
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
                mySerial.Dispose();
                mySerial.Close();
                Environment.Exit(0);
            }
            catch { }
        }
    
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {    
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();

            indata = indata.Remove(indata.Length - 1); //removing last character \r from indata
            User user = User.searchByCardID(indata); 

            if (user == null)
            {
                //TODO: iim IDtai hereglegch bhgu bna!!!
                Console.WriteLine("Burtgelgui kart baina!");
                return;
            }
            
            if(user.Uld == 0)
            {
                //TODO: Uldegedel duussan bna!!!
                Console.WriteLine("Uldegdel duussan baina!");
                displayUser(user);
                return;
            }

            user.Uld = user.Uld - 1;
            user.update();
            displayUser(user);
            populateLV();
        }

        void SerialOpen()
        {
            try
            {
                if (!mySerial.IsOpen)
                {
                    mySerial.Open();
                    mySerial.DiscardInBuffer();
                    mySerial.DiscardOutBuffer();
                    Console.WriteLine("Serial opened");
                }
            }
            catch
            {
                System.Threading.Thread.Sleep(3000);
                RestartApp();
                Console.WriteLine("Serial cant open");
            }
        }

        void listViewShow()
        {
            listView1.Items.Clear();
            
        }


        private void populateLV()
        {
            if (this.listView1.InvokeRequired)
            {
                populateLVDelegate d = new populateLVDelegate(populateLV);
                this.Invoke(d, new object[] { });
            }
            else
            {
                listView1.Items.Clear();
                ArrayList aList = new ArrayList();
                aList = User.getSqlReader();

                try
                {
                    foreach (User user in aList)
                    {
                        ListViewItem item = new ListViewItem(user.Id.ToString());
                        item.SubItems.Add(user.CardId.ToString());
                        item.SubItems.Add(user.LastName);
                        item.SubItems.Add(user.Name);
                        item.SubItems.Add(user.Phone.ToString());
                        item.SubItems.Add(user.Uld.ToString());
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mySerial.Close();
            using (AddUserForm adduser = new AddUserForm())
            {
                adduser.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            SerialOpen();
            populateLV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mySerial.Close();
            using (Charge charge = new Charge())
            {
                charge.ShowDialog();
            }
        }
    }
}
