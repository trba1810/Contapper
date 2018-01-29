using Contapper.DAL;
using Contapper.DAL.Model;
using Contapper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contapper
{
    public partial class Form1 : Form
    {
        public Company Company { get; set; } = new Company();

        public Login Login { get; set; }

        public ImageList StatusImageList { get; set; } = new ImageList();

        private bool isReloading;

        private BindingSource companiesBindingSource = new BindingSource();

        public Form1(Company company, Login login)
        {
            InitializeComponent();

            InitializeDataGrid(company);

            Login = login;

        }     

        public void InitializeDataGrid(Company company)
        {
            if (company == null)
            {
                return;
            }
            companiesDataGrid.Rows.Add(company.Id, company.CompanyName, company.City, company.Address, company.PhoneNumber, SetStatusImage(company.Status), company.FirstEntryDate, company.Details);
        }

        public void InitializeUpdatedDataGrid(Company company)
        {
            if (company == null)
            {
                return;
            }
            for (var i = 0; i < companiesDataGrid.RowCount; i++)
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
            companiesBindingSource.DataSource = data;
            companiesDataGrid.DataSource = companiesBindingSource;
            companiesDataGrid.Columns[0].Visible = false;
            companiesDataGrid.Columns[5].Visible = false;
            var imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "StatusImage";
            imageColumn.HeaderText = "Status";
            companiesDataGrid.Columns.Add(imageColumn);
        }

        public Bitmap SetStatusImage(Status status)
        {
            switch (status)
            {
                case DAL.Model.Status.NotInterested:
                    var attention = Resources.attention;
                    attention.Tag = DAL.Model.Status.NotInterested.ToString();
                    //var attentionImage = (Image)attention;
                    return attention;

                case DAL.Model.Status.Interested:
                    var check = Resources.check;
                    check.Tag = DAL.Model.Status.Interested.ToString();
                    //var checkImage = (Image)check;
                    return check;

                case DAL.Model.Status.Indeterminate:
                    var inder = Resources.inder;
                    inder.Tag = DAL.Model.Status.Indeterminate.ToString();
                    //var inderImage = (Image)inder;
                    return inder;

                case DAL.Model.Status.Compensation:
                    var comp = Resources.comp;
                    comp.Tag = DAL.Model.Status.Compensation.ToString();
                    //var compImage = (Image)comp;
                    return comp;

                case DAL.Model.Status.Block:
                    var blok = Resources.blok;
                    blok.Tag = DAL.Model.Status.Block.ToString();
                    //var blokImage = (Image)blok;
                    return blok;
            }
            return null;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Operation.Create - Oznacava da je u pitanju kreiranje operacije
            // this - saljemo parent objekat manage klasi 
            Manage m = new Manage(Operation.Create, this);
            m.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // company - kompanija koja je trenutno selektovana
            // Operation.Update - Oznacava da je u pitanju update operacija
            // this - saljemo parent objekat manage klasi 
            Manage m = new Manage(Company, Operation.Update, this);
            m.Show();

        }

        private void companiesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            // ova metoda se poziva kad se selektuje jedan red u tabeli
            if (companiesDataGrid.SelectedRows.Count == 0)
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

                for (var i = 0; i <= companiesDataGrid.Rows.Count; i++)
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

            Map map = new Map(city, address);

            map.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                MessageBox.Show("Unesite pojam za pretragu");
                return;
            }
            CompaniesDal SrchDal = new CompaniesDal();
            var result = SrchDal.SearchCompanyBy(searchBox.Text);
            if (result.Count > 0)
            {
                companiesDataGrid.Rows.Clear();

                for (var i = 0; i <= result.Count; i++)
                {
                    companiesDataGrid.Rows[i].Cells[1].Value = result[i].CompanyName;
                    companiesDataGrid.Rows[i].Cells[2].Value = result[i].City;
                    companiesDataGrid.Rows[i].Cells[3].Value = result[i].Address;
                    companiesDataGrid.Rows[i].Cells[4].Value = result[i].PhoneNumber;
                    companiesDataGrid.Rows[i].Cells[5].Value = SetStatusImage(result[i].Status);
                    companiesDataGrid.Rows[i].Cells[6].Value = result[i].FirstEntryDate;
                    companiesDataGrid.Rows[i].Cells[7].Value = result[i].Details;
                }
                MessageBox.Show("Pronadjeno je {0} rezultata", result.Count.ToString());

            }
            else
            {
                MessageBox.Show("Za dati pojam nisu nadjeni rezultati");
            }

        }

        private void InterestedBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InterestedBox.Checked == true)
            {              
                var companies = companiesBindingSource.DataSource as BindingList<Company>;

                if (companies != null && companies.Count > 0)
                {
                    foreach (var company in companies.ToList())
                    {

                        if (company.Status != Contapper.DAL.Model.Status.Interested)
                        {
                            companies.Remove(company);
                        }
                    }
                    
                    
                }
                

            }
            else
            {
                var CDal = new CompaniesDal();
                var allCompanies = CDal.GetAllCompanies();
                isReloading = true;
                companiesBindingSource.DataSource = allCompanies;
                companiesDataGrid.DataSource = companiesBindingSource;
                companiesDataGrid.Update();
                isReloading = false;
                

            }
        }

        private void NotInterestedBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotInterestedBox.Checked == true)
            {
                var companies = companiesBindingSource.DataSource as BindingList<Company>;

                if (companies != null && companies.Count > 0)
                {
                    foreach (var company in companies.ToList())
                    {

                        if (company.Status != Contapper.DAL.Model.Status.NotInterested)
                        {
                            companies.Remove(company);
                        }
                    }


                }


            }
            else
            {
                var CDal = new CompaniesDal();
                var allCompanies = CDal.GetAllCompanies();
                isReloading = true;
                companiesBindingSource.DataSource = allCompanies;
                companiesDataGrid.DataSource = companiesBindingSource;
                companiesDataGrid.Update();
                isReloading = false;


            }
        }

        private void companiesDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (companiesDataGrid.Columns[e.ColumnIndex].Name == "StatusImage")
            {
                if (isReloading)
                {
                    var row = (DataGridView)sender;
                    var statusCell = row.Rows[e.RowIndex].Cells[6].Value.ToString();
                    var status = EnumConverter.ConvertToStatusEnum(statusCell);
                    e.Value = SetStatusImage(status);
                }
                else
                {
                    var row = (DataGridView)sender;
                    var statusCell = row.Rows[e.RowIndex].Cells[5].Value.ToString();
                    var status = EnumConverter.ConvertToStatusEnum(statusCell);
                    e.Value = SetStatusImage(status);
                }
                

                
            }
            
        }
    }
}
