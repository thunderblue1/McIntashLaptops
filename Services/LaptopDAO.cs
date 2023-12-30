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
            int idNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "delete from dbo.laptop where id=@Id";
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Id", laptop.Id);

                try
                {
                    connection.Open();
                    idNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if(idNumber!=-1)
            {
                return true;
            } else {
                return false;
            }
        }

        public LaptopModel GetLaptopById(int id)
        {
            LaptopModel laptop = new LaptopModel();
            string sqlStatement = "select * from dbo.laptop where id=@myId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("myId", id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        laptop = new LaptopModel((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], (decimal)reader[4], (string)reader[5], (string)reader[6], (string)reader[7], (string)reader[8], (string)reader[9], (string)reader[10]);
                        return laptop;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return laptop;
        }

        public int Insert(LaptopModel laptop)
        {
            throw new NotImplementedException();
        }

        public List<LaptopModel> SearchLaptops(string searchTerm)
        {
            List<LaptopModel> list = new List<LaptopModel>();
            string sqlStatement = "select * from dbo.laptop where name like @searchTerm or description like @searchTerm or id like @searchTerm";

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
            int newIdNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.laptop SET photo=@Photo, name=@Name, description = @Description, price=@Price, processor=@Processor, ram=@Ram, drive_size=@DriveSize, graphics_card=@GraphicsCard, weight=@Weight, operating_system=@OperatingSystem WHERE id=@Id";
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@Id", laptop.Id);
                myCommand.Parameters.AddWithValue("@Photo", laptop.Photo);
                myCommand.Parameters.AddWithValue("@Name", laptop.Name);
                myCommand.Parameters.AddWithValue("@Description", laptop.Description);
                myCommand.Parameters.AddWithValue("@Price", laptop.Price);
                myCommand.Parameters.AddWithValue("@Processor", laptop.Processor);
                myCommand.Parameters.AddWithValue("@Ram", laptop.Ram);
                myCommand.Parameters.AddWithValue("@DriveSize", laptop.DriveSize);
                myCommand.Parameters.AddWithValue("@GraphicsCard", laptop.GraphicsCard);
                myCommand.Parameters.AddWithValue("@Weight", laptop.Weight);
                myCommand.Parameters.AddWithValue("@OperatingSystem", laptop.OperatingSystem);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }
    }
}
