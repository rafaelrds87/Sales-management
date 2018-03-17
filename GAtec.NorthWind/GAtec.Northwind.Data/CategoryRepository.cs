using System.Collections.Generic;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;
using System.Data;
using System.Data.SqlClient;
using GAtec.Northwind.Util;


namespace GAtec.Northwind.Data
{
    public class CategoryRepository : ICategoryRepository
    {

        public IDictionary<string, string> Validation { get, set; }
        public void Add(Category item)
        {

            using (var con = new SqlConnection(NorthwindSettings.connectionString))

          
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into categories (CategoryName, Description) values (@name, @description)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NText).Value = item.Description;

                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public void Update(Category item)
        {

            using (var cmd = new SqlCommand("update categories set CategoryName=@Name, Description=@Description where CategoryId=@CategoryID", con))
            {
                cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                cmd.Parameters.Add("description", SqlDbType.NText).Value = item.Description;
                cmd.Parameters.Add("Id", SqlDbType.NText).Value = Id;

                cmd.ExecuteNonQuery();
            }

            throw new System.NotImplementedException();
        }

        public void Delete(object id)
        {
            using (var cmd = new SqlCommand("delete from categories where CategoryId=@Id", con))
            {
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public Category Get(object id)
        {
            Category category = null;
            using (var con = new SqlConnection(NorthwindSettings.connectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("select CategoryId, CategoryName, Description from categories where CategoryId=@Id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category();

                            category.Id = (int)reader["CategoryId"];
                            category.Name = reader.GetString(1);
                            category.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                    }
                }
            }
        }

        public IEnumerable<Category> GetAll()
        {
           var category = new List<Category>();
            using (var con = new SqlConnection(NorthwindSettings.connectionString))
            {

                con.Open();

                using (var cmd = new SqlCommand("select CategoryId, CategoryName, Description from categories order by categoryName" , con))
                {
         
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            var category = new Category();

                            category.Id = (int)reader["CategoryId"];
                            category.Name = reader.GetString(1);
                            category.Description = reader.GetString(reader.GetOrdinal("Description"));

                        categories.Add(category);
                        }
                    }
                }
            }
        return categories;
        }

        public bool ExistsName(string name, int id = 0)
        {
            using (var con = new SqlConnection(NorthwindSettings.connectionString))
            {


                using (var cmd = new SqlCommand("select count(1) from Categories where Upper(CategoryName)=@name and CategoryId <> @id", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = name.ToUpper();
                    cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

                    result = (int)cmd.ExecuteScalar() > 0;
                }
            }
            return result;
        }
                
        
    }
}