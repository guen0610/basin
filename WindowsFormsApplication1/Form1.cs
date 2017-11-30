using System;
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
        public const int FAILED = -10;

        SQLiteConnection m_dbConnection;
        static SerialPort mySerial;
        private delegate void displayDelegate(User user);
        displayDelegate displayFunc;
        public Form1()
        {
            InitializeComponent();
            displayFunc = displayText;

            m_dbConnection = new SQLiteConnection(@"Data Source=C:\Users\Guen\Documents\WindowsFormsApplication1\auto.db; Version=3;");
            m_dbConnection.Open();

            test("abcd1333");
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
        }


        private void test(string card_id)
        {
            User user = searchByCardID(card_id);

            // start
            if (user == null)
            {
                MessageBox.Show("Хэрэглэгч бүртгэлгүй байна!");
                return;
            }

            //TODO: Databased oldvol uldegdel ni duussan esehiig shalgana
            if (user.Uld == 0)
            {
                //TODO: Uldegedel duussan bna!!!
                MessageBox.Show("Үлдэгдэл дууссан байна!");
                return;
            }
            user.Uld -= 1;
            saveUser(user);

            displayFunc(user);
            // end
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //Serial portnoos irsen utgiig unshina
            //TODO: Databased baiga esehiig shalgana
            
            User user = searchByCardID("abcd1333");
            displayFunc(user);

            if (user == null)
            {
                //TODO: iim IDtai hereglegch bhgu bna!!!
                return;
            }
            
            //TODO: Databased oldvol uldegdel ni duussan esehiig shalgana
            if(user.Uld == 0)
            {
                //TODO: Uldegedel duussan bna!!!
                return;
            }

            //TODO: Duusagui bol database update hiine
            // updateUldegdel(ret - 1);  
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

        void handleCardPresent(string id)
        {



            // Read sample data from CSV file
            // using (CsvFileReader reader = new CsvFileReader("WriteTest.csv"))
            // {
            //     CsvRow row = new CsvRow();
            //     while (reader.ReadRow(row))
            //     {
            //         if (row[1] != id)
            //             continue;
            //         displayFunc(row[0], row[1], row[2], row[3], row[4]);
            //         //listViewShow();
            //         //Thread demoThread =
            //         //new Thread(new ThreadStart(this.ThreadProcSafe));

            //         //demoThread.Start();

            //         //Console.WriteLine();
            //     }
            // }
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
                   
                }
            }
        }

        void displayText(User user)
        {
            if (cardLabel.InvokeRequired)
                cardLabel.Invoke(displayFunc, new object[] { user.CardId, user.LastName, user.Name, user.Phone, user.Uld });
            else
            {
                cardLabel.Text = user.CardId.ToString();
                lnameLabel.Text = user.LastName;
                nameLabel.Text = user.Name;
                phoneLabel.Text = user.Phone.ToString();
                uldLabel.Text = user.Uld.ToString();
            }
        }

        void addUserDB()
        {
            string sql = "INSERT INTO users (card_id, lname, name, phone, uld) VALUES ('8jjjk213', 'boldbaatar', 'bold', 89383399, 1)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        User searchByCardID(string card_id)
        {
            string sql = String.Format("SELECT id, card_id, lname, name, phone, uld FROM users WHERE card_id = '{0}'", card_id);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Name: " + reader["name"] + "\tCARD_ID: " + reader["card_id"]);
                User user = new User();
                user.Id = Convert.ToInt32(reader["id"]);
                user.CardId = reader["card_id"].ToString();
                user.LastName = reader["lname"].ToString();
                user.Name = reader["name"].ToString();
                user.Phone = Convert.ToInt32(reader["phone"]);
                user.Uld = Convert.ToInt32(reader["uld"]);
                return user;
            }

            return null;
        }

        
        // void updateUlupdegdel(int value)
        
        void saveUser(User user)
        {
            string sql = String.Format("UPDATE users SET lname='{0}', name='{1}', phone='{2}', uld='{3}' WHERE card_id='{4}'", user.LastName, user.Name, user.Phone, user.Uld, user.CardId);
            Console.WriteLine(sql);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            
            command.ExecuteNonQuery();
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
            AddUser adduser = new AddUser();
            adduser.ShowDialog();
        }
    }
}
