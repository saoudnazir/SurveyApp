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
        private Database.respondentsDataTable rdt = new Database.respondentsDataTable();
        private respondentsTableAdapter rta = new respondentsTableAdapter();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["access"] = false;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var loginAsValue = loginAs.SelectedValue;
                if (loginAsValue.Equals("U"))
                {
                    int id = DBHandler.LoginUser(emailTxt.Text, passwordTxt.Text);
                    if(id > 0)
                    {
                        Session["userID"] = id;
                        Session["access"] = false;
                        DateTime today = DateTime.Today;
                        Session["sessionID"] = DBHandler.StartSession(int.Parse(Session["userID"].ToString()), today.ToString("d"), GetIPAddress());
                        Response.Redirect("~/Pages/Survey.aspx");
                    }
                    else
                    {
                        LoginMessage.Text = "Username or Password incorrect.";
                    }
                    

                }
                else if (loginAsValue.Equals("S"))
                {
                 
                    int id = DBHandler.LoginStaff(emailTxt.Text, passwordTxt.Text);
                    if(id > 0)
                    {
                        Session["access"] = true;
                        Session["userID"] = id;
                        Response.Redirect("~/Pages/Search.aspx");
                    }
                    else
                    {
                        LoginMessage.Text = "Username or Password incorrect.";
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

        protected void GuestBtn_Click(object sender, EventArgs e)
        {
            Session["userID"] = 1;
            DateTime today = DateTime.Today;
            Session["sessionID"]=DBHandler.StartSession((int)Session["userID"], today.ToString("d"), GetIPAddress());
            Response.Redirect("~/Pages/Survey.aspx");
        }
        protected string GetIPAddress()
        {
            //get IP through PROXY
            //====================
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //should break ipAddress down, but here is what it looks like:
            // return ipAddress;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            //if not proxy, get nice ip, give that back :(
            //ACROSS WEB HTTP REQUEST
            //=======================
            ipAddress = context.Request.UserHostAddress;//ServerVariables["REMOTE_ADDR"];

            if (ipAddress.Trim() == "::1")//ITS LOCAL(either lan or on same machine), CHECK LAN IP INSTEAD
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get Ip Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return ipAddress;
        }
    }
}