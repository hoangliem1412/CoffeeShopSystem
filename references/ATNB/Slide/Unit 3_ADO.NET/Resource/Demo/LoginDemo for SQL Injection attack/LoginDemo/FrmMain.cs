using System;
using System.Windows.Forms;

namespace LoginDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var loginForm = new FrmLogin();
            loginForm.ShowDialog();

            if (loginForm.DialogResult != DialogResult.OK) Application.Exit();
           
        }
    }
}