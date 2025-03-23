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
    public partial class AppointmentSchedulingForm : Form
    {
        private ComboBox comboBoxDoctor;
        private DateTimePicker dateTimePickerAppointment;
        private TextBox txtReason;
        private Button btnBookAppointment, btnReset, btnBack;
        private Label lblDoctor, lblAppointment, lblReason;

        public AppointmentSchedulingForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(AppointmentSchedulingForm_Resize); // Handle form resize event
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Appointment Scheduling";
            this.Size = new System.Drawing.Size(800, 600); // Same size as other forms
            this.BackColor = Color.LightBlue; // Set background color
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen

            // Doctor
            lblDoctor = new Label();
            lblDoctor.Text = "Doctor:";
            lblDoctor.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblDoctor.ForeColor = Color.DarkBlue; // Text color
            lblDoctor.AutoSize = true;
            this.Controls.Add(lblDoctor);

            comboBoxDoctor = new ComboBox();
            comboBoxDoctor.Font = new Font("Arial", 12); // Font for the combobox
            comboBoxDoctor.Items.AddRange(new string[] { "Dr. Smith - Cardiologist", "Dr. Johnson - Dermatologist", "Dr. Lee - Pediatrician" });
            comboBoxDoctor.Size = new System.Drawing.Size(300, 30); // Larger combobox
            this.Controls.Add(comboBoxDoctor);

            // Appointment Date/Time
            lblAppointment = new Label();
            lblAppointment.Text = "Appointment Date/Time:";
            lblAppointment.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblAppointment.ForeColor = Color.DarkBlue;
            lblAppointment.AutoSize = true;
            this.Controls.Add(lblAppointment);

            dateTimePickerAppointment = new DateTimePicker();
            dateTimePickerAppointment.Font = new Font("Arial", 12);
            dateTimePickerAppointment.Size = new System.Drawing.Size(300, 30); // Larger datetime picker
            this.Controls.Add(dateTimePickerAppointment);

            // Reason for Visit
            lblReason = new Label();
            lblReason.Text = "Reason for Visit:";
            lblReason.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            lblReason.ForeColor = Color.DarkBlue;
            lblReason.AutoSize = true;
            this.Controls.Add(lblReason);

            txtReason = new TextBox();
            txtReason.Font = new Font("Arial", 12);
            txtReason.Size = new System.Drawing.Size(300, 30); // Larger textbox
            this.Controls.Add(txtReason);

            // Book Appointment Button
            btnBookAppointment = new Button();
            btnBookAppointment.Text = "Book Appointment";
            btnBookAppointment.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            btnBookAppointment.BackColor = Color.LightGreen; // Button background color
            btnBookAppointment.ForeColor = Color.White; // Button text color
            btnBookAppointment.Size = new System.Drawing.Size(200, 50); // Larger button
            btnBookAppointment.Click += new EventHandler(btnBookAppointment_Click);
            this.Controls.Add(btnBookAppointment);

            // Reset Button
            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            btnReset.BackColor = Color.LightCoral; // Button background color
            btnReset.ForeColor = Color.White; // Button text color
            btnReset.Size = new System.Drawing.Size(200, 50); // Larger button
            btnReset.Click += new EventHandler(btnReset_Click);
            this.Controls.Add(btnReset);

            // Back Button
            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Arial", 14, FontStyle.Bold); // Larger font
            btnBack.BackColor = Color.LightGray; // Button background color
            btnBack.ForeColor = Color.White; // Button text color
            btnBack.Size = new System.Drawing.Size(200, 50); // Larger button
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // Set initial positions
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int padding = 30; // Padding between controls
            int yOffset = 100; // Starting Y position

            // Doctor
            lblDoctor.Location = new System.Drawing.Point(padding, yOffset);
            comboBoxDoctor.Location = new System.Drawing.Point(this.ClientSize.Width - comboBoxDoctor.Width - padding, yOffset);

            // Appointment Date/Time
            yOffset += lblDoctor.Height + padding;
            lblAppointment.Location = new System.Drawing.Point(padding, yOffset);
            dateTimePickerAppointment.Location = new System.Drawing.Point(this.ClientSize.Width - dateTimePickerAppointment.Width - padding, yOffset);

            // Reason for Visit
            yOffset += lblAppointment.Height + padding;
            lblReason.Location = new System.Drawing.Point(padding, yOffset);
            txtReason.Location = new System.Drawing.Point(this.ClientSize.Width - txtReason.Width - padding, yOffset);

            // Buttons
            yOffset += lblReason.Height + padding;
            btnBookAppointment.Location = new System.Drawing.Point(padding, yOffset);
            btnReset.Location = new System.Drawing.Point(this.ClientSize.Width - btnReset.Width - padding, yOffset);

            // Back Button
            yOffset += btnBookAppointment.Height + padding;
            btnBack.Location = new System.Drawing.Point((this.ClientSize.Width - btnBack.Width) / 2, yOffset); // Center horizontally
        }

        private void AppointmentSchedulingForm_Resize(object sender, EventArgs e)
        {
            // Update control positions when the form is resized
            UpdateControlPositions();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            // Get input values
            string doctor = comboBoxDoctor.SelectedItem?.ToString() ?? "Not Selected";
            DateTime appointmentDateTime = dateTimePickerAppointment.Value;
            string reason = txtReason.Text;

            // Show confirmation message
            MessageBox.Show($"Your appointment has been booked for {appointmentDateTime.ToShortDateString()} at {appointmentDateTime.ToShortTimeString()}.");

            // Navigate to the Dashboard Form
            //DashboardForm dashboardForm = new DashboardForm();
            //dashboardForm.Show();
            this.Hide(); // Hide the appointment scheduling form
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Clear all fields
            comboBoxDoctor.SelectedIndex = -1;
            dateTimePickerAppointment.Value = DateTime.Now;
            txtReason.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate to the Dashboard Form
            //DashboardForm dashboardForm = new DashboardForm();
            //dashboardForm.Show();
            this.Hide(); // Hide the appointment scheduling form
        }

        private void AppointmentSchedulingForm_Load(object sender, EventArgs e)
        {
            // This method is not needed for now
        }
    }
}
