using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace proiect.proiectClasses
{
    class ContactClass
    {
        public string Cod_Tipologie { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }



        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        

        //SELECT DATA FROM DB
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //writting sql query
                string sql = "SELECT * FROM Abonati, Abonamente, Tipologii";

                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //sql data adapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        //INSERT DATA INTO DB
        public bool Insert(ContactClass c)
        {
            //cr default return type and setting its value type
            bool isSucces = false;

            //Connect to db
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //insert data
                string sql = "INSERT INTO Abonati(Cod_Tipologie, Nume,Prenume,Tel,Email) VALUES (@Cod_Tipologie,@Nume,@Prenume,@Tel,@Email)";
                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //parameters to add data

                cmd.Parameters.AddWithValue("@Cod_Tipologie", c.Cod_Tipologie);
                cmd.Parameters.AddWithValue("@Nume", c.Nume);
                cmd.Parameters.AddWithValue("@Prenume", c.Prenume);
                cmd.Parameters.AddWithValue("@Tel", c.Tel);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                //connection opens here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if query runs succesfully  -- value of rows will be greater than 0
                if (rows > 0)
                {
                    isSucces = true;
                }
                else isSucces = false;


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }

        //Method to update data from app
        public bool Update(ContactClass c)
        {
            //create default return type- default setting fdalse
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to update db
                string sql = "UPDATE Abonati SET Cod_Tipologie=@Cod_Tipologie, Nume=@Nume,Prenume=@Prenume, Tel=@Tel,Email=@Email WHERE IdAbonat=@IdAbonat";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //parameters to add data

                cmd.Parameters.AddWithValue("@Cod_Tipologie", c.Cod_Tipologie);
                cmd.Parameters.AddWithValue("@Nume", c.Nume);
                cmd.Parameters.AddWithValue("@Prenume", c.Prenume);
                cmd.Parameters.AddWithValue("@Tel", c.Tel);
                cmd.Parameters.AddWithValue("@Email", c.Email);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

            //method delete from db

            public bool Delete(ContactClass c)
            {
                //create default return type- default setting fdalse
                bool isSuccess = false;
                //creeate sql connection
                SqlConnection conn = new SqlConnection(myconnstrng);

                try
                {
                    //sql to update db
                    string sql = "DELETE FROM IdAbonat=@IdAbonat";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //parameters to add data
                    cmd.Parameters.AddWithValue("@Cod_Tipologie", c.Cod_Tipologie);
                    
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }

                return isSuccess;
            }

        }
    }
