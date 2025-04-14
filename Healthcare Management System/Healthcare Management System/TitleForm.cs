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
        private Label lblTitle;

        public TitleForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(TitleForm_Resize); // Handle form resize event
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System";
            this.Size = new System.Drawing.Size(800, 600);
            this.BackColor = Color.LightBlue; // Set background color
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form on the screen

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "Healthcare Management System";
            lblTitle.Font = new Font("Arial", 24, FontStyle.Bold); // Large, bold font
            lblTitle.ForeColor = Color.DarkBlue; // Text color
            lblTitle.AutoSize = true; // Automatically adjust the label size to fit the text
            this.Controls.Add(lblTitle);

            // Register Button
            btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Font = new Font("Arial", 14, FontStyle.Bold); // Font for the button
            btnRegister.BackColor = Color.LightGreen; // Button background color
            btnRegister.ForeColor = Color.White; // Button text color
            btnRegister.Size = new System.Drawing.Size(200, 50); // Button size
            this.Controls.Add(btnRegister);

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Font = new Font("Arial", 14, FontStyle.Bold); // Font for the button
            btnLogin.BackColor = Color.LightCoral; // Button background color
            btnLogin.ForeColor = Color.White; // Button text color
            btnLogin.Size = new System.Drawing.Size(200, 50); // Button size
            this.Controls.Add(btnLogin);

            // Set initial positions
            UpdateControlPositions();

            // Event handlers for button clicks
            btnRegister.Click += new EventHandler(btnRegister_Click);
            btnLogin.Click += new EventHandler(btnLogin_Click);
        }

        private void UpdateControlPositions()
        {
            // Center the title label
            lblTitle.Location = new System.Drawing.Point(
                (this.ClientSize.Width - lblTitle.Width) / 2, // Center horizontally
                100 // Position from the top
            );

            // Center the Register button
            btnRegister.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnRegister.Width) / 2, // Center horizontally
                250 // Position from the top
            );

            // Center the Login button
            btnLogin.Location = new System.Drawing.Point(
                (this.ClientSize.Width - btnLogin.Width) / 2, // Center horizontally
                350 // Position from the top
            );
        }

        private void TitleForm_Resize(object sender, EventArgs e)
        {
            // Update control positions when the form is resized
            UpdateControlPositions();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Navigate to the Registration Form
            RoleSelectionForm RoleSelectionForm = new RoleSelectionForm();
            RoleSelectionForm.Show();
            this.Hide(); // Hide the title form
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Navigate to the Login Form
            RoleSelectionLogin loginForm = new RoleSelectionLogin();
            loginForm.Show();
            this.Hide(); // Hide the title form
        }

        private void FirstPage_Load(object sender, EventArgs e)
        {
            // This method is not needed for now
        }
    }
}