﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AITSurvey.Modal;

namespace AITSurvey
{


    public class DBHandler
    {
        //Answers Table Objects
        private static DatabaseTableAdapters.answersTableAdapter ata = new DatabaseTableAdapters.answersTableAdapter();
        private static Database.answersDataTable adt = new Database.answersDataTable();

        //Sessions Table Objects
        private static DatabaseTableAdapters.sessionsTableAdapter sta = new DatabaseTableAdapters.sessionsTableAdapter();
        private static Database.sessionsDataTable sdt = new Database.sessionsDataTable();

        //Respondent Table Objects
        private static DatabaseTableAdapters.respondentsTableAdapter rta = new DatabaseTableAdapters.respondentsTableAdapter();
        private static Database.respondentsDataTable rdt = new Database.respondentsDataTable();

        //Staff Table Objects
        private static DatabaseTableAdapters.staffTableAdapter staffAdpt = new DatabaseTableAdapters.staffTableAdapter();
   

        public static void InsertAnswer(int qID, string answer, int sesID, int rID)
        {
            try
            {
                int count = ata.InsertAnswerBySesAndResID(sesID, rID, qID, answer);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static int StartSession(int userId, string date, string ipAddress)
        {
            int sesID = 0;
            try
            {
                sta.InsertSession(ipAddress, userId, date);
                var results = sta.GetSessionTB(ipAddress, userId, date);
                foreach (DataRow r in results.Rows)
                {
                    sesID = (int)r["ses_id"];
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return sesID;
        }

        public static int InsertRespondent(string username, string password, string firstname, string lastname, string gender, string state, string suburb, int postcode, string dob, string email)
        {
            int results = 0;
            try
            {
                results = rta.Register(username, password, firstname, lastname, gender, state, suburb, postcode, dob, email);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }

        public static List<Search> search(string word)
        {
            List<Search> results = new List<Search>();
            try
            {
                var output = ata.SearchByWord(word);
                if(output!= null)
                {
                    foreach(DataRow r in output)
                    {
                        Search s = new Search();
                        s.answer = r["answer"].ToString();
                        s.rID = (int)r["r_id"];
                        s.firstname = r["r_first_name"].ToString();
                        s.lastname = r["r_last_name"].ToString();
                        results.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }

        public static int LoginUser(string username,string password)
        {
            int id=0;
            try
            {
                int count = rta.Login(rdt, username, password);
                if (count == 1)
                {
                    foreach (DataRow r in rdt.Rows)
                    {
                        id = int.Parse(r["r_id"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return id;
        }

        public static int LoginStaff(string username,string password)
        {
            int id = 0;
            try
            {
                var output = staffAdpt.Login(username, password);
                if (output != null)
                {
                    foreach (DataRow r in output)
                    {
                        id = int.Parse(r["s_id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return id;
        }
    }
}