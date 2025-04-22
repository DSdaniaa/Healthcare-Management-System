using System;
using System.Drawing;
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
        private Panel panelMain, panelForm;

        public DoctorRegistrationForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(DoctorRegistrationForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Doctor Registration System";
            this.Size = new Size(1000, 800);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Main container panel
            panelMain = new Panel();
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Size = new Size(900, 700);
            this.Controls.Add(panelMain);

            // Form container panel
            panelForm = new Panel();
            panelForm.BackColor = Color.FromArgb(250, 250, 250);
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Size = new Size(800, 550);
            panelMain.Controls.Add(panelForm);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "DOCTOR REGISTRATION";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelForm.Controls.Add(lblTitle);

            // Full Name
            lblFullName = new Label();
            lblFullName.Text = "Full Name:";
            lblFullName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(64, 64, 64);
            lblFullName.AutoSize = true;
            panelForm.Controls.Add(lblFullName);

            txtFullName = new TextBox();
            txtFullName.Font = new Font("Segoe UI", 10);
            txtFullName.Size = new Size(300, 26);
            panelForm.Controls.Add(txtFullName);

            // Contact Info
            lblContactInfo = new Label();
            lblContactInfo.Text = "Contact Number:";
            lblContactInfo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblContactInfo.ForeColor = Color.FromArgb(64, 64, 64);
            lblContactInfo.AutoSize = true;
            panelForm.Controls.Add(lblContactInfo);

            txtContactInfo = new TextBox();
            txtContactInfo.Font = new Font("Segoe UI", 10);
            txtContactInfo.Size = new Size(300, 26);
            panelForm.Controls.Add(txtContactInfo);

            // Date of Birth
            lblDOB = new Label();
            lblDOB.Text = "Date of Birth:";
            lblDOB.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblDOB.ForeColor = Color.FromArgb(64, 64, 64);
            lblDOB.AutoSize = true;
            panelForm.Controls.Add(lblDOB);

            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Font = new Font("Segoe UI", 10);
            dateTimePickerDOB.Format = DateTimePickerFormat.Short;
            dateTimePickerDOB.Size = new Size(300, 26);
            panelForm.Controls.Add(dateTimePickerDOB);

            // Gender
            lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(64, 64, 64);
            lblGender.AutoSize = true;
            panelForm.Controls.Add(lblGender);

            comboBoxGender = new ComboBox();
            comboBoxGender.Font = new Font("Segoe UI", 10);
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.Items.AddRange(new string[] { "Male", "Female", "Other", "Prefer not to say" });
            comboBoxGender.Size = new Size(300, 26);
            panelForm.Controls.Add(comboBoxGender);

            // Address
            lblAddress = new Label();
            lblAddress.Text = "Address:";
            lblAddress.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(64, 64, 64);
            lblAddress.AutoSize = true;
            panelForm.Controls.Add(lblAddress);

            txtAddress = new TextBox();
            txtAddress.Font = new Font("Segoe UI", 10);
            txtAddress.Multiline = true;
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new Size(300, 60);
            panelForm.Controls.Add(txtAddress);

            // Medical License Number
            lblLicenseNumber = new Label();
            lblLicenseNumber.Text = "Medical License Number:";
            lblLicenseNumber.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblLicenseNumber.ForeColor = Color.FromArgb(64, 64, 64);
            lblLicenseNumber.AutoSize = true;
            panelForm.Controls.Add(lblLicenseNumber);

            txtLicenseNumber = new TextBox();
            txtLicenseNumber.Font = new Font("Segoe UI", 10);
            txtLicenseNumber.Size = new Size(300, 26);
            panelForm.Controls.Add(txtLicenseNumber);

            // Specialization
            lblSpecialization = new Label();
            lblSpecialization.Text = "Specialization:";
            lblSpecialization.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblSpecialization.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpecialization.AutoSize = true;
            panelForm.Controls.Add(lblSpecialization);

            comboBoxSpecialization = new ComboBox();
            comboBoxSpecialization.Font = new Font("Segoe UI", 10);
            comboBoxSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpecialization.Items.AddRange(new string[] {
                "Cardiology", "Dermatology", "Neurology", "Pediatrics",
                "Orthopedics", "Gynecology", "General Surgery", "Endocrinology",
                "Ophthalmology", "Psychiatry", "Urology", "Oncology"
            });
            comboBoxSpecialization.Size = new Size(300, 26);
            panelForm.Controls.Add(comboBoxSpecialization);

            // Years of Experience
            lblYearsExperience = new Label();
            lblYearsExperience.Text = "Years of Experience:";
            lblYearsExperience.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblYearsExperience.ForeColor = Color.FromArgb(64, 64, 64);
            lblYearsExperience.AutoSize = true;
            panelForm.Controls.Add(lblYearsExperience);

            txtYearsExperience = new TextBox();
            txtYearsExperience.Font = new Font("Segoe UI", 10);
            txtYearsExperience.Size = new Size(300, 26);
            panelForm.Controls.Add(txtYearsExperience);

            // Buttons
            btnRegister = new Button();
            btnRegister.Text = "Register Doctor";
            btnRegister.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(76, 175, 80);
            btnRegister.ForeColor = Color.White;
            btnRegister.Size = new Size(180, 40);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Click += new EventHandler(btnRegister_Click);
            btnRegister.MouseEnter += Button_MouseEnter;
            btnRegister.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnRegister);

            btnReset = new Button();
            btnReset.Text = "Reset Form";
            btnReset.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnReset.BackColor = Color.FromArgb(239, 83, 80);
            btnReset.ForeColor = Color.White;
            btnReset.Size = new Size(180, 40);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += new EventHandler(btnReset_Click);
            btnReset.MouseEnter += Button_MouseEnter;
            btnReset.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnReset);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158);
            btnBack.ForeColor = Color.White;
            btnBack.Size = new Size(180, 40);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new EventHandler(btnBack_Click);
            btnBack.MouseEnter += Button_MouseEnter;
            btnBack.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnBack);

            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            // Center the main panel
            panelMain.Location = new Point(
                (this.ClientSize.Width - panelMain.Width) / 2,
                (this.ClientSize.Height - panelMain.Height) / 2
            );

            // Center the form panel
            panelForm.Location = new Point(
                (panelMain.Width - panelForm.Width) / 2,
                20
            );

            int padding = 20;
            int yOffset = lblTitle.Bottom + padding * 2;

            // Left column labels
            lblFullName.Location = new Point(padding * 2, yOffset);
            lblContactInfo.Location = new Point(padding * 2, lblFullName.Bottom + padding);
            lblDOB.Location = new Point(padding * 2, lblContactInfo.Bottom + padding);
            lblGender.Location = new Point(padding * 2, lblDOB.Bottom + padding);
            lblAddress.Location = new Point(padding * 2, lblGender.Bottom + padding);
            lblLicenseNumber.Location = new Point(padding * 2, lblAddress.Bottom + padding + 60);
            lblSpecialization.Location = new Point(padding * 2, lblLicenseNumber.Bottom + padding);
            lblYearsExperience.Location = new Point(padding * 2, lblSpecialization.Bottom + padding);

            // Right column inputs
            int inputX = panelForm.Width - 350;
            txtFullName.Location = new Point(inputX, yOffset);
            txtContactInfo.Location = new Point(inputX, txtFullName.Bottom + padding);
            dateTimePickerDOB.Location = new Point(inputX, txtContactInfo.Bottom + padding);
            comboBoxGender.Location = new Point(inputX, dateTimePickerDOB.Bottom + padding);
            txtAddress.Location = new Point(inputX, comboBoxGender.Bottom + padding);
            txtLicenseNumber.Location = new Point(inputX, txtAddress.Bottom + padding);
            comboBoxSpecialization.Location = new Point(inputX, txtLicenseNumber.Bottom + padding);
            txtYearsExperience.Location = new Point(inputX, comboBoxSpecialization.Bottom + padding);

            // Title position
            lblTitle.Location = new Point(
                (panelForm.Width - lblTitle.Width) / 2,
                padding * 2
            );

            // Buttons position
            int buttonY = panelMain.Height - btnRegister.Height - 30;
            int centerX = panelMain.Width / 2;

            btnRegister.Location = new Point(centerX - btnRegister.Width - 20, buttonY);
            btnReset.Location = new Point(centerX + 20, buttonY);
            btnBack.Location = new Point(panelMain.Width - btnBack.Width - 30, buttonY);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(
                Math.Min(button.BackColor.R + 30, 255),
                Math.Min(button.BackColor.G + 30, 255),
                Math.Min(button.BackColor.B + 30, 255)
            );
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == btnRegister)
                button.BackColor = Color.FromArgb(76, 175, 80);
            else if (button == btnReset)
                button.BackColor = Color.FromArgb(239, 83, 80);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(158, 158, 158);
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

            if (names.Length == 0)
            {
                Random randd = new Random();
                return $"user{randd.Next(1000, 9999)}";
            }

            string firstName = names[0].ToLower();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Add subtle shadow effect to main panel
            ControlPaint.DrawBorder(e.Graphics, panelMain.Bounds,
                Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid);

            // Add outer glow effect
            using (Pen pen = new Pen(Color.FromArgb(220, 230, 240), 10))
            {
                Rectangle rect = new Rectangle(5, 5, this.ClientSize.Width - 10, this.ClientSize.Height - 10);
                e.Graphics.DrawRectangle(pen, rect);
            }

            // Add styling to form panel
            using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
            {
                e.Graphics.DrawRectangle(pen, panelForm.Left, panelForm.Top, panelForm.Width, panelForm.Height);
            }
        }

        private void DoctorRegistrationForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}

    


   