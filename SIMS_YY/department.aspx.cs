using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;
//using EBA_Validater;
namespace SIMS_YY
{
    public partial class department : System.Web.UI.Page
    {

        SIMS sims = new SIMS();
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void btn2_Click(object sender, EventArgs e)
        {
            //ComponentValidator valid = new ComponentValidator();
            //valid.addComponent(TextBox1, ComponentValidator.TEXT_AND_NUMBER, true);
           // valid.addComponent(TextBox2, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            //valid.addComponent(TextBox3, ComponentValidator.TEXT_A_TO_Z_ONLY, true);
            //if (valid.isAllComponenetValid())
            //{
                TBL_Department[] check = sims.checkdeptbyname(TextBox2.Text);
                if (check.Count() == 0)
                {
                    Generatedeptcode();
                    if(sims.Add_Department(TextBox1.Text, TextBox2.Text, TextBox3.Text))
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
                }
               

            //}


           

        }
        void Generatedeptcode()
        {
            TBL_Department[] Generatecode = sims.searchalldept();
            String dcode = TextBox2.Text.Substring(0, 4);
            foreach (TBL_Department ping in Generatecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lcount = Generatecode[count - 1].Department_Code;
                String sub = lcount.Substring(14);
                int lcode = Convert.ToInt32(sub);
                
                int decode=lcode+1;
                String code = "YUC_Dept/" + dcode + "-" + decode;
                for (int j = 0; j < count;j++ ) {
                    for(int i=0;i<count;i++)
                    {
                        if(Generatecode[i].Department_Code==code)
                        {
                            decode = decode + 1;
                            code = "YUC_Dept/" + dcode + "-" + decode;
                        }
                        else
                        {

                        }

                    }
                
                }
                TextBox1.Text = code;
                TextBox1.Enabled = false;

            }
            TextBox1.Text = "YUC_Dept/" + dcode + "-" + count++;
            TextBox1.Enabled = false;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}