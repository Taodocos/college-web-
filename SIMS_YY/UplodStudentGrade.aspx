<%@ Page Title="" Language="C#" MasterPageFile="~/intructor.master" AutoEventWireup="true" CodeBehind="UplodStudentGrade.aspx.cs" Inherits="SIMS_YY.inst_grade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
<center><div class="container-fluid align-items-center justfy-content-center" >
    <div class="row align-items-center justfy-content-center">
        <div class="col-md-15 mx-auto">
            <div class="card">
                <div class="card-body">
<div class="row">
    <div class="col-10">
       <centr></centr>
        <div class="row">
    <div class="col-10">

        div class="col-md-3"></div>
                <div class="col-lg-6">
    <label class="btn-lg" for="exampleInputFile">Upload Student Grade</label>                          
  </div>
            <table>
             <tr>
        <td><label><b>Semister</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radsemister" runat="server">
                  <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
                </table>
            <div class="form-group">
            <div class="col-md-3">
                <asp:Label ID="Label3" runat="server" Text="Grade"></asp:Label></div>
                <div class="col-lg-6">
                    
                     <asp:FileUpload ID="FileUpload2" runat="server" Width="400" ToolTip="Browse Studen Grade In Excel Format" />   
  </div>
            </div>
         <div class="form-group">
            <div class="col-md-3"></div>
                <div class="col-lg-2">
                    
                    <asp:Button ID="btnUpload" runat="server" Text="Upload Grade" />
  </div>
            </div>
        <div class="form-group">
            <div class="col-md-3"></div>
                <div class="col-lg-6">
                    
                    <asp:Label ID="Label1" runat="server" CssClass="btn-success" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" CssClass="btn-warning" Text=""></asp:Label>
  </div>
            </div>
        </div>
            </div>
        </div>
    </div></div></div>
            </div>
        </div>
   
            </center>
        </form>

</asp:Content>
