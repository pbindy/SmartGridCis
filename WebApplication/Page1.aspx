<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="WebApplication.Page1aspx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script>
    function openPopup(id) {
        var url = "Page2.aspx?id=" + id;
        var win = window.open('', '', 'left=200px, top=200px, width=800px, height=600px, scrollbars=no, status =no, resizable=no');
        win.location.href = url;
        win = null;
        return false;
    }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SGCIS Test Page 1</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager2" runat="server"></telerik:RadScriptManager>
            <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0"
                GridLines="None" PageSize="10"
                OnNeedDataSource="RadGrid1_NeedDataSource1" OnItemDataBound="RadGrid1_ItemDataBound"
                OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand" OnUpdateCommand="RadGrid1_UpdateCommand">
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <MasterTableView Width="80%" HorizontalAlign="Center" CommandItemDisplay="Top"
                    DataKeyNames="Id" ClientDataKeyNames="Id" AutoGenerateColumns="False" EditMode="EditForms"
                    EditFormSettings-PopUpSettings-KeepInScreenBounds="true" AllowSorting="True">

                    <EditFormSettings>
                        <PopUpSettings KeepInScreenBounds="True"></PopUpSettings>
                    </EditFormSettings>

                    <BatchEditingSettings EditType="Row" />
                    <PagerStyle Mode="NumericPages" />
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="Id" HeaderText="Id" DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name" DataType="System.String">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Age" HeaderText="Age" DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Type" HeaderText="Type" DataType="System.Int32">
                        </telerik:GridBoundColumn>
                        <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                        </telerik:GridEditCommandColumn>
                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ConfirmText="Do you really want to delete this record?" />
                        <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                            <ItemTemplate>
                                 <asp:LinkButton ID="linkButton" runat="server" ToolTip="See Detail" CommandArgument='<%# Eval("Id") + "," + Eval("Id") %>' 
                                      OnClientClick='<%# $"openPopup(\"{Eval("Id")}\");" %>'>
                                    <asp:Image ID="image1" runat="server" ImageUrl="~/Images/icon.png" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings UserControlName="PersonDetail.ascx" EditFormType="WebUserControl">
                        <EditColumn UniqueName="EditCommandColumn1">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>