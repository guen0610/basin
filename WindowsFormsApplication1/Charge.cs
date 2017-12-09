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

namespace WindowsFormsApplication1
{
    public partial class Charge : Form
    {
        static SerialPort mySerial;
        delegate void displayUserDelegate(User user);
        public Charge()
        {
            InitializeComponent();
            mySerial = new SerialPort("COM4", 9600);
            mySerial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            try
            {
                mySerial.Open();
                mySerial.DiscardInBuffer();
                mySerial.DiscardOutBuffer();
                Console.WriteLine("Serial opened");
            }
            catch
            {
                Console.WriteLine("Serial cant open");
            }

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

            displayUser(user);

            using (GetQuantityDialog getQuantityDialog = new GetQuantityDialog(user.Uld))
            {
                if (getQuantityDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Console.WriteLine("Selected quantity is: {0}", getQuantityDialog.selectedQuantity);
                    user.Uld += getQuantityDialog.selectedQuantity;
                    user.update();
                }
            }



        }

        private void Charge_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Closing");
            mySerial.Close();
        }
    }
}
