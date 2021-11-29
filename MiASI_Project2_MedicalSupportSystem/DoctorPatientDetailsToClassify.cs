using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MiASI_Project2_MedicalSupportSystem
{
    public partial class DoctorPatientDetailsToClassify : Form
    {
        public static string clickedUserLogin;

        public DoctorPatientDetailsToClassify()
        {
            InitializeComponent();
            loginName_LB.Text = Login.loginDisplay;
            clickedUserLogin = DoctorPatientsListToClassify.clickedUserLogin;
            patientDetailsName_LB.Text = $"{DoctorPatientsListToClassify.clickedUserName} {DoctorPatientsListToClassify.clickedUserSurname}";
            pesel_LB.Text = DoctorPatientsListToClassify.clickedUserPesel;

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;";
            SqlConnection cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Pregnancies,Glucose,BloodPressure,SkinThickness,Insulin,BMI,DiabetesPedigree,Age,Outcome FROM Project2.dbo.Samples as s INNER JOIN Project2.dbo.Users as u ON s.UserID = u.UserID where u.UserLogin Like '{clickedUserLogin}'", cnn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    pregnancies_TB.Text = dataReader[0].ToString();
                    glucose_TB.Text = dataReader[1].ToString();
                    bloodPressure_TB.Text = dataReader[2].ToString();
                    skinThickness_TB.Text = dataReader[3].ToString();
                    insulin_TB.Text = dataReader[4].ToString();
                    bmi_TB.Text = dataReader[5].ToString();
                    diabetesPedigree_TB.Text = dataReader[6].ToString();
                    age_TB.Text = dataReader[7].ToString();
                }

                cmd.Dispose();
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void loginName_LB_MouseEnter(object sender, EventArgs e)
        {
            loginName_LB.Font = new Font(loginName_LB.Font, FontStyle.Underline);
        }

        private void loginName_LB_MouseLeave(object sender, EventArgs e)
        {
            loginName_LB.Font = new Font(loginName_LB.Font, FontStyle.Regular);
        }

        private void loginName_LB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void backShowList_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorPatientsListToClassify patientsList = new DoctorPatientsListToClassify();
            patientsList.ShowDialog();
            this.Close();
        }

        private void classify_BTN_Click(object sender, EventArgs e)
        {
            classification_BTNs.Visible = true;
        }
    }
}
