using McIntashLaptops.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace McIntashLaptops.Services
{
    public class LaptopDAO : ILaptopDataService
    {
        //This string is used to establish a connection to a database
        string connectionString = "Data Source=tcp:johnkeen.database.windows.net,1433;Initial Catalog=McIntash;User Id=AdminGuy@johnkeen;Password=#WorkingHard2";
        
        //This is a default constructor
        public LaptopDAO()
        {
        }

        //This is used return all laptop relation records
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

        //This is used to delete a laptop record by LaptopModel (specifically the id)
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
        //This will return a laptop record for a laptop with a particular id
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
        //Insert a laptop record into database using LaptopModel
        public int Insert(LaptopModel laptop)
        {
            int newIdNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.laptop (photo, name, description, price, processor, ram, drive_size, graphics_card, weight, operating_system) OUTPUT INSERTED.id VALUES (@Photo, @Name, @Description, @Price, @Processor, @Ram, @DriveSize, @GraphicsCard, @Weight, @OperatingSystem)";
                SqlCommand myCommand = new SqlCommand(query, connection);
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

        //This is used to return a laptop record containing a search term in one of it's fields
        public List<LaptopModel> SearchLaptops(string searchTerm)
        {
            List<LaptopModel> list = new List<LaptopModel>();
            string sqlStatement = "select * from dbo.laptop where name like @searchTerm or description like @searchTerm or id like @searchTerm or photo like @searchTerm or price like @searchTerm or processor like @searchTerm or ram like @searchTerm or drive_size like @searchTerm or graphics_card like @searchTerm or weight like @searchTerm or operating_system like @searchTerm";

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
        //This is used to update a laptop record using a LaptopModel
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
