<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="CollegeModfication.aspx.cs" Inherits="SIMS_YY.CollegeModfication" %>
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
   <asp:Label ID="Label1" runat="server" CssClass="col-lg-3" Text="College Code:"></asp:Label>
    </div>
    <div class="form.group">
             <asp:DropDownList class="group.control" ID="Radcollegecode" runat="server">
                 
             </asp:DropDownList>
        </div> 
    <div class="form.group">
 <asp:Label ID="Label2" runat="server" CssClass="col-lg-3" Text="College Name:"></asp:Label>
    </div>
   <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="txtCollege_name" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
    <div class="form-group">
                <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btn_update" runat="server" Text="Update" CssClass=" btn-primary" OnClick="btn_update_Click"  />&nbsp;&nbsp;
                        <asp:Button ID="btn_delete" runat="server" Text="Clear" CssClass="btn-danger" OnClick="btn_delete_Click"   />
                        <br />
                        <br />
                        <br />
                        <p class="alert-success"><asp:Label ID="Label3" runat="server"></asp:Label></p>
                </div>
                  
                </div>
           
    </div></div></div></div></div></div></form>
</asp:Content>
