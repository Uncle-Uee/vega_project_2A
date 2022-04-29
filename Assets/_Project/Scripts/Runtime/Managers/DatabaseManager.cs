using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using UnityEngine;

namespace Rogue.Managers
{
    [Serializable]
    public class Player
    {
        #region VARIABLES

        [Header("User Information")]
        public int ID;
        public string Username;
        public int Money;

        #endregion
    }

    public class DatabaseManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Debug")]
        public bool TestDBConnection = false;

        [Header("Connection Properties")]
        public string Host = "Localhost";
        public string User = "root";
        public string Password = "root";
        public string Database = "vega";

        [Header("Database Properties")]
        public string TableName = "users";

        private MySqlConnectionStringBuilder _connectionString = new MySqlConnectionStringBuilder();

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            CreateConnectionString();
            print(_connectionString.ConnectionString);
        }

        private void Start()
        {
            TestConnection();
        }

        #endregion


        #region METHODS

        public void AddNewPlayer(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    string query = $"INSERT INTO {TableName} (Username, Password) VALUES (@Username, @Password)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                    }
                }

                print($"Insert Player - {username}");
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }
        }

        public Player GetPlayer(string username, string password)
        {
            Player player = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {TableName} WHERE Username = @Username AND Password = @Password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            player = new Player()
                            {
                                Username = username
                            };

                            while (reader.Read())
                            {
                                player.ID = reader.GetInt32("ID");
                                player.Money = reader.GetInt32("Money");
                            }
                        }
                    }
                    print($"Get Player - {username}.");
                }
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }

            return player;
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {TableName}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) players = new List<Player>();
                            while (reader.Read())
                            {
                                players.Add(new Player()
                                {
                                    ID = reader.GetInt32("ID"),
                                    Username = reader.GetString("Username"),
                                    Money = reader.GetInt32("Money")
                                });
                            }
                        }
                    }

                    print($"Get All Players - {players?.Count}.");
                }
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }

            return players;
        }

        public void UpdatePlayer(int id, int money)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    string query = $"UPDATE {TableName} SET MONEY = @Money WHERE ID = @ID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Money", money);
                        command.ExecuteNonQuery();
                    }

                    print($"Updated Player - {id} : {money}.");
                }
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }
        }

        public void DeletePlayer(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    string query = $"DELETE FROM {TableName} WHERE ID = @ID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }

                    print($"Deleted Player - {id}");
                }
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }
        }

        #endregion

        #region HELPER METHODS

        private void CreateConnectionString()
        {
            _connectionString.Server = Host;
            _connectionString.UserID = User;
            _connectionString.Password = Password;
            _connectionString.Database = Database;
        }

        private void TestConnection()
        {
            try
            {
                if (!TestDBConnection) return;
                using (MySqlConnection connection = new MySqlConnection(_connectionString.ToString()))
                {
                    connection.Open();
                    print("MySQL - Opened Connection");
                }
            }
            catch (MySqlException exception)
            {
                print(exception.Message);
            }
        }

        #endregion
    }
}