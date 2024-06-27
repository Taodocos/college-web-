<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="DepartmentRegistration.aspx.cs" Inherits="SIMS_YY.department" %>
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
</div>


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <asp:Label ID="Label2" runat="server" CssClass="col-lg-4" Text="Department Code:"></asp:Label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtdept_code" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><asp:Label ID="Label4" runat="server" CssClass="col-lg-4" Text="Department Name:"></asp:Label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtdept_name" runat="server" placehold="" Width="252px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div></td>
    </tr>
     <tr>
        <td><asp:Label ID="Label1" runat="server" CssClass="col-lg-4" Text="College:"></asp:Label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="radcollege" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
</table>
                    <br />
                    <br />

                   <center> <div class="col-md-6" style="margin-left:50px">
                          <asp:Button ID="btnadd" runat="server" Text="Add to Table" CssClass="btn-success" />
                        <asp:Button ID="btn_register" runat="server" Text="Register" CssClass=" btn-primary"   />
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn-danger" />
                        <br />
                        <br />
                        <br />
                        <p class="alert-success"><asp:Label ID="Label3" runat="server"></asp:Label></p>
                </div>
                  
                </div></center>
                <div class="form-group" style="margin-left:30px;">
                  <asp:GridView ID="Gvrecords" runat="server" Width="500px"  
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="College_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text='<% #Eval("College_Code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text='<% #Eval("Department_Code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                             
                                            <asp:TemplateField HeaderText="Department_name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text='<% #Eval("Department_name") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                
                </div>
                   
                    </div>
                </div>
            </div>
        </div>
  
        </form>
</asp:Content>
