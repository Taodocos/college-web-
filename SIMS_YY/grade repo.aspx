<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="grade repo.aspx.cs" Inherits="SIMS_YY.grade_repo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<div class="container-fluid">
    <div class="row">
        <div class="col-md-16-lg mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col">
       <centr><h3>Yeju University College</h3></centr> <!----photo-->
    </div>
          </div>     
<div class="row">
    <div class="col">
        <center><h3>Grade report</h3></center>
    </div>
</div>
    <div class="row">
    <div class="col">
        <hr />
    </div>
</div>
                    <div class="row">
                        <div class="col-6">
                             <label>Admission Classification</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txbac" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                            <label>Program</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                            <label>Year</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                            <label>Student Name</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox7" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                            <div class="col-6">
                                <label>Major</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                <label>Ac.Year</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                <label>Semister</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox5" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                <label>Student ID</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox6" runat="server" placehold="User name" Width="259px"></asp:TextBox>
                                <hr />
        </div>
                                <!--drop a table that shws grade of student-->
                                </div>
                                <br />
                            <div style="width: 490px">

                            </div>
                            <div class="row">
                                <div class="col-4">
                                    <p><b>Remark</b></p>
                                    <!-----mndn new yhe---->
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-6">
                                    <h5>Registrar Recorder</h5>
                                    <label>Name</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox64" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                     <label>Signature</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox65" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                     <label>Date</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox66" runat="server" placehold="User name" TextMode="Date" Width="259px"></asp:TextBox>
        </div>

                                </div>
                                <div class="col-4">
                                    <h5>Department Head</h5>
                                    <label>Name</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox67" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                     <label>Signature</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox68" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div>
                                     <label>Date</label>
        <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox69" runat="server" placehold="User name" TextMode="Date" Width="259px"></asp:TextBox>
        </div>

                                </div>
                            </div>
                            <center><p>Report is generated by </p><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox70" runat="server" placehold="User name" Width="259px"></asp:TextBox>
        </div><p>on:</p><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox71" runat="server" placehold="User name" TextMode="Date" Width="259px"></asp:TextBox>
        </div></center>
                            </div>
                        </div>

                    </div>
                    </div>
                </div>
            </div>
        </div>
    
        </form>
</asp:Content>
