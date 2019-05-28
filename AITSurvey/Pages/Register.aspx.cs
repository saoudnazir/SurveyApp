using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITSurvey.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dobCalender.Visible = false;
        }

        protected void ToggleCalender(object sender, ImageClickEventArgs e)
        {
            if (IsPostBack)
            {
                dobCalender.Visible = !dobCalender.Visible;
            }
        }
    }
}