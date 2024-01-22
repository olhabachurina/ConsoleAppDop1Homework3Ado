namespace ConsoleAppDop1Homework3Ado
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // В случае успешного подключения выводите информационное сообщение
                    // Console.WriteLine("Подключение успешно установлено.");
                    //Отображение всей информации о товаре; 
                    // DisplayAllGoods(connection);
                    //Отображение всех типов товаров; 
                    //DisplayAllTypes(connection);
                    //Отображение всех поставщиков; 
                    //DisplayAllSuppliers(connection);
                    //Показать товар с максимальным количеством; 
                    //DisplayMaxQuantityGood(connection);
                    //Показать товар с минимальным количеством;
                    //DisplayMinCostGood(connection);
                    //Показать товар с минимальной себестоимостью; 
                    //DisplayMinQuantityGood(connection);
                    //Показать товар с максимальной себестоимостью.
                    //DisplayMaxCostGood(connection);
                    //Показать товары, заданной категории;
                    //DisplayGoodsByCategory(connection, "Шоколад и начинки");
                    //Показать товары, заданного поставщика; 
                    //DisplayGoodsBySupplier(connection, "Mr Juice");
                    //Показать самый старый товар на складе; 
                    //DisplayOldestGood(connection);
                    //Показать среднее количество товаров по каждому типу товара.
                    //DisplayAverageQuantityByType(connection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
        }
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"ConnectionString: {connectionString}");

            return connectionString;
        }
        private static void DisplayAllGoods(SqlConnection connection)
        {
            Console.WriteLine("Вся информация о товарах:");
            string query = "SELECT * FROM Goods";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Тип: {reader["Type"]}, Поставщик Id: {reader["SupplierId"]}, " +
                                          $"Количество: {reader["Quantity"]}, Себестоимость: {reader["Cost"]}, Дата поставки: {reader["DeliveryDate"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayAllTypes(SqlConnection connection)
        {
            Console.WriteLine("Все типы товаров:");
            string query = "SELECT DISTINCT Type FROM Goods";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Тип товара: {reader["Type"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayAllSuppliers(SqlConnection connection)
        {
            Console.WriteLine("Все поставщики:");
            string query = "SELECT * FROM Suppliers";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название поставщика: {reader["Name"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayMaxQuantityGood(SqlConnection connection)
        {
            Console.WriteLine("Товар с максимальным количеством:");
            string query = "SELECT TOP 1 * FROM Goods ORDER BY Quantity DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Количество: {reader["Quantity"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayMinCostGood(SqlConnection connection)
        {
            Console.WriteLine("Товар с минимальным количеством:");
            string query = "SELECT TOP 1 * FROM Goods ORDER BY Quantity ASC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Количество: {reader["Quantity"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayMinQuantityGood(SqlConnection connection)
        {
            Console.WriteLine("Товар с минимальной себестоимостью:");
            string query = "SELECT TOP 1 * FROM Goods ORDER BY Cost ASC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Себестоимость: {reader["Cost"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayMaxCostGood(SqlConnection connection)
        {
            Console.WriteLine("Товар с максимальной себестоимостью:");
            string query = "SELECT TOP 1 * FROM Goods ORDER BY Cost DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Себестоимость: {reader["Cost"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        static void DisplayGoodsByCategory(SqlConnection connection, string category)
        {
            Console.WriteLine($"Товары категории '{category}':");
            string query = $"SELECT * FROM Goods WHERE Type = '{category}'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Тип: {reader["Type"]}, Поставщик Id: {reader["SupplierId"]}, " +
                                          $"Количество: {reader["Quantity"]}, Себестоимость: {reader["Cost"]}, Дата поставки: {reader["DeliveryDate"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayGoodsBySupplier(SqlConnection connection, string supplier)
        {
            {
                Console.WriteLine($"Товары от поставщика '{supplier}':");
                string query = $"SELECT * FROM Goods WHERE SupplierId IN (SELECT Id FROM Suppliers WHERE Name = '{supplier}')";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Тип: {reader["Type"]}, Поставщик Id: {reader["SupplierId"]}, " +
                                              $"Количество: {reader["Quantity"]}, Себестоимость: {reader["Cost"]}, Дата поставки: {reader["DeliveryDate"]}");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        private static void DisplayOldestGood(SqlConnection connection)
        {
            Console.WriteLine("Самый старый товар:");
            string query = "SELECT TOP 1 * FROM Goods ORDER BY DeliveryDate ASC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Название: {reader["Name"]}, Дата поставки: {reader["DeliveryDate"]}");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void DisplayAverageQuantityByType(SqlConnection connection)
        {
            Console.WriteLine("Среднее количество товаров по каждому типу:");
            string query = "SELECT Type, AVG(Quantity) AS AvgQuantity FROM Goods GROUP BY Type";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Тип товара: {reader["Type"]}, Среднее количество: {reader["AvgQuantity"]}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

