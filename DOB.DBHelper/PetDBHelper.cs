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

        public void Write(List<PetDBHelper> listPet)
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

        public void Read()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Proc_Pet_Select", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\nPets' table has the following entries :\n");
                while (reader.Read())
                {
                    Console.WriteLine("Name : {0}\t Dob : {1}\t Age : {2} years\t Pet Breed : {3}\n", reader["PersonName"], reader["PersonDob"], reader["PersonAge"], reader["PetBreed"]);
                }
            }
            else
            {
                Console.WriteLine("\nPets' Table is empty\n");
            }
            connection.Close();
        }

    }
}
