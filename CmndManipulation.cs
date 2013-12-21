using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestDatabase
{
    public static partial class Commands
    {
        public static string InsertIntoPerson(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("INSERT INTO testdb.person VALUES (101, 'Jones', 'Mike', 20), (103, 'Jones', 'Melissa', 25);", myConn);
                command1.ExecuteNonQuery();
                return "Successfully inserted persons into Person Table;";
            }
            catch (Exception ex)
            { return "In InsertIntoPerson function.\n" + ex.Message; }
        }

        public static string InsertIntoOrder(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("INSERT INTO testdb.order VALUES (1, 'Jones', 'Melissa', 103), (2, 'Parkerson', 'Sarah', 102), (3, 'Parkerson', 'Sarah', 102), (4, 'Smith', 'Regan', 111)", myConn);
                command1.ExecuteNonQuery();
                return "Successfully inserted orders into Order Table;";
            }
            catch (Exception ex)
            { return "In InsertIntoOrder function.\n" + ex.Message; }
        }

        public static string InsertIntoColumns(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("INSERT INTO testdb.person (id, last, first) VALUES (102, 'Parker', 'Sarah');", myConn);
                command1.ExecuteNonQuery();
                return "Successfully inserted 1 partial Person into person Table;";
            }
            catch (Exception ex)
            { return "In InsertIntoColumns function.\n" + ex.Message; }
        }

        public static string UpdateTable(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("UPDATE testdb.person SET age=35, last='Parkerson' WHERE id=102;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully updated person Table;";
            }
            catch (Exception ex)
            { return "In UpdateTable function.\n" + ex.Message; }
        }

        public static string DeleteFromTable(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DELETE FROM testdb.person WHERE last='Parkerson';", myConn);
                command1.ExecuteNonQuery();
                return "Successfully deleted from person Table;";
            }
            catch (Exception ex)
            { return "In DeleteFromTable function.\n" + ex.Message; }
        }

        public static string TruncateTable(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("TRUNCATE TABLE testdb.person;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully truncated table;";
            }
            catch (Exception ex)
            { return "In TruncateTable function.\n" + ex.Message; }
        }

        public static string dropIndexes(MySqlConnection myConn)
        {
            try
            {
                var command = myConn.CreateCommand();
                command.CommandText = "ALTER TABLE testdb.Person DROP INDEX Sindex; ALTER TABLE testdb.Person DROP INDEX Uindex";
                using (var reader = command.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32(0));
                        }
                        Console.WriteLine("--next command--");
                    } while (reader.NextResult());
                }
                return "Successfully dropped Sindex and Uindex;\n";
            }
            catch (Exception ex)
            { return "In dropIndexes function.\n" + ex.Message; }
        }

        public static string dropView(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                command1.CommandText = "use testdb; drop view view1";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;
                using (var reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32(0));
                        }
                        Console.WriteLine("--next command--");
                    } while (reader.NextResult());
                }
                return "Successfully dropped view;";
            }
            catch (Exception ex)
            { return "In DropView Function.\n" + ex.Message; }
        }

        public static string createSimpleIndex(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE INDEX Sindex ON testdb.Person (last);", myConn);
                command1.ExecuteNonQuery();
                return "Successfully created simple index on 'last' column;";
            }
            catch (Exception ex)
            { return "In createSimpleIndex function.\n" + ex.Message; }
        }

        public static string createUniqueIndex(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE UNIQUE INDEX Uindex ON testdb.Person (last, first);", myConn);
                command1.ExecuteNonQuery();
                return "Successfully created unique index on 'last','first' columns;";
            }
            catch (Exception ex)
            { return "In createUniqueIndex function.\n" + ex.Message; }
        }

        public static string dropTablePerson(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP TABLE testdb.Person;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped Person table from database;";
            }
            catch (Exception ex)
            { return "In dropTablePerson function.\n" + ex.Message; }
        }

        public static string dropTablePersonBackUp(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP TABLE testdb.person_backup;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped person_backup table from database;";
            }
            catch (Exception ex)
            { return "In dropTablePersonBackUp function.\n" + ex.Message; }
        }

        public static string dropTablePersonBackUpDB(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP TABLE testdb_backup.person_backup;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped testdb_backup.person_backup table from database;";
            }
            catch (Exception ex)
            { return "In dropTablePersonBackUpDB function.\n" + ex.Message; }
        }

        public static string dropTableOrder(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP TABLE testdb.Order;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped Order table from database;";
            }
            catch (Exception ex)
            { return "In dropTableOrder function.\n" + ex.Message; }
        }

        public static string createTablePerson(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE TABLE testdb.Person (ID int NOT NULL, last varchar(40), first varchar(40), age int, PRIMARY KEY(id));", myConn);
                command1.ExecuteNonQuery();
                return "Successfully added Person table to database;";
            }
            catch (Exception ex)
            { return "In createTablePerson function.\n" + ex.Message; }
        }

        public static string createTableOrder(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE TABLE testdb.Order (OID int NOT NULL, last varchar(40), first varchar(40), ID int, PRIMARY KEY(OID));", myConn);
                command1.ExecuteNonQuery();
                return "Successfully added Order table to database;";
            }
            catch (Exception ex)
            { return "In orderTablePerson function.\n" + ex.Message; }
        }

        public static string createTablePersonBackUp(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE TABLE testdb.person_backup (ID int NOT NULL, last varchar(40), first varchar(40), age int, PRIMARY KEY(id));", myConn);
                command1.ExecuteNonQuery();
                return "Successfully added person_backup table to database;";
            }
            catch (Exception ex)
            { return "In createTablePersonBackUp function.\n" + ex.Message; }
        }

        public static string createTablePersonBackUpDB(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE TABLE testdb_backup.person_backup (ID int NOT NULL, last varchar(40), first varchar(40), age int, PRIMARY KEY(id));", myConn);
                command1.ExecuteNonQuery();
                return "Successfully added tabledb_backup.person_backup table to database;";
            }
            catch (Exception ex)
            { return "In createTablePersonBackUpDB function.\n" + ex.Message; }
        }

        public static string alterTablePersonA(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("ALTER TABLE testdb.Person ADD (sex char(1));", myConn);
                command1.ExecuteNonQuery();
                return "Successfully added Sex column to Person table;";
            }
            catch (Exception ex)
            { return "In alterTablePersonA function.\n" + ex.Message; }
        }

        public static string alterTablePersonD(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("ALTER TABLE testdb.Person DROP sex;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped Sex column from Person table;";
            }
            catch (Exception ex)
            { return "In alterTablePersonD function.\n" + ex.Message; }
        }

        public static string dropDB(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP DATABASE testdb;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped testdb database;";
            }
            catch (Exception ex)
            { return "In dropDB function.\n" + ex.Message; }
        }

        public static string dropDBBackUp(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("DROP DATABASE testdb_backup;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully dropped testdb_backup database;";
            }
            catch (Exception ex)
            { return "In dropDBBackUp function.\n" + ex.Message; }
        }

        public static string createDB(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE DATABASE testdb;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully created testdb database;";
            }
            catch (Exception ex)
            { return "In createDB function.\n" + ex.Message; }
        }

        public static string createDBBackUp(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand("CREATE DATABASE testdb_backup;", myConn);
                command1.ExecuteNonQuery();
                return "Successfully created testdb_backup database;";
            }
            catch (Exception ex)
            { return "In createDBBackUp function.\n" + ex.Message; }
        }
    }
}
