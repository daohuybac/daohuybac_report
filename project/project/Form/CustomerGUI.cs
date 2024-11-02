using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Data.SqlClient;
using System.Xml.Linq;
using project;
using project.BAL;
using project.DAL;


namespace project
{
    public partial class CustomerGUI : Form
    {
        CustomerBAL cusBAL = new CustomerBAL();
        DepartmentDAL departBAL = new DepartmentDAL();
        AreaDAL areaBAL = new AreaDAL();
        GenderDAL genderBAL = new GenderDAL();
       




        public CustomerGUI()
        {
            InitializeComponent();
            tbEvaluate.ReadOnly = true;

        }

        private void CustomerGUI_Load(object sender, EventArgs e)
        {
           
            tbImageUrl.Visible = false;
            List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
            foreach (CustomerBEL cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Codestu, cus.Name, cus.DateOfBirth.ToString("dd/MM/yyyy"), 
                    cus.GenderName, cus.Class, cus.DepartmentName, cus.AreaName, cus.Score, cus.Phone, cus.Email, cus.Address, cus.ImageUrl);
            }
            List<DepartmentBEL> lstDepart = departBAL.ReadDepartmentList();
            foreach (DepartmentBEL depart in lstDepart)
            {
                cbDepartment.Items.Add(depart);
            }
            cbDepartment.DisplayMember = "name";
            List<AreaBEL> lstArea = areaBAL.ReadAreaList();
            foreach (AreaBEL area in lstArea)
            {
                cbArea.Items.Add(area);
            }
            cbArea.DisplayMember = "name";
            List<GenderBEL> lsGender = genderBAL.ReadGenderList();
            foreach (GenderBEL gender in lsGender)
            {
                cbGender.Items.Add(gender);
            }
            cbGender.DisplayMember = "name";
            if (lstCus.Count > 0 && !string.IsNullOrWhiteSpace(lstCus[0].ImageUrl))
            {
                pictureBox1.Image = Image.FromFile(lstCus[0].ImageUrl);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private int selectedCustomerId = -1;
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCustomer.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                selectedCustomerId = int.Parse(row.Cells[0].Value.ToString());

                tbId.Text = row.Cells[0].Value.ToString();
                tbCode.Text = row.Cells[1].Value.ToString();
                tbName.Text = row.Cells[2].Value.ToString();
                dtpDateOfBirth.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                cbGender.Text = row.Cells[4].Value.ToString();
                tbClass.Text = row.Cells[5].Value.ToString();
                cbDepartment.Text = row.Cells[6].Value.ToString();
                cbArea.Text = row.Cells[7].Value.ToString();
                tbScore.Text = row.Cells[8].Value.ToString();
                tbPhone.Text = row.Cells[9].Value.ToString();
                tbEmail.Text = row.Cells[10].Value.ToString();
                tbAddress.Text = row.Cells[11].Value.ToString();
                string imageUrl = row.Cells[12].Value.ToString();
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    pictureBox1.Image = Image.FromFile(imageUrl);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                tbId.ReadOnly = true;
                tbCode.ReadOnly = true;

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //check field constraints
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Please enter an ID.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (int.TryParse(tbId.Text, out int id) && id == 0)
            {
                MessageBox.Show("ID is not allowed to be 0.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbCode.Text))
            {
                MessageBox.Show("Please enter the student code.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter the name.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbClass.Text))
            {
                MessageBox.Show("Please enter the class.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select a department.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbArea.SelectedItem == null)
            {
                MessageBox.Show("Please select an area.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select a gender.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbScore.Text))
            {
                MessageBox.Show("Please enter the score.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Please enter the phone number.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Please enter the email.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Please enter the address.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbImageUrl.Text))
            {
                MessageBox.Show("Please choose Image.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbCode.Text.Length != 10)
            {
                MessageBox.Show("Student code must be 10 characters long.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbPhone.Text.Length != 10)
            {
                MessageBox.Show("Phone number must be 10 characters long.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbEmail.Text) || !tbEmail.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Please enter a valid Gmail address (must end with @gmail.com).", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // check ID is existed or not
            id = int.Parse(tbId.Text);
            List<CustomerBEL> existingCustomers = cusBAL.ReadCustomer();
            if (existingCustomers.Any(c => c.Id == id))
            {
                MessageBox.Show("ID already exists.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            //check student code ís existed or not
            if (existingCustomers.Any(c => c.Codestu == tbCode.Text))
            {
                MessageBox.Show("Student code already exists. Please enter a different code.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now < dateOfBirth.AddYears(age)) 
            {
                age--;
            }

            if (age < 18)
            {
                MessageBox.Show("The student must be at least 18 years old.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CustomerBEL cus = new CustomerBEL();
            cus.Id = int.Parse(tbId.Text);
            cus.Codestu = tbCode.Text;
            cus.Name = tbName.Text;
            cus.DateOfBirth = dtpDateOfBirth.Value;
            cus.Gender = (GenderBEL)cbGender.SelectedItem;
            cus.Class = tbClass.Text;
            cus.Department = (DepartmentBEL)cbDepartment.SelectedItem;
            cus.Area = (AreaBEL)cbArea.SelectedItem;
            cus.Score = decimal.Parse(tbScore.Text);
            cus.Phone = tbPhone.Text;
            cus.Email = tbEmail.Text;
            cus.Address = tbAddress.Text;
            if (!string.IsNullOrWhiteSpace(tbImageUrl.Text))
            {
                cus.ImageUrl = tbImageUrl.Text;
            }
            tbId.ReadOnly = false;
            tbCode.ReadOnly = false;


            cusBAL.NewCustomer(cus);
            dgvCustomer.Rows.Add(cus.Id, cus.Codestu, cus.Name, cus.DateOfBirth.ToString("dd/MM/yyyy"), 
                cus.Gender.Name, cus.Class, cus.Department.Name, cus.Area.Name, cus.Score, cus.Phone, cus.Email, cus.Address, cus.ImageUrl);
        }

        
        

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //check field constraints
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Please enter an ID.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbPhone.Text.Length != 10)
            {
                MessageBox.Show("Phone number must have 10 digits.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbImageUrl.Text))
            {
                MessageBox.Show("Please select an image.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbEmail.Text) || !tbEmail.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Please enter a valid Gmail address (Must end with @gmail.com).", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            if (age < 18)
            {
                MessageBox.Show("The student must be at least 18 years old.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgvCustomer.CurrentRow;
            if (row != null)
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(tbId.Text);
                cus.Codestu = tbCode.Text;
                cus.Name = tbName.Text;
                cus.DateOfBirth = dtpDateOfBirth.Value;
                cus.Gender = (GenderBEL)cbGender.SelectedItem;
                cus.Class = tbClass.Text;
                cus.Department = (DepartmentBEL)cbDepartment.SelectedItem;
                cus.Area = (AreaBEL)cbArea.SelectedItem;
                cus.Score = decimal.Parse(tbScore.Text);
                cus.Phone = tbPhone.Text;
                cus.Email = tbEmail.Text;
                cus.Address = tbAddress.Text;
                if (!string.IsNullOrWhiteSpace(tbImageUrl.Text))
                {
                    cus.ImageUrl = tbImageUrl.Text;  
                }
                


                cusBAL.EditCustomer(cus);
                row.Cells[0].Value = cus.Id;
                row.Cells[1].Value = cus.Codestu;
                row.Cells[2].Value = cus.Name;
                row.Cells[3].Value = cus.DateOfBirth.ToString("dd/MM/yyyy");
                row.Cells[4].Value = cus.GenderName;
                row.Cells[5].Value = cus.Class;
                row.Cells[6].Value = cus.DepartmentName;
                row.Cells[7].Value = cus.AreaName;
                row.Cells[8].Value = cus.Score;
                row.Cells[9].Value = cus.Phone;
                row.Cells[10].Value = cus.Email;
                row.Cells[11].Value = cus.Address;
                row.Cells[12].Value = cus.ImageUrl;
                




            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select a customer to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmation
            var confirmResult = MessageBox.Show("Are you sure you want to delete this Student?",
                                                 "Confirmation",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = selectedCustomerId;

                // delete student
                cusBAL.DeleteCustomer(cus);

                // delete from  DataGridView
                foreach (DataGridViewRow row in dgvCustomer.Rows)
                {
                    if (row.Cells[0].Value != null && (int)row.Cells[0].Value == selectedCustomerId)
                    {
                        dgvCustomer.Rows.Remove(row);
                        break;
                    }
                }

                tbId.Clear();
                tbCode.Clear();
                tbName.Clear();
                tbClass.Clear();
                tbScore.Clear();
                tbPhone.Clear();
                tbEmail.Clear();
                tbAddress.Clear();
                tbImageUrl.Clear();

                tbId.ReadOnly = false;
                tbCode.ReadOnly = false;
                pictureBox1.Image = null;

                selectedCustomerId = -1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 fr01 = new Form1();
            fr01.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = tbSearch.Text;

            if (string.IsNullOrWhiteSpace(searchInput))
            {
                MessageBox.Show("Please enter either a student code or a name.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<CustomerBEL> searchResults;

            // Check if the search input is exactly 10 characters (assuming it's a student code if it is)
            if (searchInput.Length == 10)
            {
                searchResults = cusBAL.SearchCustomersByCodestu(searchInput);
            }
            else
            {
                searchResults = cusBAL.SearchCustomers(searchInput);
            }

            // Clear and display results in DataGridView
            dgvCustomer.Rows.Clear();
            foreach (CustomerBEL cus in searchResults)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Codestu, cus.Name, cus.DateOfBirth.ToString("dd/MM/yyyy"),
                                     cus.GenderName, cus.Class, cus.DepartmentName, cus.AreaName,
                                     cus.Score, cus.Phone, cus.Email, cus.Address, cus.ImageUrl);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dgvCustomer.Rows.Clear();
            List<CustomerBEL> lstCus = cusBAL.ReadCustomer();
            foreach (CustomerBEL cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Codestu, cus.Name, cus.DateOfBirth.ToString("dd/MM/yyyy"), cus.GenderName, cus.Class,
                    cus.DepartmentName, cus.AreaName, cus.Score, cus.Phone, cus.Email, cus.Address, cus.ImageUrl);
            }
        }



        private void btnImageUrl_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                
                tbImageUrl.Text = openFileDialog.FileName;  
            }
        }

        private void tbImageUrl_TextChanged(object sender, EventArgs e)
        {
            tbImageUrl.ReadOnly = true;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbId.Clear();
            tbCode.Clear();
            tbName.Clear();
            tbClass.Clear();
            tbScore.Clear();
            tbPhone.Clear();
            tbEmail.Clear();
            tbAddress.Clear();
            tbImageUrl.Clear();
            tbId.ReadOnly = false;
            tbCode.ReadOnly = false;
            pictureBox1.Image = null;
        }

       

        private void tbScore_TextChanged(object sender, EventArgs e)
        {
            EvaluateStudent();
        }
        private void EvaluateStudent()
        {
            if (decimal.TryParse(tbScore.Text, out decimal score))
            {
                if (score > 9)
                {
                    tbEvaluate.Text = "Excellent";
                }
                else if (score >= 5)
                {
                    tbEvaluate.Text = "Good";
                }
                else
                {
                    tbEvaluate.Text = "Average";
                }
            }
            else
            {
                tbEvaluate.Clear();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
          
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "StudenManager.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    using (ExcelPackage excel = new ExcelPackage(fileInfo))
                    {
                        var worksheet = excel.Workbook.Worksheets.Add("StudenManager");
                       
                        for (int i = 0; i < dgvCustomer.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dgvCustomer.Columns[i].HeaderText;
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        
                        for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvCustomer.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dgvCustomer.Rows[i].Cells[j].Value;
                            }
                        }

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        try
                        {
                            excel.Save();
                            MessageBox.Show("Export successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error exporting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    using (ExcelPackage excel = new ExcelPackage(fileInfo))
                    {
                        var worksheet = excel.Workbook.Worksheets.First();
                        int rowCount = worksheet.Dimension.Rows;

                        dgvCustomer.Rows.Clear();
                        GenderDAL genderDAL = new GenderDAL();
                        DepartmentDAL departmentDAL = new DepartmentDAL();
                        AreaDAL areaDAL = new AreaDAL();
                        for (int row = 2; row <= rowCount; row++) 
                        {
                            try
                            {
                                
                                string genderName = worksheet.Cells[row, 5].Value.ToString();
                                int? genderId = genderDAL.GetGenderIdByName(genderName);

                                string departmentName = worksheet.Cells[row, 7].Value.ToString(); 
                                int? departmentId = departmentDAL.GetDepartmentIdByName(departmentName); 

                                string areaName = worksheet.Cells[row, 8].Value.ToString(); 
                                int? areaId = areaDAL.GetAreaIdByName(areaName);
                                if (genderId == null || departmentId == null || areaId == null)
                                {
                                    throw new Exception("One of the referenced IDs (Gender, Department, or Area) was not found.");
                                }
                                
                                CustomerBEL cus = new CustomerBEL
                                {
                                    Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                                    Codestu = worksheet.Cells[row, 2].Value.ToString(), 
                                    Name = worksheet.Cells[row, 3].Value.ToString(), 
                                    DateOfBirth = Convert.ToDateTime(worksheet.Cells[row, 4].Value),
                                    Gender = new GenderBEL { Id = (int)genderId, Name = genderName },
                                    Class = worksheet.Cells[row, 6].Value.ToString(), 
                                    Department = new DepartmentBEL { Id = (int)departmentId, Name = departmentName }, 
                                    Area = new AreaBEL { Id = (int)areaId, Name = areaName }, 
                                    Score = Convert.ToDecimal(worksheet.Cells[row, 9].Value), 
                                    Phone = worksheet.Cells[row, 10].Value.ToString(), 
                                    Email = worksheet.Cells[row, 11].Value.ToString(),
                                    Address = worksheet.Cells[row, 12].Value.ToString(), 
                                    ImageUrl = worksheet.Cells[row, 13].Value?.ToString() 
                                };
                                cusBAL.NewCustomer(cus);
                                dgvCustomer.Rows.Add(cus.Id, cus.Codestu, cus.Name, cus.DateOfBirth.ToString("dd/MM/yyyy"),
                                    cus.Gender.Name, cus.Class, cus.Department.Name, cus.Area.Name, cus.Score, cus.Phone, cus.Email, cus.Address, cus.ImageUrl);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error importing row {row}: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        MessageBox.Show("Import successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
