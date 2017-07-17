using System;
using System.Windows.Forms;
using LoginDemo.DataAccess;

namespace LoginDemo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void CmdLoginClick(object sender, EventArgs e)
        {
            var dao = new UserDao();

            if (!dao.IsValidLogin(txtUserName.Text, txtPass.Text))
            {
                MessageBox.Show(@" Invalid login!");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}