using System;
using System.Data;
using System.Windows.Forms;

namespace crudApplication
{
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void semailtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            String sid = sidTxt.Text;
            String sfname = sfnameTxt.Text;
            String slname = slnameTxt.Text;
            String semail = semailtxt.Text;
            String suname = sunameTxt.Text;
            String spw = spwd.Text;
            String onco = oncologistTxt.Text;

            if (String.IsNullOrEmpty(sid))
            {
                MessageBox.Show("Enter Staff ID Please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clsdb obj = new clsdb();

            try
            {
                int id = obj.setStaff(sid, sfname, slname, semail, suname, spw);

                if (id > 0)
                {

                    MessageBox.Show("Successfully saved data");
                }
                else if (id == 0)
                {
                    MessageBox.Show("Unsuccessfull ,No data found!");

                }
                else
                {
                    MessageBox.Show("error. please fill the every fields!");
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

            sidTxt.Clear();
            sfnameTxt.Clear();
            slnameTxt.Clear();
            semailtxt.Clear();
            sunameTxt.Clear();
            spwd.Clear();
            oncologistTxt.Clear();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            clsdb obj = new clsdb();

            DataTable dt = new DataTable();


            dt = obj.getAllStaffDetails();

            dataGridView2.DataSource = dt;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sid = sidTxt.Text;
            String sfname = sfnameTxt.Text;
            String slname = slnameTxt.Text;
            String semail = semailtxt.Text;
            String suname = sunameTxt.Text;
            String spw = spwd.Text;
            String onco = oncologistTxt.Text;

            if (String.IsNullOrEmpty(sid))
            {
                MessageBox.Show("Enter Staff ID Please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clsdb obj = new clsdb();

            try
            {
                int id = obj.updateStaff(sid, sfname, slname, semail, suname, spw);

                if (id > 0)
                {

                    MessageBox.Show("Successfully saved data");
                }
                else if (id == 0)
                {
                    MessageBox.Show("Unsuccessfull ,No data found!");

                }
                else
                {
                    MessageBox.Show("error. please fill the every fields!");
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

            sidTxt.Clear();
            sfnameTxt.Clear();
            slnameTxt.Clear();
            semailtxt.Clear();
            sunameTxt.Clear();
            spwd.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String sid = sidTxt.Text;

            if (String.IsNullOrEmpty(sid))
            {
                MessageBox.Show("Please Enter Only the Staff ID ,before delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clsdb obj = new clsdb();


            try
            {

                int id = obj.deleteStaff(sid);
                if (id > 0)
                {

                    MessageBox.Show("Successfully deleted data");
                }
                else if (id == 0)
                {
                    MessageBox.Show("Unsuccessfull ,No data found!");

                }
                else
                {
                    MessageBox.Show("error. please fill the required fields!");
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }

            sidTxt.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String onco =oncologistTxt.Text;

            if (String.IsNullOrEmpty(onco))
            {
                MessageBox.Show("Enter Oncologist Name Please,before delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clsdb obj = new clsdb();

            DataTable dt = new DataTable();

          

            try
            {
                int id = obj.addOncologists(onco);
                if (id > 0)
                {

                    MessageBox.Show("Successfully Enterd data");
                }
             
               


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            oncologistTxt.Clear();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Addpatients frmp = new Addpatients();
            frmp.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
