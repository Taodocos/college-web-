<%@ Page Title="" Language="C#" MasterPageFile="~/Site111.Master" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="SIMS_YY.change_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<div class="container-fluid justify-content-center align-items-center">
    <div class="row">
        <div class="col-md-15-lg mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col">
       <centr></centr> <!----photo-->
    </div>
          </div>     
<div class="row">
    <div class="col">
        <center><h3>Yeju Universty college</h3></center>
        <center><h3>Forgrt Password</h3></center>
    </div>
</div>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <label><b>UserNmae</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>New Password</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
     <tr>
        <td><label><b>Confirm Password</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
</table>
                    <br />
                    <br />

                   <center> <div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="btnsave" runat="server" text="Save " Height="54px" Width="115px" OnClick="btnsave_Click"></asp:button>
        </div></center>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
