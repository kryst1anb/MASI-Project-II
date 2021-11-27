using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiASI_Project2_MedicalSupportSystem
{
    public partial class PatientHome : Form
    {
        public static string role;
        public PatientHome()
        {
            InitializeComponent();
            loginName_LB.Text = Login.loginDisplay;
            role = Login.userRole;
        }

        private void loginName_LB_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void loginName_LB_MouseEnter(object sender, EventArgs e)
        {
            loginName_LB.Font = new Font(loginName_LB.Font, FontStyle.Underline);
        }

        private void loginName_LB_MouseLeave(object sender, EventArgs e)
        {
            loginName_LB.Font = new Font(loginName_LB.Font, FontStyle.Regular);
        }

        private void add_MedData_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientAddData patientAddData = new PatientAddData();
            patientAddData.ShowDialog();
            this.Close();
        }

        private void show_MedData_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientShowData patientShowData = new PatientShowData();
            patientShowData.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientShowResults patientShowResult = new PatientShowResults();
            patientShowResult.ShowDialog();
            this.Close();
        }
    }
}
