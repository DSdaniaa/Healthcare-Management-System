using System;
using System.Drawing;
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
        private Panel panelMain, panelForm;

        public PatientRegistrationForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(PatientRegistrationForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Patient Registration System";
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
            lblTitle.Text = "PATIENT REGISTRATION";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelForm.Controls.Add(lblTitle);

            // Patient Name
            lblPatientName = new Label();
            lblPatientName.Text = "Full Name:";
            lblPatientName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(64, 64, 64);
            lblPatientName.AutoSize = true;
            panelForm.Controls.Add(lblPatientName);

            txtPatientName = new TextBox();
            txtPatientName.Font = new Font("Segoe UI", 10);
            txtPatientName.Size = new Size(300, 26);
            panelForm.Controls.Add(txtPatientName);

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
            dateTimePickerDOB.Value = DateTime.Now.AddYears(-18);
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

            // Blood Type
            lblBloodType = new Label();
            lblBloodType.Text = "Blood Type:";
            lblBloodType.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblBloodType.ForeColor = Color.FromArgb(64, 64, 64);
            lblBloodType.AutoSize = true;
            panelForm.Controls.Add(lblBloodType);

            comboBoxBloodType = new ComboBox();
            comboBoxBloodType.Font = new Font("Segoe UI", 10);
            comboBoxBloodType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBloodType.Items.AddRange(new string[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-", "Unknown" });
            comboBoxBloodType.Size = new Size(300, 26);
            panelForm.Controls.Add(comboBoxBloodType);

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

            // Emergency Contact
            lblEmergencyContact = new Label();
            lblEmergencyContact.Text = "Emergency Contact:";
            lblEmergencyContact.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEmergencyContact.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmergencyContact.AutoSize = true;
            panelForm.Controls.Add(lblEmergencyContact);

            txtEmergencyContact = new TextBox();
            txtEmergencyContact.Font = new Font("Segoe UI", 10);
            txtEmergencyContact.Size = new Size(300, 26);
            panelForm.Controls.Add(txtEmergencyContact);

            // Buttons
            btnSubmit = new Button();
            btnSubmit.Text = "Register Patient";
            btnSubmit.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSubmit.BackColor = Color.FromArgb(76, 175, 80);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Size = new Size(180, 40);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            btnSubmit.MouseEnter += Button_MouseEnter;
            btnSubmit.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnSubmit);

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
            lblPatientName.Location = new Point(padding * 2, yOffset);
            lblContactInfo.Location = new Point(padding * 2, lblPatientName.Bottom + padding);
            lblDOB.Location = new Point(padding * 2, lblContactInfo.Bottom + padding);
            lblGender.Location = new Point(padding * 2, lblDOB.Bottom + padding);
            lblBloodType.Location = new Point(padding * 2, lblGender.Bottom + padding);
            lblAddress.Location = new Point(padding * 2, lblBloodType.Bottom + padding);
            lblEmergencyContact.Location = new Point(padding * 2, lblAddress.Bottom + padding + 60);

            // Right column inputs
            int inputX = panelForm.Width - 350;
            txtPatientName.Location = new Point(inputX, yOffset);
            txtContactInfo.Location = new Point(inputX, txtPatientName.Bottom + padding);
            dateTimePickerDOB.Location = new Point(inputX, txtContactInfo.Bottom + padding);
            comboBoxGender.Location = new Point(inputX, dateTimePickerDOB.Bottom + padding);
            comboBoxBloodType.Location = new Point(inputX, comboBoxGender.Bottom + padding);
            txtAddress.Location = new Point(inputX, comboBoxBloodType.Bottom + padding);
            txtEmergencyContact.Location = new Point(inputX, txtAddress.Bottom + padding);

            // Title position
            lblTitle.Location = new Point(
                (panelForm.Width - lblTitle.Width) / 2,
                padding * 2
            );

            // Buttons position
            int buttonY = panelMain.Height - btnSubmit.Height - 30;
            int centerX = panelMain.Width / 2;

            btnSubmit.Location = new Point(centerX - btnSubmit.Width - 20, buttonY);
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
            if (button == btnSubmit)
                button.BackColor = Color.FromArgb(76, 175, 80);
            else if (button == btnReset)
                button.BackColor = Color.FromArgb(239, 83, 80);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(158, 158, 158);
        }

        private void PatientRegistrationForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter patient name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            MessageBox.Show(message, "Registration Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void PatientRegistrationForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}


    
