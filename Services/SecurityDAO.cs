using McIntashLaptops.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace McIntashLaptops.Services
{
    public class SecurityDAO
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=McIntash;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool FindUserByUsernameAndPassword(UserModel user)
        {
            bool success = false;
            string sqlStatement = "select * from dbo.users where username=@username and password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar,255).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 255).Value = user.Password;
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        success = true;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }

        public UserModel GetUserByUsernameAndPassword(UserModel user) {
            UserModel gotten = new UserModel();
            string sqlStatement = "select * from dbo.users where username=@username and password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 255).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 255).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            gotten = new UserModel((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[5], (string)reader[6],
                                (string)reader[7], (string)reader[8], (string)reader[9],(string)reader[10], (string)reader[11]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return gotten;
        }
    }
}
