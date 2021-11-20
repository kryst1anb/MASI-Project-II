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

        private void HaveAccount_label_MouseEnter(object sender, EventArgs e)
        {
            HaveAccount_label.Font = new Font(HaveAccount_label.Font, FontStyle.Underline);
        }

        private void HaveAccount_label_MouseLeave(object sender, EventArgs e)
        {
            HaveAccount_label.Font = new Font(HaveAccount_label.Font, FontStyle.Regular);
        }
    }
}
