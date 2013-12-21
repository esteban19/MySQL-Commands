using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestDatabase
{
    class CmndCentral
    {
        public void RunCommands()
        {
            Console.WriteLine("Running .Net v{0}", System.Environment.Version);
            string myConnection = "datasource=localhost;port=3306;username=root;password=brekiarnz$1";
            try
            {
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                Console.WriteLine(Commands.createDB(myConn));
                Console.WriteLine(Commands.createDBBackUp(myConn));
                Console.WriteLine(Commands.createTablePerson(myConn));
                Console.WriteLine(Commands.createTablePersonBackUp(myConn));
                Console.WriteLine(Commands.createTablePersonBackUpDB(myConn));
                Console.WriteLine(Commands.createTableOrder(myConn));
                /* Manipulation Alter Table */
                Console.WriteLine(Commands.alterTablePersonA(myConn));
                Console.WriteLine(Commands.alterTablePersonD(myConn));
                /* Manipulation - Index */
                Console.WriteLine(Commands.createSimpleIndex(myConn));
                Console.WriteLine(Commands.createUniqueIndex(myConn));
                Console.WriteLine(Commands.dropIndexes(myConn));
                /* Manipulation - Data */
                Console.WriteLine(Commands.InsertIntoPerson(myConn));
                Console.WriteLine(Commands.InsertIntoOrder(myConn));
                Console.WriteLine(Commands.InsertIntoColumns(myConn));
                Console.WriteLine(Commands.UpdateTable(myConn));
                /* Select statements */
                Console.WriteLine(Commands.SelectStatement(myConn));
                Console.WriteLine(Commands.SelectAllStatement(myConn));
                Console.WriteLine(Commands.SelectDistinctStatement(myConn));
                Console.WriteLine(Commands.SelectStatement1(myConn));
                Console.WriteLine(Commands.SelectStatement2(myConn));
                Console.WriteLine(Commands.SelectStatement3(myConn));
                Console.WriteLine(Commands.SelectStatement4(myConn));
                Console.WriteLine(Commands.SelectStatement5(myConn));
                Console.WriteLine(Commands.SelectStatement6(myConn));
                /* Select statements con't */
                Console.WriteLine(Commands.SelectInStatement(myConn));
                Console.WriteLine(Commands.SelectOrderBy(myConn));
                Console.WriteLine(Commands.SelectOrderByD(myConn));
                Console.WriteLine(Commands.SelectOrderByA(myConn));
                Console.WriteLine(Commands.SelectGroupBy(myConn));
                Console.WriteLine(Commands.SelectGroupByHaving(myConn));
                /* Alias */
                Console.WriteLine(Commands.SelectAliasColumn(myConn));
                Console.WriteLine(Commands.SelectAliasTable(myConn));
                /* Join */
                Console.WriteLine(Commands.InnerJoin(myConn));
                Console.WriteLine(Commands.LeftJoin(myConn));
                Console.WriteLine(Commands.RightJoin(myConn));
                /* Union */
                Console.WriteLine(Commands.Union(myConn));
                Console.WriteLine(Commands.UnionAll(myConn));
                /* Select Into */
                Console.WriteLine(Commands.SelectIntoTable(myConn));
                Console.WriteLine(Commands.SelectIntoDatabase(myConn));
                /* Create View */
                Console.WriteLine(Commands.CreateView(myConn));
                ///* Data Deletion */
                Console.WriteLine(Commands.dropView(myConn));
                Console.WriteLine(Commands.DeleteFromTable(myConn));
                Console.WriteLine(Commands.TruncateTable(myConn));
                Console.WriteLine(Commands.dropTablePerson(myConn));
                Console.WriteLine(Commands.dropTablePersonBackUp(myConn));
                Console.WriteLine(Commands.dropTablePersonBackUpDB(myConn));
                Console.WriteLine(Commands.dropTableOrder(myConn));
                Console.WriteLine(Commands.dropDB(myConn));
                Console.WriteLine(Commands.dropDBBackUp(myConn));
                myConn.Close();
            }
            catch (Exception ex)
            { Console.WriteLine("In Main().\n" + ex.Message); }
        }
    }
}
