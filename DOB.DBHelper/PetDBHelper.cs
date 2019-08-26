using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;




namespace DOB.DBHelper
{
    public class PetDBHelper : PersonDetailsDBHelper
    {
        public string PetBreed { get; set; }

        public void Write(List<PetDBHelper> listPet)
        {
            //SqlConnection connection = new SqlConnection("Data source=DEV31;Initial Catalog=DateOfBirth;User Id=sa;Password=!QAZ2wsx;");
            //using (SqlCommand cmd = new SqlCommand("InsertIntoTablePet", connection))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@PersonName", SqlDbType.VarChar);
            //    cmd.Parameters.Add("@PersonDob", SqlDbType.Date);
            //    cmd.Parameters.Add("@PersonAge", SqlDbType.Int);
            //    cmd.Parameters.Add("@PetBreed", SqlDbType.VarChar);
             

            //    connection.Open();
            //    foreach (var item in listPet)
            //    {
            //        cmd.Parameters["@PersonName"].Value = item.Name;
            //        cmd.Parameters["@PersonDob"].Value = item.Dob;
            //        cmd.Parameters["@PersonAge"].Value = item.Age.Years;
            //        cmd.Parameters["@PetBreed"].Value = item.PetBreed;
            //        cmd.ExecuteNonQuery();
            //    }
            //    connection.Close();
            //}


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PersonName", typeof(string)));
            dt.Columns.Add(new DataColumn("PersonDob", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("PersonAge", typeof(Int32)));
            dt.Columns.Add(new DataColumn("PetBreed", typeof(string)));
                 foreach (var item in listPet)
            {

                dt.Rows.Add(item.Name, item.Dob, item.Age.Years,item.PetBreed);

            }

            SqlConnection connection = new SqlConnection("Data source=DEV31;Initial Catalog=DateOfBirth;User Id=sa;Password=!QAZ2wsx;");
            using (SqlCommand cmd = new SqlCommand("InsertIntoTablePet", connection))
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
            SqlConnection connection = new SqlConnection("Data source=DEV31;Initial Catalog=DateOfBirth;User Id=sa;Password=!QAZ2wsx;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("ReadFromTablePet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\nPets' table has the following entries :\n");
                while (reader.Read())
                {
                    Console.WriteLine("Name : {0}\t Dob : {1}\t Age : {2} years\t Pet Breed : {3}\n", reader.GetString(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetString(3));
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
