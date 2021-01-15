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
    public partial class Addpatients : Form
    {
        public Addpatients()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Addpatients_Load(object sender, EventArgs e)
        {
            clsdb obj = new clsdb();

            DataTable dt = new DataTable();

            ComboBox combo = poncolgstTxt;
            dt = obj.bindData(combo);
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {

            String pid = pidTxt.Text;
            String pclinicno = pclincnoTxt.Text;
            String prtno = prtnoTxt.Text;
            String pfname = pfnameTxt.Text;
            String plname = plnameTxt.Text;
            String page = pageTxt.Text;
            String paddress = paddressTxt.Text;
            String pdiadnosis = pdiagnosisTxt.Text;
            String psite = psiteTxt.Text;
            String pcontact = pcontactnoTxt.Text;
            String poncologist = poncolgstTxt.Text;

            String pgender;

            if (String.IsNullOrEmpty(pid))
            {
                MessageBox.Show("Enter Patient ID Please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            if (maleRbtn.Checked)
            {

                pgender = maleRbtn.Text;
            }
            else if (femaleRbtn.Checked)
            {
                pgender = femaleRbtn.Text;

            }
            else
            {
                pgender = "Something else";
            }


            clsdb obj = new clsdb();



            try
            {

                int id = obj.setPatients(pid, pclinicno, prtno, pfname, plname, page, paddress, pdiadnosis, psite, pcontact, poncologist, pgender);
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
                    MessageBox.Show("error. please fill the empty fields!");
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }



            pidTxt.Clear();
            pclincnoTxt.Clear();
            prtnoTxt.Clear();
            pfnameTxt.Clear();
            plnameTxt.Clear();
            pageTxt.Clear();
            paddressTxt.Clear();
            pdiagnosisTxt.Clear();
            pcontactnoTxt.Clear();



        }

   

       

        public void fillgrid()

        {

            String srchkey = srchTxt.Text;



            clsdb obj = new clsdb();

            DataTable dt = new DataTable();


            dt = obj.searchBykey(srchkey);

            dataGridView1.DataSource = dt;

            if (dt.Rows.Count > 0)

            {

                dataGridView1.DataSource = dt;


            }

        }

       

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            staff frms = new staff();
            frms.Show();
            this.Close();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

            String pid = pidTxt.Text;

            if (String.IsNullOrEmpty(pid))
            {
                MessageBox.Show("Please Enter only the Patient ID ,before delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clsdb obj = new clsdb();


            try
            {

                int id = obj.deletePatients(pid);
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

            pidTxt.Clear();

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            String pid = pidTxt.Text;
            String pclinicno = pclincnoTxt.Text;
            String prtno = prtnoTxt.Text;
            String pfname = pfnameTxt.Text;
            String plname = plnameTxt.Text;
            String page = pageTxt.Text;
            String paddress = paddressTxt.Text;
            String pdiadnosis = pdiagnosisTxt.Text;
            String psite = psiteTxt.Text;
            String pcontact = pcontactnoTxt.Text;
            String poncologist = poncolgstTxt.Text;

            String pgender;

            if (String.IsNullOrEmpty(pid))
            {
                MessageBox.Show("Enter Patient ID Please,before update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (maleRbtn.Checked)
            {

                pgender = maleRbtn.Text;
            }
            else if (femaleRbtn.Checked)
            {
                pgender = femaleRbtn.Text;

            }
            else
            {
                pgender = "Something else";
            }



            clsdb obj = new clsdb();



            try
            {

                int id = obj.updatePatients(pid, pclinicno, prtno, pfname, plname, page, paddress, pdiadnosis, psite, pcontact, poncologist, pgender);

                if (id > 0)
                {

                    MessageBox.Show("Successfully updated data");
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

            pidTxt.Clear();
            pclincnoTxt.Clear();
            prtnoTxt.Clear();
            pfnameTxt.Clear();
            plnameTxt.Clear();
            pageTxt.Clear();
            paddressTxt.Clear();
            pdiagnosisTxt.Clear();
            pcontactnoTxt.Clear();


        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            clsdb obj = new clsdb();

            DataTable dt = new DataTable();


            dt = obj.getAllPatientsDetails();

            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void poncolgstTxt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fillgrid(); //when selecting the searched name then filling its data in datagrid.  
        }
    }
}
