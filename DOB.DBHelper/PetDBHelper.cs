using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DOB.DBHelper
{
    public class PetDBHelper : PersonDetailsDBHelper
    {
        public string PetBreed { get; set; }

        public static void Write(List<PetDBHelper> listPet)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PersonName", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonDob", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("PersonAge", typeof(Int32)));
            dt.Columns.Add(new DataColumn("PetBreed", typeof(string)));
            foreach (var item in listPet)
            {
                dt.Rows.Add(item.Name, item.Dob, item.Age.Years, item.PetBreed);
            }
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            using (SqlCommand cmd = new SqlCommand("Proc_Pet_Insert", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter dtparam = cmd.Parameters.AddWithValue("@pet", dt);
                dtparam.SqlDbType = SqlDbType.Structured;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static List<PetDBHelper> Read()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Proc_Pet_Select", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<PetDBHelper> petList = new List<PetDBHelper>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {                 
                        petList.Add(new PetDBHelper
                        {
                            Id = (int)reader["PersonDetailsId"],
                            Name = (string)reader["PersonName"],
                            Dob = (DateTime)reader["PersonDob"],
                            Age = (new Age((int)reader["PersonAge"])),
                            PetBreed = (string)reader["PetBreed"]
                        });                    
                }
            }
            else
            {
                Console.WriteLine("\nPersons' Table is empty\n");
            }
            connection.Close();
            return petList;
        }
        public static PetDBHelper ReadByID(int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Proc_Pet_SelectById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            SqlDataReader reader = cmd.ExecuteReader();
            PetDBHelper personList = null;
            if (reader.Read())
            {
                personList = new PetDBHelper
                {
                    Id = (int)reader["PersonDetailsId"],
                    Name = (string)reader["PersonName"],
                    Dob = (DateTime)reader["PersonDob"],
                    Age = (new Age((int)reader["PersonAge"])),
                    PetBreed = (string)reader["PetBreed"]
                };

            }

            connection.Close();
            return personList;
        }
        public static void Update(int id, List<PetDBHelper> listPet)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PersonName", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonDob", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("PersonAge", typeof(Int32)));
            dt.Columns.Add(new DataColumn("PetBreed", typeof(string)));
            foreach (var item in listPet)
            {
                dt.Rows.Add(item.Name, item.Dob, item.Age.Years, item.PetBreed);
            }
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Proc_Pet_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            SqlParameter dtparam = cmd.Parameters.AddWithValue("@pet", dt);
            dtparam.SqlDbType = SqlDbType.Structured;
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
