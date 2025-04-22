using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare_Management_System
{
    public partial class AddPatientForm : Form
    {
        private TextBox txtPatientName, txtPatientID, txtBloodType, txtPastDisease, txtAllergies,
            txtFamilyHistory, txtSurgicalHistory, txtCurrentMedication;
        private DateTimePicker dateTimePickerDOB, dateTimePickerLastVisit, dateTimePickerNextAppointment;
        private ComboBox comboBoxGender;
        private Button btnSave, btnBack;
        private Label lblTitle;
        private PatientMedicalHistoryListForm parentForm;
        private Panel panelMain, panelForm;

        public AddPatientForm(PatientMedicalHistoryListForm parent)
        {
            InitializeComponent();
            parentForm = parent;
            CreateControls();
            this.Resize += new EventHandler(AddPatientForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Add New Patient";
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
            panelForm.Size = new Size(800, 600);
            panelMain.Controls.Add(panelForm);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "ADD NEW PATIENT RECORD";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelForm.Controls.Add(lblTitle);

            int yOffset = 60;
            int labelWidth = 180;
            int textBoxWidth = 250;
            int padding = 20;
            int leftMargin = 40;

            // Patient ID
            AddLabel("Patient ID:", leftMargin, yOffset, labelWidth, panelForm);
            txtPatientID = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            txtPatientID.Text = GeneratePatientID();
            txtPatientID.ReadOnly = true;
            yOffset += 40;

            // Patient Name
            AddLabel("Patient Name:", leftMargin, yOffset, labelWidth, panelForm);
            txtPatientName = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Date of Birth
            AddLabel("Date of Birth:", leftMargin, yOffset, labelWidth, panelForm);
            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Location = new Point(leftMargin + labelWidth + 10, yOffset);
            dateTimePickerDOB.Size = new Size(textBoxWidth, 26);
            dateTimePickerDOB.Font = new Font("Segoe UI", 10);
            panelForm.Controls.Add(dateTimePickerDOB);
            yOffset += 40;

            // Gender
            AddLabel("Gender:", leftMargin, yOffset, labelWidth, panelForm);
            comboBoxGender = new ComboBox();
            comboBoxGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            comboBoxGender.Location = new Point(leftMargin + labelWidth + 10, yOffset);
            comboBoxGender.Size = new Size(textBoxWidth, 26);
            comboBoxGender.Font = new Font("Segoe UI", 10);
            panelForm.Controls.Add(comboBoxGender);
            yOffset += 40;

            // Blood Type
            AddLabel("Blood Type:", leftMargin, yOffset, labelWidth, panelForm);
            txtBloodType = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Past Disease
            AddLabel("Past Diseases:", leftMargin, yOffset, labelWidth, panelForm);
            txtPastDisease = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Allergies
            AddLabel("Allergies:", leftMargin, yOffset, labelWidth, panelForm);
            txtAllergies = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Family History
            AddLabel("Family History:", leftMargin, yOffset, labelWidth, panelForm);
            txtFamilyHistory = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Surgical History
            AddLabel("Surgical History:", leftMargin, yOffset, labelWidth, panelForm);
            txtSurgicalHistory = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Current Medication
            AddLabel("Current Medication:", leftMargin, yOffset, labelWidth, panelForm);
            txtCurrentMedication = AddTextBox(leftMargin + labelWidth + 10, yOffset, textBoxWidth, panelForm);
            yOffset += 40;

            // Last Visit Date
            AddLabel("Last Visit Date:", leftMargin, yOffset, labelWidth, panelForm);
            dateTimePickerLastVisit = new DateTimePicker();
            dateTimePickerLastVisit.Location = new Point(leftMargin + labelWidth + 10, yOffset);
            dateTimePickerLastVisit.Size = new Size(textBoxWidth, 26);
            dateTimePickerLastVisit.Font = new Font("Segoe UI", 10);
            panelForm.Controls.Add(dateTimePickerLastVisit);
            yOffset += 40;

            // Next Appointment
            AddLabel("Next Appointment:", leftMargin, yOffset, labelWidth, panelForm);
            dateTimePickerNextAppointment = new DateTimePicker();
            dateTimePickerNextAppointment.Location = new Point(leftMargin + labelWidth + 10, yOffset);
            dateTimePickerNextAppointment.Size = new Size(textBoxWidth, 26);
            dateTimePickerNextAppointment.Font = new Font("Segoe UI", 10);
            panelForm.Controls.Add(dateTimePickerNextAppointment);
            yOffset += 50;

            // Buttons
            btnSave = new Button();
            btnSave.Text = "Save Patient";
            btnSave.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.Size = new Size(150, 40);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += new EventHandler(btnSave_Click);
            btnSave.MouseEnter += Button_MouseEnter;
            btnSave.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnSave);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158);
            btnBack.ForeColor = Color.White;
            btnBack.Size = new Size(150, 40);
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

            // Center the title
            lblTitle.Location = new Point(
                (panelForm.Width - lblTitle.Width) / 2,
                20
            );

            // Position buttons
            int buttonY = panelMain.Height - btnSave.Height - 30;
            int centerX = panelMain.Width / 2;

            btnSave.Location = new Point(centerX - btnSave.Width - 20, buttonY);
            btnBack.Location = new Point(centerX + 20, buttonY);
        }

        private Label AddLabel(string text, int x, int y, int width, Panel panel)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(64, 64, 64);
            label.Location = new Point(x, y);
            label.Size = new Size(width, 20);
            panel.Controls.Add(label);
            return label;
        }

        private TextBox AddTextBox(int x, int y, int width, Panel panel)
        {
            TextBox textBox = new TextBox();
            textBox.Font = new Font("Segoe UI", 10);
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(width, 26);
            panel.Controls.Add(textBox);
            return textBox;
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
            if (button == btnSave)
                button.BackColor = Color.FromArgb(76, 175, 80);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(158, 158, 158);
        }

        private void AddPatientForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private string GeneratePatientID()
        {
            Random random = new Random();
            return "PAT" + (100 + random.Next(900)).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter patient name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MedicalHistory newPatient = new MedicalHistory
            {
                PatientID = txtPatientID.Text,
                PatientName = txtPatientName.Text,
                DateOfBirth = dateTimePickerDOB.Value,
                Gender = comboBoxGender.SelectedItem?.ToString() ?? "Not Specified",
                BloodType = txtBloodType.Text,
                PastDisease = txtPastDisease.Text,
                Allergies = txtAllergies.Text,
                FamilyHistory = txtFamilyHistory.Text,
                SurgicalHistory = txtSurgicalHistory.Text,
                CurrentMedication = txtCurrentMedication.Text,
                LastVisitDate = dateTimePickerLastVisit.Value,
                NextAppointment = dateTimePickerNextAppointment.Value
            };

            parentForm.AddNewPatient(newPatient);
            MessageBox.Show("Patient record saved successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear form for next entry
            txtPatientID.Text = GeneratePatientID();
            txtPatientName.Clear();
            dateTimePickerDOB.Value = DateTime.Now.AddYears(-30);
            comboBoxGender.SelectedIndex = -1;
            txtBloodType.Clear();
            txtPastDisease.Clear();
            txtAllergies.Clear();
            txtFamilyHistory.Clear();
            txtSurgicalHistory.Clear();
            txtCurrentMedication.Clear();
            dateTimePickerLastVisit.Value = DateTime.Now;
            dateTimePickerNextAppointment.Value = DateTime.Now.AddMonths(6);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
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

        private void AddPatientForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}


    


    