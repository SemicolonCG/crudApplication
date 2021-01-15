using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudApplication
{


    class clsdb
    {
        SqlConnection con = new SqlConnection();
        string connString;

        public clsdb()
        {

            connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PMS;Persist Security Info=True;User ID=sa;Password=Dazz123@2020";
        }


        // get user details
        public DataTable getUserTable(string uname, string pwd)
        {
            DataTable dt = new DataTable();
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from pms_user WHERE [stk_user_name]='" + uname + "' AND [stk_password]='" + pwd + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public int setStaff(string sid, string sfname, string slname, string semail, string suname, string spw)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into [staff] (s_id,s_first_name,s_last_name,s_email,s_user_name,s_password)" +
                " values('" + sid + "','" + sfname + "' ,'" + slname + "','" + semail + "','" + suname + "','" + spw + "')", con);
            SqlCommand cmd1 = new SqlCommand("insert into [pms_user] (stk_user_name,stk_password,stk_role)" +
                " values('" + suname + "','" + spw + "','staff')", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            int id = cmd.ExecuteNonQuery();
            int none = cmd1.ExecuteNonQuery();
            con.Close();
            return id;
        }

        internal int setPatients(string pid, string pclinicno, string prtno, string pfname, string plname, string page, string paddress, string pdiadnosis, string psite, string pcontact, string poncologist, string pgender)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into [patients] (p_id,p_clinic_no,p_rt_number,p_first_name,p_last_name,p_age,p_address,p_diagnosis,p_site,p_contact_no,p_oncologist,p_gender)" +
                " values('" + pid + "','" + pclinicno + "' ,'" + prtno + "','" + pfname + "','" + plname + "','" + page + "','" + paddress + "','" + pdiadnosis + "','" + psite + "','" + pcontact + "','" + poncologist + "','" + pgender + "')", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int id = cmd.ExecuteNonQuery();
            con.Close();
            return id;



        }

        internal int updateStaff(string sid, string sfname, string slname, string semail, string suname, string spw)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update staff SET s_first_name='" +
               sfname + "',s_last_name='" + slname + "',s_email='" + semail + "',s_user_name='" + suname + "',s_password='" + spw + "'  where [p_id]='" + sid + "'", con);
            SqlCommand cmd1 = new SqlCommand("insert into [pms_user] (stk_user_name,stk_password,stk_role)" +
             " values('" + suname + "','" + spw + "','staff')", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            int id = cmd.ExecuteNonQuery();
            int none = cmd1.ExecuteNonQuery();
            con.Close();
            return id;
        }

        internal int updatePatients(string pid, string pclinicno, string prtno, string pfname, string plname, string page, string paddress, string pdiadnosis, string psite, string pcontact, string poncologist, string pgender)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update patients SET p_clinic_no='" + pclinicno + "',p_rt_number='" +
                prtno + "',p_first_name='" + pfname + "',p_last_name='" + plname + "',p_age='" + page + "',p_address='" + paddress + "' ,p_diagnosis='" + pdiadnosis + "',p_site='" + psite + "',p_contact_no='" + pcontact + "',p_oncologist='" + poncologist + "',p_gender='" + pgender + "'  where [p_id]='" + pid + "'", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int id = cmd.ExecuteNonQuery();
            con.Close();
            return id;

        }

        internal int deleteStaff(string sid)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM [staff] WHERE p_id='" + sid + "'", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int id = cmd.ExecuteNonQuery();
            con.Close();
            return id;
        }

        internal int deletePatients(string pid)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM [patients] WHERE p_id='" + pid + "'", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int id = cmd.ExecuteNonQuery();
            con.Close();
            return id;
        }

        // get all patient details
        public DataTable getAllPatientsDetails()
        {
            DataTable dt = new DataTable();
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from patients", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        // get all staff details
        public DataTable getAllStaffDetails()
        {
            DataTable dt = new DataTable();
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from staff", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        // get all patient by serach details
        public DataTable searchBykey(string srchkey)
        {
            DataTable dt = new DataTable();
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from patients where p_last_name LIKE '%" + srchkey + "%'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        // binddata of ontologist to combobox
        public DataTable bindData(ComboBox cmb)
        {

            DataTable dt = new DataTable();
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select onco_name from oncologist ", con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb.Items.Add(dr[0].ToString());
            }
            dr.Close();
            return dt;
        }
        //add oncologist
        public int addOncologists(string onco)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = connString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into [oncologist] values('" + onco + "')", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            int id = cmd.ExecuteNonQuery();
            con.Close();
            return id;

        }

    }
}
