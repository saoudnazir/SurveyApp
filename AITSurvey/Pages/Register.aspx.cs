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
            string username = userText.Text;
            string password = passwordRTxt.Text;
            string firstname = fNameTxt.Text;
            string lastname = lNameTxt.Text;
            string gender = genderTxt.SelectedValue;
            string state = stateTxt.SelectedValue;
            string suburb = suburbTxt.Text;
            int postcode = int.Parse(postCodeTxt.Text);
            string dob = datepicker.Text;
            string email = emailRTxt.Text;
            int phone = int.Parse(phoneTxt.Text);
            if (phone != 0 && !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(firstname) && !String.IsNullOrEmpty(lastname) && !String.IsNullOrEmpty(gender) && !String.IsNullOrEmpty(state) && !String.IsNullOrEmpty(suburb) && !String.IsNullOrEmpty(dob) && !String.IsNullOrEmpty(email) && postcode != 0)
            {
                int count = DBHandler.InsertRespondent(username, password, firstname, lastname, gender, state, suburb, postcode, dob, email,phone);
                if (count > 0)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                requiredTxt.Text = "Please fill up all fields OR Make sure you are entering correct information !";
            }
            

        }
    }
}