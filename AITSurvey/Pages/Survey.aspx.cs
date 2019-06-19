using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITSurvey.DatabaseTableAdapters;
using AITSurvey.Modal;

namespace AITSurvey.Pages
{
    public partial class Survey : System.Web.UI.Page
    {
        private questionsTableAdapter qta = new questionsTableAdapter();
        private Database.questionsDataTable qtd = new Database.questionsDataTable();

        private optionsTableAdapter ota = new optionsTableAdapter();
        private Database.optionsDataTable odt = new Database.optionsDataTable();


        public int nextQuestionId;
        private List<Answer> allAnswers = new List<Answer>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["answers"] != null)
            {
                allAnswers = (List<Answer>)Session["answers"];
            }
            Stack<int> followupQuestions = (Stack<int>)Session["followups"];
            if (Session["followups"] == null)
            {
                followupQuestions = new Stack<int>() ;
                followupQuestions.Push(4);
                Session["followups"]= followupQuestions;
            }
            if(followupQuestions.Count>0)
            {
                nextQuestionId = followupQuestions.Peek();
            }

            string qType = "";
           

            try
            {
                int qCount = qta.GetQuestionByQID(qtd, nextQuestionId);
                int oCount = ota.GetOptionsByQID(odt, nextQuestionId);

                if (qCount == 1)
                {
                    foreach (DataRow r in qtd.Rows)
                    {
                        Session["currentQID"] = r["q_ID"].ToString();
                        statementTxt.Text = r["q_statement"].ToString();
                        Session["qType"] = r["q_type"].ToString();
                        qType = r["q_type"].ToString();
                        Session["nextQID"] = null;
                        //int? nextID = int.Parse(r["q_next_ID"].ToString()) as int?;
                        Session["nextQID"] = r["q_next_ID"].ToString();

                    }
                }

                if (oCount >= 0)
                {
                    if (qType.Equals("text"))
                    {
                        TextBox textInput = new TextBox();
                        textInput.ID = "answer";
                        textInput.Attributes.Add("placeholder", "Enter your answer");
                        textInput.Attributes["nextQid"] = Session["nextQID"].ToString();
                        choiceHolder.Controls.Add(textInput);
                    }
                    else if (qType.Equals("checkbox"))
                    {
                        CheckBoxList checkInput = new CheckBoxList();
                        checkInput.ID = "answer";
                        foreach (DataRow r in odt.Rows)
                        {
                            ListItem item = new ListItem();
                            if(r["q_next_ID"].ToString() != "")
                            {
                                item.Attributes["nextQid"] = r["q_next_ID"].ToString();
                            }
                            item.Text = r["option"].ToString();
                            checkInput.Items.Add(item);

                        }
                        choiceHolder.Controls.Add(checkInput);
                    }
                    else if (qType.Equals("radio"))
                    {
                        RadioButtonList radioInput = new RadioButtonList();
                        radioInput.ID = "answer";
                        foreach (DataRow r in odt.Rows)
                        {
                            ListItem item = new ListItem();
                            if (r["q_next_ID"].ToString() != "")
                            {
                                item.Attributes["nextQid"] = r["q_next_ID"].ToString();
                            }
                            else
                            {
                                //item.Attributes["nextQid"] = Session["nextQID"].ToString();
                            }

                            item.Text = r["option"].ToString();
                            radioInput.Items.Add(item);
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

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            Stack<int> followupQuestions = (Stack<int>)Session["followups"];
            try
            {
                int currentQID = followupQuestions.Pop();
                int qCount = qta.GetQuestionByQID(qtd, nextQuestionId);
                foreach(DataRow r in qtd.Rows)
                {
                    if (!followupQuestions.Contains(int.Parse(r["q_next_ID"].ToString())))
                    {
                        if (int.Parse(r["q_next_ID"].ToString()) !=0){
                            followupQuestions.Push(int.Parse(r["q_next_ID"].ToString()));
                        }
                    }
                }

                Control control = choiceHolder.FindControl("answer");
                if (control is TextBox)
                {
                    TextBox anstxt = control as TextBox;
                    string ansStr = anstxt.Text;
                    if (ansStr != null)
                    {
                        var nextQID = anstxt.Attributes["nextQid"];
                        //DBHandler.InsertAnswer(currentQID, ansStr);
                        Answer ans = new Answer();
                        ans.answer = ansStr;
                        ans.qid = currentQID;
                        ans.qStatement = statementTxt.Text;
                        if (nextQID != "")
                        {
                            //Session["currentQID"] = nextQID;
                            if (!followupQuestions.Contains(int.Parse(nextQID)))
                            {
                                followupQuestions.Push(int.Parse(nextQID));
                            }
                        }
                        allAnswers.Add(ans);

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("There is no Text");
                    }
                }
                else if (control is CheckBoxList)
                {
                    CheckBoxList ansCheckBox = control as CheckBoxList;
                    foreach (ListItem box in ansCheckBox.Items)
                    {
                        if (box.Selected)
                        {
                            string nextQID = box.Attributes["nextQid"];
                            //DBHandler.InsertAnswer(currentQID, box.Text);
                            Answer ans = new Answer();
                            ans.answer = box.Text;
                            ans.qid = currentQID;
                            ans.qStatement = statementTxt.Text;
                            allAnswers.Add(ans);
                            if(nextQID != "" && nextQID != null)
                            {
                                //Session["currentQID"] = nextQID;
                                if (!followupQuestions.Contains(int.Parse(nextQID)))
                                {
                                    followupQuestions.Push(int.Parse(nextQID));
                                }
                            }
                        }
                    }

                }
                else if (control is RadioButtonList)
                {
                    RadioButtonList ansRadioBox = control as RadioButtonList;
                    foreach (ListItem box in ansRadioBox.Items)
                    {
                        if (box.Selected)
                        {
                            string nextQID = box.Attributes["nextQid"];
                            //DBHandler.InsertAnswer(currentQID, box.Text);
                            Answer ans = new Answer();
                            ans.answer = box.Text;
                            ans.qid = currentQID;
                            ans.qStatement = statementTxt.Text;
                            allAnswers.Add(ans);
                            if (nextQID != "" && nextQID != null)
                            {
                                //Session["currentQID"] = nextQID;
                                if (!followupQuestions.Contains(int.Parse(nextQID)))
                                {
                                    followupQuestions.Push(int.Parse(nextQID));
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No Controls");
                }
                Session["answers"] = allAnswers;
                Session["followups"] = followupQuestions;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            if(followupQuestions.Count== 0)
            {
                Response.Redirect("~/Pages/EndSurvey.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/Survey.aspx");
            }

        }

        protected void PrevBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Pages/Logout.aspx");
        }
    }
}