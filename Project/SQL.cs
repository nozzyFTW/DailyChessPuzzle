using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace DailyChessPuzzle
{
    internal class SQL
    {
        private SqlConnection conn = new SqlConnection(ConnVal());
        public SQL()
        {
            UserName = Environment.UserName;

            conn.Open();
            MessageBox.Show("Connection Open!");
            conn.Close();
        }

        public static string ConnVal()
        {
            return ConfigurationManager.ConnectionStrings["Application"].ConnectionString;
        }

        public static bool UsernameExists(string username)
        {
            string sql = @"SELECT * FROM Scores WHERE UserName = @UserName";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows) return true;
                else return false;
            }
        }

        public static string UserName { get; set; }
        public static string HouseTeam { get; set; }
        public static int Score { get; set; }
        public static DateTime LastPlayed { get; set; }
        public static int Difficulty { get; set; }
    }
}
