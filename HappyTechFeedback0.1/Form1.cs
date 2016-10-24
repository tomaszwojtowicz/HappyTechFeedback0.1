using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyTechFeedback
{
    public partial class Form1 : Form
    {
        int nextCodeNumber = 1;

        public Form1()
        {
            InitializeComponent();


        }

        private void add_code_Click(object sender, EventArgs e)
        {

            
            GroupBox newBox = getNewCodeGroupBox(nextCodeNumber);
            newBox.Location= new Point(150,55+ nextCodeNumber*150);
            groupBox2.Controls.Add(newBox);
            
            this.Refresh();
            nextCodeNumber++;
        }

        internal GroupBox getNewCodeGroupBox(int nextCodeNumber)
        {
            Label newLabel;

            GroupBox newGroupBox = new GroupBox();
            newGroupBox.Size = new Size(450, 120);

            newLabel = new Label();
            newLabel.Text = "Code Title";
            newLabel.Location = new Point(15, 25);
            newLabel.Size = new Size(75, 15);
            newGroupBox.Controls.Add(newLabel);


            newLabel = new Label();
            newLabel.Text = "Code Content";
            newLabel.Location = new Point(15, 50);
            newLabel.Size = new Size(75, 15);
            newGroupBox.Controls.Add(newLabel);


            TextBox txtBox = new TextBox();
            txtBox.Size = new Size(300, 20);
            txtBox.Location = new Point(100, 25);
            newGroupBox.Controls.Add(txtBox);

         
            txtBox = new TextBox();
            txtBox.Size = new Size(300, 60);
            txtBox.Location = new Point(100, 50);
            txtBox.Multiline = true;
            newGroupBox.Controls.Add(txtBox);

            newGroupBox.Refresh();
                  

            return newGroupBox;
        }

    }
}
