<%@ Page Title="" Language="C#" MasterPageFile="~/depthead1.master" AutoEventWireup="true" CodeBehind="course assig.aspx.cs" Inherits="SIMS_YY.course_assig" %>
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
        <center><h3>course assignment</h3></center>
    </div>
</div>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td> <label><b>
            Department
                    </b></label></td>
        <td>
                    <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList1" runat="server">
                 <asp:ListItem Text="computer science" Value="reg"></asp:ListItem>
                 <asp:ListItem Text="software enginering" Value="ext"></asp:ListItem>
                 <asp:ListItem Text="information tehnology" Value="sum"></asp:ListItem>
                  <asp:ListItem Text="Distance" Value="dis"></asp:ListItem>
             </asp:DropDownList>
                        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>Course Name</b></label></td>
        <td> <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList2" runat="server">
                 <asp:ListItem Text="" Value="reg"></asp:ListItem>
                 <asp:ListItem Text="" Value="ext"></asp:ListItem>
                 <asp:ListItem Text="" Value="sum"></asp:ListItem>
                  <asp:ListItem Text="Distance" Value="dis"></asp:ListItem>
             </asp:DropDownList>
                        </div></td>
    </tr>
     <tr>
        <td><label><b>Teacher Name</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList3" runat="server">
                 <asp:ListItem Text="" Value="reg"></asp:ListItem>
                 <asp:ListItem Text="" Value="ext"></asp:ListItem>
                 <asp:ListItem Text="" Value="sum"></asp:ListItem>
                  <asp:ListItem Text="Distance" Value="dis"></asp:ListItem>
             </asp:DropDownList>
                        </div></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
</table>
                    <br />
                    <br />

                   <center> <div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="btn2" runat="server" text="save " Height="54px" Width="115px" OnClick="btn2_Click"></asp:button>
        </div></center>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
