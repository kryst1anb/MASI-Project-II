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
    public partial class Login : Form
    {
        public static string loginDisplay;
        public static string userRole;

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

        private void signIn_BTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login_signIn_TB.Text) || string.IsNullOrWhiteSpace(password_signIn_TB.Text) || login_signIn_TB.Text.Any(Char.IsWhiteSpace) || password_signIn_TB.Text.Any(Char.IsWhiteSpace))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                string login = login_signIn_TB.Text;
                loginDisplay = login;

                string password = password_signIn_TB.Text;
               // string passCrypto = Encryption(password, 4);

                string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;Encrypt=false;";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();

                SqlDataReader dataReader;
                String sql;
                sql = $"SELECT u.UserLogin, p.Password, r.Description FROM Project2.dbo.Users as u INNER JOIN Project2.dbo.Passwords p ON u.PasswordID = p.PasswordID INNER JOIN Project2.dbo.Roles r ON u.RoleID = r.RoleID WHERE u.UserLogin LIKE '{login}' AND p.Password LIKE '{password}'";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                try
                {
                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        string passDB = dataReader.GetValue(1).ToString();

                        if ((dataReader.GetValue(0).ToString() == login) && (passDB == password))
                        {
                            userRole = dataReader.GetValue(2).ToString();

                            if(userRole == "Patient")
                            {
                                this.Hide();
                                PatientHome patientHome = new PatientHome();
                                patientHome.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                //show doctor win form
                                MessageBox.Show("lekarz");
                            }
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your login or password is incorrect");
                    }
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    cnn.Close();
                }

            }
        }
    }
}
