using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebApplication
{
    public partial class Page1aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms;
            }

            ////Test data
            //if (WebServiceAccess.MyWebService.GetPersons().Count == 0)
            //{
            //    WebServiceAccess.MyWebService.CreatePerson("John", 32, 1);
            //    WebServiceAccess.MyWebService.CreatePerson("Robert", 55, 1);
            //}
        }

        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = WebServiceAccess.MyWebService.GetPersons();
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                string typeId = item["Type"].Text;

                //show only if Teacher
                var typeTeacher = WebServiceAccess.MyWebService.GetPersonTypes().FirstOrDefault(x => x.Type == 1);

                if (typeTeacher != null)
                {
                    if (typeId != typeTeacher.Type.ToString())
                    {
                        var column = (LinkButton) item["TemplateColumn"].NamingContainer.FindControl("linkButton");
                        column.Visible = false;
                    }
                }

                //display the person type description in the grid instead of the id
                var currentType = WebServiceAccess.MyWebService.GetPersonTypes().FirstOrDefault(x => x.Type == Convert.ToInt32(typeId));

                if (currentType != null)
                {
                    item["Type"].Text = currentType.Description;
                }
            }
        }

        /// <summary>
        /// Handles the InsertCommand event of the RadGrid1 control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="GridCommandEventArgs"/> instance containing the event data.</param>
        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                string name = (userControl.FindControl("txtName") as TextBox).Text;
                int age = Convert.ToInt32((userControl.FindControl("txtAge") as TextBox).Text);

                var ddlType = (userControl.FindControl("ddlType") as DropDownList);
                int typeId = Convert.ToInt32(ddlType.SelectedItem.Value);

                WebServiceAccess.MyWebService.CreatePerson(name, age, typeId);
            }
            catch (Exception ex)
            {
                Label lblError = new Label();
                lblError.Text = "Unable to insert Person. Reason: " + ex.Message;
                lblError.ForeColor = System.Drawing.Color.Red;
                RadGrid1.Controls.Add(lblError);

                e.Canceled = true;
            }
        }

        /// <summary>
        /// Handles the UpdateCommand event of the RadGrid1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridCommandEventArgs"/> instance containing the event data.</param>
        protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            try
            {
                int id = Convert.ToInt32((userControl.FindControl("txtId") as TextBox).Text);
                string name = (userControl.FindControl("txtName") as TextBox).Text;
                int age = Convert.ToInt32((userControl.FindControl("txtAge") as TextBox).Text);

                var ddlType = (userControl.FindControl("ddlType") as DropDownList);
                int typeId = Convert.ToInt32(ddlType.SelectedItem.Value);

                WebServiceAccess.MyWebService.UpdatePerson(id, name, age, typeId);
            }
            catch (Exception ex)
            {
                Label lblError = new Label();
                lblError.Text = "Unable to Update Person. Reason: " + ex.Message;
                lblError.ForeColor = System.Drawing.Color.Red;
                RadGrid1.Controls.Add(lblError);

                e.Canceled = true;
            }
        }

        /// <summary>
        /// Handles the DeleteCommand event of the RadGrid1 control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="GridCommandEventArgs"/> instance containing the event data.</param>
        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;
            int id = Convert.ToInt32(item.GetDataKeyValue("Id"));

            try
            {
                WebServiceAccess.MyWebService.DeletePerson(id);
            }
            catch (Exception ex)
            {
                Label lblError = new Label();
                lblError.Text = "Unable to delete Person. Reason: " + ex.Message;
                lblError.ForeColor = System.Drawing.Color.Red;
                RadGrid1.Controls.Add(lblError);

                e.Canceled = true;
            }
        }
    }
}