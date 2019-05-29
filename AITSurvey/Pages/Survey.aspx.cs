using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITSurvey.DatabaseTableAdapters;

namespace AITSurvey.Pages
{
    public partial class Survey : System.Web.UI.Page
    {
        private questionsTableAdapter qta = new questionsTableAdapter();
        private Database.questionsDataTable qtd = new Database.questionsDataTable();

        private optionsTableAdapter ota = new optionsTableAdapter();
        private Database.optionsDataTable otd = new Database.optionsDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {        
            int questionID ;
            if (Session["nextQID"] != null)
            {
                questionID = int.Parse(Session["nextQID"].ToString());
            }
            else
            {
                questionID = 4;
            }


            if (!IsPostBack)
            {
                string qType = "";
                try
                {
                    int qCount = qta.GetQuestionByQID(qtd, questionID);
                    int oCount = ota.GetOptionsByQID(otd, questionID);

                    if (qCount == 1)
                    {
                        foreach (DataRow r in qtd.Rows)
                        {
                            Session["currentQID"] = r["q_ID"].ToString();
                            statementTxt.Text = r["q_statement"].ToString();
                            qType = r["q_type"].ToString();
                            Session["nextQID"] = r["q_next_ID"].ToString();
                        }
                    }

                    if (oCount > 0)
                    {
                        if (qType.Equals("text"))
                        {
                            TextBox textInput = new TextBox();
                            textInput.ID = "answer";
                            textInput.Attributes.Add("placeholder", "Enter your answer");
                            choiceHolder.Controls.Add(textInput);
                        }
                        else if (qType.Equals("checkbox"))
                        {
                            CheckBoxList checkInput = new CheckBoxList();
                            checkInput.ID = "answer";
                            foreach (DataRow r in otd.Rows)
                            {
                                checkInput.Items.Add(r["option"].ToString());
                            }
                            choiceHolder.Controls.Add(checkInput);
                        }
                        else if (qType.Equals("radio"))
                        {
                            RadioButtonList radioInput = new RadioButtonList();
                            radioInput.ID = "answer";
                            foreach (DataRow r in otd.Rows)
                            {
                                radioInput.Items.Add(r["option"].ToString());
                            }
                            choiceHolder.Controls.Add(radioInput);

                        }
                    }

                }
                catch (Exception excep)
                {
                    System.Diagnostics.Debug.WriteLine(excep);
                }
            }


        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            Session["lastQID"] = Session["currentQID"];
            Response.Redirect("~/Pages/Survey.aspx");
        }

        protected void PrevBtn_Click(object sender, EventArgs e)
        {
            Session["nextQID"] = Session["lastQID"];

            Response.Redirect("~/Pages/Survey.aspx");
        }
    }
}