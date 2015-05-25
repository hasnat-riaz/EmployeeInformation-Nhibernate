using System;
using System.Windows.Forms;
using EmployeeInformation.DAL.Gateway;
using NHibernate;

namespace EmployeeInformation.UI
{
    public partial class MainMenuUI : Form
    {
        private ISessionFactory sessionFactory; 
        public MainMenuUI()
        {
            InitializeComponent();
            //NOTE : FOR CERATING DATABASE
            sessionFactory = DatabaseConfigure.BuildSessionFactory();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EmployeeInformationUI employeeInformationUi = new EmployeeInformationUI();
            employeeInformationUi.Show();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FindEmployeeUI findEmployeeUi =  new FindEmployeeUI();
            findEmployeeUi.Show();
        }
    }
}
