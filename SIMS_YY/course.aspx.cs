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
    public partial class course : System.Web.UI.Page
    {
        SIMS sims = new SIMS();
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn2_Click(object sender, EventArgs e){
       

            TBL_Course[] check = sims.checkcorsbyname(TextBox2.Text);
            if (check.Count() == 0)
            {
                Generatecorscode();
                if  (sims.Add_Course(TextBox1.Text, TextBox2.Text,TextBox3.Text))
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
        void Generatecorscode()
        {
             TBL_Course[] Generatecode = sims.searchallcors();
            String dcode = TextBox2.Text.Substring(0, 4);
            foreach (TBL_Course ping in Generatecode)
            {
                count++;
            }
            if (count != 0)
            {
                String lcount = Generatecode[count - 1].Course_code;
                String sub = lcount.Substring(13);
                int lcode = Convert.ToInt32(sub);

                int decode = lcode + 1;
                String code = "YUC_cour/" + dcode + "-" + decode;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (Generatecode[i].Course_code == code)
                        {
                            decode = decode + 1;
                            code = "YUC_cour/" + dcode + "-" + decode;
                        }
                        else
                        {

                        }

                    }

                }
                TextBox1.Text = code;
                TextBox1.Enabled = false;

            }
            TextBox1.Text = "YUC_cour/" + dcode + "-" + count++;
            TextBox1.Enabled = false;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
