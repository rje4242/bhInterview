using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;

namespace bhinterview
{
    class mySql
    {
        const string addressDatabase = "database-1.cowbahg40izk.us-east-1.rds.amazonaws.com";
        const int portDatabase = 3306;
        const string passwordDatabase = "americanrivergold";
        const string userDatabase = "admin";
        const string databaseDatabase = "bhInterview";

        public static void test()
        {
            string connStr = "server=" + addressDatabase + ";user=" + userDatabase + ";database=" + databaseDatabase +
                ";port=" + portDatabase.ToString() + ";password=" + passwordDatabase;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM applicant";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Select error: " + ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }


        public static void addApplicant()
        {
            string connStr = "server=" + addressDatabase + ";user=" + userDatabase + ";database=" + databaseDatabase +
                ";port=" + portDatabase.ToString() + ";password=" + passwordDatabase;


            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO applicant (firstName, lastName) VALUES (?first, ?last)";

                cmd.Parameters.Add("?first", MySqlDbType.VarChar).Value = "Trevor";
                cmd.Parameters.Add("?last", MySqlDbType.VarChar).Value = "Foley";

                var g = cmd.ExecuteNonQuery();
                //cmd.ExecuteNonQuery();

                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
