<%@ Page Title="" Language="C#" MasterPageFile="~/depthead1.master" AutoEventWireup="true" CodeBehind="SlipReport.aspx.cs" Inherits="SIMS_YY.slip_g" %>
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
        <center><h3>Yeju Universty college</h3></center>
        <center><h3></h3></center>
        <asp:Label ID="label" runat="server" Text="" ForeColor="Red"></asp:Label> 
        <label>Select College</label>
                    <div class="form.group">
             <asp:DropDownList class="group.control" ID="radcollege" runat="server">
                 
             </asp:DropDownList>
        </div> 
        <label>Select Department</label>
                    <div class="form.group">
        <div class="form.group">
             <asp:DropDownList class="group.control" ID="raddept" runat="server">
                 
             </asp:DropDownList>
        </div> 
                        <label>Select IDNo</label>
                    <div class="form.group">
        <div class="form.group">
             <asp:DropDownList class="group.control" ID="radStudID" runat="server">
                 
             </asp:DropDownList>
        </div> 
                        
                        <label>Select Bach</label>
                    <div class="form.group">
        <div class="form.group">
             <asp:DropDownList class="group.control" ID="radyear" runat="server">
                 <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>
                 <asp:ListItem Text="III" Value="III" ></asp:ListItem>
                 <asp:ListItem Text="IV" Value="IV" ></asp:ListItem>
                 <asp:ListItem Text="V" Value="V" ></asp:ListItem>
                 <asp:ListItem Text="VI" Value="VI" ></asp:ListItem>
             </asp:DropDownList>
        </div> 
                        <label><b>Semister</b></label>
        <div class="form.group">
        <div class="form.group">
             
             <asp:DropDownList class="group.control" ID="radsemister" runat="server">
                  <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>

             </asp:DropDownList>
        </div> 
            
        </div> 
        <div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="btngenerate" runat="server" text="generate" Height="41px" Width="85px" OnClick="btngenerate_Click" ></asp:button>
        </div>
        <script type="text/javascript" src="jq.js"></script>
    <script type="text/javascript">
        $("#btn").live("click", function () {
            var divContents = $("#SLIP").html();
            var printWindow = window.open('', '', 'height=600,width=600');

            printWindow.document.write(divContents);

            printWindow.document.close();
            printWindow.print();
        });
        $("#search").live("click", function () {
            var id = $(".studid").val();

            $(".con").hide("slow");
        });
        $("#clear").live("click", function () {
            var id = $(".studid").val();


            $(".con").show("slow");



        });
        function btn_onclick() {

        }

    </script>
    <div id="SLIP" >
    <div class="form-horizontal table-bordered" style="background-color:white;">
        <table style="width: 100%">
            <tr>
                <td>
                       <div class="form-group col-md-2" style="margin-left: 220px; width: 247px;">

                <asp:Image ID="Image2" runat="server" CssClass="img-responsive" Width="250" Height="100" />

            </div>
                </td>
                <td>
                    <div class="form-group col-md-2" style="margin-top:60px; width: 247px;">
                       <asp:Label ID="date" runat="server"></asp:Label>
                        </div>
                </td>
            </tr>
        </table>
       
      
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="name" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ageandsex" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="region" runat="server" Text=""></asp:Label>
            </tr>
        </table>
        <asp:GridView ID="RadGrid1" runat="server"></asp:GridView>
            <tr>
                
                <td>
                    <asp:Label ID="anames" runat="server"></asp:Label>
                    </td>
                <td>
                    <asp:Label ID="regi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <td >
                    <asp:Label ID="sign" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="note" runat="server" Text=""></asp:Label>
                </td></tr>
            <tr>
                <td>
                    <asp:Label ID="no" runat="server" Text=""></asp:Label>
                </td>
            </tr>
                       
        </table>
       </div>
        </div>
       <input type="button" class="btn btn-info" value="print" id="btn" />
  
    </form>
</asp:Content>
