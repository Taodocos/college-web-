<%@ Page Title="" Language="C#" MasterPageFile="~/Site111.Master" AutoEventWireup="true" CodeBehind="log in.aspx.cs" Inherits="SIMS_YY.log_in" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
<center><div class="container-fluid align-items-center justfy-content-center" >
    <div class="row align-items-center justfy-content-center">
        <div class="col-md-15 mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col-10">
       <centr></centr>
&nbsp;<!----photo--><img class="img-fluid" src="login.jpg"  /><center>
            <h3>&nbsp;&nbsp; Member Log in</h3>
        </center>
    </div>
          </div>
    <div class="row">
    <div class="col">
        <hr />
    </div>
</div>
    <div class="row">
    <div class="col-10">
    <table align="center" cellpadding="1" class="w-100">
        <tr>
            <td><label>Username</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="username" runat="server" placehold="User name" Width="188px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="pass" runat="server" placehold="" Width="187px" TextMode="Password"></asp:TextBox>
        </div></td>
        </tr>
    </table>
       <div>
           <center><table align="center" cellpading="2" class="w-100">
               <tr>
                   <td><div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="login" runat="server" text="LOGIN" Height="41px" Width="85px" OnClick="login_Click" ></asp:button>
        </div></td>
                   <td><div class="form.group">
            <asp:button Class="btn btn-danger btn-block btn-lg" ID="Clear" runat="server" text="CLEAR" Height="44px" Width="85px"></asp:button>
                      
        </div></td>
               </tr>
                
               <tr>
                   <td><asp:Label ID="lbl2" runat="server" ForeColor="Red"></asp:Label>;</td>
                   <td>&nbsp;</td>
               </tr>
           </table>
               <div class="form-group">
                <div class="col-md-1"></div>
                    <div class="col-md-6"> 
                        <asp:LinkButton ID="lblforgetpass" runat="server"><a href="ResetPassword.aspx"> Forgot Password!</a></asp:LinkButton>
                </div>
                </div>
          
        </div>
        </div>
        </div>
        </center>
        </form>
</asp:Content>
