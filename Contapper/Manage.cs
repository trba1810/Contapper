using Contapper.DAL;
using Contapper.DAL.Model;
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
    public partial class Manage : Form
    {
        public Form1 Parent { get; set; }

        public Operation ButtonOperation { get; set; }

        public Status DefaultStatus { get; set; }

        public string ID { get; set; }       

        public Manage(Operation operation,Form1 parent)
        {

            ButtonOperation = operation;
            InitializeComponent();
            Parent = parent;
            FillStatusComboBox();
        }

        public Manage(Company company,Operation operation,Form1 parent)
        {
            InitializeComponent();
            FillStatusComboBox();
            Parent = parent;
            ID = company.Id;
            companyName.Text = company.CompanyName;
            address.Text = company.Address;
            city.Text = company.City;
            phoneNumber.Text = company.PhoneNumber;
            StatusComboBox.SelectedItem = company.Status.ToString();
            DetailsTextBox.Text = company.Details;
            dateTimePicker1.Text = company.FirstEntryDate;
            ButtonOperation = operation;
            DefaultStatus = company.Status;
        }

        

        private void FillStatusComboBox()
        {
            var statuses = new string[]
            {
                Status.Block.ToString(),
                Status.Compensation.ToString(),
                Status.Indeterminate.ToString(),
                Status.Interested.ToString(),
                Status.NotInterested.ToString()
            };
            StatusComboBox.Items.AddRange(statuses);
        }

        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                var repository = new CompaniesDal();
                var company = new Company();
                company.Id = GuidGenerator.GenerateGuid();
                company.CompanyName = companyName.Text;
                company.City = city.Text;
                company.Address = address.Text;
                company.Status = EnumConverter.ConvertToStatusEnum(StatusComboBox.SelectedItem);
                company.FirstEntryDate = dateTimePicker1.Text;
                company.Details = DetailsTextBox.Text;
                company.PhoneNumber = phoneNumber.Text;
                if (ButtonOperation == Operation.Create)
                {
                    result = repository.InsertNewCompany(company);
                    if (result)
                    {
                        Parent.InitializeDataGrid(company);
                    }

                    
                }
                else
                {
                    company.Id = ID;
                    result = repository.UpdateCompany(company);

                    if (result)
                    {

                        Parent.InitializeUpdatedDataGrid(company);
                    }

                }
                MessageBox.Show("Sve je proslo u redu");

                Close();

            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }
    }
}
