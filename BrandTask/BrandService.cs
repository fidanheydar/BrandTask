using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrandTask
{
    internal class BrandService
    {
        public void CreateBrand(string name, int year)
        {
            string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "INSERT INTO Brands(Name,Year) VALUES(@name,@year)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBrand(int id)
        {
            string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "DELETE FROM Brands WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

            }

        }

        public Brands GetBrandById(int id)
        {
            Brands brand = null;
            string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "SELECT TOP(1) * FROM Brands WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        brand = new Brands();
                        brand.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        brand.Name = reader.GetString(reader.GetOrdinal("Name"));
                        brand.Year = reader.GetInt32(reader.GetOrdinal("Year"));
                    }
                }
            }
            return brand;

        }

        public List<Brands> GetAllBrands()
        {
            List<Brands> brands = new List<Brands>();
            string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "SELECT Id,Name,Year FROM Brands";
                SqlCommand cmd = new SqlCommand(query, connection);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brands brand = new Brands
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year"))
                        };
                        brands.Add(brand);
                    }
                }
                return brands;
            }
        }

        public void UpdateNameOfBrand(int id, string name)
        {
            string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "UPDATE Brands SET Name = @name WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.ExecuteNonQuery();
                }
            }

        }
            public void UpdateYearOfBrand(int id, int year)
            {
                string connectionStr = "Server=(localdb)\\MSSqlLocalDb;Database = BrandsDb;Trusted_Connection=true";
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    string query = "UPDATE Brands SET Name = @name WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
}
