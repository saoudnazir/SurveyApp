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
                    //Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                //Response.Redirect("~/Default.aspx");
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            searchMessage.Text = null;
            List<string> criterias = new List<string>();
            List<Modal.Search> results = new List<Modal.Search>();
            List<Modal.Search> allresuls = new List<Modal.Search>();
            foreach (ListItem li in searchCriteria.Items)
            {
                if (li.Selected)
                {
                    if (!String.IsNullOrEmpty(searchInput.Text) && li.Text == "Suburb")
                    {
                        results = DBHandler.SearchBySuburbORPostCode(searchInput.Text, "Suburb");
                        foreach(var r in results)
                        {
                            Modal.Search search = new Modal.Search();
                            search.answer = r.answer;
                            search.firstname = r.firstname;
                            search.lastname = r.lastname;
                            search.rID = r.rID;
                            allresuls.Add(search);
                        }
                    }
                    else if (!String.IsNullOrEmpty(searchInput.Text) && li.Text == "Post Code")
                    {
                            var isNumeric = int.TryParse(searchInput.Text, out int n);
                        if (isNumeric)
                        {
                            results = DBHandler.SearchBySuburbORPostCode(searchInput.Text, "Post Code");
                            foreach (var r in results)
                            {
                                Modal.Search search = new Modal.Search();
                                search.answer = r.answer;
                                search.firstname = r.firstname;
                                search.lastname = r.lastname;
                                search.rID = r.rID;
                                allresuls.Add(search);
                            }
                        }
                    }
                    else if (!String.IsNullOrEmpty(searchInput.Text) && (li.Text=="Bank" || li.Text=="Bank Service"))
                    {
                        results = DBHandler.search(searchInput.Text);
                        foreach (var r in results)
                        {
                            Modal.Search search = new Modal.Search();
                            search.answer = r.answer;
                            search.firstname = r.firstname;
                            search.lastname = r.lastname;
                            search.rID = r.rID;
                            allresuls.Add(search);
                        }
                    }
                    else
                    {
                        searchMessage.Text = "Please Enter Some Text!!!!";
                    }
                }
            }
            if (results != null)
            {
                searchTable.DataSource = allresuls;
                searchTable.DataBind();
            }

        }


    }
}
