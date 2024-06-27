<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="Enterance result.aspx.cs" Inherits="SIMS_YY.Enterance_result" %>
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
        <center><h3>Office of the Registrar Enterance Result Registration Form</h3></center>
    </div>
</div>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <label><b>ID</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td> <label><b>Min-Enterance-Result</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>Gender</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
    <tr>
        <td><label><b>Year</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
</table>
                    <br />
                    <div class="row">
                        <div class="col">
                            <div class="form.group">
                       <asp:Button  Class="btn btn-success btn-block btn-lg" ID="Button3" runat="server"  Text="Save" Width="166px" OnClick="Button3_Click" />
        </div>
                        </div>
                        <div class="col">
                            <div class="form.group">
                       <asp:Button  Class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server"  Text="Reset" Width="160px" />
        </div>
                        </div>
                    </div>

                  
                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
