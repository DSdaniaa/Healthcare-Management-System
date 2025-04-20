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
        private Label lblSelectRole, lblInstruction;
        private Button btnAdmin, btnDoctor, btnPatient, btnBack;
        private Panel panelMain, panelButtons;
        private PictureBox pictureBoxIcon;

        public RoleSelectionForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(RoleSelectionForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System - Select Role";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Shield;

            // Main container panel with shadow effect
            panelMain = new Panel();
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Size = new Size(900, 600);
            this.Controls.Add(panelMain);

            // Role selection icon
            pictureBoxIcon = new PictureBox();
            pictureBoxIcon.Size = new Size(100, 100);
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Image = CreateRoleSelectionIcon();
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            panelMain.Controls.Add(pictureBoxIcon);

            // Heading: Select a Role
            lblSelectRole = new Label();
            lblSelectRole.Text = "SELECT YOUR ROLE";
            lblSelectRole.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblSelectRole.ForeColor = Color.FromArgb(0, 102, 204);
            lblSelectRole.AutoSize = true;
            panelMain.Controls.Add(lblSelectRole);

            // Instruction label
            lblInstruction = new Label();
            lblInstruction.Text = "Please choose your role to continue with registration";
            lblInstruction.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            lblInstruction.ForeColor = Color.FromArgb(64, 64, 64);
            lblInstruction.AutoSize = true;
            panelMain.Controls.Add(lblInstruction);

            // Buttons container panel
            panelButtons = new Panel();
            panelButtons.BackColor = Color.FromArgb(240, 240, 240);
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Size = new Size(500, 350);
            panelMain.Controls.Add(panelButtons);

            // Admin Button
            btnAdmin = new Button();
            btnAdmin.Text = "ADMINISTRATOR";
            btnAdmin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAdmin.BackColor = Color.FromArgb(192, 57, 43); // Professional red
            btnAdmin.ForeColor = Color.White;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.Size = new Size(350, 60);
            btnAdmin.Cursor = Cursors.Hand;
            btnAdmin.Click += new EventHandler(btnAdmin_Click);
            btnAdmin.MouseEnter += Button_MouseEnter;
            btnAdmin.MouseLeave += Button_MouseLeave;
            panelButtons.Controls.Add(btnAdmin);

            // Doctor Button
            btnDoctor = new Button();
            btnDoctor.Text = "DOCTOR";
            btnDoctor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDoctor.BackColor = Color.FromArgb(41, 128, 185); // Professional blue
            btnDoctor.ForeColor = Color.White;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.FlatAppearance.BorderSize = 0;
            btnDoctor.Size = new Size(350, 60);
            btnDoctor.Cursor = Cursors.Hand;
            btnDoctor.Click += new EventHandler(btnDoctor_Click);
            btnDoctor.MouseEnter += Button_MouseEnter;
            btnDoctor.MouseLeave += Button_MouseLeave;
            panelButtons.Controls.Add(btnDoctor);

            // Patient Button
            btnPatient = new Button();
            btnPatient.Text = "PATIENT";
            btnPatient.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnPatient.BackColor = Color.FromArgb(39, 174, 96); // Professional green
            btnPatient.ForeColor = Color.White;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.Size = new Size(350, 60);
            btnPatient.Cursor = Cursors.Hand;
            btnPatient.Click += new EventHandler(btnPatient_Click);
            btnPatient.MouseEnter += Button_MouseEnter;
            btnPatient.MouseLeave += Button_MouseLeave;
            panelButtons.Controls.Add(btnPatient);

            // Back Button (positioned in bottom-right corner)
            btnBack = new Button();
            btnBack.Text = "BACK";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(149, 165, 166); // Professional gray
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Size = new Size(120, 40); // Compact but clearly visible
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new EventHandler(btnBack_Click);
            btnBack.MouseEnter += Button_MouseEnter;
            btnBack.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnBack);

            UpdateControlPositions();
        }

        private Image CreateRoleSelectionIcon()
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (Brush brush = new SolidBrush(Color.FromArgb(0, 102, 204)))
                {
                    // Draw three silhouettes
                    g.FillEllipse(brush, 20, 10, 20, 20); // Head 1
                    g.FillRectangle(brush, 25, 30, 10, 30); // Body 1

                    g.FillEllipse(brush, 40, 10, 20, 20); // Head 2
                    g.FillRectangle(brush, 45, 30, 10, 30); // Body 2

                    g.FillEllipse(brush, 60, 10, 20, 20); // Head 3
                    g.FillRectangle(brush, 65, 30, 10, 30); // Body 3
                }
            }
            return bmp;
        }

        private void UpdateControlPositions()
        {
            // Center the main panel
            panelMain.Location = new Point(
                (this.ClientSize.Width - panelMain.Width) / 2,
                (this.ClientSize.Height - panelMain.Height) / 2
            );

            // Icon position
            pictureBoxIcon.Location = new Point(
                (panelMain.Width - pictureBoxIcon.Width) / 2,
                40
            );

            // Title position
            lblSelectRole.Location = new Point(
                (panelMain.Width - lblSelectRole.Width) / 2,
                pictureBoxIcon.Bottom + 20
            );

            // Instruction position
            lblInstruction.Location = new Point(
                (panelMain.Width - lblInstruction.Width) / 2,
                lblSelectRole.Bottom + 10
            );

            // Buttons panel position
            panelButtons.Location = new Point(
                (panelMain.Width - panelButtons.Width) / 2,
                lblInstruction.Bottom + 40
            );

            // Admin button position
            btnAdmin.Location = new Point(
                (panelButtons.Width - btnAdmin.Width) / 2,
                40
            );

            // Doctor button position
            btnDoctor.Location = new Point(
                (panelButtons.Width - btnDoctor.Width) / 2,
                btnAdmin.Bottom + 20
            );

            // Patient button position
            btnPatient.Location = new Point(
                (panelButtons.Width - btnPatient.Width) / 2,
                btnDoctor.Bottom + 20
            );

            // Back button position (bottom-right corner with padding)
            btnBack.Location = new Point(
                panelMain.Width - btnBack.Width - 30, // 30px from right edge
                panelMain.Height - btnBack.Height - 30  // 30px from bottom
            );
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
            if (button == btnAdmin)
                button.BackColor = Color.FromArgb(192, 57, 43);
            else if (button == btnDoctor)
                button.BackColor = Color.FromArgb(41, 128, 185);
            else if (button == btnPatient)
                button.BackColor = Color.FromArgb(39, 174, 96);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(149, 165, 166);
        }

        private void RoleSelectionForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminRegistration adminRegistration = new AdminRegistration();
            adminRegistration.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            DoctorRegistrationForm doctorRegistrationForm = new DoctorRegistrationForm();
            doctorRegistrationForm.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            PatientRegistrationForm patientRegistrationForm = new PatientRegistrationForm();
            patientRegistrationForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TitleForm titleForm = new TitleForm();
            titleForm.Show();
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
        }

        private void RoleSelectionForm_Load(object sender, EventArgs e)
        {
        }
    }
}

    


   

    

    
