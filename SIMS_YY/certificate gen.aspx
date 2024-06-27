<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="certificate gen.aspx.cs" Inherits="SIMS_YY.certificate_gen" %>
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
        <center><h4>Yeju University College</h4></center>
    <p>+251-----------<br />
        P.O.Box: 32,woldia, North Wollo,Ethiopia
    </p>
        <%--<hr />--%>
    </div>
</div>
                    <div class="row">
    <div class="col">
        <!----photo-->
    </div>
                    </div>
                    <div class="row">
    <div class="col">
      <center><h2>TEMPORARY CERTIFICATE OF GRADUATION</h2></center>
    </div>
                    </div>
                    <p>This is to certify that</p>
                     <div class="row">
    <div class="col-6">
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="tbxname" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                    </div>
                         <p>graduated form Yeju university college of Agriculture and Natural Resourse with <b>Bachelor of Science(B.Sc.)</b></p><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>on<div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="User name" Width="259px"></asp:TextBox>
                         </div>
                         <p>with cumulative Grade Point Average(CGPA)of</p><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="User name" Width="259px"></asp:TextBox>
                         </div>
                         <p>The original diploma and Transcript will be issued up on the discharge of cost sharing duty</p>
                         <br />
                         <br />
                         <br />
                         <br />
                        
                         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="User name" Width="259px"></asp:TextBox>
                         </div>
                         <label>Vice President</label>
                         <br />
                         <br />
                         <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox5" runat="server" placehold="User name" Width="259px"></asp:TextBox>
                         </div>
                         <label>Registrar</label>
                         </div>
                         </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
