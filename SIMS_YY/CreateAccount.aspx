<%@ Page Title="" Language="C#" MasterPageFile="~/aadmin.master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="SIMS_YY.create_account" %>
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
        <asp:Label ID="label" runat="server" ForeColor="Red"></asp:Label>
        <tr>
            <td>
                 <label>
          Select Account Type</label>
                </td>
            <td>
         <div class="form.group">
             <asp:DropDownList class="group.control" ID="radacounttype" runat="server">
                 <asp:ListItem  Text="Admin" Value="Admin"></asp:ListItem>
                 <asp:ListItem Text="Registrar" Value="Registrar"></asp:ListItem>
                 <asp:ListItem  Text="Instructor" Value="Instructor"></asp:ListItem>
                  <asp:ListItem  Text="Student" Value="Student"></asp:ListItem>
                 
             </asp:DropDownList>
            
        </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px"><label>First name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtfname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
         <tr>
            <td style="width: 110px"><label>Middle name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtmname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Last name name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtlname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Username</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtusername" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Password</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtpassword" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Confirm Password</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtconfirmpass" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
         <tr>
        <td><label><b>Sex</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radsex" runat="server">
                  <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                 <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
         <tr>
        <td><label><b>Select College</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radcollege" runat="server">
                 
             </asp:DropDownList>
        </div> </td></tr>
         <tr>
        <td><label><b>Select department</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="raddept" runat="server">
                 
             </asp:DropDownList>
        </div> </td></tr>
        <tr>
                <td colspan="2">
                     <div class="form-group">
               
                <div class="col-md-6" style="margin-left:90px;margin-top:10px;">
                     <asp:Button ID="btn_register" runat="server" Text="Create" CssClass="btn-primary" OnClick="btn_register_Click"   />
                        <asp:Button ID="btn_cancel" runat="server" Text="Clear" CssClass="btn-danger" OnClick="btn_cancel_Click"    />
                    </div>
                         </div>
         
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
