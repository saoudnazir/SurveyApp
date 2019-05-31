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
                Response.Redirect("~/Pages/Survey");
            }
            catch (Exception excep)
            {
                System.Diagnostics.Debug.WriteLine(excep);
            }
        }
    }
}