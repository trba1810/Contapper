using Contapper.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contapper
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                MessageBox.Show("Unesite username");
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("Unesite password");
            }




            var loginRep = new LoginRepository();

            var result = loginRep.AuthenticatUserBy(UsernameBox.Text, PasswordBox.Text);

            if (result)
            {
                this.Hide();
                var f1 = new Form1(null,this);
                f1.Show();
                UsernameBox.Text = string.Empty;
                PasswordBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Korisnik nije pronadjen");
            }
        }
    }
}
