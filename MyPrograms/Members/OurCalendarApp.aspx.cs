using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.Security;

namespace MyPrograms.Members
{
    public partial class OurCalendarApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populate day of month
                //for (int day = 1; day <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); day++)
                //{
                //    this.DropDownList1.Items.Add(day.ToString());
                //}

                //Select current day
                //this.DropDownList1.SelectedIndex = DateTime.Now.Day - 1;

                //Populate start and end time dropboxes
                for (double numMinutes = 0; numMinutes < (60 * 24); numMinutes += 5)
                {
                    this.DropDownList2.Items.Add(DateTime.Now.Date.AddMinutes(numMinutes).ToString("t"));
                    this.DropDownList3.Items.Add(DateTime.Now.Date.AddMinutes(numMinutes).ToString("t"));
                }

                //Populate lunch time
                for (int lunchMinutes = 0; lunchMinutes <= 60; lunchMinutes += 5)
                {
                    this.DropDownList4.Items.Add(lunchMinutes.ToString());
                }
            }
        }

        protected void RadCalendar1_DayRender(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
        {
            RadCalendar1.SelectedDate = DateTime.Now.Date;

            using (var db = new MyConnection())
            {
                var myEntries = db.OurCalendarApp.Where(x => x.user == User.Identity.Name ).ToList();
                double timeLeft = 40;
                //var weekBegin = new DateTime(2015, 10, 04);
                //var weekEnd = new DateTime(2015, 10, 11);

                //var entryWeek = myEntries.Where(x => (x.thisDate >= weekBegin && x.thisDate < weekEnd)).ToList();

                foreach (var entry in myEntries)
                {
                    if (entry.thisDate.Day == e.Day.Date.Day && entry.thisDate.Month == e.Day.Date.Month)
                    {
                        //Label lbl = new Label();
                        //lbl.Text = "<br />" + entry.numHours;
                        //e.Cell.Controls.Add(lbl);

                        var weekBegin = (entry.thisDate).StartOfWeek(DayOfWeek.Sunday);
                        var weekEnd = (entry.thisDate).StartOfWeek(DayOfWeek.Sunday).AddDays(7);

                        var entryWeek = myEntries.Where(x => x.thisDate >= weekBegin && x.thisDate < weekEnd);

                        decimal hoursWorked = 0;

                        foreach (var calDay in entryWeek)
                        {
                            hoursWorked += calDay.numHours;
                        }

                        e.Cell.ToolTip = "Hours worked: " + entry.numHours;
                        e.Cell.ToolTip += "\nHours worked this week: " + hoursWorked;

                        Label label = new Label();
                        label.Text = e.Day.Date.Day.ToString();
                        e.Cell.Controls.Add(label);
                        label = new Label();
                        label.Text = "<br />" + entry.numHours.ToString();
                        e.Cell.Controls.Add(label);

                        e.View.RowSelectorText = hoursWorked.ToString();
                        //e.Cell.BorderColor = System.Drawing.Color.Orange;
                    }

                    if (Convert.ToDateTime(entry.thisDate) >= DateTime.Now.StartOfWeek(DayOfWeek.Sunday) &&
                        Convert.ToDateTime(entry.thisDate) < DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddDays(7))
                    {
                        timeLeft -= Convert.ToDouble(entry.numHours);
                    }

                    RadCalendar1.RowHeaderText = "Test";

                    //TODO Add uniformity to numbering
                }

                this.Label2.Text = timeLeft.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Verify start time isn't further ahead of end time
            if (Convert.ToDateTime(this.DropDownList2.SelectedValue) > Convert.ToDateTime(this.DropDownList3.SelectedValue))
            {
                this.tempLabel.Text = "Invalid Timespan!";
                return;
            }

            //Get the length of time
            double lengthOfTime = ((Convert.ToDateTime(this.DropDownList3.SelectedValue)) - Convert.ToDateTime(this.DropDownList2.SelectedValue)).TotalHours - (Convert.ToDouble(this.DropDownList4.SelectedValue) / 60);


            //this.tempLabel.Text = "Length of time: " + lengthOfTime;

            using (var db = new MyConnection())
            {
                //string stringCheck = DateTime.Now.Date.ToString("MM") + "/" + RadCalendar1.SelectedDate.Day.ToString() + "/" + DateTime.Now.Date.ToString("yyyy");
                if (db.OurCalendarApp.Where(x => x.thisDate == RadCalendar1.SelectedDate.Date && x.user == User.Identity.Name).Count() != 0)
                {
                    this.tempLabel.Text = "Date already has a time entered";
                    return;
                }

                try
                {
                    //var Id = db.OurCalendarApp.OrderByDescending(u => u.Id).FirstOrDefault().Id;
                    var newEntry = new Entry { Id = 1, thisDate = RadCalendar1.SelectedDate, numHours = Convert.ToDecimal(lengthOfTime), user = User.Identity.Name };
                    db.OurCalendarApp.Add(newEntry);
                    db.SaveChanges();
                    //var input = new Entry { Id = 2, thisDate = "10/12/2015", numHours = (decimal)6.5 };
                    //db.OurCalendarApp.Add(input);
                    //db.SaveChanges();
                }
                catch (Exception err)
                {
                    this.tempLabel.Text = "Error getting information: " + err.Message;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (var db = new MyConnection())
            {
                //string stringCheck = DateTime.Now.Date.ToString("MM") + "/" + RadCalendar1.SelectedDate.Day.ToString() + "/" + DateTime.Now.Date.ToString("yyyy");
                if (db.OurCalendarApp.Where(x => x.thisDate == RadCalendar1.SelectedDate && x.user == User.Identity.Name).Count() == 0)
                {
                    this.tempLabel.Text = "Error - Date is already empty";
                    return;
                }

                Entry entryLookup = db.OurCalendarApp.Where(x => x.thisDate == RadCalendar1.SelectedDate && x.user == User.Identity.Name).First();

                try
                {
                    db.OurCalendarApp.Remove(entryLookup);
                    db.SaveChanges();
                }
                catch (Exception err)
                {
                    this.tempLabel.Text = err.Message;
                    return;
                }

                this.tempLabel.Text = "Successfully removed";
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}