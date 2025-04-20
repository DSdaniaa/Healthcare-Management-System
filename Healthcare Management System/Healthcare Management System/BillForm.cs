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
    public partial class BillForm : Form
    {
        private Button btnBack, btnPrint;
        private Panel panelMain, panelBill;
        private Label lblTitle, lblClinicInfo, lblPatientInfo, lblBillDetails, lblThankYou;
        private PictureBox pictureBoxLogo;

        public BillForm()
        {
            InitializeComponent();
            CreateControls();
            this.Resize += new EventHandler(BillForm_Resize);
            this.DoubleBuffered = true;
        }

        private void CreateControls()
        {
            // Form setup
            this.Text = "Healthcare Management System - Payment Receipt";
            this.Size = new Size(1000, 800);
            this.BackColor = Color.FromArgb(240, 245, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Shield;

            // Main container panel
            panelMain = new Panel();
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Size = new Size(900, 700);
            this.Controls.Add(panelMain);

            // Bill container panel (receipt-like appearance)
            panelBill = new Panel();
            panelBill.BackColor = Color.FromArgb(250, 250, 250); // Light gray background
            panelBill.BorderStyle = BorderStyle.FixedSingle;
            panelBill.Size = new Size(750, 550); // Narrower receipt
            panelBill.AutoScroll = true; // Add scroll if content is too long
            panelMain.Controls.Add(panelBill);

            // Clinic logo
            pictureBoxLogo = new PictureBox();
            pictureBoxLogo.Size = new Size(100, 100); // Smaller logo
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = CreateClinicLogo();
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            panelBill.Controls.Add(pictureBoxLogo);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "MEDICAL SERVICES RECEIPT";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.AutoSize = true;
            panelBill.Controls.Add(lblTitle);

            // Clinic Information (hardcoded)
            lblClinicInfo = new Label();
            lblClinicInfo.Text = "HEALTHCARE MANAGEMENT SYSTEM\n" +
                                "123 Medical Center Drive\n" +
                                "Healthville, HV 12345\n" +
                                "Phone: (555) 123-4567\n" +
                                "Tax ID: 12-3456789\n" +
                                $"Date: {DateTime.Now:MMMM dd, yyyy}\n" +
                                $"Receipt #: {new Random().Next(10000, 99999)}";
            lblClinicInfo.Font = new Font("Segoe UI", 9, FontStyle.Regular); // Smaller font
            lblClinicInfo.ForeColor = Color.FromArgb(64, 64, 64);
            lblClinicInfo.AutoSize = true;
            panelBill.Controls.Add(lblClinicInfo);

            // Patient Information (hardcoded)
            lblPatientInfo = new Label();
            lblPatientInfo.Text = "PATIENT INFORMATION:\n" +
                                "Name: Dania Saqib\n" +
                                "Age: 28\n" +
                                "Gender: Female\n" +
                                "Patient ID: PAT-2023-7890\n" +
                                "Insurance: Premium Health Plus\n" +
                                "Policy #: PHP-7890-1234";
            lblPatientInfo.Font = new Font("Segoe UI", 9, FontStyle.Bold); // Smaller font
            lblPatientInfo.ForeColor = Color.FromArgb(64, 64, 64);
            lblPatientInfo.AutoSize = true;
            panelBill.Controls.Add(lblPatientInfo);

            // Bill Details (hardcoded with realistic medical pricing)
            lblBillDetails = new Label();
            lblBillDetails.Text = "BILL DETAILS:\n" +
                                "----------------------------------------------------------\n" +
                                "Service Description".PadRight(40) + "Amount".PadLeft(15) + "\n" +
                                "----------------------------------------------------------\n" +
                                "Consultation with Dr. Smith".PadRight(40) + "$250.00".PadLeft(15) + "\n" +
                                "Diagnostic Tests".PadRight(40) + "$175.50".PadLeft(15) + "\n" +
                                "Medical Procedures".PadRight(40) + "$420.75".PadLeft(15) + "\n" +
                                "Medications".PadRight(40) + "$85.25".PadLeft(15) + "\n" +
                                "----------------------------------------------------------\n" +
                                "Subtotal:".PadRight(40) + "$931.50".PadLeft(15) + "\n" +
                                "Tax (7.5%)".PadRight(40) + "$69.86".PadLeft(15) + "\n" +
                                "Insurance Adjustment".PadRight(40) + "-$300.00".PadLeft(15) + "\n" +
                                "----------------------------------------------------------\n" +
                                "TOTAL DUE:".PadRight(40) + "$701.36".PadLeft(15) + "\n" +
                                "----------------------------------------------------------\n" +
                                "Payment Method: Credit Card (****-****-****-1234)\n" +
                                "Payment Status: PAID\n" +
                                $"Payment Date: {DateTime.Now:MMMM dd, yyyy}";
            lblBillDetails.Font = new Font("Consolas", 9, FontStyle.Regular); // Smaller monospaced font
            lblBillDetails.ForeColor = Color.Black;
            lblBillDetails.AutoSize = true;
            panelBill.Controls.Add(lblBillDetails);

            // Thank you message
            lblThankYou = new Label();
            lblThankYou.Text = "Thank you for choosing our healthcare services!\n" +
                             "Please bring this receipt for your next visit.\n" +
                             "For questions, call (555) 123-4567 during business hours.";
            lblThankYou.Font = new Font("Segoe UI", 9, FontStyle.Italic); // Smaller font
            lblThankYou.ForeColor = Color.FromArgb(64, 64, 64);
            lblThankYou.TextAlign = ContentAlignment.MiddleCenter;
            lblThankYou.AutoSize = false;
            lblThankYou.Size = new Size(650, 60); // Narrower to fit receipt
            panelBill.Controls.Add(lblThankYou);

            // Back Button
            btnBack = new Button();
            btnBack.Text = "BACK TO MAIN MENU";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = Color.FromArgb(149, 165, 166);
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Size = new Size(200, 40);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new EventHandler(btnBack_Click);
            btnBack.MouseEnter += Button_MouseEnter;
            btnBack.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnBack);

            // Print Button
            btnPrint = new Button();
            btnPrint.Text = "PRINT RECEIPT";
            btnPrint.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnPrint.BackColor = Color.FromArgb(41, 128, 185);
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Size = new Size(200, 40);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Click += new EventHandler(btnPrint_Click);
            btnPrint.MouseEnter += Button_MouseEnter;
            btnPrint.MouseLeave += Button_MouseLeave;
            panelMain.Controls.Add(btnPrint);

            UpdateControlPositions();
        }

        private Image CreateClinicLogo()
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Draw medical cross with heart
                using (Brush brush = new SolidBrush(Color.FromArgb(0, 102, 204)))
                {
                    // Cross
                    g.FillRectangle(brush, 40, 20, 20, 60);
                    g.FillRectangle(brush, 20, 40, 60, 20);

                    // Heart
                    Point[] heartPoints = {
                        new Point(50, 70),
                        new Point(60, 80),
                        new Point(70, 70),
                        new Point(60, 50),
                        new Point(50, 70)
                    };
                    g.FillPolygon(brush, heartPoints);
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

            // Center the bill panel (narrow receipt in the middle)
            panelBill.Location = new Point(
                (panelMain.Width - panelBill.Width) / 2,
                30
            );

            // Logo position
            pictureBoxLogo.Location = new Point(
                (panelBill.Width - pictureBoxLogo.Width) / 2,
                20
            );

            // Title position
            lblTitle.Location = new Point(
                (panelBill.Width - lblTitle.Width) / 2,
                pictureBoxLogo.Bottom + 10
            );

            // Clinic info position
            lblClinicInfo.Location = new Point(
                (panelBill.Width - lblClinicInfo.Width) / 2,
                lblTitle.Bottom + 15
            );

            // Patient info position
            lblPatientInfo.Location = new Point(
                50,
                lblClinicInfo.Bottom + 20
            );

            // Bill details position
            lblBillDetails.Location = new Point(
                50,
                lblPatientInfo.Bottom + 20
            );

            // Thank you message position
            lblThankYou.Location = new Point(
                (panelBill.Width - lblThankYou.Width) / 2,
                lblBillDetails.Bottom + 20
            );

            // Adjust panel height to fit all content
            panelBill.Height = Math.Min(lblThankYou.Bottom + 20, 550);

            // Buttons position
            btnBack.Location = new Point(
                panelMain.Width / 2 - btnBack.Width - 20,
                panelMain.Height - btnBack.Height - 30
            );

            btnPrint.Location = new Point(
                panelMain.Width / 2 + 20,
                panelMain.Height - btnPrint.Height - 30
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
            if (button == btnBack)
                button.BackColor = Color.FromArgb(149, 165, 166);
            else if (button == btnPrint)
                button.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void BillForm_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TitleForm titleForm = new TitleForm();
            titleForm.Show();
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality would be implemented here in a production environment.",
                "Print Receipt",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            // Add receipt-like styling to bill panel
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, panelBill.Left, panelBill.Top, panelBill.Width, panelBill.Height);
            }
        }

        private void BillForm_Load(object sender, EventArgs e)
        {

        }

    }
}


    