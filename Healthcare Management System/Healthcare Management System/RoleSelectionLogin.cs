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
        private Panel panelMain;
        private PictureBox pictureBoxIcon;

        public RoleSelectionLogin()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(RoleSelectionLoginForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System - Login";
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

            // Healthcare icon
            pictureBoxIcon = new PictureBox();
            pictureBoxIcon.Size = new Size(120, 120);
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Image = CreateHealthcareIcon();
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            panelMain.Controls.Add(pictureBoxIcon);

            // Heading: Select Your Role
            lblSelectRole = new Label();
            lblSelectRole.Text = "LOGIN AS";
            lblSelectRole.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblSelectRole.ForeColor = Color.FromArgb(0, 102, 204);
            lblSelectRole.AutoSize = true;
            panelMain.Controls.Add(lblSelectRole);

            // Admin Button
            btnAdmin = new Button();
            btnAdmin.Text = "ADMINISTRATOR";
            btnAdmin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAdmin.BackColor = Color.FromArgb(192, 57, 43); // Professional red
            btnAdmin.ForeColor = Color.White;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.Size = new Size(250, 60);
            btnAdmin.Cursor = Cursors.Hand;
            btnAdmin.Click += new EventHandler(btnAdmin_Click);
            btnAdmin.MouseEnter += Button_MouseEnter;
            btnAdmin.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnAdmin);

            // Doctor Button
            btnDoctor = new Button();
            btnDoctor.Text = "DOCTOR";
            btnDoctor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDoctor.BackColor = Color.FromArgb(41, 128, 185); // Professional blue
            btnDoctor.ForeColor = Color.White;
            btnDoctor.FlatStyle = FlatStyle.Flat;
            btnDoctor.FlatAppearance.BorderSize = 0;
            btnDoctor.Size = new Size(250, 60);
            btnDoctor.Cursor = Cursors.Hand;
            btnDoctor.Click += new EventHandler(btnDoctor_Click);
            btnDoctor.MouseEnter += Button_MouseEnter;
            btnDoctor.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnDoctor);

            // Patient Button
            btnPatient = new Button();
            btnPatient.Text = "PATIENT";
            btnPatient.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnPatient.BackColor = Color.FromArgb(39, 174, 96); // Professional green
            btnPatient.ForeColor = Color.White;
            btnPatient.FlatStyle = FlatStyle.Flat;
            btnPatient.FlatAppearance.BorderSize = 0;
            btnPatient.Size = new Size(250, 60);
            btnPatient.Cursor = Cursors.Hand;
            btnPatient.Click += new EventHandler(btnPatient_Click);
            btnPatient.MouseEnter += Button_MouseEnter;
            btnPatient.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnPatient);

            // Back Button
            btnBack = new Button();
            btnBack.Text = "BACK";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(149, 165, 166); // Professional gray
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Size = new Size(120, 40);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new EventHandler(btnBack_Click);
            btnBack.MouseEnter += Button_MouseEnter;
            btnBack.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnBack);

            // Inspirational Quote
            lblQuote = new Label();
            lblQuote.Text = "\"Healing is a matter of time, but it is sometimes also a matter of opportunity.\" - Hippocrates";
            lblQuote.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblQuote.ForeColor = Color.FromArgb(100, 100, 100);
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.AutoSize = false;
            lblQuote.Size = new Size(700, 40);
            panelMain.Controls.Add(lblQuote);

            UpdateControlPositions();
        }

        private Image CreateHealthcareIcon()
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Draw a medical cross with a person silhouette
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 102, 204)))
                {
                    // Person silhouette
                    g.FillEllipse(brush, 40, 10, 40, 40); // Head
                    g.FillRectangle(brush, 50, 50, 20, 40); // Body

                    // Medical cross
                    g.FillRectangle(brush, 30, 80, 60, 10); // Horizontal
                    g.FillRectangle(brush, 55, 55, 10, 50); // Vertical
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

            // Button positions (stacked vertically)
            int buttonStartY = lblSelectRole.Bottom + 50;
            int buttonSpacing = 30;

            btnAdmin.Location = new Point(
                (panelMain.Width - btnAdmin.Width) / 2,
                buttonStartY
            );

            btnDoctor.Location = new Point(
                (panelMain.Width - btnDoctor.Width) / 2,
                btnAdmin.Bottom + buttonSpacing
            );

            btnPatient.Location = new Point(
                (panelMain.Width - btnPatient.Width) / 2,
                btnDoctor.Bottom + buttonSpacing
            );

            // Back button position (bottom-right corner with padding)
            btnBack.Location = new Point(
                panelMain.Width - btnBack.Width - 30,
                panelMain.Height - btnBack.Height - 30
            );

            // Quote position (bottom center)
            lblQuote.Location = new Point(
                (panelMain.Width - lblQuote.Width) / 2,
                panelMain.Height - lblQuote.Height - 20
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
            button.Size = new Size(button.Width + 5, button.Height + 5);
            button.Location = new Point(button.Location.X - 2, button.Location.Y - 2);
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

            button.Size = new Size(button.Width - 5, button.Height - 5);
            button.Location = new Point(button.Location.X + 2, button.Location.Y + 2);
        }

        private void RoleSelectionLoginForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginForm appoint = new LoginForm();
            appoint.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            LoginForm1 PatientMedicalHistoryListForm = new LoginForm1();
            PatientMedicalHistoryListForm.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            LoginForm2 appointmentSchedulingForm = new LoginForm2();
            appointmentSchedulingForm.Show();
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

        private void RoleSelectionLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}


    

   

   