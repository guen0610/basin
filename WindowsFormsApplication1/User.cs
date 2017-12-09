using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    class User
    {
        private static string connString = @"Data Source=C:\Users\Guen\Documents\WindowsFormsApplication1\basin.db; Version=3;";

        public int Id { get; set; }

        public string CardId { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int Uld { get; set; }

        public static ArrayList getSqlReader()
        {
            using (SQLiteConnection m_dbConnection = new SQLiteConnection(connString))
            {
                m_dbConnection.Open();
                string sql = "SELECT * FROM users";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                try
                {
                    SQLiteDataReader reader = reader = command.ExecuteReader();
                    ArrayList aList = new ArrayList();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.CardId = reader["card_id"].ToString();
                        user.LastName = reader["lname"].ToString();
                        user.Name = reader["name"].ToString();
                        user.Phone = Convert.ToInt32(reader["phone"]);
                        user.Uld = Convert.ToInt32(reader["uld"]);
                        aList.Add(user);
                    }
                    return aList;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }                            
            }
        }
        public static User searchByCardID(string card_id)
        {
            using (SQLiteConnection m_dbConnection = new SQLiteConnection(connString))
            {
                m_dbConnection.Open();

                string sql = String.Format("SELECT id, card_id, lname, name, phone, uld FROM users WHERE card_id = '{0}'", card_id);
                Console.WriteLine(sql);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("Name: " + reader["name"] + "\tCARD_ID: " + reader["card_id"]);
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
        }


        public void update()
        {
            using (SQLiteConnection m_dbConnection = new SQLiteConnection(connString))
            {
                m_dbConnection.Open();

                string sql = String.Format("UPDATE users SET card_id = '{0}', lname='{1}', name='{2}', phone='{3}', uld='{4}' WHERE card_id='{5}'", this.CardId, this.LastName, this.Name, this.Phone, this.Uld, this.CardId);
                Console.WriteLine(sql);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                command.ExecuteNonQuery();
            }
        }

        public void insert()
        {
            using (SQLiteConnection m_dbConnection = new SQLiteConnection(connString))
            {
                m_dbConnection.Open();

                string sql = String.Format("INSERT INTO users (card_id,lname,name,phone,uld) VALUES ('{0}', '{1}', '{2}', {3}, {4})", this.CardId, this.LastName, this.Name, this.Phone, this.Uld);
                //Console.WriteLine(sql);
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Амжилттай боллоо");
                }
                catch (System.Data.SQLite.SQLiteException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Алдаа гарлаа! Бүртгэлтэй карт байж магадгүй");
                }
            }
        }

        
    }
}
