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
    public partial class TitleForm : Form
    {
        private Button btnRegister, btnLogin;
        private Label lblTitle, lblSubtitle, lblQuote;
        private Panel panelMain, panelButtons;
        private PictureBox pictureBoxLogo;

        public TitleForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(TitleForm_Resize);
            this.DoubleBuffered = true; // Reduce flickering
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(240, 245, 249); // Soft blue background
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Shield; // Medical shield icon

            // Main container panel with shadow effect
            panelMain = new Panel();
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Size = new Size(900, 600);
            this.Controls.Add(panelMain);

            // Logo
            pictureBoxLogo = new PictureBox();
            pictureBoxLogo.Size = new Size(120, 120);
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = CreateMedicalIcon();
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            panelMain.Controls.Add(pictureBoxLogo);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "HEALTHCARE MANAGEMENT SYSTEM";
            lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204); // Professional blue
            lblTitle.AutoSize = true;
            panelMain.Controls.Add(lblTitle);

            // Subtitle Label
            lblSubtitle = new Label();
            lblSubtitle.Text = "Comprehensive Patient Care Solution";
            lblSubtitle.Font = new Font("Segoe UI", 14, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblSubtitle.AutoSize = true;
            panelMain.Controls.Add(lblSubtitle);

            // Button container panel
            panelButtons = new Panel();
            panelButtons.BackColor = Color.FromArgb(240, 240, 240);
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Size = new Size(400, 200);
            panelMain.Controls.Add(panelButtons);

            // Register Button
            btnRegister = new Button();
            btnRegister.Text = "REGISTER";
            btnRegister.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(76, 175, 80); // Professional green
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Size = new Size(300, 50);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.MouseEnter += Button_MouseEnter;
            btnRegister.MouseLeave += Button_MouseLeave;
            panelButtons.Controls.Add(btnRegister);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "LOGIN";
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(41, 128, 185); // Professional blue
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Size = new Size(300, 50);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.MouseEnter += Button_MouseEnter;
            btnLogin.MouseLeave += Button_MouseLeave;
            panelButtons.Controls.Add(btnLogin);

            // Medical Quote
            lblQuote = new Label();
            lblQuote.Text = "\"Wherever the art of medicine is loved, there is also a love of humanity.\" - Hippocrates";
            lblQuote.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblQuote.ForeColor = Color.FromArgb(100, 100, 100);
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.AutoSize = false;
            lblQuote.Size = new Size(800, 40);
            panelMain.Controls.Add(lblQuote);

            // Set initial positions
            UpdateControlPositions();

            // Event handlers for button clicks
            btnRegister.Click += new EventHandler(btnRegister_Click);
            btnLogin.Click += new EventHandler(btnLogin_Click);
        }

        private Image CreateMedicalIcon()
        {
            // Create a simple medical icon programmatically
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Draw medical cross
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 102, 204)))
                {
                    g.FillRectangle(brush, 50, 20, 20, 80); // Vertical bar
                    g.FillRectangle(brush, 20, 50, 80, 20); // Horizontal bar
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

            // Logo position
            pictureBoxLogo.Location = new Point(
                (panelMain.Width - pictureBoxLogo.Width) / 2,
                40
            );

            // Title position
            lblTitle.Location = new Point(
                (panelMain.Width - lblTitle.Width) / 2,
                pictureBoxLogo.Bottom + 20
            );

            // Subtitle position
            lblSubtitle.Location = new Point(
                (panelMain.Width - lblSubtitle.Width) / 2,
                lblTitle.Bottom + 10
            );

            // Buttons panel position
            panelButtons.Location = new Point(
                (panelMain.Width - panelButtons.Width) / 2,
                lblSubtitle.Bottom + 60
            );

            // Register button position
            btnRegister.Location = new Point(
                (panelButtons.Width - btnRegister.Width) / 2,
                30
            );

            // Login button position
            btnLogin.Location = new Point(
                (panelButtons.Width - btnLogin.Width) / 2,
                btnRegister.Bottom + 20
            );

            // Quote position
            lblQuote.Location = new Point(
                (panelMain.Width - lblQuote.Width) / 2,
                panelMain.Height - lblQuote.Height - 30
            );
        }

        private void TitleForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
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
            if (button == btnRegister)
                button.BackColor = Color.FromArgb(76, 175, 80);
            else if (button == btnLogin)
                button.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Navigate to the Registration Form
            RoleSelectionForm roleSelectionForm = new RoleSelectionForm();
            roleSelectionForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Navigate to the Login Form
            RoleSelectionLogin loginForm = new RoleSelectionLogin();
            loginForm.Show();
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
        private void FirstPage_Load(object sender, EventArgs e)
        {
            // This method is not needed for now
        }
    }
}


   