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
    public partial class RoleSelectionForm : Form
    {
        private Label lblSelectRole;
        private Button btnAdmin, btnDoctor, btnPatient;

        public RoleSelectionForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(RoleSelectionForm_Resize); // Handle form resize event
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Select Role";
            this.Size = new System.Drawing.Size(800, 600); // Same size as the Title Form
            this.BackColor = Color.LightBlue; // Set background color
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen

            // Heading: Select a Role
            lblSelectRole = new Label();
            lblSelectRole.Text = "Select a Role";
            lblSelectRole.Font = new Font("Arial", 24, FontStyle.Bold); // Large, bold font
            lblSelectRole.ForeColor = Color.DarkBlue; // Text color
            lblSelectRole.AutoSize = true;
            this.Controls.Add(lblSelectRole);

            // Admin Button
            btnAdmin = new Button();
            btnAdmin.Text = "Admin";
            btnAdmin.Font = new Font("Arial", 14, FontStyle.Bold); // Font for the button
            btnAdmin.BackColor = Color.LightCoral; // Button background color
            btnAdmin.ForeColor = Color.White; // Button text color
            btnAdmin.Size = new System.Drawing.Size(200, 50); // Button size
            btnAdmin.Click += new EventHandler(btnAdmin_Click); // Event handler for button click
            this.Controls.Add(btnAdmin);

            // Doctor Button
            btnDoctor = new Button();
            btnDoctor.Text = "Doctor";
            btnDoctor.Font = new Font("Arial", 14, FontStyle.Bold); // Font for the button
            btnDoctor.BackColor = Color.LightGreen; // Button background color
            btnDoctor.ForeColor = Color.White; // Button text color
            btnDoctor.Size = new System.Drawing.Size(200, 50); // Button size
            btnDoctor.Click += new EventHandler(btnDoctor_Click); // Event handler for button click
            this.Controls.Add(btnDoctor);

            // Patient Button
            btnPatient = new Button();
            btnPatient.Text = "Patient";
            btnPatient.Font = new Font("Arial", 14, FontStyle.Bold); // Font for the button
            btnPatient.BackColor = Color.LightSkyBlue; // Button background color
            btnPatient.ForeColor = Color.White; // Button text color
            btnPatient.Size = new System.Drawing.Size(200, 50); // Button size
            btnPatient.Click += new EventHandler(btnPatient_Click); // Event handler for button click
            this.Controls.Add(btnPatient);

            // Set initial positions
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int padding = 30; // Padding between controls
            int yOffset = 100; // Starting Y position

            // Heading: Select a Role
            lblSelectRole.Location = new System.Drawing.Point(
                (this.ClientSize.Width - lblSelectRole.Width) / 2, // Center horizontally
                yOffset
            );

            // Admin Button
            yOffset += lblSelectRole.Height + padding;
            btnAdmin.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnAdmin.Width) / 2, // Center horizontally
                yOffset
            );

            // Doctor Button
            yOffset += btnAdmin.Height + padding;
            btnDoctor.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnDoctor.Width) / 2, // Center horizontally
                yOffset
            );

            // Patient Button
            yOffset += btnDoctor.Height + padding;
            btnPatient.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnPatient.Width) / 2, // Center horizontally
                yOffset
            );
        }

        private void RoleSelectionForm_Resize(object sender, EventArgs e)
        {
            // Update control positions when the form is resized
            UpdateControlPositions();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // Navigate to the Dashboard Form
           // DashboardForm dashboardForm = new DashboardForm();
           // dashboardForm.Show();
            this.Hide(); // Hide the role selection form
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            // Navigate to the Dashboard Form
            //DashboardForm dashboardForm = new DashboardForm();
            //dashboardForm.Show();
            this.Hide(); // Hide the role selection form
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            // Navigate to the Patient Registration Form
            PatientRegistrationForm patientRegistrationForm = new PatientRegistrationForm();
            patientRegistrationForm.Show();
            this.Hide(); // Hide the role selection form
        }
        private void RoleSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
