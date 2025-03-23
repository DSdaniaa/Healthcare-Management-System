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
        private TextBox txtPatientName, txtContactInfo;
        private DateTimePicker dateTimePickerDOB;
        private ComboBox comboBoxGender;
        private Button btnSubmit, btnReset;
        private Label lblPatientName, lblContactInfo, lblDOB, lblGender;

        public PatientRegistrationForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(PatientRegistrationForm_Resize); // Handle form resize event
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Patient Registration";
            this.Size = new System.Drawing.Size(800, 600); // Same size as the Title Form
            this.BackColor = Color.LightBlue; // Set background color
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen

            // Patient Name
            lblPatientName = new Label();
            lblPatientName.Text = "Patient Name:";
            lblPatientName.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblPatientName.ForeColor = Color.DarkBlue; // Text color
            lblPatientName.AutoSize = true;
            this.Controls.Add(lblPatientName);

            txtPatientName = new TextBox();
            txtPatientName.Font = new Font("Arial", 12); // Font for the textbox
            txtPatientName.Size = new System.Drawing.Size(300, 30); // Larger textbox
            this.Controls.Add(txtPatientName);

            // Contact Info
            lblContactInfo = new Label();
            lblContactInfo.Text = "Contact Info:";
            lblContactInfo.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblContactInfo.ForeColor = Color.DarkBlue;
            lblContactInfo.AutoSize = true;
            this.Controls.Add(lblContactInfo);

            txtContactInfo = new TextBox();
            txtContactInfo.Font = new Font("Arial", 12);
            txtContactInfo.Size = new System.Drawing.Size(300, 30); // Larger textbox
            this.Controls.Add(txtContactInfo);

            // Date of Birth
            lblDOB = new Label();
            lblDOB.Text = "Date of Birth:";
            lblDOB.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblDOB.ForeColor = Color.DarkBlue;
            lblDOB.AutoSize = true;
            this.Controls.Add(lblDOB);

            dateTimePickerDOB = new DateTimePicker();
            dateTimePickerDOB.Font = new Font("Arial", 12);
            dateTimePickerDOB.Size = new System.Drawing.Size(300, 30); // Larger datetime picker
            this.Controls.Add(dateTimePickerDOB);

            // Gender
            lblGender = new Label();
            lblGender.Text = "Gender:";
            lblGender.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblGender.ForeColor = Color.DarkBlue;
            lblGender.AutoSize = true;
            this.Controls.Add(lblGender);

            comboBoxGender = new ComboBox();
            comboBoxGender.Font = new Font("Arial", 12);
            comboBoxGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            comboBoxGender.Size = new System.Drawing.Size(300, 30); // Larger combobox
            this.Controls.Add(comboBoxGender);

            // Submit Button
            btnSubmit = new Button();
            btnSubmit.Text = "Register";
            btnSubmit.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            btnSubmit.BackColor = Color.LightGreen;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Size = new System.Drawing.Size(150, 50); // Larger button
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.Controls.Add(btnSubmit);

            // Reset Button
            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            btnReset.BackColor = Color.LightCoral;
            btnReset.ForeColor = Color.White;
            btnReset.Size = new System.Drawing.Size(150, 50); // Larger button
            btnReset.Click += new EventHandler(btnReset_Click);
            this.Controls.Add(btnReset);

            // Set initial positions
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int padding = 30; // Padding between controls
            int yOffset = 50; // Starting Y position

            // Patient Name
            lblPatientName.Location = new System.Drawing.Point(padding, yOffset);
            txtPatientName.Location = new System.Drawing.Point(this.ClientSize.Width - txtPatientName.Width - padding, yOffset);

            // Contact Info
            yOffset += lblPatientName.Height + padding;
            lblContactInfo.Location = new System.Drawing.Point(padding, yOffset);
            txtContactInfo.Location = new System.Drawing.Point(this.ClientSize.Width - txtContactInfo.Width - padding, yOffset);

            // Date of Birth
            yOffset += lblContactInfo.Height + padding;
            lblDOB.Location = new System.Drawing.Point(padding, yOffset);
            dateTimePickerDOB.Location = new System.Drawing.Point(this.ClientSize.Width - dateTimePickerDOB.Width - padding, yOffset);

            // Gender
            yOffset += lblDOB.Height + padding;
            lblGender.Location = new System.Drawing.Point(padding, yOffset);
            comboBoxGender.Location = new System.Drawing.Point(this.ClientSize.Width - comboBoxGender.Width - padding, yOffset);

            // Buttons
            yOffset += lblGender.Height + padding;
            btnSubmit.Location = new System.Drawing.Point(padding, yOffset);
            btnReset.Location = new System.Drawing.Point(this.ClientSize.Width - btnReset.Width - padding, yOffset);
        }

        private void PatientRegistrationForm_Resize(object sender, EventArgs e)
        {
            // Update control positions when the form is resized
            UpdateControlPositions();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get input values
            string patientName = txtPatientName.Text;
            string contactInfo = txtContactInfo.Text;
            DateTime dateOfBirth = dateTimePickerDOB.Value;
            string gender = comboBoxGender.SelectedItem?.ToString() ?? "Not Selected";

            // Automatically generate a Patient ID (for demo purposes)
            string patientID = GeneratePatientID();

            // Save the data (for demo, we'll just show a message)
            MessageBox.Show($"Patient Registered!\nID: {patientID}\nName: {patientName}\nContact: {contactInfo}\nDOB: {dateOfBirth.ToShortDateString()}\nGender: {gender}");

            // Navigate to the Dashboard Form
            TitleForm titleForm = new TitleForm();
            titleForm.Show();
            this.Hide(); // Hide the registration form
        }

        private string GeneratePatientID()
        {
            // Generate a random Patient ID (for demo purposes)
            Random random = new Random();
            return "PAT" + random.Next(1000, 9999).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all fields
            txtPatientName.Clear();
            txtContactInfo.Clear();
            dateTimePickerDOB.Value = DateTime.Now;
            comboBoxGender.SelectedIndex = -1;
        }

        private void PatientRegistrationForm_Load(object sender, EventArgs e)
        {
            // This method is not needed for now
        }
    }
}