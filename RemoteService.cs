using Gymate7.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Gymate7.Services
{
   public class RemoteService
    {
        public List<ExerciseRecord> GetSqlServerExerceriseData()
        {
            List<ExerciseRecord> exerciseList = new List<ExerciseRecord>();
            try
            {
                using (var connection = new SqlConnection(Constants.RemoteConnection))
                {

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Select * from ExerciseRecord";
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ExerciseRecord tbl = new ExerciseRecord();

                            tbl.PhoneNumber = reader["PhoneNumber"] as string;
                            tbl.LatPullDown =reader["LatPullDown"] as string;
                            tbl.BarbellRow = reader["BarbellRow"] as string;
                            tbl.BenchPress = reader["BenchPress"] as string;
                            tbl.CalfRaise = reader["CalfRaise"] as string;
                            tbl.FrontRaise = reader["FrontRaise"] as string;
                            tbl.InlcineBenchPress = reader["InlcineBenchPress"] as string;
                            tbl.LatRopePullDown = reader["LatRopePullDown"] as string;
                            tbl.LegPress = reader["LegPress"] as string;
                            tbl.OverHeadShoulderPress = reader["OverHeadShoulderPress"] as string;
                            tbl.PhoneNumber = reader["PhoneNumber"] as string;
                            tbl.RecordDate = Convert.IsDBNull(reader["RecordDate"]) ? null : (DateTime?)reader["RecordDate"];
                            tbl.Squat = reader["Squat"] as string;
                            tbl.SideLateralRaise = reader["SideLateralRaise"] as string;

                            exerciseList.Add(tbl);
                        }
                    }

                }


            }
            catch (SqlException ex)
            {
                
              App.Current.MainPage.DisplayAlert("Error Occurred", ex.StackTrace.ToString(), "Ok");

            }
            catch (InvalidOperationException ex)
            {
                App.Current.MainPage.DisplayAlert("Error Occurred", ex.StackTrace.ToString(), "Ok");

            }
            finally
            {
                // conne.Close();
            }
            return exerciseList;
        }

        public bool InsertRecord(ExerciseRecord er)
        {
            try
            {
              
                using (var connection = new SqlConnection(Constants.RemoteConnection))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = "insert into ExerciseRecord(PhoneNumber,OverHeadShoulderPress,SideLateralRaise,FrontRaise,BenchPress,InlcineBenchPress,LatPullDown,BarbellRow,LatRopePullDown,Squat,LegPress,CalfRaise,RecordDate) values (@PhoneNumber,@OverHeadShoulderPress,@SideLateralRaise,@FrontRaise,@BenchPress,@InlcineBenchPress,@LatPullDown,@BarbellRow,@LatRopePullDown,@Squat,@LegPress,@CalfRaise,@RecordDate)";

                    command.Parameters.AddWithValue("@PhoneNumber", er.PhoneNumber);
                    command.Parameters.AddWithValue("@OverHeadShoulderPress", er.OverHeadShoulderPress);
                    command.Parameters.AddWithValue("@SideLateralRaise", er.SideLateralRaise);
                    command.Parameters.AddWithValue("@FrontRaise", er.FrontRaise);
                    command.Parameters.AddWithValue("@BenchPress", er.BenchPress);
                    command.Parameters.AddWithValue("@InlcineBenchPress", er.InlcineBenchPress);
                    command.Parameters.AddWithValue("@LatPullDown", er.LatPullDown);
                    
                    command.Parameters.AddWithValue("@BarbellRow", er.BarbellRow);
                    command.Parameters.AddWithValue("@LatRopePullDown", er.LatRopePullDown);
                    command.Parameters.AddWithValue("@Squat", er.Squat);
                    command.Parameters.AddWithValue("@LegPress", er.LegPress);
                    command.Parameters.AddWithValue("@CalfRaise", er.CalfRaise);
                    command.Parameters.AddWithValue("@RecordDate", er.RecordDate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { 
            }
            
            return true;
        }
       
    }
}
