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
    public partial class RoleSelectionLogin : Form
    {
        private Label lblSelectRole, lblQuote;
        private Button btnAdmin, btnDoctor, btnPatient, btnBack;

        public RoleSelectionLogin()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(RoleSelectionLoginForm_Resize);
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Select Your Role";
            this.Size = new System.Drawing.Size(900, 600); // Slightly wider for horizontal layout
            this.BackColor = Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Heading: Select Your Role
            lblSelectRole = new Label();
            lblSelectRole.Text = "Select Your Role";
            lblSelectRole.Font = new Font("Arial", 24, FontStyle.Bold);
            lblSelectRole.ForeColor = Color.DarkBlue;
            lblSelectRole.AutoSize = true;
            this.Controls.Add(lblSelectRole);

            // Admin Button
            btnAdmin = new Button();
            btnAdmin.Text = "Admin";
            btnAdmin.Font = new Font("Arial", 14, FontStyle.Bold);
            btnAdmin.BackColor = Color.LightCoral;
            btnAdmin.ForeColor = Color.White;
            btnAdmin.Size = new System.Drawing.Size(200, 50);
            btnAdmin.Click += new EventHandler(btnAdmin_Click);
            this.Controls.Add(btnAdmin);

            // Doctor Button
            btnDoctor = new Button();
            btnDoctor.Text = "Doctor";
            btnDoctor.Font = new Font("Arial", 14, FontStyle.Bold);
            btnDoctor.BackColor = Color.LightGreen;
            btnDoctor.ForeColor = Color.White;
            btnDoctor.Size = new System.Drawing.Size(200, 50);
            btnDoctor.Click += new EventHandler(btnDoctor_Click);
            this.Controls.Add(btnDoctor);

            // Patient Button
            btnPatient = new Button();
            btnPatient.Text = "Patient";
            btnPatient.Font = new Font("Arial", 14, FontStyle.Bold);
            btnPatient.BackColor = Color.LightSkyBlue;
            btnPatient.ForeColor = Color.White;
            btnPatient.Size = new System.Drawing.Size(200, 50);
            btnPatient.Click += new EventHandler(btnPatient_Click);
            this.Controls.Add(btnPatient);

            // Back Button
            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Font = new Font("Arial", 14, FontStyle.Bold);
            btnBack.BackColor = Color.LightGray;
            btnBack.ForeColor = Color.White;
            btnBack.Size = new System.Drawing.Size(200, 50);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // Inspirational Quote
            lblQuote = new Label();
            lblQuote.Text = "\"Healing is a matter of time, but it is sometimes also a matter of opportunity.\" - Hippocrates";
            lblQuote.Font = new Font("Arial", 12, FontStyle.Italic);
            lblQuote.ForeColor = Color.DarkSlateBlue;
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.AutoSize = false;
            lblQuote.Size = new System.Drawing.Size(800, 50);
            this.Controls.Add(lblQuote);

            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int padding = 30;
            int buttonSpacing = 20;
            int yOffset = 100;

            // Center heading
            lblSelectRole.Location = new System.Drawing.Point(
                (this.ClientSize.Width - lblSelectRole.Width) / 2,
                yOffset
            );

            // Position buttons horizontally
            yOffset += lblSelectRole.Height + padding * 2;

            int totalButtonsWidth = btnAdmin.Width + btnDoctor.Width + btnPatient.Width + (buttonSpacing * 2);
            int startX = (this.ClientSize.Width - totalButtonsWidth) / 2;

            btnAdmin.Location = new System.Drawing.Point(startX, yOffset);
            btnDoctor.Location = new System.Drawing.Point(startX + btnAdmin.Width + buttonSpacing, yOffset);
            btnPatient.Location = new System.Drawing.Point(startX + btnAdmin.Width + btnDoctor.Width + buttonSpacing * 2, yOffset);

            // Position Back button below the role buttons
            yOffset += btnAdmin.Height + padding;
            btnBack.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnBack.Width) / 2,
                yOffset
            );

            // Position quote at bottom
            lblQuote.Location = new System.Drawing.Point(
                (this.ClientSize.Width - lblQuote.Width) / 2,
                this.ClientSize.Height - padding - lblQuote.Height
            );
        }

        private void RoleSelectionLoginForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // Navigate to Admin Dashboard
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            // Navigate to Doctor Dashboard
            PatientMedicalHistoryListForm PatientMedicalHistoryListForm = new PatientMedicalHistoryListForm();
            PatientMedicalHistoryListForm.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            AppointmentSchedulingForm appointmentSchedulingForm = new AppointmentSchedulingForm();
            appointmentSchedulingForm.Show();
            // Navigate to Patient Dashboard
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to Title Form
            TitleForm titleForm = new TitleForm();
            titleForm.Show();
            this.Hide();
        }

        private void RoleSelectionLogin_Load(object sender, EventArgs e)
        {
        }
    }
}

   

   