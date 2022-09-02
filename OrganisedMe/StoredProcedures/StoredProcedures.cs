using OrganisedMe.Models;
using System.Data;
using System.Data.SqlClient;

namespace OrganisedMe.StoredProcedures
{
    public static class StoredProcedures
    {

        public static string SqlconString = "Data Source=DESKTOP-J6APBTK;Initial Catalog=Budget;Integrated Security=True";
        public static bool AddTransaction(Transaction transaction)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("dbo.InsertTransaction", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Type", transaction.Type);
                    sql_cmnd.Parameters.AddWithValue("@Amount", transaction.Amount);
                    sql_cmnd.Parameters.AddWithValue("@CostCode", transaction.CostCode);
                    sql_cmnd.Parameters.AddWithValue("@Account", transaction.Account);
                    sql_cmnd.Parameters.AddWithValue("@Date", transaction.Date);
                    sql_cmnd.Parameters.AddWithValue("@Narrative", transaction.Narrative);
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();

                    return true;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteTransaction(int Id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("dbo.DeleteTransaction", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Id", Id);
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Transaction> GetTransactions()
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("dbo.GetTransactions", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    var dataReader = sql_cmnd.ExecuteReader();
                    //sqlCon.Close();

                    List<Transaction> transactions = new List<Transaction>();
                    while(dataReader.Read())
                    {
                        Transaction t = new Transaction();
                        foreach (var prop in t.GetType().GetProperties())
                        {
                            var propType = prop.PropertyType;
                            prop.SetValue(t, Convert.ChangeType(dataReader[prop.Name].ToString(), propType));
                        }
                        transactions.Add(t);
                    }

                    return transactions;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
