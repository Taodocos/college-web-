<%@ Page Title="" Language="C#" MasterPageFile="~/aadmin.master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="SIMS_YY.Changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
<div class="container-fluid">
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
    <div class="form.group">
  <asp:Label ID="Label1" runat="server" Text="Change password Form"></asp:Label>
    </div>
    <div class="form.group">
  <asp:Label ID="label" runat="server" Text=""></asp:Label>
    </div>
    <table style="width: 68%">
            <tr>
                <td style="width: 261px">
                    <div class="form-group">
               
                <div class="col-md-8" style="margin-left:10px;margin-top:10px;">
                    <asp:Label ID="Label2" runat="server" Text="Current Password:"></asp:Label>
                    </div>
                        </div>
                </td>
                <td>
                    <div class="form-group">
               
                <div class="col-md-4" style="margin-left:10px;margin-top:10px;">
                   <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="txtcpassword" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
                    </div>
                        </div>
                </td>
            </tr>
            <tr>
                <td style="width: 261px">
                    <div class="form-group">
               
                <div class="col-md-8" style="margin-left:10px;margin-top:10px;">
                    <asp:Label ID="Label3" runat="server" Text="New Password:"></asp:Label>
                    </div>
                        </div>
                </td>
                <td>
                    <div class="form-group">
               
                <div class="col-md-4" style="margin-left:10px;margin-top:10px;">
                     <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="txtnpassword" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
                    </div>
                        </div>
                </td>
            </tr>
            <tr>
                <td style="width: 261px">
                    <div class="form-group">
               
                <div class="col-md-8" style="margin-left:10px;margin-top:10px;">
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                    </div>
                        </div>
                </td>
                <td>
                    <div class="form-group">
               
                <div class="col-md-4" style="margin-left:10px;margin-top:10px;">
                     <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="txtconfpass" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
                    </div>
                        </div>
                </td>
            </tr>
            <tr>
                <td style="width: 261px">
                    <div class="form-group">
               
                <div class="col-md-4" style="margin-left:10px;margin-top:10px;">
                    </div>
                        </div>
                </td>
                <td>
                    <div class="form-group">
               
                <div class="col-md-12" style="margin-top:10px;">
                     <asp:Button ID="btnchangepassword" runat="server" Text="Change Password" CssClass="btn-success" OnClick="btnchangepassword_Click"   />
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass=" btn-primary" OnClick="btncancel_Click" />
                    </div>
                        </div>
                </td>
            </tr>
        </table>
    </div></div></div></div></div></div></form>
</asp:Content>
