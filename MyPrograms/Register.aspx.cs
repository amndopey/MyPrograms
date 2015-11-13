using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Data.Entity;
//using MyPrograms.Members;
using PasswordHash;

namespace MyPrograms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username_error_label.Text = string.Empty;
            password_error_label.Text = string.Empty;
            confirm_password_error_label.Text = string.Empty;
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            if (this.username_textbox.Text.Trim() == string.Empty)
            {
                this.username_error_label.Text = "Field cannot be blank";
                return;
            }

            if (this.password_textbox.Text.Trim() == string.Empty)
            {
                this.password_error_label.Text = "Field cannot be blank";
                return;
            }
            if (this.confirm_password_textbox.Text.Trim() == string.Empty)
            {
                this.confirm_password_error_label.Text = "Field cannot be blank";
                return;
            }
            
            if (!IsAlphaNumeric(this.username_textbox.Text))
            {
                this.username_error_label.Text = "Username must be alpha-numeric";
                return;
            }
            if (this.username_textbox.Text.Length > 50)
            {
                this.username_error_label.Text = "Username must be less than 50 characters";
                return;
            }
            if (this.password_textbox.Text.Length > 50)
            {
                this.password_error_label.Text = "Password must be less than 50 characters";
                return;
            }
            if (this.password_textbox.Text != this.confirm_password_textbox.Text)
            {
                this.password_error_label.Text = "Passwords do not match";
                this.confirm_password_error_label.Text = "Passwords do not match";
                return;
            }

            //string hash = Hasher.HashString(this.password_textbox.Text);
            string hash = PasswordHash.PasswordHash.CreateHash(this.password_textbox.Text);

            using (var db = new MyConnection())
            {
                if (db.Authentication.Where(x => x.Username == this.username_textbox.Text).Count() != 0)
                {
                    this.username_error_label.Text = "User already exists";
                    return;
                }

                //var Id = db.Authentication.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                var creds = new myUser() { Id = 1, Username = this.username_textbox.Text, Password = hash, Group = "User"};

                try
                {
                    db.Authentication.Add(creds);
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    this.username_error_label.Text = "Error accessing database: " + err;
                    return;
                }
            }

            Response.Redirect("~/Login.aspx");
        }

        public bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
        }
    }
}