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
    public partial class AppointmentListForm : Form
    {
        private DataGridView dataGridViewAppointments;
        private Button btnRefresh, btnAddAppointment, btnRemoveAppointment, btnBack, btnUpdate;
        private TextBox txtSearch;
        private Label lblTitle, lblSearch;
        private List<Appointment> appointmentList;

        public AppointmentListForm()
        {
            InitializeComponent();
            CreateControls();
            LoadDummyData();
            StyleDataGridView();
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Appointment Scheduling System";
            this.Size = new System.Drawing.Size(1200, 700);
            this.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue background
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += new EventHandler(Form_Resize);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "APPOINTMENT SCHEDULING SYSTEM";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204); // Dark blue
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Search Components
            lblSearch = new Label();
            lblSearch.Text = "Search Appointments:";
            lblSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSearch.AutoSize = true;
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSearch.Size = new System.Drawing.Size(250, 26);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            this.Controls.Add(txtSearch);

            // DataGridView
            dataGridViewAppointments = new DataGridView();
            dataGridViewAppointments.Location = new System.Drawing.Point(50, 100);
            dataGridViewAppointments.Size = new System.Drawing.Size(1100, 450);
            dataGridViewAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAppointments.ReadOnly = true;
            dataGridViewAppointments.RowHeadersVisible = false;
            dataGridViewAppointments.AllowUserToAddRows = false;
            dataGridViewAppointments.AllowUserToDeleteRows = false;
            dataGridViewAppointments.AllowUserToResizeRows = false;
            this.Controls.Add(dataGridViewAppointments);

            // Buttons
            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRefresh.BackColor = Color.FromArgb(0, 122, 204); // Blue
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Size = new System.Drawing.Size(150, 40);
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
            this.Controls.Add(btnRefresh);

            btnAddAppointment = new Button();
            btnAddAppointment.Text = "Add Appointment";
            btnAddAppointment.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAddAppointment.BackColor = Color.FromArgb(76, 175, 80); // Green
            btnAddAppointment.ForeColor = Color.White;
            btnAddAppointment.Size = new System.Drawing.Size(150, 40);
            btnAddAppointment.TextAlign = ContentAlignment.MiddleCenter;
            btnAddAppointment.Click += new EventHandler(btnAddAppointment_Click);
            this.Controls.Add(btnAddAppointment);

            btnRemoveAppointment = new Button();
            btnRemoveAppointment.Text = "Remove Appointment";
            btnRemoveAppointment.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRemoveAppointment.BackColor = Color.FromArgb(211, 47, 47); // Red
            btnRemoveAppointment.ForeColor = Color.White;
            btnRemoveAppointment.Size = new System.Drawing.Size(150, 40);
            btnRemoveAppointment.TextAlign = ContentAlignment.MiddleCenter;
            btnRemoveAppointment.Click += new EventHandler(btnRemoveAppointment_Click);
            this.Controls.Add(btnRemoveAppointment);

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUpdate.BackColor = Color.FromArgb(255, 193, 7); // Amber
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Size = new System.Drawing.Size(150, 40);
            btnUpdate.TextAlign = ContentAlignment.MiddleCenter;
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.Controls.Add(btnUpdate);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158); // Gray
            btnBack.ForeColor = Color.White;
            btnBack.Size = new System.Drawing.Size(150, 40);
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            UpdateControlPositions();
        }

        private void StyleDataGridView()
        {
            dataGridViewAppointments.BorderStyle = BorderStyle.None;
            dataGridViewAppointments.BackgroundColor = Color.White;
            dataGridViewAppointments.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewAppointments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dataGridViewAppointments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewAppointments.EnableHeadersVisualStyles = false;
            dataGridViewAppointments.GridColor = Color.FromArgb(224, 224, 224);
            dataGridViewAppointments.RowTemplate.Height = 30;
            dataGridViewAppointments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Format DateTime column
            if (dataGridViewAppointments.Columns["DateTime"] != null)
            {
                dataGridViewAppointments.Columns["DateTime"].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            }
        }

        private void LoadDummyData()
        {
            appointmentList = new List<Appointment>
            {
                new Appointment {
                    AppointmentID = "APT101",
                    PatientName = "John Doe",
                    Doctor = "Dr. Smith (Cardiology)",
                    DateTime = DateTime.Now.AddDays(1).AddHours(10),
                    Reason = "Routine Checkup",
                    Status = "Scheduled",
                    PatientContact = "555-0101"
                },
                new Appointment {
                    AppointmentID = "APT102",
                    PatientName = "Jane Smith",
                    Doctor = "Dr. Johnson (Dermatology)",
                    DateTime = DateTime.Now.AddDays(2).AddHours(14),
                    Reason = "Skin Allergy Test",
                    Status = "Confirmed",
                    PatientContact = "555-0102"
                },
                new Appointment {
                    AppointmentID = "APT103",
                    PatientName = "Robert Johnson",
                    Doctor = "Dr. Williams (Neurology)",
                    DateTime = DateTime.Now.AddDays(1).AddHours(11),
                    Reason = "Migraine Consultation",
                    Status = "Scheduled",
                    PatientContact = "555-0103"
                },
                new Appointment {
                    AppointmentID = "APT104",
                    PatientName = "Emily Davis",
                    Doctor = "Dr. Brown (Pediatrics)",
                    DateTime = DateTime.Now.AddDays(3).AddHours(9),
                    Reason = "Child Vaccination",
                    Status = "Confirmed",
                    PatientContact = "555-0104"
                },
                new Appointment {
                    AppointmentID = "APT105",
                    PatientName = "Michael Wilson",
                    Doctor = "Dr. Miller (Orthopedics)",
                    DateTime = DateTime.Now.AddDays(4).AddHours(15),
                    Reason = "Knee Pain Evaluation",
                    Status = "Pending",
                    PatientContact = "555-0105"
                },
                new Appointment {
                    AppointmentID = "APT106",
                    PatientName = "Sarah Thompson",
                    Doctor = "Dr. Anderson (Gynecology)",
                    DateTime = DateTime.Now.AddDays(2).AddHours(10),
                    Reason = "Annual Checkup",
                    Status = "Scheduled",
                    PatientContact = "555-0106"
                },
                new Appointment {
                    AppointmentID = "APT107",
                    PatientName = "David Lee",
                    Doctor = "Dr. Garcia (General Surgery)",
                    DateTime = DateTime.Now.AddDays(5).AddHours(13),
                    Reason = "Post-Op Follow-up",
                    Status = "Confirmed",
                    PatientContact = "555-0107"
                },
                new Appointment {
                    AppointmentID = "APT108",
                    PatientName = "Jennifer Adams",
                    Doctor = "Dr. Martinez (Endocrinology)",
                    DateTime = DateTime.Now.AddDays(3).AddHours(11),
                    Reason = "Diabetes Management",
                    Status = "Scheduled",
                    PatientContact = "555-0108"
                },
                new Appointment {
                    AppointmentID = "APT109",
                    PatientName = "Thomas Clark",
                    Doctor = "Dr. Taylor (Ophthalmology)",
                    DateTime = DateTime.Now.AddDays(4).AddHours(10),
                    Reason = "Eye Exam",
                    Status = "Pending",
                    PatientContact = "555-0109"
                },
                new Appointment {
                    AppointmentID = "APT110",
                    PatientName = "Lisa Rodriguez",
                    Doctor = "Dr. Hernandez (Psychiatry)",
                    DateTime = DateTime.Now.AddDays(6).AddHours(14),
                    Reason = "Therapy Session",
                    Status = "Confirmed",
                    PatientContact = "555-0110"
                },
                new Appointment {
                    AppointmentID = "APT111",
                    PatientName = "James Moore",
                    Doctor = "Dr. Jackson (Urology)",
                    DateTime = DateTime.Now.AddDays(2).AddHours(16),
                    Reason = "Prostate Exam",
                    Status = "Scheduled",
                    PatientContact = "555-0111"
                },
                new Appointment {
                    AppointmentID = "APT112",
                    PatientName = "Patricia White",
                    Doctor = "Dr. Martin (Oncology)",
                    DateTime = DateTime.Now.AddDays(7).AddHours(10),
                    Reason = "Chemotherapy Consultation",
                    Status = "Confirmed",
                    PatientContact = "555-0112"
                }
            };

            dataGridViewAppointments.DataSource = appointmentList;
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
            dataGridViewAppointments.Location = new Point(padding, txtSearch.Bottom + padding);
            dataGridViewAppointments.Size = new Size(this.ClientSize.Width - 2 * padding,
                this.ClientSize.Height - txtSearch.Bottom - 3 * padding - 50);

            // Buttons
            int buttonY = dataGridViewAppointments.Bottom + padding;
            btnRefresh.Location = new Point(padding, buttonY);
            btnAddAppointment.Location = new Point(btnRefresh.Right + padding, buttonY);
            btnRemoveAppointment.Location = new Point(btnAddAppointment.Right + padding, buttonY);
            btnUpdate.Location = new Point(btnRemoveAppointment.Right + padding, buttonY);
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
                dataGridViewAppointments.DataSource = appointmentList;
                return;
            }

            var filteredList = appointmentList.Where(a =>
                a.PatientName.ToLower().Contains(searchText) ||
                a.Doctor.ToLower().Contains(searchText) ||
                a.AppointmentID.ToLower().Contains(searchText)).ToList();

            if (filteredList.Count == 0)
            {
                MessageBox.Show("No matching appointments found.", "Search Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewAppointments.DataSource = null;
            }
            else
            {
                dataGridViewAppointments.DataSource = filteredList;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDummyData();
            txtSearch.Clear();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentSchedulingForm addAppointmentForm = new AppointmentSchedulingForm();
            addAppointmentForm.Show();
            this.Hide();
        }

        private void btnRemoveAppointment_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedAppointment = (Appointment)dataGridViewAppointments.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show($"Are you sure you want to remove the appointment for {selectedAppointment.PatientName} with {selectedAppointment.Doctor}?",
                "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                appointmentList.Remove(selectedAppointment);
                dataGridViewAppointments.DataSource = null;
                dataGridViewAppointments.DataSource = appointmentList;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Placeholder for update functionality
            // Currently does nothing as requested
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RoleSelectionLogin roleForm = new RoleSelectionLogin();
            roleForm.Show();
            this.Hide();
        }

        public void AddNewAppointment(Appointment newAppointment)
        {
            appointmentList.Add(newAppointment);
            dataGridViewAppointments.DataSource = null;
            dataGridViewAppointments.DataSource = appointmentList;
        }

        private void AppointmentListForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }

    public class Appointment
    {
        public string AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string PatientContact { get; set; }
    }
}

