using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AITSurvey.DatabaseTableAdapters;
using AITSurvey.Modal;

namespace AITSurvey
{
    public partial class _Default : Page
    {
        private Database db = new Database();
        private Database.respondentsDataTable rdt = new Database.respondentsDataTable();
        private respondentsTableAdapter rta = new respondentsTableAdapter();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int count = rta.Login(rdt, emailTxt.Text, passwordTxt.Text);
                if (count == 1)
                {
                    foreach (DataRow r in rdt.Rows)
                    {
                        Session["userID"] = r["r_id"].ToString();
                    }
                }
            }
            catch (Exception excep)
            {
                System.Diagnostics.Debug.WriteLine(excep);
            }

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Register.aspx");
        }
    }
}