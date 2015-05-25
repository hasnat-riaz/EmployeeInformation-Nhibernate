using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.Entities;

namespace EmployeeInformation.UI
{
    public partial class FindEmployeeUI : Form
    {
        private EmployeeManager employeeManager = new EmployeeManager();

        public FindEmployeeUI()
        {
            InitializeComponent();
            
        }
        public FindEmployeeUI(string searchKey):this()
        {
            LoadListView(searchKey);
        }

        private string searchKey = "";

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchKey = searchTextBox.Text;
            LoadListView(searchKey);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = GetSelectedEmployee();
            if(selectedEmployee!=null)
            {
                EmployeeInformationUI employeeInformationUi = new EmployeeInformationUI(selectedEmployee,resultListView);
                employeeInformationUi.ShowDialog();
                LoadListView(searchKey);
                resultListView.HideSelection = false;
            }
        }

        private Employee GetSelectedEmployee()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Employee) item.Tag;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
            deleteToolStripMenuItem.Enabled = (resultListView.Items.Count > 0);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = GetSelectedEmployee();
            int selectedIndex = resultListView.SelectedIndices[0];
            DialogResult result =
                MessageBox.Show("You are about to delete " + selectedEmployee.Name + " \nIs that alright?",
                                "Delete Employee", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                string message = "";
                try
                {
                    employeeManager.DeleteEmployee(selectedEmployee);
                    resultListView.Items.RemoveAt(selectedIndex);

                }
                catch(Exception exception)
                {
                    message = exception.Message;
                    MessageBox.Show(message);
                }
                
              
            }
        }

        public void LoadListView(string searchKey)
        {
            resultListView.Items.Clear();
            IList<Employee> employees;
            try
            {
                employees = employeeManager.GetEmployeesWithMatchingWord(searchKey);

                var employeeList = from employee in employees
                                   orderby employee.Name ascending
                                   select employee;
                int serialNo = 1;
                foreach (var employee in employeeList)
                {
                    ListViewItem anItem = new ListViewItem(serialNo.ToString());
                    anItem.Tag = (Employee) employee;
                    anItem.SubItems.Add(employee.Name);
                    anItem.SubItems.Add(employee.Email);
                    resultListView.Items.Add(anItem);
                    serialNo++;
                }
                if (!(resultListView.Items.Count > 0))
                {
                    MessageBox.Show(@"Sorry No Items remains for Key: " + "" + searchKey + "");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public void LoadListView()
        {
            resultListView.Items.Clear();
            IList<Employee> employees;
            try
            {
                employees = employeeManager.GetAll();

                var employeeList = from employee in employees
                                   orderby employee.Name ascending
                                   select employee;
                searchTextBox.Text = "";

                int serialNo = 1;
                foreach (var employee in employeeList)
                {
                    ListViewItem anItem = new ListViewItem(serialNo.ToString());
                    anItem.Tag = (Employee)employee;
                    anItem.SubItems.Add(employee.Name);
                    anItem.SubItems.Add(employee.Email);
                    resultListView.Items.Add(anItem);
                    serialNo++;
                }
                if (!(resultListView.Items.Count > 0))
                {
                    MessageBox.Show("Sorry No Items remains for Key: " + "" + searchKey + "");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
