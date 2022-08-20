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

        public static List<Transaction> GetTransactions(int Id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("dbo.InsertTransaction", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Id", Id);
                    DataTable st = (DataTable)sql_cmnd.ExecuteScalar();
                    sqlCon.Close();

                    List<Transaction> transactions
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
