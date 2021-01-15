using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            userName.Clear();
            userPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String uName = userName.Text.ToString();
            String uPwd = userPassword.Text.ToString();

            clsdb obj = new clsdb();

            DataTable dt = new DataTable();
          
    
            dt = obj.getUserTable(uName, uPwd);

            if (dt.Rows.Count > 0 && dt.Rows[0][3].ToString() == "su_admin")
            {
                Addpatients frm = new Addpatients();

                frm.Show();

                this.Hide();

            }

            else if (dt.Rows.Count > 0 && dt.Rows[0][3].ToString() == "staff")
            {

                Addpatients frm = new Addpatients();
                frm.Show();
               


            }
           
            else
            {

                MessageBox.Show("Username or password is incorrect!");
              

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
