<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonDetail.ascx.cs" Inherits="WebApplication.PersonDetail" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2017.1.228.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Import Namespace="Telerik.Web.UI" %>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vg"
    ShowSummary="True" HeaderText="Please fix the following fields:" DisplayMode="List" ForeColor="Red" />

<table>
    <tr>
        <td>
            <asp:Label runat="server" Text="Person Details" />
        </td>
        <td></td>
    </tr>

    <tr>
        <td>
            <asp:Label runat="server" Text="ID" Visible="False" />
        </td>
        <td>
            <asp:TextBox ID="txtId" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>' ReadOnly="True" />
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label runat="server" Text="Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtName"
                ErrorMessage="Name is a required field."
                ValidationGroup="vg"
                Enabled="True"
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label runat="server" Text="Age"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAge" type="number" min="0" max="120" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Age") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtAge"
                ErrorMessage="Age is a required field."
                ValidationGroup="vg"
                Enabled="True"
                Text="*"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label runat="server" Text="Type"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" />
        </td>
    </tr>

    <tr>
        <td>
            <asp:Button ID="btnupdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                ValidationGroup="vg" CausesValidation="true"
                runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "Performinsert" : "Update" %>' />
            &nbsp;
            <asp:Button ID="btncancel" Text="Cancel" runat="server" CommandName="Cancel" ValidationGroup="vg" CausesValidation="true" />
        </td>
    </tr>
</table>
