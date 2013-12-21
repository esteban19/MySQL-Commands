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
        public static string Union(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT person.last, person.first FROM testdb.person UNION SELECT order.last, order.first FROM testdb.order";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetString(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Union results:\n" + result;
            }
            catch (Exception ex)
            { return "In Union function.\n" + ex.Message; }
        }

        public static string InnerJoin(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT person.last, person.first, OID FROM testdb.person INNER JOIN testdb.order ON person.ID=order.ID";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetString(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += reader.GetInt32(2) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Inner Join results:\n" + result;
            }
            catch (Exception ex)
            { return "In InnerJoin function.\n" + ex.Message; }
        }

        public static string LeftJoin(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT person.last, person.first, IFNULL(order.OID,0) FROM testdb.person LEFT JOIN testdb.order ON person.ID=order.ID";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetString(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += reader.GetInt32(2) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Left Join results:\n" + result;
            }
            catch (Exception ex)
            { return "In LeftJoin function.\n" + ex.Message; }
        }

        public static string RightJoin(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT IFNULL(person.last, 'null'), IFNULL(person.first, 'null'), order.OID FROM testdb.person RIGHT JOIN testdb.order ON person.ID=order.ID";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetString(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += reader.GetInt32(2) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Right Join results:\n" + result;
            }
            catch (Exception ex)
            { return "In RightJoin function.\n" + ex.Message; }
        }

        public static string UnionAll(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT person.last, person.first FROM testdb.person UNION ALL SELECT order.last, order.first FROM testdb.order";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetString(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Union ALL results:\n" + result;
            }
            catch (Exception ex)
            { return "In UnionAll function.\n" + ex.Message; }
        }

        public static string SelectIntoTable(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                command1.CommandText = "INSERT INTO testdb.person_backup (ID, last, first, age) SELECT * FROM testdb.person";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;
                command1.ExecuteNonQuery();
                return "Successfully inserted person table into backup table;";
            }
            catch (Exception ex)
            { return "In SelectIntoTable Function.\n" + ex.Message; }
        }

        public static string SelectIntoDatabase(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                command1.CommandText = "INSERT INTO testdb_backup.person_backup (ID, last, first, age) SELECT * FROM testdb.person";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;
                command1.ExecuteNonQuery();
                return "Successfully inserted person table into backup database's table;";
            }
            catch (Exception ex)
            { return "In SelectIntoDatabase Function.\n" + ex.Message; }
        }

        public static string CreateView(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                command1.CommandText = "use testdb; CREATE VIEW view1 AS SELECT person.ID, person.last, person.first, person.age, order.OID FROM testdb.person INNER JOIN testdb.order ON person.ID=order.ID";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;
                //command1.ExecuteNonQuery();
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
                return "Successfully created view;";
            }
            catch (Exception ex)
            { return "In CreateView Function.\n" + ex.Message; }
        }
    }
}
