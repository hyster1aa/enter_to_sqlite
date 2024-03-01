using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using enter_to_sqlite.BackUpClasses;
using Microsoft.Data.Sqlite;
using static System.ComponentModel.Design.ObjectSelectorEditor;


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
        public void initTables()
        {
            initCities();
            initUsers();
            initRoutes();
            initSchedule();
            initTickets();
        }
        private void initTickets()
        {
            openConnection();
            SqliteCommand initTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS " +
                "\"tickets\" (\r\n\t\"id_ticket\"\tINTEGER NOT NULL," +
                "\r\n\t\"id_travel\"\tINTEGER NOT NULL," +
                "\r\n\t\"id_p\"\tINTEGER NOT NULL," +
                "\r\n\t\"car_number\"\tINTEGER NOT NULL," +
                "\r\n\t\"place_number\"\tINTEGER NOT NULL," +
                "\r\n\tFOREIGN KEY(\"id_p\") REFERENCES \"passengers\"(\"id_p\")" +
                ",\r\n\tFOREIGN KEY(\"id_travel\") REFERENCES \"schedule\"(\"id_travel\")," +
                "\r\n\tPRIMARY KEY(\"id_ticket\" AUTOINCREMENT)\r\n);", connection);
            initTable.CommandType = CommandType.Text;
            initTable.ExecuteNonQuery();
            closeConnection();
        }
        private void  initSchedule()
        {
            openConnection();
            SqliteCommand initTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS \"schedule\" " +
                "(\r\n\t\"id_travel\"\tINTEGER NOT NULL," +
                "\r\n\t\"id_train\"\tINTEGER NOT NULL," +
                "\r\n\t\"id_route\"\tINTEGER," +
                "\r\n\t\"type_train\"\tTEXT NOT NULL," +
                "\r\n\t\"time_start\"\tTEXT NOT NULL," +
                "\r\n\t\"time_travel\"\tTEXT NOT NULL," +
                "\r\n\t\"date_start\"\tTEXT NOT NULL," +
                "\r\n\tPRIMARY KEY(\"id_travel\" AUTOINCREMENT)\r\n);", connection);
            initTable.CommandType = CommandType.Text;
            initTable.ExecuteNonQuery();
            closeConnection();
        }
        private void initRoutes()
        {
            openConnection();
            SqliteCommand initTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS \"Routes\" " +
                "(\r\n\t\"id_route\"\tINTEGER NOT NULL," +
                "\r\n\t\"dep_point\"\tINTEGER NOT NULL," +
                "\r\n\t\"arr_point\"\tINTEGER NOT NULL," +
                "\r\n\tFOREIGN KEY(\"arr_point\") REFERENCES \"cities\"(\"id_city\")," +
                "\r\n\tFOREIGN KEY(\"dep_point\") REFERENCES \"cities\"(\"id_city\")," +
                "\r\n\tPRIMARY KEY(\"id_route\" AUTOINCREMENT)\r\n);", connection);
            initTable.CommandType = CommandType.Text;
            initTable.ExecuteNonQuery();
            closeConnection();
        }
        private void initCities()
        {
            openConnection();
            SqliteCommand initTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS \"cities\" " +
                "(\r\n\t\"id_city\"\tINTEGER NOT NULL," +
                "\r\n\t\"name_city\"\tINTEGER NOT NULL," +
                "\r\n\tPRIMARY KEY(\"id_city\" AUTOINCREMENT)\r\n);", connection);
            initTable.CommandType = CommandType.Text;
            initTable.ExecuteNonQuery();
            closeConnection();
        }
        private void initUsers()
        {
            openConnection();
            SqliteCommand initTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS \"passengers\" " +
                "(\r\n\t\"id_p\"\tINTEGER NOT NULL," +
                "\r\n\t\"full_name_p\"\tTEXT NOT NULL," +
                "\r\n\t\"passport\"\tTEXT NOT NULL UNIQUE," +
                "\r\n\t\"benefit\"\tBOOLEAN NOT NULL DEFAULT FALSE," +
                "\r\n\tPRIMARY KEY(\"id_p\" AUTOINCREMENT)\r\n);", connection);
            initTable.CommandType = CommandType.Text;
            initTable.ExecuteNonQuery();
            closeConnection();
        }
        public int insertCity(string city)
        {
            SqliteCommand insertSQL = new SqliteCommand("INSERT INTO cities (name_city) VALUES (@param1)", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.Parameters.Add(new SqliteParameter("@param1", city));
            insertSQL.ExecuteNonQuery();
            return getLastRowId();
        }
        public void UpdateCity(int index, string updateValue)
        {
            SqliteCommand insertSQL = new SqliteCommand($"UPDATE cities SET name_city = \"{updateValue}\" WHERE id_city = {index}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
        }
        public void DeleteCity(int index)
        {
            SqliteCommand deleteSQL = new SqliteCommand($"DELETE FROM cities WHERE id_city = {index}", connection);
            deleteSQL.CommandType = CommandType.Text;
            deleteSQL.ExecuteNonQuery();
        }
        public int getLastRowId()
        {
            int index = 0;
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "SELECT id_city FROM cities WHERE ROWID = last_insert_rowid()";
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        index = reader.GetInt32(0);
                    }
                }
            }
            return index;
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
                            Passenger passenger = new Passenger(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetBoolean(3));
                            passengers.Add(passenger);
                        }
                    }
                }
            }
        }
        public List<BackUpRoutes> getRoutes()
        {
            openConnection();
            List<BackUpRoutes> list = new List<BackUpRoutes>();
            SqliteCommand selectSQL = new SqliteCommand("SELECT * FROM Routes", connection);
            selectSQL.CommandType = CommandType.Text;
            using(SqliteDataReader reader = selectSQL.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new BackUpRoutes(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
            }
            closeConnection();
            return list;
        }
        public List<ScheduleItem> schedule = new List<ScheduleItem>();
        public void getSchedule ()
        {
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT schedule.type_train, schedule.date_start, schedule.time_start, " +
                                            "dep_city.name_city AS dep_city_name, arr_city.name_city AS arr_city_name, schedule.time_travel, Routes.id_route, schedule.id_travel, schedule.id_train " +
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
                            schedule.Add(new ScheduleItem (reader.GetInt32(7),reader.GetInt32(8),reader.GetString(0), new Routes(reader.GetInt32(6),reader.GetString(3), reader.GetString(4)),reader.GetString(2), reader.GetString(1),reader.GetString(5)));
                        }
                    }
                }
            }
        }
        public List<City> getCities()
        {
            List<City> cities = new List<City>();
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
                            cities.Add(new City( reader.GetInt32(0),reader.GetString(1)));
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
                command.CommandText = "SELECT passengers.full_name_p, " + //0
                                        "passengers.passport, " + //1
                                        "passengers.benefit, " + //2
                                        "schedule.type_train, " + //3
                                            "dep_city.name_city AS dep_city_name, " + //4
                                            "arr_city.name_city AS arr_city_name, " + //5
                                            "schedule.time_start, " + //6
                                            "schedule.date_start, " + //7
                                            "schedule.time_travel, " + //8
                                            "tickets.car_number, " + //9
                                            "tickets.place_number," + //10
                                            " Routes.id_route, " + //11
                                            "schedule.id_travel, " + //12
                                            "tickets.id_ticket, " + //13
                                            "passengers.id_p, " + //14
                                            "schedule.id_train " + //15
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
                            Ticket ticket = new Ticket( reader.GetInt32(13),
                                new Passenger( reader.GetInt32(14), reader.GetString(0), reader.GetString(1), reader.GetBoolean(2) ),
                                new ScheduleItem( reader.GetInt32(12), reader.GetInt32(15),reader.GetString(3), new Routes(reader.GetInt32(11),reader.GetString(4),reader.GetString(5)),reader.GetString(6),reader.GetString(7), reader.GetString(8) )
                                ,reader.GetInt32(9),reader.GetInt32(10));
                            tickets.Add(ticket);
                        }
                    }
                }
            }
        }
    }
}
