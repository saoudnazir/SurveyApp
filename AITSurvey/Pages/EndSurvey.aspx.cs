using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITSurvey.Modal;

namespace AITSurvey.Pages
{
    public partial class EndSurvey : System.Web.UI.Page
    {
        private List<Answer> allAnswers = new List<Answer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["answers"]!= null)
            {
                allAnswers = (List<Answer>)Session["answers"];
                
                responseTable.DataSource = allAnswers;
                responseTable.DataBind();
            }
            else
            {
                SubmitBtn.Enabled = false;
                CancelBtn.Text = "Logout";
                EOSMessage.Text = "No Answers";
                //System.Diagnostics.Debug.WriteLine("Answer list is empty!");
                //Response.Redirect("~/Default.aspx");
            }


        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if(allAnswers != null)
            {
                foreach(var answer in allAnswers)
                {
                    try
                    {
                        DBHandler.InsertAnswer(answer.qid, answer.answer,int.Parse(Session["sessionID"].ToString()),int.Parse(Session["userID"].ToString()));
                        SubmitBtn.Enabled = false;
                        CancelBtn.Text = "Logout";
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }


            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Logout");
        }
    }
}