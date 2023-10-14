using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace DailyChessPuzzle
{
    internal class SQL
    {
        private static SqlConnection connect = new SqlConnection(ConnVal());
        public SQL()
        {
            Score = 0;
            LastPlayed = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        public static string ConnVal()
        {
            return ConfigurationManager.ConnectionStrings["Application"].ConnectionString;
        }

        public static bool UsernameExists(string username)
        {
            string query = @"SELECT * FROM Scores WHERE UserName = @UserName";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    connect.Close();
                    return true;
                }
                else
                {
                    connect.Close();
                    return false;
                }
            }
        }

        public static void NewUser()
        {
            string query = @"INSERT INTO Scores (UserName, HouseTeam, Score, LastPlayed, Difficulty) VALUES (@UserName, @HouseTeam, @Score, @LastPlayed, @Difficulty)";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@HouseTeam", HouseTeam);
                cmd.Parameters.AddWithValue("@Score", Score);
                cmd.Parameters.AddWithValue("@LastPlayed", LastPlayed);
                cmd.Parameters.AddWithValue("@Difficulty", Difficulty);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static bool AlreadyPlayed()
        {
            string query = $"SELECT LastPlayed FROM Scores WHERE UserName='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    string lastPlayed = (string)cmd.ExecuteScalar();
                    if (lastPlayed == LastPlayed)
                    {
                        connect.Close();
                        return true;
                    }
                    else
                    {
                        UpdateLastPlayedSetting();
                        connect.Close();
                        return false;
                    }
                }
                else
                {
                    UpdateLastPlayedSetting();
                    connect.Close();
                    return false;
                }
            }
        }

        public static void UpdateLastPlayedSetting()
        {
            string query = $"UPDATE Scores SET LastPlayed={LastPlayed} WHERE UserName='{UserName}'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateDifficultySetting()
        {
            string query = $"UPDATE Scores SET Difficulty={Difficulty} WHERE UserName='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static void UpdateScoreSetting()
        {
            string query = $"UPDATE Scores SET Score={Score} WHERE UserName='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static string UserName { get; set; }
        public static string HouseTeam { get; set; }
        public static int Score { get; set; }
        public static string LastPlayed { get; set; }
        public static int Difficulty { get; set; }
    }
}
