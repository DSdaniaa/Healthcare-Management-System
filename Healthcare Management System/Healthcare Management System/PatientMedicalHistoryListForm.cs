using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_Management_System
{
    public partial class PatientMedicalHistoryListForm : Form
    {
        private DataGridView dataGridViewMedicalHistory;
        private Button btnRefresh, btnAddPatient, btnRemovePatient, btnBack, btnUpdate;
        private TextBox txtSearch;
        private Label lblTitle, lblSearch;
        private List<MedicalHistory> medicalHistoryList;

        public PatientMedicalHistoryListForm()
        {
            InitializeComponent();
            CreateControls();
            LoadDummyData();
            StyleDataGridView();
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Patient Medical Records";
            this.Size = new System.Drawing.Size(1200, 700);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += new EventHandler(Form_Resize);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "PATIENT MEDICAL RECORDS";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Search Components
            lblSearch = new Label();
            lblSearch.Text = "Search Patient:";
            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSearch.AutoSize = true;
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSearch.Size = new System.Drawing.Size(250, 26);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            this.Controls.Add(txtSearch);

            // DataGridView
            dataGridViewMedicalHistory = new DataGridView();
            dataGridViewMedicalHistory.Location = new System.Drawing.Point(50, 100);
            dataGridViewMedicalHistory.Size = new System.Drawing.Size(1100, 450);
            dataGridViewMedicalHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMedicalHistory.ReadOnly = true;
            dataGridViewMedicalHistory.RowHeadersVisible = false;
            dataGridViewMedicalHistory.AllowUserToAddRows = false;
            dataGridViewMedicalHistory.AllowUserToDeleteRows = false;
            dataGridViewMedicalHistory.AllowUserToResizeRows = false;
            this.Controls.Add(dataGridViewMedicalHistory);

            // Buttons
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh Records";
            btnRefresh.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRefresh.BackColor = Color.FromArgb(0, 122, 204);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Size = new System.Drawing.Size(150, 40);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            this.Controls.Add(btnRefresh);

            btnAddPatient = new Button();
            btnAddPatient.Text = "Add New Patient";
            btnAddPatient.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAddPatient.BackColor = Color.FromArgb(76, 175, 80);
            btnAddPatient.ForeColor = Color.White;
            btnAddPatient.Size = new System.Drawing.Size(150, 40);
            btnAddPatient.Click += new EventHandler(btnAddPatient_Click);
            this.Controls.Add(btnAddPatient);

            btnRemovePatient = new Button();
            btnRemovePatient.Text = "Remove Patient";
            btnRemovePatient.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRemovePatient.BackColor = Color.FromArgb(211, 47, 47);
            btnRemovePatient.ForeColor = Color.White;
            btnRemovePatient.Size = new System.Drawing.Size(150, 40);
            btnRemovePatient.Click += new EventHandler(btnRemovePatient_Click);
            this.Controls.Add(btnRemovePatient);

            // New Update Button
            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUpdate.BackColor = Color.FromArgb(255, 193, 7); // Amber color
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Size = new System.Drawing.Size(150, 40);
            this.Controls.Add(btnUpdate);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158);
            btnBack.ForeColor = Color.White;
            btnBack.Size = new System.Drawing.Size(150, 40);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            UpdateControlPositions();
        }

        private void StyleDataGridView()
        {
            dataGridViewMedicalHistory.BorderStyle = BorderStyle.None;
            dataGridViewMedicalHistory.BackgroundColor = Color.White;
            dataGridViewMedicalHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewMedicalHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewMedicalHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dataGridViewMedicalHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewMedicalHistory.EnableHeadersVisualStyles = false;
            dataGridViewMedicalHistory.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewMedicalHistory.RowTemplate.Height = 30;
            dataGridViewMedicalHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewMedicalHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void LoadDummyData()
        {
            medicalHistoryList = new List<MedicalHistory>
            {
                new MedicalHistory
                {
                    PatientID = "PAT101",
                    PatientName = "John Doe",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = "Male",
                    BloodType = "A+",
                    PastDisease = "Hypertension, Appendectomy (2015)",
                    Allergies = "None",
                    FamilyHistory = "Father: Diabetes, Mother: Hypertension",
                    SurgicalHistory = "Appendectomy (2015)",
                    CurrentMedication = "Lisinopril 10mg daily",
                    LastVisitDate = new DateTime(2023, 5, 10),
                    NextAppointment = new DateTime(2023, 11, 15)
                },
                new MedicalHistory
                {
                    PatientID = "PAT102",
                    PatientName = "Jane Smith",
                    DateOfBirth = new DateTime(1985, 8, 20),
                    Gender = "Female",
                    BloodType = "B-",
                    PastDisease = "Asthma, Gestational Diabetes",
                    Allergies = "Penicillin, Shellfish",
                    FamilyHistory = "Mother: Heart Disease, Father: High Cholesterol",
                    SurgicalHistory = "C-Section (2018), Tonsillectomy (2005)",
                    CurrentMedication = "Albuterol PRN, Metformin 500mg BID",
                    LastVisitDate = new DateTime(2023, 6, 22),
                    NextAppointment = new DateTime(2023, 12, 10)
                },
                new MedicalHistory
                {
                    PatientID = "PAT103",
                    PatientName = "Alice Johnson",
                    DateOfBirth = new DateTime(1975, 3, 10),
                    Gender = "Female",
                    BloodType = "O+",
                    PastDisease = "Type 2 Diabetes, Osteoarthritis",
                    Allergies = "Sulfa drugs, Latex",
                    FamilyHistory = "Both parents: Cancer",
                    SurgicalHistory = "Knee Replacement (2020), Hysterectomy (2015)",
                    CurrentMedication = "Metformin 1000mg BID, Tylenol PRN",
                    LastVisitDate = new DateTime(2023, 7, 5),
                    NextAppointment = new DateTime(2023, 10, 30)
                },
                new MedicalHistory
                {
                    PatientID = "PAT104",
                    PatientName = "Robert Brown",
                    DateOfBirth = new DateTime(1980, 12, 25),
                    Gender = "Male",
                    BloodType = "AB+",
                    PastDisease = "High Cholesterol, GERD",
                    Allergies = "Pollen, Dust Mites",
                    FamilyHistory = "Father: Hypertension, Mother: Stroke",
                    SurgicalHistory = "Gallbladder Removal (2019), Hernia Repair (2012)",
                    CurrentMedication = "Atorvastatin 20mg daily, Omeprazole 20mg daily",
                    LastVisitDate = new DateTime(2023, 8, 18),
                    NextAppointment = new DateTime(2024, 2, 15)
                },
                new MedicalHistory
                {
                    PatientID = "PAT105",
                    PatientName = "Emily Davis",
                    DateOfBirth = new DateTime(1995, 7, 30),
                    Gender = "Female",
                    BloodType = "A-",
                    PastDisease = "Migraines, Anemia",
                    Allergies = "NSAIDs, Eggs",
                    FamilyHistory = "Mother: Migraines, Father: None",
                    SurgicalHistory = "None",
                    CurrentMedication = "Iron supplements, Sumatriptan PRN",
                    LastVisitDate = new DateTime(2023, 9, 2),
                    NextAppointment = new DateTime(2023, 12, 2)
                },
                new MedicalHistory
                {
                    PatientID = "PAT106",
                    PatientName = "Michael Wilson",
                    DateOfBirth = new DateTime(1988, 2, 14),
                    Gender = "Male",
                    BloodType = "B+",
                    PastDisease = "Hypertension, Sleep Apnea",
                    Allergies = "None",
                    FamilyHistory = "Father: Heart Disease, Mother: Diabetes",
                    SurgicalHistory = "Tonsillectomy (1995), Wisdom Teeth Removal (2006)",
                    CurrentMedication = "Lisinopril 5mg daily, CPAP therapy",
                    LastVisitDate = new DateTime(2023, 6, 30),
                    NextAppointment = new DateTime(2023, 12, 30)
                }
            };

            dataGridViewMedicalHistory.DataSource = medicalHistoryList;
        }

        private void UpdateControlPositions()
        {
            int padding = 20;

            // Title
            lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.Width) / 2, padding);

            // Search components
            lblSearch.Location = new Point(padding, lblTitle.Bottom + padding + 10);
            txtSearch.Location = new Point(lblSearch.Right + 10, lblTitle.Bottom + padding + 5);

            // DataGridView
            dataGridViewMedicalHistory.Location = new Point(padding, txtSearch.Bottom + padding);
            dataGridViewMedicalHistory.Size = new Size(this.ClientSize.Width - 2 * padding,
                this.ClientSize.Height - txtSearch.Bottom - 3 * padding - 50);

            // Buttons (updated to include Update button)
            int buttonY = dataGridViewMedicalHistory.Bottom + padding;
            btnRefresh.Location = new Point(padding, buttonY);
            btnAddPatient.Location = new Point(btnRefresh.Right + padding, buttonY);
            btnRemovePatient.Location = new Point(btnAddPatient.Right + padding, buttonY);
            btnUpdate.Location = new Point(btnRemovePatient.Right + padding, buttonY);
            btnBack.Location = new Point(this.ClientSize.Width - btnBack.Width - padding, buttonY);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridViewMedicalHistory.DataSource = medicalHistoryList;
                return;
            }

            var filteredList = medicalHistoryList.Where(p =>
                p.PatientName.ToLower().Contains(searchText) ||
                p.PatientID.ToLower().Contains(searchText)).ToList();

            if (filteredList.Count == 0)
            {
                MessageBox.Show("No matching patient records found.", "Search Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewMedicalHistory.DataSource = null;
            }
            else
            {
                dataGridViewMedicalHistory.DataSource = filteredList;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDummyData();
            txtSearch.Clear();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatientForm = new AddPatientForm(this);
            addPatientForm.Show();
            this.Hide();
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            if (dataGridViewMedicalHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPatient = (MedicalHistory)dataGridViewMedicalHistory.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show($"Are you sure you want to remove {selectedPatient.PatientName}?",
                "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                medicalHistoryList.Remove(selectedPatient);
                dataGridViewMedicalHistory.DataSource = null;
                dataGridViewMedicalHistory.DataSource = medicalHistoryList;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RoleSelectionLogin roleForm = new RoleSelectionLogin();
            roleForm.Show();
            this.Hide();
        }

        public void AddNewPatient(MedicalHistory newPatient)
        {
            medicalHistoryList.Add(newPatient);
            dataGridViewMedicalHistory.DataSource = null;
            dataGridViewMedicalHistory.DataSource = medicalHistoryList;
        }

        private void PatientMedicalHistoryListForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }

    public class MedicalHistory
    {
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string PastDisease { get; set; }
        public string Allergies { get; set; }
        public string FamilyHistory { get; set; }
        public string SurgicalHistory { get; set; }
        public string CurrentMedication { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime NextAppointment { get; set; }
    }
}

