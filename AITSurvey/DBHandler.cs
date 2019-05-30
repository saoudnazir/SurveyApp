using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITSurvey
{


    public class DBHandler
    {
        private static DatabaseTableAdapters.answersTableAdapter ata = new DatabaseTableAdapters.answersTableAdapter();
        private static Database.answersDataTable adt = new Database.answersDataTable();
        public static void InsertAnswer(int qID, string answer)
        {
            try
            {
                int count = ata.InsertAnswer(qID, answer);
                if (count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Row Added.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static void InsertAnswer(int qID, string answer, int sesID)
        {
            try
            {
                int count = ata.InsertAnswerBySesID(sesID, qID, answer);
                if (count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Row Added.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static void InsertAnswer(int qID, string answer, int sesID, int rID)
        {
            try
            {
                int count = ata.InsertAnswerBySesAndResID(sesID, rID, qID, answer);
                if (count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Row Added.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}