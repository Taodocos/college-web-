<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="UploadStudentList.aspx.cs" Inherits="SIMS_YY.UploadStudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<div class="container-fluid justify-content-center align-items-center">
    <div class="row">
        <div class="col-md-15-lg mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col">
       <centr><p class="alert-success">
                            Department Registration Form:
                        </p></centr> <!----photo-->
    </div>
          </div>     
<div class="row">
    <div class="col">
        <center><h3>Yeju Universty college</h3></center>
        <center><h3>Office of the Registrar Department Registration Form</h3></center>
    </div>
    <label class="btn-lg" for="exampleInputFile">Upload List of Student</label>
     <br />
                    <br />
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="400" ToolTip="Select Excel File Sent From ME" />
                  <div class="form-group">
            <div class="col-md-3"></div>
                <div class="col-lg-2">
                    
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
  </div>
            </div>
    <div class="form-group">
            <div class="col-md-3"></div>
                <div class="col-lg-6">
                    
                    <asp:Label ID="Label1" runat="server" CssClass="btn-success" Text=""></asp:Label>
  </div>
            </div>
        </div>






    </div></div></div></div></div></form>
</asp:Content>
