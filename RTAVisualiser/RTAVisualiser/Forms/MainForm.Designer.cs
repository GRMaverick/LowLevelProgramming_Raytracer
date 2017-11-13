namespace RTAVisualiser.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DurationAllCartesian = new LiveCharts.WinForms.CartesianChart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RenderPreview = new System.Windows.Forms.PictureBox();
            this.ResCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ThreadCountNUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.PhysicsTickBox = new System.Windows.Forms.CheckBox();
            this.ConcurrentTickBox = new System.Windows.Forms.CheckBox();
            this.FramesTB = new System.Windows.Forms.TextBox();
            this.FPSCBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ConsoleOutputTB = new System.Windows.Forms.RichTextBox();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RenderPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCountNUD)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(850, 22);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(967, 781);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(959, 755);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "All";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cartesianChart1);
            this.groupBox5.Location = new System.Drawing.Point(6, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(947, 365);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Memory Report";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(7, 16);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(934, 343);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "DurationCartesian";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DurationAllCartesian);
            this.groupBox4.Location = new System.Drawing.Point(9, 375);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(944, 372);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Duration Report";
            // 
            // DurationAllCartesian
            // 
            this.DurationAllCartesian.Location = new System.Drawing.Point(4, 19);
            this.DurationAllCartesian.Name = "DurationAllCartesian";
            this.DurationAllCartesian.Size = new System.Drawing.Size(934, 353);
            this.DurationAllCartesian.TabIndex = 0;
            this.DurationAllCartesian.Text = "DurationCartesian";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(959, 755);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Sequential";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RenderPreview
            // 
            this.RenderPreview.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RenderPreview.Location = new System.Drawing.Point(1, 0);
            this.RenderPreview.Name = "RenderPreview";
            this.RenderPreview.Size = new System.Drawing.Size(823, 434);
            this.RenderPreview.TabIndex = 1;
            this.RenderPreview.TabStop = false;
            // 
            // ResCBox
            // 
            this.ResCBox.FormattingEnabled = true;
            this.ResCBox.Items.AddRange(new object[] {
            "3820x2160",
            "1920x1080",
            "640x480"});
            this.ResCBox.Location = new System.Drawing.Point(142, 30);
            this.ResCBox.Name = "ResCBox";
            this.ResCBox.Size = new System.Drawing.Size(121, 21);
            this.ResCBox.TabIndex = 2;
            this.ResCBox.SelectedIndexChanged += new System.EventHandler(this.ResCBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resolution:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 286);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(297, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 259);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scene Objects";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ThreadCountNUD);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.PhysicsTickBox);
            this.groupBox2.Controls.Add(this.ConcurrentTickBox);
            this.groupBox2.Controls.Add(this.FramesTB);
            this.groupBox2.Controls.Add(this.FPSCBox);
            this.groupBox2.Controls.Add(this.ResCBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 259);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Renderer";
            // 
            // ThreadCountNUD
            // 
            this.ThreadCountNUD.Location = new System.Drawing.Point(141, 148);
            this.ThreadCountNUD.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ThreadCountNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadCountNUD.Name = "ThreadCountNUD";
            this.ThreadCountNUD.Size = new System.Drawing.Size(120, 20);
            this.ThreadCountNUD.TabIndex = 11;
            this.ThreadCountNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadCountNUD.ValueChanged += new System.EventHandler(this.ThreadCountNUD_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Max Threads:";
            // 
            // PhysicsTickBox
            // 
            this.PhysicsTickBox.AutoSize = true;
            this.PhysicsTickBox.Location = new System.Drawing.Point(18, 188);
            this.PhysicsTickBox.Name = "PhysicsTickBox";
            this.PhysicsTickBox.Size = new System.Drawing.Size(91, 17);
            this.PhysicsTickBox.TabIndex = 9;
            this.PhysicsTickBox.Text = "Apply Physics";
            this.PhysicsTickBox.UseVisualStyleBackColor = true;
            this.PhysicsTickBox.CheckedChanged += new System.EventHandler(this.PhysicsBox_CheckedChanged);
            // 
            // ConcurrentTickBox
            // 
            this.ConcurrentTickBox.AutoSize = true;
            this.ConcurrentTickBox.Location = new System.Drawing.Point(18, 122);
            this.ConcurrentTickBox.Name = "ConcurrentTickBox";
            this.ConcurrentTickBox.Size = new System.Drawing.Size(130, 17);
            this.ConcurrentTickBox.TabIndex = 5;
            this.ConcurrentTickBox.Text = "Concurrent Rendering";
            this.ConcurrentTickBox.UseVisualStyleBackColor = true;
            this.ConcurrentTickBox.CheckedChanged += new System.EventHandler(this.ConcurrentTickBox_CheckedChanged);
            // 
            // FramesTB
            // 
            this.FramesTB.Location = new System.Drawing.Point(142, 59);
            this.FramesTB.Name = "FramesTB";
            this.FramesTB.Size = new System.Drawing.Size(120, 20);
            this.FramesTB.TabIndex = 8;
            this.FramesTB.Text = "Enter Framecount";
            this.FramesTB.TextChanged += new System.EventHandler(this.FramesTB_TextChanged);
            // 
            // FPSCBox
            // 
            this.FPSCBox.FormattingEnabled = true;
            this.FPSCBox.Items.AddRange(new object[] {
            "24",
            "30",
            "60",
            "90",
            "120"});
            this.FPSCBox.Location = new System.Drawing.Point(142, 86);
            this.FPSCBox.Name = "FPSCBox";
            this.FPSCBox.Size = new System.Drawing.Size(121, 21);
            this.FPSCBox.TabIndex = 4;
            this.FPSCBox.SelectedIndexChanged += new System.EventHandler(this.FPSCBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frames:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Frames Per Second:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 314);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(701, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Render";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 343);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 460);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RenderPreview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Render Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ConsoleOutputTB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Console Output";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ConsoleOutputTB
            // 
            this.ConsoleOutputTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleOutputTB.Location = new System.Drawing.Point(6, 6);
            this.ConsoleOutputTB.Name = "ConsoleOutputTB";
            this.ConsoleOutputTB.ReadOnly = true;
            this.ConsoleOutputTB.Size = new System.Drawing.Size(812, 420);
            this.ConsoleOutputTB.TabIndex = 0;
            this.ConsoleOutputTB.Text = "";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1829, 815);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl2);
            this.Name = "MainForm";
            this.Text = "RTA Visualiser";
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RenderPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadCountNUD)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private LiveCharts.WinForms.CartesianChart DurationAllCartesian;
        private System.Windows.Forms.PictureBox RenderPreview;
        private System.Windows.Forms.ComboBox ResCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FramesTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FPSCBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox5;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ConcurrentTickBox;
        private System.Windows.Forms.NumericUpDown ThreadCountNUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox PhysicsTickBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox ConsoleOutputTB;
    }
}