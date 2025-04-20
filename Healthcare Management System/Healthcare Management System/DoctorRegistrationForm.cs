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
    public partial class DoctorRegistrationForm : Form
    {
        private TextBox txtFullName, txtContactInfo, txtAddress, txtLicenseNumber, txtYearsExperience;
        private DateTimePicker dateTimePickerDOB;
        private ComboBox comboBoxGender, comboBoxSpecialization;
        private Button btnRegister, btnReset, btnBack;
        private Label lblTitle, lblFullName, lblContactInfo, lblDOB, lblGender, lblAddress,
                      lblLicenseNumber, lblSpecialization, lblYearsExperience;

        public DoctorRegistrationForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(DoctorRegistrationForm_Resize);
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Doctor Registration System";
            this.Size = new System.Drawing.Size(900, 750);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "DOCTOR REGISTRATION";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Full Name
            lblFullName = new Label();
            lblFullName.Text = "Full Name:";
            lblFullName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(64, 64, 64);
            lblFullName.AutoSize = true;
            this.Controls.Add(lblFullName);

            txtFullName = new TextBox();
            txtFullName.Font = new Font("Segoe UI", 11);
            txtFullName.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtFullName);

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

            // Medical License Number
            lblLicenseNumber = new Label();
            lblLicenseNumber.Text = "Medical License Number:";
            lblLicenseNumber.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblLicenseNumber.ForeColor = Color.FromArgb(64, 64, 64);
            lblLicenseNumber.AutoSize = true;
            this.Controls.Add(lblLicenseNumber);

            txtLicenseNumber = new TextBox();
            txtLicenseNumber.Font = new Font("Segoe UI", 11);
            txtLicenseNumber.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtLicenseNumber);

            // Specialization
            lblSpecialization = new Label();
            lblSpecialization.Text = "Specialization:";
            lblSpecialization.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblSpecialization.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpecialization.AutoSize = true;
            this.Controls.Add(lblSpecialization);

            comboBoxSpecialization = new ComboBox();
            comboBoxSpecialization.Font = new Font("Segoe UI", 11);
            comboBoxSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialization.Items.AddRange(new string[] {
                "Cardiology", "Dermatology", "Neurology", "Pediatrics",
                "Orthopedics", "Gynecology", "General Surgery", "Endocrinology",
                "Ophthalmology", "Psychiatry", "Urology", "Oncology"
            });
            comboBoxSpecialization.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(comboBoxSpecialization);

            // Years of Experience
            lblYearsExperience = new Label();
            lblYearsExperience.Text = "Years of Experience:";
            lblYearsExperience.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblYearsExperience.ForeColor = Color.FromArgb(64, 64, 64);
            lblYearsExperience.AutoSize = true;
            this.Controls.Add(lblYearsExperience);

            txtYearsExperience = new TextBox();
            txtYearsExperience.Font = new Font("Segoe UI", 11);
            txtYearsExperience.Size = new System.Drawing.Size(350, 30);
            this.Controls.Add(txtYearsExperience);

            // Buttons
            btnRegister = new Button();
            btnRegister.Text = "Register Doctor";
            btnRegister.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(76, 175, 80);
            btnRegister.ForeColor = Color.White;
            btnRegister.Size = new System.Drawing.Size(180, 45);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Click += new EventHandler(btnRegister_Click);
            this.Controls.Add(btnRegister);

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
            lblFullName.Location = new Point(padding, yOffset);
            lblContactInfo.Location = new Point(padding, lblFullName.Bottom + padding);
            lblDOB.Location = new Point(padding, lblContactInfo.Bottom + padding);
            lblGender.Location = new Point(padding, lblDOB.Bottom + padding);
            lblAddress.Location = new Point(padding, lblGender.Bottom + padding);
            lblLicenseNumber.Location = new Point(padding, lblAddress.Bottom + padding + 60);
            lblSpecialization.Location = new Point(padding, lblLicenseNumber.Bottom + padding);
            lblYearsExperience.Location = new Point(padding, lblSpecialization.Bottom + padding);

            // Right column inputs
            int inputX = this.ClientSize.Width - 400;
            txtFullName.Location = new Point(inputX, yOffset);
            txtContactInfo.Location = new Point(inputX, txtFullName.Bottom + padding);
            dateTimePickerDOB.Location = new Point(inputX, txtContactInfo.Bottom + padding);
            comboBoxGender.Location = new Point(inputX, dateTimePickerDOB.Bottom + padding);
            txtAddress.Location = new Point(inputX, comboBoxGender.Bottom + padding);
            txtLicenseNumber.Location = new Point(inputX, txtAddress.Bottom + padding);
            comboBoxSpecialization.Location = new Point(inputX, txtLicenseNumber.Bottom + padding);
            txtYearsExperience.Location = new Point(inputX, comboBoxSpecialization.Bottom + padding);

            // Buttons
            int buttonY = Math.Max(
                lblYearsExperience.Bottom + padding,
                txtYearsExperience.Bottom + padding
            ) + 20;

            btnRegister.Location = new Point(padding, buttonY);
            btnReset.Location = new Point(btnRegister.Right + padding, buttonY);
            btnBack.Location = new Point(this.ClientSize.Width - btnBack.Width - padding, buttonY);
        }

        private void DoctorRegistrationForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("Please fill all required fields", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = GenerateUsername(txtFullName.Text);
            string password = GeneratePassword();

            string message = $"Doctor Registered Successfully!\n\n" +
                            $"Doctor ID: DR{DateTime.Now:yyMMddHHmm}\n" +
                            $"Name: {txtFullName.Text}\n" +
                            $"Specialization: {comboBoxSpecialization.SelectedItem}\n\n" +
                            $"Your login credentials:\n" +
                            $"Username: {username}\n" +
                            $"Password: {password}\n\n" +
                            $"Please change your password after first login.";

            MessageBox.Show(message, "Registration Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnReset_Click(sender, e);
        }

        private string GenerateUsername(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Random randd = new Random();
                return $"user{randd.Next(1000, 9999)}";
            }

            string[] names = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Handle case where splitting results in empty array
            if (names.Length == 0)
            {
                Random randd = new Random();
                return $"user{randd.Next(1000, 9999)}";
            }

            string firstName = names[0].ToLower();
            // Traditional way to get last element instead of names[^1]
            string lastName = names.Length > 1 ? names[names.Length - 1].ToLower() : "";

            Random rand = new Random();
            int randomNum = rand.Next(100, 999);

            return string.IsNullOrEmpty(lastName)
                ? $"admin.{firstName}{randomNum}"
                : $"admin.{firstName}.{lastName}{randomNum}";
        }

        private string GeneratePassword()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz23456789!@#$%";
            Random rand = new Random();
            char[] password = new char[10];
            for (int i = 0; i < 10; i++)
            {
                password[i] = chars[rand.Next(chars.Length)];
            }
            return new string(password);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtContactInfo.Clear();
            dateTimePickerDOB.Value = DateTime.Now.AddYears(-30);
            comboBoxGender.SelectedIndex = -1;
            txtAddress.Clear();
            txtLicenseNumber.Clear();
            comboBoxSpecialization.SelectedIndex = -1;
            txtYearsExperience.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RoleSelectionForm roleForm = new RoleSelectionForm();
            roleForm.Show();
            this.Hide();
        }
        private void DoctorRegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}

   