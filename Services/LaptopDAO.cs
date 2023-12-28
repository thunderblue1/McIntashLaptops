using McIntashLaptops.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace McIntashLaptops.Services
{
    public class LaptopDAO : ILaptopDataService
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=McIntash;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public LaptopDAO()
        {
        }

        public List<LaptopModel> All()
        {
            List<LaptopModel> list = new List<LaptopModel>();
            string sqlStatement = "select * from dbo.laptop";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new LaptopModel ( (int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (decimal)reader[4], (string)reader[5], (string)reader[6], (string)reader[7], (string)reader[8], (string)reader[9], (string)reader[10] ));
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return list;
        }

        public bool Delete(LaptopModel laptop)
        {
            throw new NotImplementedException();
        }

        public LaptopModel GetLaptopById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(LaptopModel laptop)
        {
            throw new NotImplementedException();
        }

        public List<LaptopModel> SearchLaptops(string searchTerm)
        {
            List<LaptopModel> list = new List<LaptopModel>();
            string sqlStatement = "select * from dbo.laptop where name like @searchTerm or description like @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@searchTerm", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new LaptopModel((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (decimal)reader[4], (string)reader[5], (string)reader[6], (string)reader[7], (string)reader[8], (string)reader[9], (string)reader[10]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return list;
        }

        public int Update(LaptopModel laptop)
        {
            throw new NotImplementedException();
        }
    }
}
