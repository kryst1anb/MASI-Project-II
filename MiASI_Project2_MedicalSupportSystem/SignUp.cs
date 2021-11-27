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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            PinPESELCode_TB.Visible = true;
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
                PinPESELCode_TB.Visible = false;
                IsPatient_CB.Checked = false;
            }
            else
            {
                PinCode_TB.Visible = false;
                PinPESELCode_TB.Visible = true;
            }
        }

        private void IsPatient_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPatient_CB.Checked)
            {
                PinCode_TB.Visible = false;
                PinPESELCode_TB.Visible = true;
                IsDoctor_CB.Checked = false;
            }
            else
            {
                PinCode_TB.Visible = true;
                PinPESELCode_TB.Visible = false;
            }
        }

        private void signUp_BTN_Click(object sender, EventArgs e)
        {
            string userName = name_signUp_TB.Text;
            string userSurname = surname_signUp_TB.Text;
            string userLogin = login_signUp_TB.Text;
            string userPesel = PinPESELCode_TB.Text;
            string userPassword = password_signUp_TB.Text;
            string commandText = "";

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand cmdSelect = new SqlCommand($"SELECT * FROM Project2.dbo.Users WHERE UserLogin Like '{userLogin}'", cnn);

            try
            {
                SqlDataReader dataReader = cmdSelect.ExecuteReader();
                while (!dataReader.Read())
                {
                    if (PinCode_TB.Text == "213742069" && IsDoctor_CB.Checked == true)
                    {
                        //Doctor
                        if (string.IsNullOrWhiteSpace(login_signUp_TB.Text) || string.IsNullOrWhiteSpace(password_signUp_TB.Text) || login_signUp_TB.Text.Any(Char.IsWhiteSpace) || password_signUp_TB.Text.Any(Char.IsWhiteSpace))
                        {
                            MessageBox.Show("Invalid input");
                        }
                        else
                        {
                            commandText = $"INSERT INTO Project2.dbo.Passwords (Password) VALUES ('{userPassword}'); INSERT INTO Project2.dbo.Users (UserLogin, UserName, UserLastName, UserPesel, RoleID, PasswordID) VALUES ('{userLogin}', '{userName}', '{userSurname}', '{userPesel}', 1, (SELECT TOP 1 PasswordID FROM Project1.dbo.Passwords ORDER BY PasswordID DESC));";
                        }
                    }
                    else if (IsDoctor_CB.Checked == false && IsPatient_CB.Checked == true)
                    {
                        //Patient
                        if (string.IsNullOrWhiteSpace(login_signUp_TB.Text) || string.IsNullOrWhiteSpace(password_signUp_TB.Text) || login_signUp_TB.Text.Any(Char.IsWhiteSpace) || password_signUp_TB.Text.Any(Char.IsWhiteSpace))
                        {
                            MessageBox.Show("Invalid input");
                        }
                        else
                        {
                            commandText = $"INSERT INTO Project2.dbo.Passwords (Password) VALUES ('{userPassword}'); INSERT INTO Project2.dbo.Users (UserLogin, UserName, UserLastName, UserPesel, RoleID, PasswordID) VALUES ('{userLogin}', '{userName}', '{userSurname}', '{userPesel}', 2, (SELECT TOP 1 PasswordID FROM Project1.dbo.Passwords ORDER BY PasswordID DESC));";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong pin code!");
                        PinCode_TB.Text = "";
                    }

                    SqlCommand cmd = new SqlCommand(commandText, cnn);
                    cmd.ExecuteNonQuery();

                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                    this.Close();
                }
                MessageBox.Show("Login exist!");
                login_signUp_TB.Text = "";
                password_signUp_TB.Text = "";
                name_signUp_TB.Text = "";
                surname_signUp_TB.Text = "";
                PinPESELCode_TB.Text = "";
                PinCode_TB.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmdSelect.Dispose();
                cnn.Close();
            }

        }
    }
}
