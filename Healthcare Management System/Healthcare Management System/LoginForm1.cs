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
    public partial class LoginForm1 : Form
    {
        // Hardcoded credentials
        private const string ValidUsername = "Dania Saqib";
        private const string ValidPassword = "dania123";

        private Label lblTitle, lblInstruction, lblQuote;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnBack;
        private Panel panelMain;
        private PictureBox pictureBoxIcon;

        public LoginForm1()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(LoginForm_Resize);
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

            // Main container panel
            panelMain = new Panel();
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Size = new Size(900, 600);
            this.Controls.Add(panelMain);

            // Login icon
            pictureBoxIcon = new PictureBox();
            pictureBoxIcon.Size = new Size(100, 100);
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Image = CreateLoginIcon();
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            panelMain.Controls.Add(pictureBoxIcon);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "USER LOGIN";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelMain.Controls.Add(lblTitle);

            // Instruction label
            lblInstruction = new Label();
            lblInstruction.Text = "Please enter your credentials to access the system";
            lblInstruction.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            lblInstruction.ForeColor = Color.FromArgb(64, 64, 64);
            lblInstruction.AutoSize = true;
            panelMain.Controls.Add(lblInstruction);

            // Username Label
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblUsername.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsername.AutoSize = true;
            panelMain.Controls.Add(lblUsername);

            // Username TextBox
            txtUsername = new TextBox();
            txtUsername.Font = new Font("Segoe UI", 11);
            txtUsername.Size = new Size(350, 30);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(txtUsername);

            // Password Label
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.AutoSize = true;
            panelMain.Controls.Add(lblPassword);

            // Password TextBox
            txtPassword = new TextBox();
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.Size = new Size(350, 30);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '•';
            panelMain.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "LOGIN";
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(41, 128, 185); // Professional blue
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Size = new Size(350, 50);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += new EventHandler(btnLogin_Click);
            btnLogin.MouseEnter += Button_MouseEnter;
            btnLogin.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnLogin);

            // Back Button (bottom-right corner)
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

            // Healthcare Quote
            lblQuote = new Label();
            lblQuote.Text = "\"The art of medicine consists of amusing the patient while nature cures the disease.\" - Voltaire";
            lblQuote.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblQuote.ForeColor = Color.FromArgb(100, 100, 100);
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.AutoSize = false;
            lblQuote.Size = new Size(800, 40);
            panelMain.Controls.Add(lblQuote);

            UpdateControlPositions();
        }

        private Image CreateLoginIcon()
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Draw a simple key icon
                using (Pen pen = new Pen(Color.FromArgb(0, 102, 204), 4))
                {
                    // Key handle
                    g.DrawEllipse(pen, 30, 30, 40, 40);
                    // Key teeth
                    g.DrawLine(pen, 50, 70, 50, 90);
                    g.DrawLine(pen, 50, 80, 70, 80);
                    g.DrawLine(pen, 70, 70, 70, 90);
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
            lblTitle.Location = new Point(
                (panelMain.Width - lblTitle.Width) / 2,
                pictureBoxIcon.Bottom + 20
            );

            // Instruction position
            lblInstruction.Location = new Point(
                (panelMain.Width - lblInstruction.Width) / 2,
                lblTitle.Bottom + 10
            );

            // Username label position
            Label lblUsername = (Label)panelMain.Controls[3]; // 4th control added
            lblUsername.Location = new Point(
                (panelMain.Width - 350) / 2,
                lblInstruction.Bottom + 40
            );

            // Username textbox position
            txtUsername.Location = new Point(
                (panelMain.Width - txtUsername.Width) / 2,
                lblUsername.Bottom + 10
            );

            // Password label position
            Label lblPassword = (Label)panelMain.Controls[5]; // 6th control added
            lblPassword.Location = new Point(
                (panelMain.Width - 350) / 2,
                txtUsername.Bottom + 20
            );

            // Password textbox position
            txtPassword.Location = new Point(
                (panelMain.Width - txtPassword.Width) / 2,
                lblPassword.Bottom + 10
            );

            // Login button position
            btnLogin.Location = new Point(
                (panelMain.Width - btnLogin.Width) / 2,
                txtPassword.Bottom + 30
            );

            // Back button position (bottom-right corner)
            btnBack.Location = new Point(
                panelMain.Width - btnBack.Width - 30,
                panelMain.Height - btnBack.Height - 30
            );

            // Quote position
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
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == btnLogin)
                button.BackColor = Color.FromArgb(41, 128, 185);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(149, 165, 166);
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == ValidUsername && txtPassword.Text == ValidPassword)
            {
                // Successful login - navigate to dashboard
                PatientMedicalHistoryListForm dashboard = new PatientMedicalHistoryListForm();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // Failed login
                MessageBox.Show("Username or password is incorrect. Please try again.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Clear password field and focus it
                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RoleSelectionLogin roleSelection = new RoleSelectionLogin();
            roleSelection.Show();
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


        private void LoginForm1_Load(object sender, EventArgs e)
        {

        }
    }
}


