using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using MyPrograms.Members;
using PasswordHash;

namespace MyPrograms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                bool authenticated = this.ValidateCredentials(this.username_textbox.Text, this.password_textbox.Text);

                if (authenticated)
                {
                    FormsAuthentication.RedirectFromLoginPage(this.username_textbox.Text, false);
                }
            }
        }

        public bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
        }

        private bool ValidateCredentials(string userName, string password)
        {
            bool returnValue = false;

            if (this.IsAlphaNumeric(this.username_textbox.Text) && this.username_textbox.Text.Length <= 50 && this.password_textbox.Text.Length <= 50)
            {
                using (var authDB = new MyConnection())
                {
                    try
                    {
                        if (authDB.Authentication.Where(x => x.Username == userName).Count() == 0)
                        {
                            statusLabel.Text = "No user found";
                            return false;
                        }

                        var verify = authDB.Authentication.Where(x => x.Username == userName).First();

                        if (PasswordHash.PasswordHash.ValidatePassword(password, verify.Password))
                        {
                            return true;
                        }
                        else
                        {
                            statusLabel.Text = "Invalid Username/Password";
                        }

                    }
                    catch (Exception err)
                    {
                        statusLabel.Text = "Error: " + err.Message;
                        return false;
                    }
                }
            }
            else
            {
                statusLabel.Text = "Username/Password exceeded character limit";
                return false;
            }

            return returnValue;
        }
    }
}