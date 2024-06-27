<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="SIMS_YY.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
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
        <center><h3>Office of the Registrar course Registration Form</h3></center>
    </div>
</div>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <label><b>course code</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>course Name</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
     <tr>
        <td><label><b>Department code</b></label></td>
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
            <asp:button Class="btn btn-success btn-block btn-lg" ID="btn2" runat="server" text="save " Height="54px" Width="115px" OnClick="btn2_Click"></asp:button>
        </div></center>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
