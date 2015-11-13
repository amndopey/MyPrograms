using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Design;
using System.Configuration;
using System.Data.Metadata.Edm;
using System.Reflection;
using System.Data.Linq;
using System.Data;
using Telerik.Web.UI;
using System.Data.Entity.Core.Objects;

namespace MyPrograms.Members
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Droplist_Tables.Items.Add("-Select One-");

                var storeGenerator = new EntityStoreSchemaGenerator(
                  "System.Data.SqlClient",
                  ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString,
                  "namespace");

                storeGenerator.GenerateStoreMetadata();

                var tables = storeGenerator.StoreItemCollection
                  .GetItems<EntityContainer>()
                  .Single()
                  .BaseEntitySets
                  .OfType<EntitySet>()
                  .Where(s => !s.MetadataProperties.Contains("Type")
                    || s.MetadataProperties["Type"].ToString() == "Tables");

                foreach (var table in tables)
                {
                    this.Droplist_Tables.Items.Add(table.Name);
                }

                //Add delete button to gridview
                //GridButtonColumn deleteButton = new GridButtonColumn();

                //this.tableGrid.MasterTableView.Columns.Add(deleteButton);

                //deleteButton.UniqueName = "deleteButton";
                //deleteButton.HeaderText = "Delete";
                //deleteButton.Text = "Delete";
                //deleteButton.ConfirmText = "Are you sure you want to delete this record?";
                //deleteButton.ButtonType = GridButtonColumnType.LinkButton;
                //deleteButton.CommandName = "Delete";

                //Add edit button to gridview
                GridButtonColumn detailsButton = new GridButtonColumn();

                this.tableGrid.MasterTableView.Columns.Add(detailsButton);

                detailsButton.UniqueName = "detailsButton";
                detailsButton.HeaderText = "Details";
                detailsButton.Text = "Details";
                detailsButton.ButtonType = GridButtonColumnType.LinkButton;
                detailsButton.CommandName = "Details";
                }
        }

        protected void fetchButton_Click(object sender, EventArgs e)
        {
            if (this.Droplist_Tables.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                string comboboxValue = this.Droplist_Tables.SelectedItem.Text;


                //var x = t.GetField("comboboxValue");

                using (var db = new MyConnection())
                {
                    var t = typeof(MyConnection);
                    PropertyInfo prop = t.GetProperty(this.Droplist_Tables.SelectedItem.Text);
                    var query = prop.GetValue(db, null);
                    var myType = query.GetType();
                    var connection = db.Database.Connection;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = query.ToString();
                    command.CommandType = CommandType.Text;

                    this.tableGrid.DataSource = command.ExecuteReader();
                    this.tableGrid.DataBind();

                    connection.Close();
                }

                //GridButtonColumn newColumn = new GridButtonColumn();
                //newColumn.HeaderText = "Options";
                //newColumn.Text = "Delete";

                //this.tableGrid.Columns.Add(newColumn);
            }

        }

        protected void tableGrid_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                string Id = item["Id"].Text;
                //Response.Write("<script>alert('ID Selected was " + Id + " from table " + this.Droplist_Tables.SelectedItem.Text + "')</script>");

                using (var db = new MyConnection())
                {
                    try
                    {
                        db.Database.ExecuteSqlCommand("DELETE FROM " + this.Droplist_Tables.SelectedItem.Text + " WHERE ID = " + Id);
                        Response.Write("<script>alert('Successfully removed')</script>");
                    }
                    catch (Exception err)
                    {
                        Response.Write("<script>alert('Error: " + err.Message + "')</script>");
                        return;
                    }
                }
            }

            if (e.CommandName == "Details")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int Id = Int32.Parse(item["Id"].Text);
                Response.Write("<script>alert('ID Selected was " + Id + " from table " + this.Droplist_Tables.SelectedItem.Text + "')</script>");
            }
        }
    }
}