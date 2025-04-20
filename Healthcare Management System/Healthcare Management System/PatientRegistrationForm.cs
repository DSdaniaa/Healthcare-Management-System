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
    public partial class PatientRegistrationForm : Form
    {
        private TextBox txtPatientName, txtContactInfo, txtAddress, txtEmergencyContact;
        private DateTimePicker dateTimePickerDOB;
        private ComboBox comboBoxGender, comboBoxBloodType;
        private Button btnSubmit, btnReset, btnBack;
        private Label lblTitle, lblPatientName, lblContactInfo, lblDOB, lblGender, lblAddress, lblEmergencyContact, lblBloodType;

        public PatientRegistrationForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(PatientRegistrationForm_Resize);
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Patient Registration System";
            this.Size = new System.Drawing.Size(900, 750); // Slightly taller to accommodate all controls
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "PATIENT REGISTRATION";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Patient Name
            lblPatientName = new Label();
            lblPatientName.Text = "Full Name:";
            lblPatientName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(64, 64, 64);
            lblPatientName.AutoSize = true;
            this.Controls.Add(lblPatientName);

            txtPatientName = new TextBox();
            txtPatientName.Font = new Font("Segoe UI", 11);
            txtPatientName.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtPatientName);

            // Contact Info
            lblContactInfo = new Label();
            lblContactInfo.Text = "Contact Number:";
            lblContactInfo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblContactInfo.ForeColor = Color.FromArgb(64, 64, 64);
            lblContactInfo.AutoSize = true;
            this.Controls.Add(lblContactInfo);

            txtContactInfo = new TextBox();
            txtContactInfo.Font = new Font("Segoe UI", 11);
            txtContactInfo.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtContactInfo);

            // Date of Birth
            lblDOB = new Label();
            lblDOB.Text = "Date of Birth:";
            lblDOB.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(64, 64, 64);
            lblDOB.AutoSize = true;
            this.Controls.Add(lblDOB);

            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Font = new Font("Segoe UI", 11);
            dateTimePickerDOB.Format = DateTimePickerFormat.Short;
            dateTimePickerDOB.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(dateTimePickerDOB);

            // Gender
            lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(64, 64, 64);
            lblGender.AutoSize = true;
            this.Controls.Add(lblGender);

            comboBoxGender = new ComboBox();
            comboBoxGender.Font = new Font("Segoe UI", 11);
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Items.AddRange(new string[] { "Male", "Female", "Other", "Prefer not to say" });
            comboBoxGender.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(comboBoxGender);

            // Blood Type
            lblBloodType = new Label();
            lblBloodType.Text = "Blood Type:";
            lblBloodType.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblBloodType.ForeColor = Color.FromArgb(64, 64, 64);
            lblBloodType.AutoSize = true;
            this.Controls.Add(lblBloodType);

            comboBoxBloodType = new ComboBox();
            comboBoxBloodType.Font = new Font("Segoe UI", 11);
            comboBoxBloodType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBloodType.Items.AddRange(new string[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-", "Unknown" });
            comboBoxBloodType.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(comboBoxBloodType);

            // Address
            lblAddress = new Label();
            lblAddress.Text = "Address:";
            lblAddress.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(64, 64, 64);
            lblAddress.AutoSize = true;
            this.Controls.Add(lblAddress);

            txtAddress = new TextBox();
            txtAddress.Font = new Font("Segoe UI", 11);
            txtAddress.Multiline = true;
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new System.Drawing.Size(350, 60);
            this.Controls.Add(txtAddress);

            // Emergency Contact
            lblEmergencyContact = new Label();
            lblEmergencyContact.Text = "Emergency Contact:";
            lblEmergencyContact.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblEmergencyContact.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmergencyContact.AutoSize = true;
            this.Controls.Add(lblEmergencyContact);

            txtEmergencyContact = new TextBox();
            txtEmergencyContact.Font = new Font("Segoe UI", 11);
            txtEmergencyContact.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtEmergencyContact);

            // Buttons
            btnSubmit = new Button();
            btnSubmit.Text = "Register Patient";
            btnSubmit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSubmit.BackColor = Color.FromArgb(76, 175, 80);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Size = new System.Drawing.Size(180, 45);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.Controls.Add(btnSubmit);

            btnReset = new Button();
            btnReset.Text = "Reset Form";
            btnReset.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnReset.BackColor = Color.FromArgb(239, 83, 80);
            btnReset.ForeColor = Color.White;
            btnReset.Size = new System.Drawing.Size(180, 45);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += new EventHandler(btnReset_Click);
            this.Controls.Add(btnReset);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158);
            btnBack.ForeColor = Color.White;
            btnBack.Size = new System.Drawing.Size(180, 45);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int padding = 30;
            int yOffset = lblTitle.Bottom + padding;

            // Left column labels
            lblPatientName.Location = new Point(padding, yOffset);
            lblContactInfo.Location = new Point(padding, lblPatientName.Bottom + padding);
            lblDOB.Location = new Point(padding, lblContactInfo.Bottom + padding);
            lblGender.Location = new Point(padding, lblDOB.Bottom + padding);
            lblBloodType.Location = new Point(padding, lblGender.Bottom + padding);
            lblAddress.Location = new Point(padding, lblBloodType.Bottom + padding);
            lblEmergencyContact.Location = new Point(padding, lblAddress.Bottom + padding + 60); // Extra space for address box

            // Right column inputs
            int inputX = this.ClientSize.Width - 400;
            txtPatientName.Location = new Point(inputX, yOffset);
            txtContactInfo.Location = new Point(inputX, txtPatientName.Bottom + padding);
            dateTimePickerDOB.Location = new Point(inputX, txtContactInfo.Bottom + padding);
            comboBoxGender.Location = new Point(inputX, dateTimePickerDOB.Bottom + padding);
            comboBoxBloodType.Location = new Point(inputX, comboBoxGender.Bottom + padding);
            txtAddress.Location = new Point(inputX, comboBoxBloodType.Bottom + padding);
            txtEmergencyContact.Location = new Point(inputX, txtAddress.Bottom + padding);

            // Buttons - positioned below all other controls with proper spacing
            int buttonY = Math.Max(
                lblEmergencyContact.Bottom + padding,
                txtEmergencyContact.Bottom + padding
            ) + 20; // Extra space before buttons

            btnSubmit.Location = new Point(padding, buttonY);
            btnReset.Location = new Point(btnSubmit.Right + padding, buttonY);
            btnBack.Location = new Point(this.ClientSize.Width - btnBack.Width - padding, buttonY);
        }

        private void PatientRegistrationForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter patient name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patientID = GeneratePatientID();
            string message = $"Patient Registered Successfully!\n\n" +
                            $"Patient ID: {patientID}\n" +
                            $"Name: {txtPatientName.Text}\n" +
                            $"Contact: {txtContactInfo.Text}\n" +
                            $"DOB: {dateTimePickerDOB.Value.ToShortDateString()}\n" +
                            $"Gender: {comboBoxGender.SelectedItem ?? "Not specified"}\n" +
                            $"Blood Type: {comboBoxBloodType.SelectedItem ?? "Unknown"}";

            MessageBox.Show(message, "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReset_Click(sender, e);
        }

        private string GeneratePatientID()
        {
            Random random = new Random();
            return "PAT" + DateTime.Now.ToString("yyMMdd") + random.Next(100, 999);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPatientName.Clear();
            txtContactInfo.Clear();
            dateTimePickerDOB.Value = DateTime.Now.AddYears(-18);
            comboBoxGender.SelectedIndex = -1;
            comboBoxBloodType.SelectedIndex = -1;
            txtAddress.Clear();
            txtEmergencyContact.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RoleSelectionForm roleForm = new RoleSelectionForm();
            roleForm.Show();
            this.Hide();
        }

        private void PatientRegistrationForm_Load(object sender, EventArgs e)
        {
            dateTimePickerDOB.Value = DateTime.Now.AddYears(-18);
        }
    }
}