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
    public partial class Form1 : Form
    {
        public Company Company { get; set; } = new Company();

        public Form1(Company company)
        {
            InitializeComponent();
            

            InitializeDataGrid(company);
                           
        }

        public void InitializeDataGrid(Company company)
        {
            if (company == null)
            {
                return;
            }
            companiesDataGrid.Rows.Add(company.Id , company.CompanyName, company.City, company.Address , company.PhoneNumber, SetStatusImage(company.Status) , company.FirstEntryDate , company.Details) ;
        }

        public void InitializeUpdatedDataGrid(Company company)
        {
            if (company == null)
            {
                return;
            }
            for (var i = 0;i < companiesDataGrid.RowCount; i++)
            {
                if (companiesDataGrid.Rows[i].Cells[0].Value.ToString() == company.Id)
                {
                    companiesDataGrid.Rows[i].Cells[1].Value = company.CompanyName;
                    companiesDataGrid.Rows[i].Cells[2].Value = company.City;
                    companiesDataGrid.Rows[i].Cells[3].Value = company.Address;
                    companiesDataGrid.Rows[i].Cells[4].Value = company.PhoneNumber;
                    companiesDataGrid.Rows[i].Cells[5].Value = SetStatusImage(company.Status);
                    companiesDataGrid.Rows[i].Cells[6].Value = company.FirstEntryDate;
                    companiesDataGrid.Rows[i].Cells[7].Value = company.Details;
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // kad se ucita form1 prozor izvuci sve iz baze
            updateButton.Enabled = false;
            deleteButton.Enabled = false;

            CompaniesDal CDal = new CompaniesDal();
            var data = CDal.GetAllCompanies();
           
            foreach (var d in data)
            {
                companiesDataGrid.Rows.Add(d.Id,d.CompanyName,d.City,d.Address,d.PhoneNumber, SetStatusImage(d.Status),d.FirstEntryDate,d.Details);
            }
        }

        public Bitmap SetStatusImage(Status status)
        {
            switch (status)
            {
                case DAL.Model.Status.NotInterested:
                    return Properties.Resources.attention;
                case DAL.Model.Status.Interested:
                    return Properties.Resources.check;
                case DAL.Model.Status.Indeterminate:
                    return Properties.Resources.inder;
                case DAL.Model.Status.Compensation:
                    return Properties.Resources.comp;
                case DAL.Model.Status.Block:
                    return Properties.Resources.blok;
            }
            return null;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Operation.Create - Oznacava da je u pitanju kreiranje operacije
            // this - saljemo parent objekat manage klasi 
            Manage m = new Manage(Operation.Create,this);
            m.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // company - kompanija koja je trenutno selektovana
            // Operation.Update - Oznacava da je u pitanju update operacija
            // this - saljemo parent objekat manage klasi 
            Manage m = new Manage(Company,Operation.Update,this);
            m.Show();
            
        }

        private void companiesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            // ova metoda se poziva kad se selektuje jedan red u tabeli
            if(companiesDataGrid.SelectedRows.Count == 0)
            {
                return;
            }
            var selectedRow = companiesDataGrid.SelectedRows[0];
            if (selectedRow != null)
            {
                updateButton.Enabled = true;
                Company.Id = selectedRow.Cells[0].Value.ToString();
                Company.CompanyName = selectedRow.Cells[1].Value.ToString();
                Company.City = selectedRow.Cells[2].Value.ToString();
                Company.Address = selectedRow.Cells[3].Value.ToString();
                Company.PhoneNumber = selectedRow.Cells[4].Value.ToString();
                Company.Status = EnumConverter.ConvertToStatusEnum(selectedRow.Cells[5].Value.ToString());
                Company.FirstEntryDate = selectedRow.Cells[6].Value.ToString();
                Company.Details = selectedRow.Cells[7].Value.ToString();
            }
            

        }




        private void deleteButton_Click(object sender, EventArgs e)
        {
            CompaniesDal DelDal = new CompaniesDal();
            var result = DelDal.DeleteCompany(Company.Id);

            if (result)
            {
                MessageBox.Show("Kompanija je uspesno obrisana");

                for (var i = 0; i<=companiesDataGrid.Rows.Count; i++)
                {
                    if (companiesDataGrid.Rows[i].Cells[0].Value.ToString() == Company.Id)
                    {
                        companiesDataGrid.Rows.RemoveAt(i);
                    }
                }
            }
            
        }

        private void companiesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
            {
                return;
            }

            var cell = sender as DataGridView;


            var city = cell.Rows[e.RowIndex].Cells[2].Value.ToString();

            var address = cell.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Za datu kompaniju nije pronadjena adresa");
                return;
            }

            Map map = new Map(city,address);

            map.Show();
        }
    }
}
