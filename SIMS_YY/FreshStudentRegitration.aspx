<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="FreshStudentRegitration.aspx.cs" Inherits="SIMS_YY.student_addmi" %>
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
        <center><h3>Office of the Registrar Student Admission Application Form</h3></center>
    </div>
</div>
                                         <p class="btn-default">
                                <asp:Label ID="label" runat="server" ForeColor="#FF3300"></asp:Label></p>
                    <table align="center" class="auto-style1">
    <tr>
        <td> <label><b>ID NO</b></label></td>
        <td>
            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtidno" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
            </td>
    </tr>
    <tr>
        <td><label><b>First Name</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtfname" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
     <tr>
        <td><label><b>Middle Name</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtmname" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div></td>
    </tr>
                        <tr>
        <td><label><b>Last Name</b></label></td>
        <td><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="txtlname" runat="server" placehold="" Width="252px"></asp:TextBox>
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
        </div>
             <asp:Button ID="btn_add" runat="server" Text="Add to Table" CssClass="btn-primary" BackColor="Gray"  />
            <asp:Button ID="btn_register" runat="server" Text="Register" CssClass="btn-warning"  BackColor="Gray" Height="40px" Width="100px"/>
                         <asp:Button ID="Button1" runat="server" Text="Clear" CssClass="btn-warning" BackColor="Gray" Height="40px" Width="100px" />
        </td>
    </tr>
                        <tr>
                               <div class="form-group" style="margin-left:12px;" >
                  <asp:GridView ID="GridView1" runat="server" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IDNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" runat="server" Text="IDNo"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="fName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfname" runat="server" Text="First_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="mName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmname" runat="server" Text="Middle_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="lName">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllname" runat="server" Text="Last_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="College_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text="College_code"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Dept_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text="Dept_code"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age">
                                            <ItemTemplate>
                                                <asp:Label ID="lblage" runat="server" Text="Age"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Sex">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsex" runat="server" Text="Sex"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Nationality">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnation" runat="server" Text="Nationality"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Region">
                                            <ItemTemplate>
                                                <asp:Label ID="lblregion" runat="server" Text="Region"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Zone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblzone" runat="server" Text="Zone"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                        </Columns>
                                    </asp:GridView>
                                <div class="form-group" >
                <div class="col-md-3"></div>
                    <div class="col-md-6"style="margin-left:30px;" >
                         
                        
                        <%--<asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="btn-default" />--%>
                        <br />
                        
                </div>
                  
                </div>
                    <div class="form-group" style="margin-left:12px;" >
                  <asp:GridView ID="Gvrecords" runat="server" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IDNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblid" runat="server" Text="IDNo"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="fName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfname" runat="server" Text="First_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="mName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmname" runat="server" Text="Middle_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="lName">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllname" runat="server" Text="Last_Name"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="College_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcollege" runat="server" Text="College_code"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Dept_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldept" runat="server" Text="Dept_code"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age">
                                            <ItemTemplate>
                                                <asp:Label ID="lblage" runat="server" Text="Age"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Sex">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsex" runat="server" Text="Sex"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Nationality">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnation" runat="server" Text="Nationality"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Region">
                                            <ItemTemplate>
                                                <asp:Label ID="lblregion" runat="server" Text="Region"></asp:Label>                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Zone">
                                            <ItemTemplate>
                                                <asp:Label ID="lblzone" runat="server" Text="Zone"></asp:Label>                                            
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                        </Columns>
                                    </asp:GridView>
            
                </div>   
    </div>
    </div>
                            </td>
                        </tr>
                       
                        
                  
    <tr>
        <td>
            <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label></td>
       
    </tr>
</table>
</div>
</div>

                            </div>
                  
                   
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
