<%@ Page Title="" Language="C#" MasterPageFile="~/aadmin.master" AutoEventWireup="true" CodeBehind="create account.aspx.cs" Inherits="SIMS_YY.create_account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
<center><div class="container-fluid align-items-center justfy-content-center" >
    <div class="row align-items-center justfy-content-center">
        <div class="col-md-15 mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col-10">
       <centr></centr>
        <div class="row">
    <div class="col-10">
    <table align="center" style="width: 100%">
        <tr>
            <td colspan="2"> <h3><center>Register</center> </h3></td>
        </tr>
        <tr>
            <td colspan="2"> <center><h3>Create New Account</h3></center></td>
        </tr>
        <tr>
            <td>
                 <label>
           Roll</label>
                </td>
            <td>
         <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList1" runat="server">
                 <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                 <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                 <asp:ListItem Text="Instructor" Value="Instructor"></asp:ListItem>
                  <asp:ListItem Text="Department head" Value="Department head"></asp:ListItem>
                 <asp:ListItem Text="College dean" Value="College dean"></asp:ListItem>
                  <asp:ListItem Text="Registrar" Value="Registrar"></asp:ListItem>
                 
             </asp:DropDownList>
            
        </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Username</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Password</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Confirm Password</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
         <tr>
            <td style="width: 110px"><label>Email</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
    
         <tr>
            <td>
                 <label>Status
           </label>
                </td>
            <td>
         <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList2" runat="server">
                 <asp:ListItem Text="Activate" Value="Activate"></asp:ListItem>
                 <asp:ListItem Text="Deactivate" Value="Deactivate"></asp:ListItem>
                 
             </asp:DropDownList>
            
        </div>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
        <tr>
            <td> <br /><div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" text="REGISTER" Height="41px" Width="114px" OnClick="Button1_Click" ></asp:button>
        </div></td>
            <td><center><br /><div class="form.group">
            <asp:button Class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server" text="CLEAR" Height="44px" Width="85px"></asp:button>
        </div></center></td>
        </tr>
    </table>
        </div>
            </div>
        </div>
    </div></div></div>
            </div>
        </div>
    </div>
    
            </center>
        </form>
</asp:Content>
