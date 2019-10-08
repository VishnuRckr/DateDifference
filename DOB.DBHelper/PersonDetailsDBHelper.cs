using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DOB.DBHelper
{
    public class PersonDetailsDBHelper
    {
        public int Id { get; set; }
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

        public static List<PersonDetailsDBHelper> Read()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Proc_PersonDetails_Select", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<PersonDetailsDBHelper> personList = new List<PersonDetailsDBHelper>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    personList.Add(new PersonDetailsDBHelper
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["PersonName"],
                        Dob = (DateTime)reader["PersonDob"],
                        Age = new Age((int)reader["PersonAge"])
                    });
                }
            }
            else
            {
                Console.WriteLine("\nPersons' Table is empty\n");
            }
            connection.Close();
            return personList;
        }

        public static PersonDetailsDBHelper ReadByID(int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DOBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Proc_PersonDetails_SelectById", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id; 
            SqlDataReader reader = cmd.ExecuteReader();
            PersonDetailsDBHelper personList = null;
            if(reader.Read())
            {
                personList = new PersonDetailsDBHelper
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["PersonName"],
                    Dob = (DateTime)reader["PersonDob"],
                    Age = new Age((int)reader["PersonAge"])
                };

            }
            
            connection.Close();
            return personList;
        }

        public static void Update(int id, List<PersonDetailsDBHelper> listPerson)
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
            SqlCommand cmd = new SqlCommand("Proc_PersonDetails_Update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            SqlParameter dtparam = cmd.Parameters.AddWithValue("@persondetails", dt);
            dtparam.SqlDbType = SqlDbType.Structured;
            connection.Open();
            cmd.ExecuteNonQuery();
        }
    } 

    public class Age
    {
        public int Years { get; set; }
        public Age(int Years)
        {
            this.Years = Years;
        }
    }
}
