<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="StudentID.aspx.cs" Inherits="SIMS_YY.StudentID" %>
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
    <asp:Label ID="label" runat="server" ForeColor="#FF3300"></asp:Label>
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
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Profile Picture" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn-primary" Text="Generate ID" Width="102px" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;</td>
            </tr></table>
     </div>
    <br />
    <script type="text/javascript" src="jq.js"></script>
    <script type="text/javascript">
        $("#btn").live("click", function () {
            var divContents = $("#SLIP").html();
            var printWindow = window.open('', '', 'height=470,width=295');

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
        <div class="form-horizontal">

            <table style="width: 39%; background-image: url('uploads/studbag.PNG');">
                <tr>
                    <td colspan="2">

                <asp:Image ID="Image2" runat="server" CssClass="img-responsive" Width="255" Height="100" />
                          
                    </td>
                </tr>
           
                <tr>
                    <td rowspan="5" style="width: 110px">
                                <asp:Image ID="Image1" runat="server" CssClass="img-rounded" Width="100" Height="150" />
                         

                    </td>
                    <td style="width: 481px">
                        
                                <h4 class="">
                                    <i><asp:Label ID="name" runat="server" ForeColor="Black"></asp:Label></i></h4>
                      
                    </td>
                </tr>
                <tr>
                    <td style="width: 481px">
                       
                                <h5 class="">
                                    <asp:Label ID="dept" runat="server" ForeColor="Black"></asp:Label></h5>
                     

                    </td>
                </tr>
                <tr>
                    <td style="width: 481px">
                        <%--<div class="form-group">--%>
                            <%-- <div class="col-md-2" style="width: 247px;">--%>
                            <h5 class="">
                                <asp:Label ID="under" runat="server" ForeColor="Black"></asp:Label></h5>
                            <%--</div>--%>
                      <%--  </div>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 481px">
                        <%--<div class="form-group">--%>
                            <%-- <div class="col-md-2" style="width:247px;">--%>
                            <h5 class="">
                                <asp:Label ID="valid" runat="server" ForeColor="Black"></asp:Label></h5>
                            <%--</div>--%>
                      <%--  </div>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 481px">
                        <%--<div class="form-group">--%>
                            <%-- <div class="col-md-2" style="width:247px;">--%>
                            <h5 class="">
                                <asp:Label ID="id" runat="server" ForeColor="Black"></asp:Label></h5>
                            <%--</div>--%>
                        <%--</div>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 110px">

                        <h5 class="btn-default">
                            <asp:Label ID="pbox" runat="server" ForeColor="Black"></asp:Label></h5>

                    </td>
                    <td style="width: 481px">
                        <h5 class="btn-default">
                            <asp:Label ID="dire" runat="server" ForeColor="Black"></asp:Label></h5>
                    </td>
                </tr>
            </table>

        </div>
    </div>
    <input type="button" class="btn btn-info" value="print" id="btn" onclick="return btn_onclick()" />
    
    

</div></div></div></div></div></form>
</asp:Content>
