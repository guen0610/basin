using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class AddUserForm : Form
    {
        static SerialPort mySerial;
        delegate void displayUserDelegate();
        public AddUserForm()
        {
            InitializeComponent();
            mySerial.E
            System.Text.RegularExpressions.Regex.IsMatch(lastNameTB.Text, "[ ^ 0-9]");
            mySerial = new SerialPort("COM4", 9600);
            mySerial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }


        private void hideIndicator()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.cardIndicatorL.InvokeRequired)
            {
                displayUserDelegate d = new displayUserDelegate(hideIndicator);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.cardIndicatorL.Visible = false;
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadLine();

            indata = indata.Remove(indata.Length - 1); //removing last character \r from indata
            User findingUser = User.searchByCardID(indata);

            if (findingUser != null)
            {
                //TODO: Burtgeltei kart bna!
                Console.WriteLine("Burtgeltei kart bna");
                return;
            }

            User addingUser = new User();
            addingUser.CardId = indata;
            addingUser.LastName = lastNameTB.Text;
            addingUser.Name = nameTB.Text;
            addingUser.Phone = Convert.ToInt32(phoneTB.Text);
            addingUser.Uld = Convert.ToInt32(uldNUD.Value);           
            addingUser.insert();

            hideIndicator();
            /*
            User user = new User();
            user.CardId = "dddd3232";
            user.LastName = lastNameTB.Text;
            user.Name = nameTB.Text;
            user.Phone = Convert.ToInt32(phoneTB.Text);
            user.Uld = Convert.ToInt32(uldNUD.Value);
            user.insert();
            cardIndicatorL.Visible = false; */
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lastNameTB.Text == "" || nameTB.Text == "" || phoneTB.Text == "")
            {
                MessageBox.Show("Хэрэглэгчийн мэдээллийг бүрэн оруулна уу!");
                return;
            }
            cardIndicatorL.Visible = true;
            try
            {
                mySerial.Open();
                Console.WriteLine("Serial opened");
            }
            catch
            {
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Serial cant open");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
