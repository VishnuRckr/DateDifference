using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DOB.DBHelper
{
    public class PersonDetailsDBHelper
    {
        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Age Age { get; set; }



        public static void Write(List<PersonDetailsDBHelper> listPerson)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PersonName", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonDob", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("PersonAge", typeof(Int32)));
            foreach (var item in listPerson)
            {
                dt.Rows.Add(item.Name, item.Dob, item.Age.Years);
            }
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            using (SqlCommand cmd = new SqlCommand("Proc_PersonDetails_Insert", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter dtparam = cmd.Parameters.AddWithValue("@persondetails", dt);
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
            SqlCommand cmd = new SqlCommand("Proc_PersonDetails_Select", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\nPersons' table has the following entries :\n");
                while (reader.Read())
                {
                    //reader["PersonId"]
                    //reader["PersonName"]
                    Console.WriteLine("Name : {0}\t Dob : {1}\t Age : {2} years\n", reader["PersonName"], reader["PersonDob"], reader["PersonAge"]);
                }
            }
            else
            {
                Console.WriteLine("\nPersons' Table is empty\n");
            }
            connection.Close();
        }


    }
    public class Age
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public Age(int Years)
        {
            this.Years = Years;
        }
    }


}
