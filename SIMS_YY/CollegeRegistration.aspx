<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="CollegeRegistration.aspx.cs" Inherits="SIMS_YY.and" %>
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
        <center><h3>Office of the Registrar College Registration Form</h3></center>
    </div>
</div>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <label><b>College code</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtcollege_code" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>College Name</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtCollege_name" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
     <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
</table>
                   <div class="form-group">
                <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn-primary" OnClick="btnadd_Click"  />
                        <asp:Button ID="btn_register" runat="server" Text="Register" CssClass=" btn-success" OnClick="btn_register_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn-danger"   />
                        <br />
                        <br />
                              <asp:GridView ID="Gvrecords" runat="server" Width="200px"  
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="College_Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<% #Eval("College_Code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="College_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<% #Eval("College_Name") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                       
                        <br />
                        <p class="alert-success"><asp:Label ID="Label3" runat="server"></asp:Label></p>
                </div>
                  
                </div>
           
                   
                
        </div>
    

                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
