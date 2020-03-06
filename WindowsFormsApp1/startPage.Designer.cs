namespace WindowsFormsApp1
{
    partial class startPage
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
            this.button1 = new System.Windows.Forms.Button();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.postCheckBox = new System.Windows.Forms.CheckBox();
            this.getSingleCheckBox = new System.Windows.Forms.CheckBox();
            this.putCheckBox = new System.Windows.Forms.CheckBox();
            this.getCheckBox = new System.Windows.Forms.CheckBox();
            this.resourceNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.moduleComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generateCodeButton = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.rowPanel = new System.Windows.Forms.Panel();
            this.enumButton = new System.Windows.Forms.Button();
            this.enumTextBox = new System.Windows.Forms.TextBox();
            this.enumLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.apiLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listPanel.SuspendLayout();
            this.rowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(725, 30);
            this.button1.TabIndex = 29;
            this.button1.Text = "Add Field";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Location = new System.Drawing.Point(745, 123);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(57, 17);
            this.deleteCheckBox.TabIndex = 26;
            this.deleteCheckBox.Text = "Delete";
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // postCheckBox
            // 
            this.postCheckBox.AutoSize = true;
            this.postCheckBox.Location = new System.Drawing.Point(622, 123);
            this.postCheckBox.Name = "postCheckBox";
            this.postCheckBox.Size = new System.Drawing.Size(47, 17);
            this.postCheckBox.TabIndex = 25;
            this.postCheckBox.Text = "Post";
            this.postCheckBox.UseVisualStyleBackColor = true;
            // 
            // getSingleCheckBox
            // 
            this.getSingleCheckBox.AutoSize = true;
            this.getSingleCheckBox.Location = new System.Drawing.Point(382, 123);
            this.getSingleCheckBox.Name = "getSingleCheckBox";
            this.getSingleCheckBox.Size = new System.Drawing.Size(75, 17);
            this.getSingleCheckBox.TabIndex = 24;
            this.getSingleCheckBox.Text = "Get Single";
            this.getSingleCheckBox.UseVisualStyleBackColor = true;
            // 
            // putCheckBox
            // 
            this.putCheckBox.AutoSize = true;
            this.putCheckBox.Location = new System.Drawing.Point(505, 123);
            this.putCheckBox.Name = "putCheckBox";
            this.putCheckBox.Size = new System.Drawing.Size(42, 17);
            this.putCheckBox.TabIndex = 23;
            this.putCheckBox.Text = "Put";
            this.putCheckBox.UseVisualStyleBackColor = true;
            // 
            // getCheckBox
            // 
            this.getCheckBox.AutoSize = true;
            this.getCheckBox.Location = new System.Drawing.Point(279, 123);
            this.getCheckBox.Name = "getCheckBox";
            this.getCheckBox.Size = new System.Drawing.Size(43, 17);
            this.getCheckBox.TabIndex = 22;
            this.getCheckBox.Text = "Get";
            this.getCheckBox.UseVisualStyleBackColor = true;
            // 
            // resourceNameTextBox
            // 
            this.resourceNameTextBox.Location = new System.Drawing.Point(505, 64);
            this.resourceNameTextBox.Name = "resourceNameTextBox";
            this.resourceNameTextBox.Size = new System.Drawing.Size(138, 20);
            this.resourceNameTextBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Resource Name:";
            // 
            // moduleComboBox
            // 
            this.moduleComboBox.FormattingEnabled = true;
            this.moduleComboBox.Items.AddRange(new object[] {
            "ACCOUNTP",
            "ACSP",
            "ABSP",
            "AUTHP",
            "D2FSP",
            "SMSP",
            "SNSP"});
            this.moduleComboBox.Location = new System.Drawing.Point(222, 64);
            this.moduleComboBox.Name = "moduleComboBox";
            this.moduleComboBox.Size = new System.Drawing.Size(121, 21);
            this.moduleComboBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Module:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "CRUD Code Generator - LION";
            // 
            // generateCodeButton
            // 
            this.generateCodeButton.Location = new System.Drawing.Point(174, 491);
            this.generateCodeButton.Name = "generateCodeButton";
            this.generateCodeButton.Size = new System.Drawing.Size(725, 30);
            this.generateCodeButton.TabIndex = 33;
            this.generateCodeButton.Text = "Generate Code";
            this.generateCodeButton.UseVisualStyleBackColor = true;
            this.generateCodeButton.Click += new System.EventHandler(this.generateCodeButton_Click);
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.Controls.Add(this.rowPanel);
            this.listPanel.Location = new System.Drawing.Point(175, 196);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(765, 260);
            this.listPanel.TabIndex = 32;
            // 
            // rowPanel
            // 
            this.rowPanel.Controls.Add(this.enumButton);
            this.rowPanel.Controls.Add(this.enumTextBox);
            this.rowPanel.Controls.Add(this.enumLabel);
            this.rowPanel.Controls.Add(this.typeComboBox);
            this.rowPanel.Controls.Add(this.typeLabel);
            this.rowPanel.Controls.Add(this.nameTextBox);
            this.rowPanel.Controls.Add(this.nameLabel);
            this.rowPanel.Location = new System.Drawing.Point(3, 3);
            this.rowPanel.Name = "rowPanel";
            this.rowPanel.Size = new System.Drawing.Size(721, 51);
            this.rowPanel.TabIndex = 2;
            // 
            // enumButton
            // 
            this.enumButton.Location = new System.Drawing.Point(327, 11);
            this.enumButton.Name = "enumButton";
            this.enumButton.Size = new System.Drawing.Size(88, 30);
            this.enumButton.TabIndex = 32;
            this.enumButton.Text = "Enum";
            this.enumButton.UseVisualStyleBackColor = true;
            this.enumButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // enumTextBox
            // 
            this.enumTextBox.Location = new System.Drawing.Point(588, 15);
            this.enumTextBox.Name = "enumTextBox";
            this.enumTextBox.Size = new System.Drawing.Size(126, 20);
            this.enumTextBox.TabIndex = 5;
            this.enumTextBox.Visible = false;
            // 
            // enumLabel
            // 
            this.enumLabel.AutoSize = true;
            this.enumLabel.Location = new System.Drawing.Point(428, 18);
            this.enumLabel.Name = "enumLabel";
            this.enumLabel.Size = new System.Drawing.Size(159, 13);
            this.enumLabel.TabIndex = 4;
            this.enumLabel.Text = "Enum Values(comma separated)";
            this.enumLabel.Visible = false;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "int",
            "string",
            "bool",
            "enum"});
            this.typeComboBox.Location = new System.Drawing.Point(188, 16);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.typeComboBox.TabIndex = 3;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(151, 18);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "Type";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(44, 15);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(700, 67);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(23, 13);
            this.urlLabel.TabIndex = 34;
            this.urlLabel.Text = "Url:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(745, 64);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(179, 20);
            this.urlTextBox.TabIndex = 35;
            // 
            // apiLabel
            // 
            this.apiLabel.AutoSize = true;
            this.apiLabel.Location = new System.Drawing.Point(175, 124);
            this.apiLabel.Name = "apiLabel";
            this.apiLabel.Size = new System.Drawing.Size(66, 13);
            this.apiLabel.TabIndex = 36;
            this.apiLabel.Text = "CRUD APIs:";
            // 
            // startPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 633);
            this.Controls.Add(this.apiLabel);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.generateCodeButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteCheckBox);
            this.Controls.Add(this.postCheckBox);
            this.Controls.Add(this.getSingleCheckBox);
            this.Controls.Add(this.putCheckBox);
            this.Controls.Add(this.getCheckBox);
            this.Controls.Add(this.resourceNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.moduleComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "startPage";
            this.Text = "Form1";
            this.listPanel.ResumeLayout(false);
            this.rowPanel.ResumeLayout(false);
            this.rowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.CheckBox postCheckBox;
        private System.Windows.Forms.CheckBox getSingleCheckBox;
        private System.Windows.Forms.CheckBox putCheckBox;
        private System.Windows.Forms.CheckBox getCheckBox;
        private System.Windows.Forms.TextBox resourceNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox moduleComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generateCodeButton;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Panel rowPanel;
        private System.Windows.Forms.Button enumButton;
        private System.Windows.Forms.TextBox enumTextBox;
        private System.Windows.Forms.Label enumLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label apiLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

