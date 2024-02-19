using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace enter_to_sqlite
{
    public class DataBase
    {
        SqliteConnection connection = new SqliteConnection("DataSource=myTodoList.db");

        public List<Passenger> passengers = new List<Passenger>();
        public List<Ticket> tickets = new List<Ticket>();
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void getUsers()
        {
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM passengers";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Passenger passenger = new Passenger(reader.GetString(1),reader.GetString(2),reader.GetBoolean(3));
                            passengers.Add(passenger);
                        }
                    }
                }
            }
        }

        public List<schedule> schedule = new List<schedule>();
        public void getSchedule ()
        {
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT schedule.type_train, schedule.date_start, schedule.time_start, " +
                                            "dep_city.name_city AS dep_city_name, arr_city.name_city AS arr_city_name, schedule.time_travel " +
                                        "FROM schedule " +
                                            "INNER JOIN Routes ON schedule.id_route = Routes.id_route " +
                                            "LEFT JOIN cities AS dep_city ON Routes.dep_point = dep_city.id_city " +
                                            "LEFT JOIN cities AS arr_city ON Routes.arr_point = arr_city.id_city";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            schedule.Add(new schedule (reader.GetString(0),reader.GetString(3), reader.GetString(4),reader.GetString(2), reader.GetString(1),reader.GetString(5)));
                        }
                    }
                }
            }
        }
        public List<string> getCities()
        {
            List<string> cities = new List<string>();
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM cities";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cities.Add(reader.GetString(1));
                        }
                    }
                }
            }
            return cities;
        }

        public void getTickets()
        {
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT passengers.full_name_p, passengers.passport, passengers.benefit, schedule.type_train, " +
                                            "dep_city.name_city AS dep_city_name, arr_city.name_city AS arr_city_name,schedule.time_start, " +
                                            "schedule.date_start, schedule.time_travel, tickets.car_number, tickets.place_number " +
                                        "FROM tickets " +
                                            "INNER JOIN passengers ON tickets.id_p = passengers.id_p " +
                                            "INNER JOIN schedule ON tickets.id_travel = schedule.id_travel " +
                                            "INNER JOIN Routes ON schedule.id_route = Routes.id_route " +
                                            "LEFT JOIN cities AS dep_city ON Routes.dep_point = dep_city.id_city " +
                                            "LEFT JOIN cities AS arr_city ON Routes.arr_point = arr_city.id_city;";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Ticket ticket = new Ticket( new Passenger( reader.GetString(0), reader.GetString(1), reader.GetBoolean(2) )
                                ,new schedule( reader.GetString(3), reader.GetString(4), reader.GetString(5),reader.GetString(6),reader.GetString(7),reader.GetString(8) )
                                ,reader.GetInt32(9),reader.GetInt32(10));
                            tickets.Add(ticket);
                        }
                    }
                }
            }
        }
    }
}
