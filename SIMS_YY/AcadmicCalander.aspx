<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="AcadmicCalander.aspx.cs" Inherits="SIMS_YY.calendar" %>
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
 <asp:Label ID="Label4" runat="server" CssClass="col-lg-4" Text="Acadmic year:"></asp:Label>
    </div>
                    <div class="col-md-6">
                         <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="txtacadmiccyear" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
                    <div class="form.group">
 <asp:Label ID="Label2" runat="server" CssClass="col-lg-4" Text="Acadmic Activites:"></asp:Label>
    </div>
                        

                        <div class="col-md-6">
                         <div class="form.group">
             <asp:TextBox CssClass="form.control" ID="" runat="server" placehold="" Width="254px"></asp:TextBox>
                         </div>
                            </div>
         <div class="col-md-6">
                         <div class="form.group">
             <asp:DropDownList class="group.control" ID="radacadmicactivites" runat="server">
                 <asp:ListItem Text="Registration for all 2nd year and above students" Value="Registration for all 2nd year and above students" ></asp:ListItem>
                 <asp:ListItem Text="Add &amp; Drop to all University students" Value="Add &amp; Drop to all University students" ></asp:ListItem>
                 <asp:ListItem Text=" submit grades of Graduate students" Value=" submit grades of Graduate students"></asp:ListItem>

             </asp:DropDownList>
                         </div></div>
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
                 <div class="form.group">
 <asp:Label ID="Label1" runat="server" CssClass="col-lg-4" Text="Start Date(G.C):"></asp:Label>
    </div>
                 <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                 <div class="form.group">
 <asp:Label ID="Label3" runat="server" CssClass="col-lg-4" Text="Last Date(G.C):"></asp:Label>
    </div>
                 <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                 <asp:Label ID="da" runat="server" ForeColor="Red"></asp:Label>
                 <div class="form.group">
 <asp:Label ID="da" runat="server" ForeColor="Red"></asp:Label>
                     <asp:Label ID="label" runat="server" ForeColor="Red"></asp:Label>
    </div>
                 <div class="form-group">
                <div class="col-md-3"></div>
                    <div class="col-md-6" style="margin-left:30px;">
                        <asp:Button ID="btnadd" runat="server" Text="Add to Table" CssClass="btn-success"  />
                        <asp:Button ID="btn_register" runat="server" Text="Register" />
                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass=" btn-primary" OnClick="btnupdate_Click" />

                        <br />
                </div>
                  
                </div>
                 
           
                   <div class="form-group" style="margin-left:30px;">
                       <asp:GridView ID="Gvrecords" runat="server"AutoGenerateColumns="False">
                           <Columns>

                           </Columns>
                           
                       </asp:GridView>
                </div>   
                
</asp:Content>
