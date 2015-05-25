using System;
using System.Windows.Forms;
using EmployeeInformation.BLL;
using EmployeeInformation.DAL.Entities;

namespace EmployeeInformation.UI
{
    public partial class DesignationUI : Form
    {
        private Designation aDesignation = new Designation();

        public DesignationUI()
        {
            InitializeComponent();
        }

        public Designation GetLastAddedDesignationByThisUI()
        {
            return aDesignation;
        }

        private void saveDesignationButton_Click(object sender, EventArgs e)
        {
            DesignationManager designationManager = new DesignationManager();

            if (codeTextBox.Text != "" &&
            titleTextBox.Text != "")
            {
                aDesignation.Code = codeTextBox.Text;
                aDesignation.Title = titleTextBox.Text;
                try
                {
                    designationManager.SaveOrUpdate(aDesignation);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show(@"Please fill-up the designation fields properly");
            }
        }
    }
}
