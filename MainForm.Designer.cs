namespace TemplateEngineApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(984, 461);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.projectNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.openButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.createButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.generateButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.consoleTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.projectNameLabel, 2);
            this.projectNameLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.projectNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.projectNameLabel.Location = new System.Drawing.Point(2, 0);
            this.projectNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(546, 27);
            this.projectNameLabel.TabIndex = 2;
            this.projectNameLabel.Text = "Project not found";
            this.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.AutoSize = true;
            this.openButton.BackColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(2, 398);
            this.openButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(271, 26);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Open project";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.createButton.AutoSize = true;
            this.createButton.BackColor = System.Drawing.Color.White;
            this.createButton.Location = new System.Drawing.Point(277, 398);
            this.createButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(271, 26);
            this.createButton.TabIndex = 3;
            this.createButton.Text = "Create project";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.AutoSize = true;
            this.generateButton.BackColor = System.Drawing.Color.White;
            this.generateButton.Location = new System.Drawing.Point(2, 431);
            this.generateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(271, 26);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.AutoSize = true;
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(277, 431);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(271, 26);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save settings";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanel1.SetColumnSpan(this.consoleTextBox, 2);
            this.consoleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleTextBox.Location = new System.Drawing.Point(3, 30);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.Size = new System.Drawing.Size(544, 362);
            this.consoleTextBox.TabIndex = 4;
            this.consoleTextBox.Text = "";
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.White;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpBackColor = System.Drawing.Color.White;
            this.propertyGrid.Location = new System.Drawing.Point(2, 3);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid.Size = new System.Drawing.Size(427, 455);
            this.propertyGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(392, 227);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEA";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private PropertyGrid propertyGrid;
        private Label projectNameLabel;
        private Button openButton;
        private Button createButton;
        private Button generateButton;
        private Button saveButton;
        private RichTextBox consoleTextBox;
    }
}