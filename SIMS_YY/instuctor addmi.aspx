<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="instuctor addmi.aspx.cs" Inherits="SIMS_YY.instuctor_addmi" %>
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
    <div class="col">
        <center><h3>Instruction addmission</h3></center>
    </div>
</div>
    <div class="row">
    <div class="col">
        <hr />
    </div>
</div>
    <div class="row">
    <div class="col-6">
        <label>Id No</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
        <label>Full name</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txbf" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
         <label>Date of birth</label>
         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="tbod" runat="server" placehold="password" TextMode="Date" Width="257px"></asp:TextBox>
        </div>
        <label>Birth place</label>
         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="" Width="254px"></asp:TextBox>
        </div>
        <label>Gender</label>
         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
        <label>
            Department</label>
         <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList1" runat="server">
                 <asp:ListItem Text="cs" Value="cs"></asp:ListItem>
                 <asp:ListItem Text="swe" Value="swe"></asp:ListItem>
                 <asp:ListItem Text="it" Value="it"></asp:ListItem>

             </asp:DropDownList>
            
        </div>
        <label>Position</label>
         <div class="form.group">
             <asp:DropDownList class="group.control" ID="dd1" runat="server">
                 <asp:ListItem Text="Department head" Value="Department head"></asp:ListItem>
                 <asp:ListItem Text="college head" Value="college head"></asp:ListItem>
                 <asp:ListItem Text="Registrar" Value="Registrar"></asp:ListItem>

             </asp:DropDownList>
            
        </div>
        <label>Email</label>
         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox5" runat="server" placehold="Email" TextMode="Email" Width="255px"></asp:TextBox>
        </div>
        <label>Address</label>
         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="password" Width="254px"></asp:TextBox>
        </div>
        <div class="row">
    <div class="col">
        <hr />
    </div>
</div>
        <div class="row-3">
            <div class="col">
                <div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" text="REGISTER" Height="39px" Width="122px" OnClick="Button1_Click"></asp:button>
        </div>
                <div class="col">
                <div class="form.group">
            <asp:button Class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server" text="RESET" Height="39px" Width="122px" OnClick="Button1_Click"></asp:button>
        </div>
                 
            </div>
        
        </div>
    </div>
</div>

 </div>
            </div>

        </div>
    </div>
    <div>
        <a href="Home.aspx">Back to home</a>
    </div>
    <%--</form>--%>
    </form>
</asp:Content>
