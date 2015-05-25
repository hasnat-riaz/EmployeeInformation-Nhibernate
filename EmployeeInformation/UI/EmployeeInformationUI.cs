using System;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.Entities;

namespace EmployeeInformation.UI
{
    public partial class EmployeeInformationUI : Form
    {
        private Employee employee = new Employee();
        DesignationManager designationManager = new DesignationManager();
        private EmployeeManager employeeManager = new EmployeeManager();

        public EmployeeInformationUI()
        {
            InitializeComponent();
            LoadAllDesignation();
        }
        
        public EmployeeInformationUI(Designation designation) :this()
        {
            SelectDesignation(designation);
        }


        public EmployeeInformationUI(Employee employee, ListView resultView) : this()
        {
            saveEmployeeButton.Text = @"Update";
            FillFieldsWith(employee);
            this.employee = employee;

        }

        private void FillFieldsWith(Employee employee)
        {
            nameTextBox.Text = employee.Name;
            addressTextBox.Text = employee.Address;
            emailTextBox.Text = employee.Email;
            SelectDesignation(employee.EmployeeDesignation);
        }

        public void  LoadAllDesignation()
        {
            try
            {
                designationComboBox.DataSource = designationManager.GetAll();
                designationComboBox.DisplayMember = "Title";
                designationComboBox.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveEmployeeButton_Click(object sender, EventArgs e)
        {
            employee.Name = nameTextBox.Text;
            employee.Email = emailTextBox.Text;
            employee.Address = addressTextBox.Text;
            employee.EmployeeDesignation = (Designation)designationComboBox.SelectedItem;
            
            if (nameTextBox.Text != "" &&
                    emailTextBox.Text != "" &&
                    addressTextBox.Text != "" &&
                    designationComboBox.Text != "")
            {
                string message = "";
                try
                {
                    employeeManager.SaveOrUpdate(employee);
                    MessageBox.Show(@"Employee has been saved successfully.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }

                ClearEmployee();
            }
            else
            {
                MessageBox.Show(@"Please fill-up the Employee's Form Fields Properly");
            }
        }

        private void addDesignatioButton_Click(object sender, EventArgs e)
        {
            //DesignationUI designationUi = new DesignationUI();
            //designationUi.Show();

            DesignationUI designationUi = new DesignationUI();
            designationUi.ShowDialog();
            LoadAllDesignation();
            Designation lastAddedDesignation = designationUi.GetLastAddedDesignationByThisUI();
            if (lastAddedDesignation != null)
            {
                designationComboBox.Text = lastAddedDesignation.Title;
            }
        }

        private void ClearEmployee()
        {
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            designationComboBox.Text = "";
        }
        
        public void SelectDesignation(Designation aDesignation)
        {
            designationComboBox.SelectedItem = aDesignation;
        }
    }
}
