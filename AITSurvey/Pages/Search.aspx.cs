using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITSurvey.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["access"] != null)
            {
                if ((bool)Session["access"] == false)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            searchMessage.Text = null;
            /*List<string> criterias = new List<string>();

            foreach(ListItem li in searchCriteria.Items)
            {
                if (li.Selected)
                {
                    criterias.Add(li.Text);
                }
            }*/
            if (!String.IsNullOrEmpty(searchInput.Text))
            {
                var results = DBHandler.search(searchInput.Text);
                if(results != null)
                {
                    searchTable.DataSource = results;
                    searchTable.DataBind();
                }
            }
            else
            {
                searchMessage.Text = "Please Enter Some Text!!!!";
            }
        }
    }
}