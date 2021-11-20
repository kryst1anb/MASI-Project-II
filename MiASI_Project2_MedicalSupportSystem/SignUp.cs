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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void HaveAccount_label_MouseEnter(object sender, EventArgs e)
        {
            HaveAccount_label.Font = new Font(HaveAccount_label.Font, FontStyle.Underline);
        }

        private void HaveAccount_label_MouseLeave(object sender, EventArgs e)
        {
            HaveAccount_label.Font = new Font(HaveAccount_label.Font, FontStyle.Regular);
        }

        private void HaveAccount_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void IsDoctor_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDoctor_CB.Checked)
            {
                PinCode_TB.Visible = true;
            }
            else
            {
                PinCode_TB.Visible = false;
            }
        }
    }
}
