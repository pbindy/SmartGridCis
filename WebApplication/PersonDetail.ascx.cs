using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebApplication
{
    public partial class PersonDetail : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, System.EventArgs e)
        {
            ddlType.DataSource = WebServiceAccess.MyWebService.GetPersonTypes().OrderBy(x => x.Description);
            ddlType.DataValueField = "Type";
            ddlType.DataTextField = "Description";
            ddlType.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Gets the right TypeId of the current person 
            //used when updating a person
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var currentPerson = WebServiceAccess.MyWebService.GetPersons().FirstOrDefault(x => x.Id == Convert.ToInt32(txtId.Text));

                if (currentPerson != null)
                {
                    ddlType.SelectedValue = currentPerson.Type.ToString();
                }
            }
        }
    }
}