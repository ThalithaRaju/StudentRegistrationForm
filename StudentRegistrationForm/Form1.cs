using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationForm
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> numberNames = new Dictionary<int, string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberNames.Add(1, "MCA");
           // cmbCollege.DataSource = new BindingSource(numberNames, null);
            cmbCollege.DisplayMember ="MCA";
            cmbCollege.ValueMember = "key";
            //string value = ((KeyValuePair<int, string>)cmbCollege.SelectedValue).Value.ToString();

            #region Design
            //lblSave.BackColor = Color.FromArgb(41,141,235);
            label1.ForeColor = Color.FromArgb(41, 141, 235);
            label2.ForeColor = Color.FromArgb(41, 141, 235);
            label3.ForeColor = Color.FromArgb(41, 141, 235);
            label4.ForeColor = Color.FromArgb(41, 141, 235);
            label5.ForeColor = Color.FromArgb(41, 141, 235);
            lblSave.BackColor = Color.FromArgb(41, 141, 235);
            #endregion
            
            SqlConnection con = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=CollegeCMS;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UniversityGet", con);
            // MessageBox.Show("connected");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
             cmbUniversity.Items.Add(dr["Name"].ToString());
            }
            con.Close();
          
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            
        }

        private void lblSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=CollegeCMS;Trusted_Connection=True");
            conn.Open();
            SqlCommand cmdd = new SqlCommand("StudentSave", conn);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Name", txtName.Text);
            cmdd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmdd.Parameters.AddWithValue("@Name", txtPhone.Text);
          //  cmdd.Parameters.AddWithValue("@CollegeId",);
            conn.Close();
        }

        private void cmbUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCollege.Items.Clear();
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-Q2N7MAED\SQLEXPRESS ;Database=CollegeCMS;Trusted_Connection=True");
            conn.Open();
            SqlCommand cmdd = new SqlCommand("CollegeGet", conn);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@Name",cmbUniversity.SelectedItem);
            SqlDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                cmbCollege.Items.Add(drr["Name"].ToString());
            }
            conn.Close();
            
        }

        private void cmbCollege_SelectedValueChanged(object sender, EventArgs e)
        {
           // string value = ((KeyValuePair<int, string>)cmbCollege.SelectedValue).Value.ToString();
        }

        private void cmbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCollege.SelectedItem.ToString();
            if (numberNames.ContainsValue(cmbCollege.SelectedItem.ToString()))
            {
                MessageBox.Show("Test");
            }
               
        }
    }
}
