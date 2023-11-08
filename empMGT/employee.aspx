<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="empMGT.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <h1 class="text-center">EMPLOYEES MANAGEMENT SYSTEM</h1>
        <p class="text-center">&nbsp;</p>
        <p class="text-center">&nbsp;</p>

        <div class="form-group text-center">
            <asp:Label ID="MessageLbl" runat="server" Text=""></asp:Label>
        </div>

        <%-- here --%>
        <div class="form-group row">
            <asp:Panel ID="Panel6" runat="server" CssClass="form-group col-md-2">
                <asp:Label ID="Label6" runat="server" Text="SSN "></asp:Label>
                <asp:TextBox ID="empIdBox" runat="server" CssClass="form-control"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="Panel1" runat="server" CssClass="form-group col-md-4">
                <asp:Label ID="Label1" runat="server" Text="FullName"></asp:Label>
                <asp:TextBox ID="fullnameBox" runat="server" CssClass="form-control"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" CssClass="form-group col-md-4">
                <asp:Label ID="Label2" runat="server" Text="Dept"></asp:Label>
                <asp:TextBox ID="emailBox" runat="server" CssClass="form-control"></asp:TextBox>
            </asp:Panel>

            <asp:Panel ID="Panel7" runat="server" CssClass="form-group col-md-2">
                <asp:Label ID="Label7" runat="server" Text="Salary"></asp:Label>
                <asp:TextBox ID="salaryBox" runat="server" CssClass="form-control"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" CssClass="form-group col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Index"></asp:Label>
                <asp:TextBox ID="phoneBox" runat="server" CssClass="form-control"></asp:TextBox>
            </asp:Panel>                      
            <br />
        </div>
                     

        <div class="form-group">
            <asp:Button ID="CreateBtn" runat="server" Text="Create" CssClass="btn btn-warning" OnClick="CreateBtn_Click1" />
            <asp:Button ID="UpdateBtn" runat="server" Text="Add Bonus" CssClass="btn btn-warning" OnClick="UpdateBtn_Click" />
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DeleteBtn_Click" />
        </div>
        <%-- ---- --%>

        <br />

      <asp:GridView ID="GridViewList" runat="server" CssClass="table" AutoGenerateColumns="False" OnRowCommand="GridViewList_RowCommand" OnSelectedIndexChanged="GridViewList_SelectedIndexChanged1">
            <Columns>
                <%-- This are columns --%>
                <asp:BoundField DataField="SSN" HeaderText="SSN" />
                <asp:BoundField DataField="fullnames" HeaderText="FullName" />
                <asp:BoundField DataField="dept" HeaderText="Dept" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" />
                <asp:BoundField DataField="Indexi" HeaderText="Index" />                                
                <%-- view button with emp_id binding to it --%>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-primary" CommandName="ViewDetails" CommandArgument='<%# Bind("SSN") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>



