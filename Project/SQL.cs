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
            // Gets Connection String from App.config
            return ConfigurationManager.ConnectionStrings["Application"].ConnectionString;
        }

        public static bool UsernameExists(string username)
        {
            string query = @"SELECT * FROM IndividualScores WHERE UserName = @UserName";
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
            string query = @"INSERT INTO IndividualScores (UserName, HouseTeam, Score, LastPlayed, Difficulty) VALUES (@UserName, @HouseTeam, @Score, @LastPlayed, @Difficulty)";
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

        public static void GetCurrentScore()
        {
            string query = $"SELECT Score FROM IndividualScores WHERE Username='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    Score = (int)cmd.ExecuteScalar();
                }
                connect.Close();
            }
        }

        public static bool AlreadyPlayed()
        {
            string query = $"SELECT LastPlayed FROM IndividualScores WHERE UserName='{UserName}'";
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
            string query = $"UPDATE IndividualScores SET LastPlayed='{LastPlayed}' WHERE UserName='{UserName}'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateDifficultySetting()
        {
            string query = $"UPDATE IndividualScores SET Difficulty={Difficulty} WHERE UserName='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static void UpdateScoreSetting()
        {
            string query = $"UPDATE IndividualScores SET Score={Score} WHERE UserName='{UserName}'";
            connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public static void GetTeamScores()
        {
            string query;
            connect.Open();

            // Kepler
            query = @"SELECT Score FROM TeamScores WHERE TeamName='Kepler'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    int KeplerScore = (int)cmd.ExecuteScalar();
                    Puzzle.teamScores[0] = KeplerScore;
                }
            }

            // Newton
            query = @"SELECT Score FROM TeamScores WHERE TeamName='Newton'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    int NewtonScore = (int)cmd.ExecuteScalar();
                    Puzzle.teamScores[1] = NewtonScore;
                }
            }

            // Kelvin
            query = @"SELECT Score FROM TeamScores WHERE TeamName='Kelvin'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    int KelvinScore = (int)cmd.ExecuteScalar();
                    Puzzle.teamScores[2] = KelvinScore;
                }
            }

            // Faraday
            query = @"SELECT Score FROM TeamScores WHERE TeamName='Faraday'";
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (cmd.ExecuteScalar() != null)
                {
                    int FaradayScore = (int)cmd.ExecuteScalar();
                    Puzzle.teamScores[3] = FaradayScore;
                }
            }
            connect.Close();
        }

        public static void UpdateTeamScores()
        {
            int teamScore = 0;
            if (HouseTeam == "Kepler") teamScore = Puzzle.teamScores[0] + Puzzle.score;
            if (HouseTeam == "Newton") teamScore = Puzzle.teamScores[1] + Puzzle.score;
            if (HouseTeam == "Kelvin") teamScore = Puzzle.teamScores[2] + Puzzle.score;
            if (HouseTeam == "Faraday") teamScore = Puzzle.teamScores[3] + Puzzle.score;

            string query = $"UPDATE TeamScores SET Score={teamScore} WHERE TeamName='{HouseTeam}'";
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
