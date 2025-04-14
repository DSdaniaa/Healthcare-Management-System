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
    public partial class AddPatientForm : Form
    {
        private TextBox txtPatientName, txtPatientID, txtBloodType, txtPastDisease, txtAllergies,
            txtFamilyHistory, txtSurgicalHistory, txtCurrentMedication;
        private DateTimePicker dateTimePickerDOB, dateTimePickerLastVisit, dateTimePickerNextAppointment;
        private ComboBox comboBoxGender;
        private Button btnSave, btnBack;
        private Label lblTitle;
        private PatientMedicalHistoryListForm parentForm;

        public AddPatientForm(PatientMedicalHistoryListForm parent)
        {
            InitializeComponent();
            parentForm = parent;
            CreateControls();
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Add New Patient";
            this.Size = new System.Drawing.Size(800, 700);
            this.BackColor = Color.FromArgb(240, 248, 255);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "ADD NEW PATIENT RECORD";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            int yOffset = 80;
            int labelWidth = 180;
            int textBoxWidth = 250;
            int padding = 20;

            // Patient ID
            AddLabel("Patient ID:", 20, yOffset, labelWidth);
            txtPatientID = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            txtPatientID.Text = GeneratePatientID();
            txtPatientID.ReadOnly = true;
            yOffset += 40;

            // Patient Name
            AddLabel("Patient Name:", 20, yOffset, labelWidth);
            txtPatientName = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Date of Birth
            AddLabel("Date of Birth:", 20, yOffset, labelWidth);
            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Location = new Point(20 + labelWidth + 10, yOffset);
            dateTimePickerDOB.Size = new Size(textBoxWidth, 26);
            dateTimePickerDOB.Font = new Font("Segoe UI", 10);
            this.Controls.Add(dateTimePickerDOB);
            yOffset += 40;

            // Gender
            AddLabel("Gender:", 20, yOffset, labelWidth);
            comboBoxGender = new ComboBox();
            comboBoxGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            comboBoxGender.Location = new Point(20 + labelWidth + 10, yOffset);
            comboBoxGender.Size = new Size(textBoxWidth, 26);
            comboBoxGender.Font = new Font("Segoe UI", 10);
            this.Controls.Add(comboBoxGender);
            yOffset += 40;

            // Blood Type
            AddLabel("Blood Type:", 20, yOffset, labelWidth);
            txtBloodType = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Past Disease
            AddLabel("Past Diseases:", 20, yOffset, labelWidth);
            txtPastDisease = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Allergies
            AddLabel("Allergies:", 20, yOffset, labelWidth);
            txtAllergies = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Family History
            AddLabel("Family History:", 20, yOffset, labelWidth);
            txtFamilyHistory = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Surgical History
            AddLabel("Surgical History:", 20, yOffset, labelWidth);
            txtSurgicalHistory = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Current Medication
            AddLabel("Current Medication:", 20, yOffset, labelWidth);
            txtCurrentMedication = AddTextBox(20 + labelWidth + 10, yOffset, textBoxWidth);
            yOffset += 40;

            // Last Visit Date
            AddLabel("Last Visit Date:", 20, yOffset, labelWidth);
            dateTimePickerLastVisit = new DateTimePicker();
            dateTimePickerLastVisit.Location = new Point(20 + labelWidth + 10, yOffset);
            dateTimePickerLastVisit.Size = new Size(textBoxWidth, 26);
            dateTimePickerLastVisit.Font = new Font("Segoe UI", 10);
            this.Controls.Add(dateTimePickerLastVisit);
            yOffset += 40;

            // Next Appointment
            AddLabel("Next Appointment:", 20, yOffset, labelWidth);
            dateTimePickerNextAppointment = new DateTimePicker();
            dateTimePickerNextAppointment.Location = new Point(20 + labelWidth + 10, yOffset);
            dateTimePickerNextAppointment.Size = new Size(textBoxWidth, 26);
            dateTimePickerNextAppointment.Font = new Font("Segoe UI", 10);
            this.Controls.Add(dateTimePickerNextAppointment);
            yOffset += 50;

            // Buttons
            btnSave = new Button();
            btnSave.Text = "Save Patient";
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.ForeColor = Color.White;
            btnSave.Size = new Size(150, 40);
            btnSave.Location = new Point(this.ClientSize.Width / 2 - 160, yOffset);
            btnSave.Click += new EventHandler(btnSave_Click);
            this.Controls.Add(btnSave);

            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(158, 158, 158);
            btnBack.ForeColor = Color.White;
            btnBack.Size = new Size(150, 40);
            btnBack.Location = new Point(this.ClientSize.Width / 2 + 10, yOffset);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);
        }

        private Label AddLabel(string text, int x, int y, int width)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label.Location = new Point(x, y);
            label.Size = new Size(width, 20);
            this.Controls.Add(label);
            return label;
        }

        private TextBox AddTextBox(int x, int y, int width)
        {
            TextBox textBox = new TextBox();
            textBox.Font = new Font("Segoe UI", 10);
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(width, 26);
            this.Controls.Add(textBox);
            return textBox;
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

        private void AddPatientForm_Load(object sender, EventArgs e)
        {

        }
    }
}

    