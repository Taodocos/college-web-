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
    public partial class and : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            TBL_College[] check = sims.checkcollbyname(TextBox2.Text);
            if (check.Count() == 0)
            {
                Generatecollcode();
                if (sims.Add_college(TextBox1.Text, TextBox2.Text))
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
        void Generatecollcode()
        {
            TBL_College[] Generatecode = sims.searchallcoll();
            String dcode = TextBox2.Text.Substring(0, 4);
            foreach (TBL_College ping in Generatecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lcount = Generatecode[count - 1].College_Code;
                String sub = lcount.Substring(15);
                int lcode = Convert.ToInt32(sub);

                int decode = lcode + 1;
                String code = "YUC_coll/" + dcode + "-" + decode;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (Generatecode[i].College_Code == code)
                        {
                            decode = decode + 1;
                            code = "YUC_coll/" + dcode + "-" + decode;
                        }
                        else
                        {

                        }

                    }

                }
                TextBox1.Text = code;
                TextBox1.Enabled = false;

            }
            TextBox1.Text = "YUC_coll/" + dcode + "-" + count++;
            TextBox1.Enabled = false;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}