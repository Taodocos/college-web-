<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="CourseRegistrationForm.aspx.cs" Inherits="SIMS_YY.course" %>
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
<div class="form.group">
 <asp:Label ID="label" runat="server" ForeColor="#FF3300"></asp:Label>
    </div>
                    <div class="form.group">
 <asp:Label ID="Label1" runat="server" CssClass="col-lg-4" Text="College:"></asp:Label>
    </div>
                     <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="radcollege" runat="server">
                 

             </asp:DropDownList>
                         </div>
                    <div class="form.group">
  <asp:Label ID="Label2" runat="server" CssClass="col-lg-4" Text="Department:"></asp:Label>
    </div>
<div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="raddept" runat="server">
                 

             </asp:DropDownList>
                         </div>

                    <div class="form.group">
 <asp:Label ID="Label3" runat="server" CssClass="col-lg-4" Text="Course Code:"></asp:Label>
    </div>
    <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtcoursecode" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>

                    <div class="form.group">
  <asp:Label ID="Label4" runat="server" CssClass="col-lg-4" Text="Course Name:"></asp:Label>
    </div>
    <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="txtcoursename" runat="server">
                 

             </asp:DropDownList>
                         </div>
         <div class="form.group">
  <asp:Label ID="Label5" runat="server" CssClass="col-lg-4" Text="Credit Hour:"></asp:Label>
    </div>
    <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="txtcredithour" runat="server">
     
             </asp:DropDownList>
                         </div>
         <div class="form.group">
 <asp:Label ID="Label6" runat="server" CssClass="col-lg-4" Text="Year:"></asp:Label>
    </div>
    <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="radyear" runat="server">
                 
                 <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>
                 <asp:ListItem Text="III" Value="III"></asp:ListItem>
                 <asp:ListItem  Text="IV" Value="IV" ></asp:ListItem>
                 <asp:ListItem Text="V" Value="V"></asp:ListItem>
                 <asp:ListItem Text="VI" Value="VI"></asp:ListItem>
             </asp:DropDownList>
                         </div>
         <div class="form.group">
  <asp:Label ID="Label7" runat="server" CssClass="col-lg-4" Text="Semister:"></asp:Label>
    </div>
    <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="radsemister" runat="server">
                 <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>

             </asp:DropDownList>
                         </div>
         <div class="form-group">
                <div class="col-md-3"></div>
                    <div class="col-md-6" style="margin-left:30px;">
                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn-success" OnClick="btnadd_Click"  />
                        <asp:Button ID="btn_register" runat="server" Text="Register" CssClass=" btn-primary" OnClick="btn_register_Click"  />
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn-danger" OnClick="btn_cancel_Click"  />
                        <br />
                      
                        
                       
                </div>
             <div class="form-group" style="margin-left:30px;">
                  <asp:GridView ID="Gvrecords" runat="server" Width="200px"  
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="College_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text='<% #Eval("College_code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text='<% #Eval("Department_code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Course_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcoursecode" runat="server" Text='<% #Eval("Course_code") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course_name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcourseName" runat="server" Text='<% #Eval("Course_name") %>'></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Credit_hour">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcredithour" runat="server" Text="Credit_hour"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblyear" runat="server" Text="Year"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Semister">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsemister" runat="server" Text="Semister"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
            
                </div>   
                

                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
