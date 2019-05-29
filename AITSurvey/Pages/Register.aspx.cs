using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITSurvey.DatabaseTableAdapters;

namespace AITSurvey.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        private respondentsTableAdapter rta = new respondentsTableAdapter();
        private Database.respondentsDataTable rdt = new Database.respondentsDataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterRBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int count = rta.Register(userText.Text, passwordRTxt.Text, fNameTxt.Text, lNameTxt.Text, genderTxt.SelectedValue, stateTxt.SelectedValue, suburbTxt.Text, int.Parse(postCodeTxt.Text), datepicker.Text, emailRTxt.Text);
                if (count > 0)
                {
                    Response.Redirect("~/Pages/Survey");
                }
            }
            catch (Exception excep)
            {
                System.Diagnostics.Debug.WriteLine(excep);
            }
        }
    }
}