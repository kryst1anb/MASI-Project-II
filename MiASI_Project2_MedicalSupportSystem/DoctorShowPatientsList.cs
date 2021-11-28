﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MiASI_Project2_MedicalSupportSystem
{
    public partial class DoctorShowPatientsList : Form
    {
        public static string userLogin;
        public static ArrayList usersNamesList = new ArrayList();
        public static ArrayList usersLastNamesList = new ArrayList();
        public static ArrayList usersPeselsList = new ArrayList();
        public DoctorShowPatientsList()
        {
            InitializeComponent();
            loginName_LB.Text = Login.loginDisplay;
            userLogin = Login.loginDisplay;
            usersNamesList.Clear();
            usersLastNamesList.Clear();
            usersPeselsList.Clear();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;";
            SqlConnection cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT UserName, UserLastName, UserPesel FROM Project2.dbo.Users WHERE RoleID LIKE '1'", cnn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    usersNamesList.Add(dataReader[0].ToString());
                    usersLastNamesList.Add(dataReader[1].ToString());
                    usersPeselsList.Add(dataReader[2].ToString());
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


            for (int i = 0; i < usersNamesList.Count; i++)
            {
                Button button = new Button();
                button.Tag = i;
                button.Name = (i).ToString() + "_BTN";
                button.ForeColor = Color.White;
                button.FlatStyle = FlatStyle.Flat;
                button.AutoSize = false;
                button.Height = 50;
                button.Width = 645;
                button.Text = (usersNamesList[i].ToString() + " " + usersLastNamesList[i].ToString() + " | PESEL: " + usersPeselsList[i].ToString());
                patientsList_FP.Controls.Add(button);
                button.Click += new EventHandler(this.button_click);

                //patientsList_FP.AutoScroll = false;
                //patientsList_FP.VerticalScroll.Maximum = 0;
                //patientsList_FP.VerticalScroll.Visible = false;
                //patientsList_FP.HorizontalScroll.Maximum = 0;
                //patientsList_FP.HorizontalScroll.Visible = false;
                //patientsList_FP.AutoScroll = true;
            }
        }

        void button_click(object sender, EventArgs e)
        {
            MessageBox.Show("patient clicked");
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

        private void backHomeDoctor_BTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorHome docHome = new DoctorHome();
            docHome.ShowDialog();
            this.Close();
        }
    }
}
