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
        public static string SelectAllStatement(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT ID,last,first,COALESCE(age,0) FROM testdb.person";
                command1.CommandType = System.Data.CommandType.Text;
                command1.Connection = myConn;

                string result = null;
                using (reader = command1.ExecuteReader())
                {
                    do
                    {
                        while (reader.Read())
                        {
                            result += reader.GetInt32(0) + "\t";
                            result += reader.GetString(1) + "\t";
                            result += reader.GetString(2) + "\t";
                            result += reader.GetInt32(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select all statement results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectAllStatement function.\n" + ex.Message; }
        }

        public static string SelectStatement(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT last, first FROM testdb.person";
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
                return "Select statement results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement function.\n" + ex.Message; }
        }

        public static string SelectDistinctStatement(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT DISTINCT last FROM testdb.person";
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
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select distinct statement results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectDistinctStatement function.\n" + ex.Message; }
        }

        public static string SelectStatement1(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE last='Jones' AND first='Mike'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 1 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement1 function.\n" + ex.Message; }
        }

        public static string SelectStatement2(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE first='Melissa' OR last='Jones'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 2 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement2 function.\n" + ex.Message; }
        }

        public static string SelectStatement3(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE (first='Melissa' OR first='Sarah') AND last='Jones'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 3 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement3 function.\n" + ex.Message; }
        }

        public static string SelectStatement4(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE first LIKE 'M%'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 4 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement4 function.\n" + ex.Message; }
        }

        public static string SelectStatement5(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE first LIKE '%a'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 5 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement5 function.\n" + ex.Message; }
        }

        public static string SelectStatement6(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE first LIKE '%a%'";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select statement 6 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectStatement6 function.\n" + ex.Message; }
        }

        public static string SelectInStatement(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person WHERE last IN ('Jones','Parkerson')";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select in statement results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectInStatement function.\n" + ex.Message; }
        }

        public static string SelectOrderBy(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person ORDER BY last, first";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Order By results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectOrderBy function.\n" + ex.Message; }
        }

        public static string SelectOrderByD(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person ORDER BY ID DESC";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Order By Desc results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectOrderByD function.\n" + ex.Message; }
        }

        public static string SelectOrderByA(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT * FROM testdb.person ORDER BY last ASC, age DESC";
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
                            result += reader.GetString(2) + "\t";
                            result += reader.GetString(3) + "\t";
                            result += "\n";
                        }
                        result += "--next command--";
                    } while (reader.NextResult());
                }
                return "Select Order By Asc results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectOrderByA function.\n" + ex.Message; }
        }

        public static string SelectGroupBy(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT last, AVG(age) FROM testdb.person GROUP BY last";
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
                return "Select Group By results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectGroupBy function.\n" + ex.Message; }
        }

        public static string SelectGroupByHaving(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;    /* AVG(age) calulated with all values */           /* Picks Jones' group*/
                command1.CommandText = "SELECT last, AVG(age) FROM testdb.person GROUP BY last HAVING MIN(age)<24";
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
                return "Select Having results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectGroupByHaving function.\n" + ex.Message; }
        }

        public static string SelectAliasColumn(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader; /* Changes column title to alias*/
                command1.CommandText = "SELECT last AS l, first AS f, age AS a FROM testdb.person WHERE last='Jones' AND first='Melissa' AND age > 20";
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
                return "Select Alias 1 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectAlias1 function.\n" + ex.Message; }
        }

        public static string SelectAliasTable(MySqlConnection myConn)
        {
            try
            {
                MySqlCommand command1 = new MySqlCommand();
                MySqlDataReader reader;
                command1.CommandText = "SELECT p.last, p.first, p.age FROM testdb.person AS p WHERE p.last='Jones' and p.age > 20";
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
                return "Select Alias 2 results:\n" + result;
            }
            catch (Exception ex)
            { return "In SelectAlias2 function.\n" + ex.Message; }
        }
    }
}
