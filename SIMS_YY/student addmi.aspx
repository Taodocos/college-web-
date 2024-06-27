<%@ Page Title="" Language="C#" MasterPageFile="~/registrar.master" AutoEventWireup="true" CodeBehind="student addmi.aspx.cs" Inherits="SIMS_YY.student_addmi" %>
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
                                        <label>Date</label>
                     <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBoxdate" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
<label>Classification</label>
                    <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList1" runat="server">
                 <asp:ListItem Text="Regular" Value="reg"></asp:ListItem>
                 <asp:ListItem Text="Extention" Value="ext"></asp:ListItem>
                 <asp:ListItem Text="Summer" Value="sum"></asp:ListItem>
                  <asp:ListItem Text="Distance" Value="dis"></asp:ListItem>
             </asp:DropDownList>
        </div> 
                    <label>Faculty/College</label>
                     <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox2" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                     <label>Department/Stream</label>
                     <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox1" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                    <p>This form, Completed and accompained by all the neccessary academic credentials, must be returned to the registrar's
                         office on or before the the end of the registraration data decleared by the registrar. Pleasefill all the blank space 
                        properly because it will have its own effect on the services that will obtained from the college.
                    </p>
                    <hr />
                    <p><b>1.Personal data of the applicant</b><br />
                        <b>Basic information</b>
                        Student identification Card(ID.No)</p><div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox3" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                    <div class="row">
                        <div class="col-4">
                            <label>Full Name</label>
                     <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox4" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                        </div>
                        
                             <label>Gender</label>
                     <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox6" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                        <label>nationality</label>
                    <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList2" runat="server">
                 <asp:ListItem Text="Etiopian" Value="eth"></asp:ListItem>
                 <asp:ListItem Text="Kenya" Value="ken"></asp:ListItem>
                 <asp:ListItem Text="Sudan" Value="sud"></asp:ListItem>
                 </asp:DropDownList>
                        </div>
                            <label>Place of birth</label>
                             
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox7" runat="server" placehold="Region" Width="252px"></asp:TextBox>
        </div>
                            <p><b>Date of birth</b></p>
                            <label>In Gregorian Calendar</label>
                             <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox12" runat="server" placehold="Town/Kebele" Width="252px"></asp:TextBox>
        </div>
                    <label>Marital Status</label>
                    <div class="form.group">
             <asp:DropDownList class="group.control" ID="DropDownList3" runat="server">
                 <asp:ListItem Text="Single" Value="sin"></asp:ListItem>
                 <asp:ListItem Text="Married" Value="mar"></asp:ListItem>
                 <asp:ListItem Text="Divorced" Value="div"></asp:ListItem>
                 <asp:ListItem Text="Widowed" Value="wid"></asp:ListItem>
                 </asp:DropDownList>
                        </div>
                        <div class="row"> 
                         <div class="col-4" >
                            <p><b>Full Address of the Applicant</b></p>
                            <label>Region</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox13" runat="server" placehold="Region" Width="252px"></asp:TextBox>
        </div>
                                                        <label>Zone/Kifleketema</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox14" runat="server" placehold="Zone/Kifleketema" Width="252px"></asp:TextBox>
        </div>
                            <label>Woreda"</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox15" runat="server" placehold="Woreda" Width="252px"></asp:TextBox>
        </div>
                            <label>Town/Kebele</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox16" runat="server" placehold="Town/Kebele" Width="252px"></asp:TextBox>
        </div>
                            <label>Phone No</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox17" runat="server" placehold="cell Phone" Width="252px"></asp:TextBox>
        </div>     

                            <p><b>Family Information</b></p>
                            <label>Mother's Full name</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox18" runat="server" placehold="Region" Width="252px"></asp:TextBox>
        </div>
                             <label>Mother's Phone No</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox8" runat="server" placehold="Region" Width="252px"></asp:TextBox>
        </div>
                            
                             </div>
                            </div>
                            <!----check box-->
                            <p><b>Student contact information/ person to contacted in case of emergency.</b></p>
                             <label>Contact's Full name</label>
                            <div class="form.group">
            <asp:TextBox CssClass="form.control" ID="TextBox20" runat="server" placehold="Region" Width="252px"></asp:TextBox>
        </div>
                            <p><b>Contact Address Information</b></p>
                            <div class="col-4">
                                <label>contact's cell no:</label>
                             <div class="form.group ">
            <asp:TextBox CssClass="form.control" ID="TextBox21" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
<label>Interance Result:</label>
                             <div class="form.group ">
            <asp:TextBox CssClass="form.control" ID="TextBox5" runat="server" placehold="" Width="252px"></asp:TextBox>
        </div>
                                <asp:Label ID="lbltxt" runat="server" Text=""></asp:Label>
<div class="form.group">
            <asp:button Class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" text="Register" Height="41px" Width="85px" OnClick="Button1_Click"></asp:button>
        </div>
</div>
</div>

                            </div>
                  
                   
                </div>
            </div>
        </div>
    </div>
        </form>
</asp:Content>
