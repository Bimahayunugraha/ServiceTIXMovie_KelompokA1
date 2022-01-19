using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceTIXMovie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=LAPTOP-GVH5477F;Initial Catalog=TIXMovie;Persist Security Info=true;User ID=sa;Password=bima071200";
        SqlConnection connection;
        SqlCommand com;

        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_User, Username, Email, Phone, Password, Role from UserAccess";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.email = reader.GetString(2);
                    data.phone = reader.GetString(3);
                    data.password = reader.GetString(4);
                    data.role = reader.GetString(5);
                    list.Add(data);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return list;
        }

        public string deletefilm(string JudulFilm)
        {
            try
            {
                int id = 0;
                string sql = "select ID_Film from dbo.Film where Judul_Film = '" + JudulFilm + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }

                connection.Close();
                string sql2 = "delete from Film where ID_Film = " + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public string deletetransaksitiket(string NamaCustomer)
        {
            string a = "gagal";

            try
            {
                string sql = "delete from dbo.TransaksiTicket where ID_transaksi = '" + NamaCustomer + "'";
                connection = new SqlConnection(constring); 
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return a;
        }

        public string editfilm(int id, string Harga)
        {
            string a = "gagal";

            try
            {
                string sql = "update dbo.Film set Harga = '" + Harga + "'where ID_Film = " + id + "";
                connection = new SqlConnection(constring); 
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }

            return a;
        }

        public string edittransaksitiket(int IDTransaksi, string Status)
        {
            string a = "gagal";

            try
            {
                string sql = "update dbo.TransaksiTicket set Status = '" + Status + "''where ID_Film = " + IDTransaksi + "";
                connection = new SqlConnection(constring); 
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }

            return a;
        }

        public string film(string JudulFilm, string Deskripsi, string Harga)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Film values ('" + JudulFilm + "', '" + Deskripsi + "', '" + Harga + "')"; 
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<DataFilm> DataFilm()
        {
            List<DataFilm> list = new List<DataFilm>();
            try
            {
                string sql = "select ID_Film, Judul_Film, Deskripsi, Harga from dbo.Film";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataFilm data = new DataFilm();
                    data.id = reader.GetInt32(0);
                    data.JudulFilm = reader.GetString(1);
                    data.Deskripsi = reader.GetString(2);
                    data.Harga = reader.GetString(3);
                    list.Add(data);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return list;
        }

        public string Login(string email, string password)
        {
            string kategori = "";

            string sql = "select role from UserAccess where Email = '" + email + "' and Password = '" + password + "'";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }

            return kategori;
        }

        public string Register(string username, string email, string phone, string password, string role)
        {
            try
            {
                string sql = "insert into UserAccess values ('" + username + "', '" + email + "', '" + phone + "', '" + password + "', '" + role + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "Sukses";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string statustiket(int IDStatus, string IDTransaksi)
        {
            throw new NotImplementedException();
        }

        public List<StatusTiket> StatusTiket()
        {
            List<StatusTiket> statusTikets = new List<StatusTiket>(); 
            try
            {
                string sql = "select ID_Status, ID_Transaksi from dbo.StatusTiket";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection); 
                connection.Open(); 
                SqlDataReader reader = com.ExecuteReader(); 
                while (reader.Read())
                {
                    /* Nama Class */
                    StatusTiket data = new StatusTiket(); 
                    // Bentuk array
                    data.IDStatus = reader.GetInt32(0); 
                    data.IDTransaksi = reader.GetString(1);
                    statusTikets.Add(data); 
                }
                connection.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return statusTikets;
        }

        public string transaksitiket(int IDFilm, string Bioskop, string NamaCustomer, string Phone, int Studio, string Tanggal, string JamTayang, string Row, string Seat, string Harga, string Total, string Status)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.TransaksiTicket values ('" + IDFilm + "', '" + Bioskop + "', '" + NamaCustomer + "', '" + Phone + "', '" + Studio + "', '" + Tanggal + "', '" + JamTayang + "', '" + Row + "', '" + Seat + "', '" + Harga + "', '" + Total + "', '" + Status + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<DataTransaksi> DataTransaksi()
        {
            List<DataTransaksi> list = new List<DataTransaksi>(); 

            try
            {
                string sql = "select ID_Transaksi, ID_Film, Bioskop, Nama_Customer, Phone, Studio, Tanggal, Jam_Tayang, Row, Seat, Harga, Total, Status from dbo.TransaksiTicket";
                connection = new SqlConnection(constring); 
                com = new SqlCommand(sql, connection); 
                connection.Open();
                SqlDataReader reader = com.ExecuteReader(); 
                while (reader.Read())
                {
                    // Nama class
                    DataTransaksi data = new DataTransaksi(); 

                    // Bentuk array
                    data.IDTransaksi = reader.GetInt32(0); 
                    data.Film = reader.GetInt32(1);
                    data.Bioskop = reader.GetString(2);
                    data.NamaCustomer = reader.GetString(3);
                    data.Phone = reader.GetString(4);
                    data.Studio = reader.GetInt32(5);
                    data.Tanggal = reader.GetString(6);
                    data.JamTayang = reader.GetString(7);
                    data.Row = reader.GetString(8);
                    data.Seat = reader.GetString(9);
                    data.Harga = reader.GetString(10);
                    data.Total = reader.GetString(11);
                    data.Status = reader.GetString(12);
                    list.Add(data); 
                }

                connection.Close(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return list;
        }
    }
}
