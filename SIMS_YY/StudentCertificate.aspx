<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="StudentCertificate.aspx.cs" Inherits="SIMS_YY.certificate_gen" %>
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
<asp:Label ID="label" runat="server" ForeColor="Red"></asp:Label>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

<table align="center" class="auto-style1">
    <tr>
        <td><label><b>Select College</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radcollege" runat="server">
                 
             </asp:DropDownList>
        </div> </td></tr>
    <tr>
        <td><label><b>Select department</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="raddept" runat="server">
                 
             </asp:DropDownList>
        </div> </td></tr>
     <tr>
        <td><label><b>Select Stud ID</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radStudID" runat="server">
                 
             </asp:DropDownList>
        </div> </td></tr>
     <tr>
        <tr>
                <td>
                     <div class="form-group"style="margin-left:10px;" >
                    <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Profile Picture" /></div>
                </td>
                <td>
                    <asp:Button ID="btngenerate" runat="server" CssClass="btn-primary" Text="Generate Ceritficate" Width="150px"  />
                </td>
                <td>&nbsp;</td>
            </tr></table>
    <<script type="text/javascript" src="jq.js"></script>
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
    <div id="SLIP">
        <div class="form-horizontal table-bordered">

            <table style="width: 100%">
                <tr>
                    <td rowspan="4">
                        <asp:Image ID="Image2" runat="server" CssClass="img-rounded" Width="100" Height="100" />
                    </td>
                    <td></td>
                    <td rowspan="4">
                        <asp:Image ID="Image1" runat="server" CssClass="img-circle" Width="100" Height="100" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            <asp:Label ID="hu" runat="server" Text=""></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image3" runat="server" CssClass="img-responsive" Width="300" Height="100" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h4>
                            <asp:Label ID="tempo" runat="server" Text="" ForeColor="Black"></asp:Label></h4>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <h5>
                            <asp:Label ID="certify" runat="server" Text="" ForeColor="Black"></asp:Label></h5>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <h5>
                            <asp:Label ID="cert" runat="server" Text="" ForeColor="Black"></asp:Label></h5>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">
                        <h5><b>
                            <asp:Label ID="dept" runat="server" Text="" ForeColor="Black"></asp:Label></b></h5>
                    </td>

                </tr>
                <tr><td colspan="3">
                    <h5>
                        <b><asp:Label ID="cgpad" runat="server" Text="" ForeColor="Black"></asp:Label></b></h5>
                    </td></tr>
                <tr><td>
                    <asp:Label ID="deansign" runat="server" Text="_____________________"></asp:Label></td>
                    <td>
                        <asp:Label ID="regsig" runat="server" Text="____________________"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="dean" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:Label ID="reg" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </div>
     <input type="button" class="btn btn-info" value="print" id="btn" onclick="return btn_onclick()"/>

                         </div>
                         </div>
                </div>
            </div>
        </div>
    
        </form>
</asp:Content>
