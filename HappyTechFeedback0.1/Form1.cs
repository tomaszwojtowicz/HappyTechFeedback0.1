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
        int nextSectionNumber = 1;

        public Form1()
        {
            InitializeComponent();

            Button addSectionButton = new Button();
            addSectionButton.Text = "Add Section";
            addSectionButton.Location = new Point(10, 230);
            

            GroupBox newSectionBox = getNewSectionGroupBox(0);
            //newBox.Location = new Point(150, 55);
            templateEditGroupBox.Controls.Add(newSectionBox);

            
            templateEditGroupBox.Controls.Add(addSectionButton);


        }



        private void removeCode_Click(object sender, EventArgs e)
        {
            //find out the parent groupBox of the button that was clicked
            Control codeGroupBoxToBeRemoved = ((Button)sender).Parent;

            // and calling button's "grandparent" to remove the groupBox 
            codeGroupBoxToBeRemoved.Parent.Controls.Remove(codeGroupBoxToBeRemoved);

            //change the number of next code so the groupboxes and buttons can be re-aligned after removing the current groupbox
            nextCodeNumber--;
            this.Refresh();

        }

        private void addCodeButton_Click(object sender, EventArgs e)
        {

            //generating new group box to contain code entry dialogs
            GroupBox newCodeGroupBox = getNewCodeGroupBox(nextCodeNumber);

            //setting its location so it can dynamicaly move down depending on nextCodeNumber
            //this part might need some adjusting so the box will be created where we want it
            //  ****** NEEED TO ADD check if that is code number 0 - at the moment it places code nr 0 too high
            // overlaping other texbox
            newCodeGroupBox.Location = new Point(150, nextCodeNumber * 170);

            //find out the parent groupBox of the button that was clicked
            Control currentSectionGroupBox = ((Button)sender).Parent;

            currentSectionGroupBox.Controls.Add(newCodeGroupBox);

            //sectionEntryGroupBox.Controls.Add(newCodeGroupBox);

            //moving the "Add Code" button down, depending on nextCodeNumber
            //again, might need adjusting
            Button currentButton = (Button)sender;

            currentButton.Location = new Point(180, 185 + nextCodeNumber * 150);

            //addSectionButton.Location = new Point(15, 250 + 100);

            this.Refresh();
            nextCodeNumber++;
        }
        /// <summary>
        /// Generates new code entry box
        /// takes one parameter - the next code number
        /// lets say we start with code 0
        /// </summary>
        /// <param name="nextCodeNumber"></param>
        /// <returns></returns>
        internal GroupBox getNewCodeGroupBox(int nextCodeNumber)
        {
            Label newLabel;
            TextBox txtBox;

            //setting up the new Group Box, to contain all dialogs related to code entry
            GroupBox newCodeGroupBox = new GroupBox();
            newCodeGroupBox.Size = new Size(500, 120);

            //creating label and text entry box for the "Code Title"
            //label
            newLabel = new Label();
            newLabel.Text = "Code Title";
            newLabel.Location = new Point(15, 25);
            newLabel.Size = new Size(75, 15);
            newCodeGroupBox.Controls.Add(newLabel);
            //text entry box
            txtBox = new TextBox();
            txtBox.Size = new Size(300, 20);
            txtBox.Location = new Point(100, 25);
            newCodeGroupBox.Controls.Add(txtBox);

            //creating label and text entry box for the "Code Content"
            //label
            newLabel = new Label();
            newLabel.Text = "Code Content";
            newLabel.Location = new Point(15, 50);
            newLabel.Size = new Size(75, 15);
            newCodeGroupBox.Controls.Add(newLabel);
            //text entry box
            txtBox = new TextBox();
            txtBox.Size = new Size(300, 60);
            txtBox.Location = new Point(100, 50);
            txtBox.Multiline = true;
            newCodeGroupBox.Controls.Add(txtBox);

            //creating "Remove Code" button
            Button removeCodeButton = new Button();
            removeCodeButton.Location = new Point(410, 25);
            removeCodeButton.Text = "Remove Code";
            removeCodeButton.AutoSize = true;
            newCodeGroupBox.Controls.Add(removeCodeButton);

            //setting up what to do when "Remove Code" button is clicked
            removeCodeButton.Click += new System.EventHandler(removeCode_Click);

            newCodeGroupBox.Name = "codeGroupBox" + nextCodeNumber;

            return newCodeGroupBox;
        }

        internal GroupBox getNewSectionGroupBox(int nextSectionNumber)
        {
            Label newLabel;
            TextBox newTxtBox;
            Button newButton;
            GroupBox newCodeGroupBox;

            //setting up the new Group Box, to contain all dialogs related to section entry
            GroupBox newSectionGroupBox = new GroupBox();
            newSectionGroupBox.Size = new Size(835, 224);

            newButton = new Button();
            newButton.Text = "Colapse";
            newButton.Name = "colapseSectionButton";
            newButton.Location = new Point(6, 10);
            newButton.Size = new Size(54, 24);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Colapse" button is clicked
            newButton.Click += new System.EventHandler(colapseSectionButton_Click);

            newButton = new Button();
            newButton.Text = "UP";
            newButton.Location = new Point(66, 10);
            newButton.Size = new Size(35, 23);
            newButton.Visible = true;
            newSectionGroupBox.Controls.Add(newButton);

            newButton = new Button();
            newButton.Text = "Down";
            newButton.Location = new Point(107, 10);
            newButton.Size = new Size(50, 23);
            newSectionGroupBox.Controls.Add(newButton);

            newButton = new Button();
            newButton.Text = "Remove";
            newButton.Location = new Point(766, 16);
            newButton.Size = new Size(63, 23);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Remove Code" button is clicked
            newButton.Click += new System.EventHandler(removeSectionButton_Click);


            newButton = new Button();
            newButton.Text = "Add Code";
            newButton.Location = new Point(182, 182);
            newButton.Size = new Size(63, 23);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Add Code" button is clicked
            newButton.Click += new System.EventHandler(addCodeButton_Click);



            newLabel = new Label();
            newLabel.Text = "Section title";
            newLabel.Location = new Point(188, 22);
            newLabel.Size = new Size(62, 13);
            newSectionGroupBox.Controls.Add(newLabel);

            newTxtBox = new TextBox();
            newTxtBox.Location = new Point(256, 19);
            newTxtBox.Size = new Size(283, 20);
            newSectionGroupBox.Controls.Add(newTxtBox);

            newCodeGroupBox = getNewCodeGroupBox(nextCodeNumber);
            newCodeGroupBox.Location = new Point(150, 55);
            newCodeGroupBox.Name = "codeGroupBox" + nextCodeNumber;
            newSectionGroupBox.Controls.Add(newCodeGroupBox);

            newSectionGroupBox.AutoSize = true;

            return newSectionGroupBox;
        }

        private void colapseSectionButton_Click(object sender, EventArgs e)
        {

            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;

            // change the "Colapse" button into "Expand" button
            ((Button)sender).Text = "Expand";
            ((Button)sender).Click += new System.EventHandler(expandSectionButton_Click);

            currentSectionGroupBox.AutoSize = false;
            currentSectionGroupBox.Size = new Size(835, 50);
            // I could make individual controls invisible, but above solutions works so will leave it for now
           
        }

        private void expandSectionButton_Click(object sender, EventArgs e)
        {

            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;
            
            // change the "Expand" button into "Colapse" button
            ((Button)sender).Text = "Colapse";
            ((Button)sender).Click += new System.EventHandler(colapseSectionButton_Click);

            currentSectionGroupBox.AutoSize = true;

        }

        private void addSectionButton_Click(object sender, EventArgs e)
        {
            GroupBox newSectionGroupBox = getNewSectionGroupBox(nextSectionNumber);

            //setting its location so it can dynamicaly move down depending on nextCodeNumber
            //this part might need some adjusting so the box will be created where we want it
            newSectionGroupBox.Location = new Point(6, 5);

            templateEditGroupBox.Controls.Add(newSectionGroupBox);

            //moving the "Add Code" button down, depending on nextCodeNumber
            //again, might need adjusting
            //addCodeButton.Location = new Point(180, 185 + nextCodeNumber * 150);

            // addSectionButton.Location = new Point(15, 250 + 100);

            templateEditGroupBox.Refresh();
            nextSectionNumber++;
        }

        private void removeSectionButton_Click(object sender, EventArgs e)
        {
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;

            templateEditGroupBox.Controls.Remove(currentSectionGroupBox);
            templateEditGroupBox.Refresh();
        }

        private void moveSectionUpButton_Clicked(object sender, EventArgs e)
        {
            //if the section is not on top

            //call section parrent to move it up

        }
    }
}
