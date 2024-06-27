using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;


namespace SIMS_YY
{
    public partial class student_addmi : System.Web.UI.Page
    {
         SIMS sims = new SIMS();
         int count = 0;

         protected void Page_Load(object sender, EventArgs e)
         {

         }


         protected void Button1_Click(object sender, EventArgs e)
         {

             TBL_Stud_Admission[] check = sims.checkstudbyid(TextBox3.Text);
             if (check.Count() == 0)
             {
         
                 Generatestudid();
                 if (sims.Add_Student(DateTime.Parse(TextBoxdate.Text), DropDownList1.Text, TextBox2.Text,TextBox1.Text,TextBox3.Text,TextBox4.Text,
                     TextBox6.Text,DropDownList2.Text,TextBox7.Text,DateTime.Parse(TextBox12.Text),DropDownList3.Text,TextBox13.Text,TextBox14.Text,TextBox15.Text,
                     TextBox16.Text,TextBox17.Text,
                     TextBox18.Text,TextBox8.Text,TextBox20.Text,TextBox21.Text,Decimal.Parse(TextBox5.Text)))
                 {
                     lbltxt.Text = "succesful registered";
                 }
                 else
                 {
                     lbltxt.Text = "error occur";
                 }

             }
             else
             {
                 lbltxt.Text = TextBox2.Text + " " + "already registered";
             }}
             void Generatestudid()
         {
              TBL_Stud_Admission[] Generateid = sims.searchallstud();
             String scode = TextBoxdate.Text.Substring(0, 4);
             foreach ( TBL_Stud_Admission ping in Generateid)
             {
                 count++;
             }
             if (count != 0)
             {
                 String lcount = Generateid[count - 1].Stud_Id;
                 String sub = lcount.Substring(4);
                 int lcode = Convert.ToInt32(sub);
                
                 int decode=lcode+1;
                 String code = "YUC/" + scode + "-" + decode;
                 for (int j = 0; j < count;j++ ) {
                     for(int i=0;i<count;i++)
                     {
                         if(Generateid[i].Stud_Id==code)
                         {
                             decode = decode + 1;
                             code = "YUC/" + scode + "-" + decode;
                         }
                         else
                         {

                         }

                     }
                
                 }
                 TextBox3.Text = code;
                 TextBox3.Enabled = false;

             }
             TextBox3.Text = "YUC/" + scode + "-" + count++;
             TextBox3.Enabled = false;

         }

         protected void TextBox2_TextChanged(object sender, EventArgs e)
         {

         }
     }
        
    }

        
    
