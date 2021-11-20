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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CreateAccount_label_MouseEnter(object sender, EventArgs e)
        {
            CreateAccount_label.Font = new Font(CreateAccount_label.Font, FontStyle.Underline);
        }

        private void CreateAccount_label_MouseLeave(object sender, EventArgs e)
        {
            CreateAccount_label.Font = new Font(CreateAccount_label.Font, FontStyle.Regular);
        }

        private void CreateAccount_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
            this.Close();
        }
    }
}
