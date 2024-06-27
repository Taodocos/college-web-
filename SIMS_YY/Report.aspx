<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SIMS_YY.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
<div class="container-fluid">
    <div class="row">
        <div class="col-md-15-lg mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col">
       <centr> <p class="btn-lg">
                            Modify College Information Form
                        </p></centr> <!----photo-->
    </div>
          </div>     
<div class="row">
    <div class="form.group">
   <div class="form-horizontal table-bordered">
         <h2 class="label-default"> Generate Report in pdf format </h2>
        <ol class="list-group-item-heading">
   
         <li> <a href="GenerateReport.aspx"> <asp:Label ID="Label1" ForeColor="Black" CssClass="" runat="server" Text="All Colleges in YU "></asp:Label></a></li>
          <li> <a href="DepartmentReport.aspx"> <asp:Label ID="Label2" ForeColor="Black" CssClass="" runat="server" Text="All Department in YU "></asp:Label></a></li>
            <li> <a href="StudentReport.aspx"> <asp:Label ID="Label3" ForeColor="Black" CssClass="" runat="server" Text="All Student in YU "></asp:Label></a></li>
        </ol> 
    </div>
    </div></div></div></div></div></div></form>
</asp:Content>
