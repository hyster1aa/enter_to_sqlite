using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using enter_to_sqlite.BackUpClasses;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.Devices;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace enter_to_sqlite
{
    public class DataBase
    {
        SqliteConnection connection = new SqliteConnection("DataSource=myTodoList.db");
        public List<Passenger> passengers = new List<Passenger>();
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
            return getLastRowIdCity();
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
        public int getLastRowIdCity()
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
        public List<Route> getRoutes()
        {
            openConnection();
            List<Route> list = new List<Route>();
            SqliteCommand selectSQL = new SqliteCommand("SELECT Routes.id_route, dep_city.id_city, dep_city.name_city AS dep_city_name," +
                                            " arr_city.id_city, arr_city.name_city AS arr_city_name  " +
                                        "FROM Routes " +
                                            "LEFT JOIN cities AS dep_city ON Routes.dep_point = dep_city.id_city " +
                                            "LEFT JOIN cities AS arr_city ON Routes.arr_point = arr_city.id_city", connection);
            selectSQL.CommandType = CommandType.Text;
            using(SqliteDataReader reader = selectSQL.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Route(reader.GetInt32(0), new City(reader.GetInt32(1),reader.GetString(2)), new City(reader.GetInt32(3),reader.GetString(4))));
                    }
                }
            }
            closeConnection();
            return list;
        } 
        public List<ScheduleItem> getSchedule ()
        {
            List<ScheduleItem> schedule = new List<ScheduleItem>();
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT schedule.type_train, schedule.date_start, schedule.time_start, " +
                                            "dep_city.name_city AS dep_city_name, arr_city.name_city AS arr_city_name, schedule.time_travel, Routes.id_route, schedule.id_travel, schedule.id_train, dep_city.id_city, arr_city.id_city " +
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
                            schedule.Add(new ScheduleItem (reader.GetInt32(7),reader.GetInt32(8),reader.GetString(0), new Route(reader.GetInt32(6),new City(reader.GetInt32(9),reader.GetString(3)), new City(reader.GetInt32(10),reader.GetString(4))),reader.GetString(2), reader.GetString(1),reader.GetString(5)));
                        }
                    }
                }
            }
            return schedule;
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

        public List<Ticket> getTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
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
                                            "schedule.id_train, " + //15
                                            "dep_city.id_city, " + //16
                                            "arr_city.id_city " + //17
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
                                new ScheduleItem( reader.GetInt32(12), reader.GetInt32(15),reader.GetString(3), new Route(reader.GetInt32(11),new City(reader.GetInt32(16),reader.GetString(4)),new City(reader.GetInt32(17),reader.GetString(5))),reader.GetString(6),reader.GetString(7), reader.GetString(8) )
                                ,reader.GetInt32(9),reader.GetInt32(10));
                            tickets.Add(ticket);
                        }
                    }
                }
            }
            return tickets;
        }

        public void initTableCities(City city)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO cities VALUES ({city.Id}, \"{city.Name}\")", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }
        public void initTableUsers(Passenger passenger)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO passengers VALUES ({passenger.id_p}, \"{passenger.full_name}\", \"{passenger.passport}\", {passenger.benefit})", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }

        public void initTableRoutes(BackUpRoutes route)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO Routes VALUES ({route.id_route}, {route.dep_point}, {route.arr_point})", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }

        public void initTableSchedule(BackUpSchedule scheduleItem)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO schedule VALUES ({scheduleItem.id_travel}, {scheduleItem.id_train}, {scheduleItem.id_route}, \"{scheduleItem.type_train}\", \"{scheduleItem.timeStart}\", \"{scheduleItem.timeTravel}\", \"{scheduleItem.dateStart}\") ", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }

        public void initTableTicket(BackUpTickets ticket)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO tickets VALUES ({ticket.id_ticket}, {ticket.id_travel}, {ticket.id_p}, {ticket.car_number}, {ticket.place_number})", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }
        public int getLastRowIdRoute()
        {
            openConnection();
            int index = 0;
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "SELECT id_route FROM Routes WHERE ROWID = last_insert_rowid()";
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
            closeConnection();
            return index;
        }
        public int insertRoute(int depPoint, int arrPoint)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO Routes (dep_point, arr_point) VALUES ({depPoint}, {arrPoint})", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            return getLastRowIdRoute();
        }
        public void UpdateRoute(int depPoint, int arrPoint, int id_route)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"UPDATE Routes SET dep_point = {depPoint}, arr_point = {arrPoint} WHERE id_route = {id_route}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }

        public void DeleteRoute(int idRoute)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"DELETE FROM Routes WHERE id_route = {idRoute}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }

        public int insertScheduleItem(ScheduleItem scheduleitem)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO schedule (id_train, id_route, type_train, time_start, time_travel, date_start) VALUES ({scheduleitem.id_train}, {scheduleitem.routes.id_route}, \"{scheduleitem.typeTrain}\", \"{scheduleitem.timeStart}\", \"{scheduleitem.timeTravel}\", \"{scheduleitem.dateStart}\")", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            return getLastRowIdRoute();

        }
        public void updateScheduleItem(ScheduleItem scheduleitem)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"UPDATE schedule SET id_train={scheduleitem.id_train}, id_route={scheduleitem.routes.id_route}, type_train=\"{scheduleitem.typeTrain}\", time_start=\"{scheduleitem.timeStart}\", time_travel=\"{scheduleitem.timeTravel}\", date_start=\"{scheduleitem.dateStart}\" WHERE id_travel = {scheduleitem.id_travel}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }
        public void DeleteScheduleItem(int idTravel)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"DELETE FROM schedule WHERE id_travel = {idTravel}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            closeConnection();
        }
        public int getLastRowIdSchedule()
        {
            openConnection();
            int index = 0;
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "SELECT id_travel FROM schedule WHERE ROWID = last_insert_rowid()";
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
            closeConnection();
            return index;
        }

        public int insertPassenger(Passenger passenger)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO passengers (full_name_p, passport, benefit) VALUES (\"{passenger.full_name}\", \"{passenger.passport}\", {passenger.benefit} )", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            return getLastRowIdPassenger();
        }
        public void updatePassenger(Passenger passenger)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"UPDATE passengers SET full_name_p=\"{passenger.full_name}\", passport=\"{passenger.passport}\", benefit={passenger.benefit} WHERE id_p = {passenger.id_p}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
        }
        public void deletePassenger(int  id_passenger)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"DELETE FROM passengers WHERE id_p= {id_passenger}", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
        }
        public int getLastRowIdPassenger()
        {
            openConnection();
            int index = 0;
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "SELECT id_p FROM passengers WHERE ROWID = last_insert_rowid()";
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
            closeConnection();
            return index;
        }
        public int getLastRowIdTicket()
        {
            openConnection();
            int index = 0;
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "SELECT id_ticket FROM tickets WHERE ROWID = last_insert_rowid()";
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
            closeConnection();
            return index;
        }
        public int insertTicket(Ticket ticket)
        {
            openConnection();
            SqliteCommand insertSQL = new SqliteCommand($"INSERT INTO tickets (id_travel, id_p, car_number, place_number) VALUES ({ticket.travelInformation.id_travel}, {ticket.passenger.id_p}, {ticket.trainCarNumber}, {ticket.trainCarPlaceNumber} )", connection);
            insertSQL.CommandType = CommandType.Text;
            insertSQL.ExecuteNonQuery();
            return getLastRowIdTicket();
        }
        public void updateTicket(Ticket ticket)
        {
            openConnection();
            SqliteCommand updateSQL = new SqliteCommand($"UPDATE tickets SET id_travel={ticket.travelInformation.id_travel}, id_p={ticket.passenger.id_p}, car_number={ticket.trainCarNumber}, place_number={ticket.trainCarPlaceNumber} WHERE id_ticket={ticket.id_ticket}", connection);
            updateSQL.CommandType = CommandType.Text;
            updateSQL.ExecuteNonQuery();
        }
        public void deleteTicket(int ticket)
        {
            openConnection();
            SqliteCommand updateSQL = new SqliteCommand($"DELETE FROM tickets WHERE id_ticket={ticket}", connection);
            updateSQL.CommandType = CommandType.Text;
            updateSQL.ExecuteNonQuery();
        }
    }
}
