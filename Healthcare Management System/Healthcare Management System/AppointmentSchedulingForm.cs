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
        private Label lblTitle, lblDoctor, lblAppointment, lblReason;
        private Panel panelMain;
        private PictureBox pictureBoxIcon;

        public AppointmentSchedulingForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(AppointmentSchedulingForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System - Schedule Appointment";
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

            // Appointment icon
            pictureBoxIcon = new PictureBox();
            pictureBoxIcon.Size = new Size(100, 100);
            pictureBoxIcon.BackColor = Color.Transparent;
            pictureBoxIcon.Image = CreateAppointmentIcon();
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            panelMain.Controls.Add(pictureBoxIcon);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "SCHEDULE YOUR APPOINTMENT";
            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelMain.Controls.Add(lblTitle);

            // Doctor Label
            lblDoctor = new Label();
            lblDoctor.Text = "Select Doctor:";
            lblDoctor.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblDoctor.ForeColor = Color.FromArgb(64, 64, 64);
            lblDoctor.AutoSize = true;
            panelMain.Controls.Add(lblDoctor);

            // Doctor ComboBox
            comboBoxDoctor = new ComboBox();
            comboBoxDoctor.Font = new Font("Segoe UI", 11);
            comboBoxDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDoctor.Items.AddRange(new string[] {
                "Dr. Smith - Cardiology",
                "Dr. Johnson - Dermatology",
                "Dr. Lee - Pediatrics",
                "Dr. Williams - Neurology",
                "Dr. Brown - General Surgery"
            });
            comboBoxDoctor.Size = new Size(400, 30);
            panelMain.Controls.Add(comboBoxDoctor);

            // Appointment Date/Time Label
            lblAppointment = new Label();
            lblAppointment.Text = "Appointment Date & Time:";
            lblAppointment.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAppointment.ForeColor = Color.FromArgb(64, 64, 64);
            lblAppointment.AutoSize = true;
            panelMain.Controls.Add(lblAppointment);

            // Appointment DateTimePicker
            dateTimePickerAppointment = new DateTimePicker();
            dateTimePickerAppointment.Font = new Font("Segoe UI", 11);
            dateTimePickerAppointment.Format = DateTimePickerFormat.Custom;
            dateTimePickerAppointment.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePickerAppointment.Size = new Size(400, 30);
            dateTimePickerAppointment.MinDate = DateTime.Today;
            dateTimePickerAppointment.MaxDate = DateTime.Today.AddMonths(3);
            panelMain.Controls.Add(dateTimePickerAppointment);

            // Reason Label
            lblReason = new Label();
            lblReason.Text = "Reason for Visit:";
            lblReason.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblReason.ForeColor = Color.FromArgb(64, 64, 64);
            lblReason.AutoSize = true;
            panelMain.Controls.Add(lblReason);

            // Reason TextBox
            txtReason = new TextBox();
            txtReason.Font = new Font("Segoe UI", 11);
            txtReason.Size = new Size(400, 30);
            txtReason.BorderStyle = BorderStyle.FixedSingle;
            txtReason.Multiline = true;
            txtReason.Height = 80;
            panelMain.Controls.Add(txtReason);

            // Book Appointment Button
            btnBookAppointment = new Button();
            btnBookAppointment.Text = "BOOK APPOINTMENT";
            btnBookAppointment.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnBookAppointment.BackColor = Color.FromArgb(39, 174, 96); // Professional green
            btnBookAppointment.ForeColor = Color.White;
            btnBookAppointment.FlatStyle = FlatStyle.Flat;
            btnBookAppointment.FlatAppearance.BorderSize = 0;
            btnBookAppointment.Size = new Size(250, 50);
            btnBookAppointment.Cursor = Cursors.Hand;
            btnBookAppointment.Click += new EventHandler(btnBookAppointment_Click);
            btnBookAppointment.MouseEnter += Button_MouseEnter;
            btnBookAppointment.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnBookAppointment);

            // Reset Button
            btnReset = new Button();
            btnReset.Text = "RESET FORM";
            btnReset.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnReset.BackColor = Color.FromArgb(192, 57, 43); // Professional red
            btnReset.ForeColor = Color.White;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Size = new Size(250, 50);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Click += new EventHandler(btnReset_Click);
            btnReset.MouseEnter += Button_MouseEnter;
            btnReset.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnReset);

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

            UpdateControlPositions();
        }

        private Image CreateAppointmentIcon()
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Draw calendar icon
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 102, 204)))
                {
                    // Calendar body
                    g.FillRectangle(brush, 20, 30, 60, 50);

                    // Calendar header
                    g.FillRectangle(brush, 20, 15, 60, 15);

                    // Calendar lines
                    using (Pen pen = new Pen(Color.White, 2))
                    {
                        g.DrawLine(pen, 35, 40, 35, 70);
                        g.DrawLine(pen, 50, 40, 50, 70);
                        g.DrawLine(pen, 25, 50, 75, 50);
                    }
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

            // Doctor label position
            lblDoctor.Location = new Point(
                (panelMain.Width - 400) / 2,
                lblTitle.Bottom + 40
            );

            // Doctor combobox position
            comboBoxDoctor.Location = new Point(
                (panelMain.Width - comboBoxDoctor.Width) / 2,
                lblDoctor.Bottom + 10
            );

            // Appointment label position
            lblAppointment.Location = new Point(
                (panelMain.Width - 400) / 2,
                comboBoxDoctor.Bottom + 20
            );

            // Appointment datetime picker position
            dateTimePickerAppointment.Location = new Point(
                (panelMain.Width - dateTimePickerAppointment.Width) / 2,
                lblAppointment.Bottom + 10
            );

            // Reason label position
            lblReason.Location = new Point(
                (panelMain.Width - 400) / 2,
                dateTimePickerAppointment.Bottom + 20
            );

            // Reason textbox position
            txtReason.Location = new Point(
                (panelMain.Width - txtReason.Width) / 2,
                lblReason.Bottom + 10
            );

            // Book Appointment button position
            btnBookAppointment.Location = new Point(
                (panelMain.Width / 2) - btnBookAppointment.Width - 20,
                txtReason.Bottom + 30
            );

            // Reset button position
            btnReset.Location = new Point(
                (panelMain.Width / 2) + 20,
                txtReason.Bottom + 30
            );

            // Back button position (bottom-right corner)
            btnBack.Location = new Point(
                panelMain.Width - btnBack.Width - 30,
                panelMain.Height - btnBack.Height - 30
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
            if (button == btnBookAppointment)
                button.BackColor = Color.FromArgb(39, 174, 96);
            else if (button == btnReset)
                button.BackColor = Color.FromArgb(192, 57, 43);
            else if (button == btnBack)
                button.BackColor = Color.FromArgb(149, 165, 166);
        }

        private void AppointmentSchedulingForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if (comboBoxDoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a doctor.", "Incomplete Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for your visit.", "Incomplete Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string doctor = comboBoxDoctor.SelectedItem.ToString();
            DateTime appointmentTime = dateTimePickerAppointment.Value;
            string reason = txtReason.Text;

            DialogResult result = MessageBox.Show(
                $"Confirm your appointment with {doctor} on {appointmentTime:MMMM dd, yyyy} at {appointmentTime:h:mm tt}?\n\nReason: {reason}",
                "Confirm Appointment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Your appointment has been successfully booked!", "Appointment Confirmed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to Bill Form
                BillForm billForm = new BillForm();
                billForm.Show();
                this.Hide();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxDoctor.SelectedIndex = -1;
            dateTimePickerAppointment.Value = DateTime.Now;
            txtReason.Clear();
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

        private void AppointmentSchedulingForm_Load(object sender, EventArgs e)
        {
            // This method is not needed for now
        }
    }
}


    