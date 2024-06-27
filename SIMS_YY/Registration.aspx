<%@ Page Title="" Language="C#" MasterPageFile="~/student1.master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SIMS_YY.stud_regist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
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
        <center><h3>Student registration</h3></center>
    </div>
</div>
    <p class="btn-default">
                                <asp:Label ID="label" runat="server" ForeColor="Red"></asp:Label></p>
                     <table align="center" style="width: 100%">
                          <tr>
            <td style="width: 110px"><label>Student ID</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtstudid" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
                          <tr>
        <td><label><b>Semister</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radsemister" runat="server">
                  <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
                         <tr>
        <td><label><b>Year</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radyear" runat="server">
                  <asp:ListItem Text="I" Value="I"></asp:ListItem>
                 <asp:ListItem Text="II" Value="II" ></asp:ListItem>
                 <asp:ListItem Text="III" Value="III" ></asp:ListItem>
                 <asp:ListItem Text="IV" Value="IV" ></asp:ListItem>
                 <asp:ListItem Text="V" Value="V" ></asp:ListItem>
                 <asp:ListItem Text="VI" Value="VI" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
                          <tr>
            <td style="width: 110px"><label>First name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtfname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
                          <tr>
            <td style="width: 110px"><label>Middle name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtmname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
        <tr>
            <td style="width: 110px"><label>Last name name</label></td>
            <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtlname" runat="server" placehold="User name" Width="182px"></asp:TextBox>
        </div></td>
        </tr>
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
        <td><label><b>Age</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtage" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
                          <tr>
        <td><label><b>Sex</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radsex" runat="server">
                  <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                 <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
                          <tr>
        <td><label><b>Nationality</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtnatonal" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
                          <tr>
        <td><label><b>Region</b></label></td>
        <td><div class="form.group">
             <asp:DropDownList class="group.control" ID="radregion" runat="server">
                  <asp:ListItem Text="Amhara" Value="Amhara"></asp:ListItem>
                 <asp:ListItem Text="Tigray" Value="Tigray" ></asp:ListItem>
                 <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                 <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>
                 <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                 <asp:ListItem Text="Female" Value="Female" ></asp:ListItem>

             </asp:DropDownList>
        </div> </td></tr>
                         <tr>
        <td><label><b>zone</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtzone" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
                          <tr>
             <td colspan="2">
                    <div class="form-group">
                <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btn_register" runat="server" Text="Register" CssClass=" btn-primary" OnClick="btn_register_Click"/>
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn-danger" />
                        <br />
                        
                </div>
                  
                </div>
                </td>
         </tr></div>
     <br /></div></table>
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
    <div class="form-horizontal" style="background-color:white;">
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
        <table style="width: 100%">
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
       
       <input type="button" class="btn btn-info" value="print" id="btn" onclick="return btn_onclick()"/>
                </div>
                
            </div>
        </div>
       </div>
    
</asp:Content>
