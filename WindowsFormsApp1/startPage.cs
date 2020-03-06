using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class startPage : Form
    {
        public startPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel newRowPanel = new System.Windows.Forms.Panel();
            // 
            // enumTextbox
            // 
            TextBox newEnumTextBox = new TextBox();
            newEnumTextBox.Location = this.enumTextBox.Location;

            newEnumTextBox.Size = this.enumTextBox.Size;
            newEnumTextBox.Visible = false;
            newEnumTextBox.Name = "enumTextBox" + rowCount;
            // 
            // enumLabel
            // 
            Label newEnumLabel = new Label();

            newEnumLabel.AutoSize = true;
            newEnumLabel.Location = this.enumLabel.Location;

            newEnumLabel.Size = this.enumLabel.Size;
            newEnumLabel.Text = this.enumLabel.Text;
            newEnumLabel.Visible = false;
            newEnumLabel.Name = "enumLabel" + rowCount;


            // enumButton
            // 
            Button newEnumButton = new Button();
            newEnumButton.Location = this.enumButton.Location;

            newEnumButton.Size = this.enumButton.Size;
            newEnumButton.TabIndex = 32;
            newEnumButton.Text = "Enum";
            newEnumButton.UseVisualStyleBackColor = true;
            newEnumButton.Click += (object sender1, EventArgs e1) => {
                newEnumLabel.Visible = !newEnumLabel.Visible;
                newEnumTextBox.Visible = !newEnumTextBox.Visible;
            };
            newEnumButton.Name = "enumButton" + rowCount;

            // 
            // typeComboBox
            // 
            ComboBox newTypeComboBox = new ComboBox();
            newTypeComboBox.FormattingEnabled = true;
            newTypeComboBox.Items.AddRange(new object[] {
            "int",
            "string",
            "bool",
            "enum"});
            newTypeComboBox.Location = this.typeComboBox.Location;

            newTypeComboBox.Size = this.typeComboBox.Size;
            newTypeComboBox.Name = "typeComboBox" + rowCount;

            // 
            // typeLabel
            // 
            Label newTypeLabel = new Label();

            newTypeLabel.AutoSize = true;
            newTypeLabel.Location = this.typeLabel.Location;
            newTypeLabel.Size = this.typeLabel.Size;
            newTypeLabel.Text = this.typeLabel.Text;
            newTypeLabel.Name = "typeLabel" + rowCount;

            // 
            // nameTextBox
            // 

            TextBox newNameTextBox = new TextBox();
            newNameTextBox.Location = this.nameTextBox.Location;
            newNameTextBox.Size = this.nameTextBox.Size;
            newNameTextBox.Name = "nameTextBox" + rowCount;

            // 
            // nameLabel
            // 

            Label newNameLabel = new Label();

            newNameLabel.AutoSize = true;
            newNameLabel.Location = this.nameLabel.Location;
            newNameLabel.Size = this.nameLabel.Size;
            newNameLabel.Text = this.nameLabel.Text;
            newNameLabel.Name = "nameLabel" + rowCount;

            //add them all to rowPanel
            newRowPanel.Controls.Add(newEnumButton);
            newRowPanel.Controls.Add(newEnumTextBox);
            newRowPanel.Controls.Add(newEnumLabel);
            newRowPanel.Controls.Add(newTypeComboBox);
            newRowPanel.Controls.Add(newTypeLabel);
            newRowPanel.Controls.Add(newNameTextBox);
            newRowPanel.Controls.Add(newNameLabel);
            newRowPanel.Location = new System.Drawing.Point(rowPanel.Location.X, rowPanel.Location.Y + rowCount * rowPanel.Size.Height);
            newRowPanel.Name = "rowPanel" + rowCount;
            newRowPanel.Size = new System.Drawing.Size(rowPanel.Size.Width, rowPanel.Size.Height);
            newRowPanel.TabIndex = 1;
            listPanel.Controls.Add(newRowPanel);
            rowCount++;
        }

        private void generateCodeButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            string folderName = "";
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
               folderName = folderBrowserDialog1.SelectedPath;
            }

            LionResource lionResource = DataParser.startPageToResource(this);
            CodeGenerator codeGenerator = new CodeGenerator(lionResource);
            codeGenerator.Generate(folderName);
        }

        private Int32 rowCount = 1;

        private void button4_Click(object sender, EventArgs e)
        {
            this.enumLabel.Visible = !this.enumLabel.Visible;
            this.enumTextBox.Visible = !this.enumTextBox.Visible;
        }
    }
}
