using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace DataAccessCourse
{




    class Program
    {

        private static string providerName = ConfigurationManager.ConnectionStrings["Northwnd"].ProviderName;

        private static string connectionString = ConfigurationManager.ConnectionStrings["Northwnd"].ConnectionString;

        public static DataSet ExecuteDataSet(string sql)
        {
            var ds = new DataSet();

            var factory = DbProviderFactories.GetFactory(providerName);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = connectionString;

                conexao.Open();

                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = sql;
                    using (var adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = comando;

                        adapter.Fill(ds);
                    }

                }
            }
            return ds;
        }

        public static DataSet GetDataSet(string sql)
        {
            var ds = new DataSet();
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var adapter = new SqlDataAdapter(sql, conexao))
                {
                    adapter.Fill(ds);

                }
            }
            return null;


        }




            static void Aula1(string[] args)
        {
            var ordersDataSet = GetDataSet("select * from Orders");

            var ordersTable = ordersDataSet.Tables[0];

            foreach (DataRow row in ordersTable.Rows)
            {
                var shipName = row["ShipName"].ToString();
                var shipCity = row["ShipCity"].ToString();

                Console.WriteLine($"${shipName} - {shipCity}");

            }



            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();



                using (var comando = new SqlCommand("Select * from categories", conexao))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int? categoryId;

                            /**  var categoryIdValue = reader["CategoryId"];
                              var categoryId = categoryIdValue == DBNull.Value ? 0 : (int) categoryIdValue; **/

                            categoryId = reader["CategoryId"] as int?;
                            var categoryName = reader["CategoryName"].ToString();
                            var description = reader["Description"].ToString();

                            Console.WriteLine($"{categoryId} - {categoryName} - {description}");
                        }

                        reader.Close();
                    }
                }
                using (var soma = new SqlCommand("select sum(UnitPrice*UnitsInStock) from Produts where CategoryId=@CategoryId", conexao))
                {
                    soma.Parameters.Add("CategoryId", SqlDbType.Int).Value = 1;

                    var somaTotal = Convert.ToDecimal(soma.ExecuteScalar());

                    Console.WriteLine("Total: " + somaTotal.ToString("C2"));
                }




                /*
                using (var transacao = conexao.BeginTransaction())
                {
                    Console.WriteLine("Category Name: ");
                    string categoryName = Console.ReadLine();

                    Console.WriteLine("Category Description: ");
                    string categoryDescription = Console.ReadLine();

                    try
                    {


                        using (var inclusao = new SqlCommand("Insert into Categories (CategoryName, Description) values(@categoryName,@Description)", conexao))
                        {
                            inclusao.Parameters.Add("CategoryName", SqlDbType.NVarChar).Value = categoryName;
                            inclusao.Parameters.Add("Description", categoryDescription);

                            inclusao.ExecuteNonQuery();

                        }
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        transacao.Rollback();
                        Console.WriteLine(e);

                    }
                }
            }


            reader.Close();
        }
    }

    using (var contagem = new SqlCommand("select count(*) from categories", conexao))
    {
        var total = contagem.ExecuteScalar();

        Console.WriteLine("Total: " + total);
    }

    using (var soma = new SqlCommand("", conexao))
    {

    }
     */
                conexao.Close();
            }
        }

        static void PrintProviders()
        {
            var factoriesDataTable = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in factoriesDataTable.Rows)
            {
                Console.WriteLine($"{row["Name"]} - {row["InvariantName"]}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {

            var customersDataSet = GetDataSet("select * from customers");

            var customersTable = customersDataSet.Tables[0];

                var contactName = row["ContactName"].ToString();
                var contactTitle = row["ContactTitle"].ToString();
                var city = row["City"].ToString();

                Console.WriteLine($"${contactName} - {contactTitle} - {city}");

  


        }
    }
}
