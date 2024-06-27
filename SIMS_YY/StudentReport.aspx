<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="SIMS_YY.StudentReport" %>
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
    <div class="form-horizontal">

            <div class="form-group">
                <br />
                <div class="col-md-3">
                </div>
                <div class="col-lg-6">
                    <h4 class="active">
                        <asp:Label ID="Label2" runat="server" Text="All students in YUC"></asp:Label>
                                   </h4>
                </div>
            </div>
         <div class="form-group">
             <asp:GridView ID="GridView1" runat="server" Width="526px" DataSourceID="LinqDataSource3" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                 <Columns>
                     <asp:BoundField DataField="Stud_ID" HeaderText="Stud_ID" ReadOnly="True" SortExpression="Stud_ID" />
                     <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" ReadOnly="True" />
                     <asp:BoundField DataField="middle_name" HeaderText="middle_name" SortExpression="middle_name" ReadOnly="True" />
                     <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" ReadOnly="True" />
                     <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" ReadOnly="True" />
                     <asp:BoundField DataField="sex" HeaderText="sex" SortExpression="sex" ReadOnly="True" />
                     <asp:BoundField DataField="Acadmic_year" HeaderText="Acadmic_year" SortExpression="Acadmic_year" ReadOnly="True" />
                     <asp:BoundField DataField="Class_year" HeaderText="Class_year" SortExpression="Class_year" ReadOnly="True" />
                 </Columns>
                 <FooterStyle BackColor="#CCCCCC" />
                 <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#808080" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#383838" />
             </asp:GridView>
                
             <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="BOL_YY.DataClasses1DataContext" EntityTypeName="" Select="new (Stud_ID, first_name, middle_name, last_name, department, sex, Acadmic_year, Class_year)" TableName="TBL_FreshStudents">
             </asp:LinqDataSource>
                
            </div>
           <div class="form-group" style="margin-left:530px">
     <asp:Button ID="btnpdf" runat="server"  class="btn-warning" Text="Export to Pdf" OnClick="btnpdf_Click"  />
    
       </div>
        </div>
    </div></div></div></div></div></div></form>
</asp:Content>
