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

            //Adding and setting up "Add Section" button
            Button btAddSection = new Button();
            btAddSection.Text = "Add Section";
            btAddSection.Size = new Size(60, 50);
            btAddSection.Location = new Point(10, 230);

            this.Controls.Add(btAddSection);

            //Adding and setting up "Add Comment Box" button
            Button btAddCommentSection = new Button();
            btAddCommentSection.Text = "Add Comment Box";
            btAddCommentSection.Size = new Size(60, 50);
            btAddCommentSection.Location = new Point(10, 430);

            btAddCommentSection.Click += new System.EventHandler(btAddCommentSection_Click);


            this.Controls.Add(btAddCommentSection);



            //templateEditGroupBox.Controls.Add(btAddSection);
            btAddSection.Click += new System.EventHandler(btAddSection_Click);

            //loading dummy template so we got some pre-filled data to display/work on
            HappyTechFeedback.Template.currentTemplate = HappyTechFeedback.Template.getDummyTemplate();


            //creating groupBoxes for each section contained in current template

            for (int i = 0; i < HappyTechFeedback.Template.currentTemplate.sectionList.Count; i++)
            {
                GroupBox newSectionBox = null;

                if (HappyTechFeedback.Template.currentTemplate.sectionList[i].Type == "ComplexSection")
                {
                    newSectionBox = getNewSectionGroupBox(i);
                    newSectionBox.Location = new Point(100, 5 + i * 230);
                    newSectionBox.Dock = DockStyle.Bottom;

                    templateEditGroupBox.Controls.Add(newSectionBox);
                }
                else if (HappyTechFeedback.Template.currentTemplate.sectionList[i].Type == "CommentBox")
                {
                    newSectionBox = getNewCommentGroupBox(i);

                    newSectionBox.Location = new Point(100, 5 + i * 230);
                    newSectionBox.Dock = DockStyle.Bottom;

                    templateEditGroupBox.Controls.Add(newSectionBox);
                    //newSectionBox.Location = new Point(100, 5 + i * 230);

                    // templateEditGroupBox.Controls.Add(newSectionBox);

                }


                this.Refresh();
            }



        }

        private void btAddCommentSection_Click(object sender, EventArgs e)
        {
            //nextSectionNumber is a temporary solution
            //once the ui is binded with the back end, should use indexes of objects in sectionList
            GroupBox newCommentGroupBox = getNewCommentGroupBox(nextSectionNumber);

            //setting its location so it can dynamicaly move down depending on nextCodeNumber
            //this part might need some adjusting so the box will be created where we want it
            newCommentGroupBox.Location = new Point(100, 230 * nextSectionNumber);

            newCommentGroupBox.Dock = DockStyle.Bottom;
            templateEditGroupBox.Controls.Add(newCommentGroupBox);

            //moving the "Add Code" button down, depending on nextCodeNumber
            //again, might need adjusting
            //addCodeButton.Location = new Point(180, 185 + nextCodeNumber * 150);

            // addSectionButton.Location = new Point(15, 250 + 100);

            templateEditGroupBox.Refresh();
            nextSectionNumber++;
        }

        private GroupBox getNewCommentGroupBox(int i)
        {
            Button newButton;
            GroupBox newCommentGroupBox = new GroupBox();

            newButton = new Button();
            newButton.Text = "Colapse";
            newButton.Name = "btColapseSection";
            newButton.Location = new Point(6, 10);
            newButton.Size = new Size(54, 24);
            newCommentGroupBox.Controls.Add(newButton);
            //setting up what to do when "Colapse" button is clicked
            newButton.Click += new System.EventHandler(btColapseSection_Click);

            newButton = new Button();
            newButton.Text = "Expand";
            newButton.Name = "btExpandSection";
            newButton.Location = new Point(6, 10);
            newButton.Size = new Size(54, 24);
            newCommentGroupBox.Controls.Add(newButton);
            //setting up what to do when "Expand" button is clicked
            newButton.Click += new System.EventHandler(btExpandSection_Click);
            newButton.Visible = false;

            newButton = new Button();
            newButton.Text = "UP";
            newButton.Location = new Point(66, 10);
            newButton.Size = new Size(35, 23);
            newButton.Visible = true;
            newCommentGroupBox.Controls.Add(newButton);

            newButton.Click += new System.EventHandler(btMoveSectionUp_Clicked);

            newButton = new Button();
            newButton.Text = "Down";
            newButton.Location = new Point(107, 10);
            newButton.Size = new Size(50, 23);
            newCommentGroupBox.Controls.Add(newButton);
            newButton.Click += new System.EventHandler(btMoveSectionDown_Clicked);

            newButton = new Button();
            newButton.Text = "Remove";
            newButton.Location = new Point(766, 16);
            newButton.Size = new Size(63, 23);
            newCommentGroupBox.Controls.Add(newButton);
            //setting up what to do when "Remove Code" button is clicked
            newButton.Click += new System.EventHandler(btRemoveSection_Click);


            TextBox commentBox = new TextBox();
            commentBox.Location = new Point(188, 15);
            commentBox.Size = new Size(500, 100);
            commentBox.Multiline = true;
            newCommentGroupBox.Controls.Add(commentBox);

            //newCommentGroupBox.Size = new Size(835, 120);
            newCommentGroupBox.AutoSize = true;

            return newCommentGroupBox;

        }

        private void btMoveSectionDown_Clicked(object sender, EventArgs e)
        {
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;
            int currentIndex = templateEditGroupBox.Controls.GetChildIndex(currentSectionGroupBox);

            int gboxCount = 0;
            foreach (GroupBox gbox in templateEditGroupBox.Controls)
            {
                gboxCount++;
            }


            //if the section is not on top
            if (currentIndex < gboxCount)

                //call section parrent to move it up

                templateEditGroupBox.Controls.SetChildIndex(currentSectionGroupBox, currentIndex + 1);

            templateEditGroupBox.Refresh();
        }

        private void btRemoveCode_Click(object sender, EventArgs e)
        {
            //find out the parent groupBox of the button that was clicked
            Control codeGroupBoxToBeRemoved = ((Button)sender).Parent;

            //this part need to be FIXED

            //int gboxCount = 0;
            //foreach (GroupBox codeBox in codeGroupBoxToBeRemoved.Parent.Controls)
            //{
            //    gboxCount++;

            //}
            // and calling button's "grandparent" to remove the groupBox 
            codeGroupBoxToBeRemoved.Parent.Controls.Remove(codeGroupBoxToBeRemoved);


            
            //change the number of next code so the groupboxes and buttons can be re-aligned after removing the current groupbox
            nextCodeNumber--;

            this.Refresh();

        }

        private void btAddCode_Click(object sender, EventArgs e)
        {

            //generating new group box to contain code entry dialogs
            GroupBox newCodeGroupBox = getNewCodeGroupBox(nextCodeNumber); // change back to nextCodeNumber if it doesn't work

            newCodeGroupBox.Dock = DockStyle.Bottom;

            //find out the parent groupBox of the button that was clicked
            Control currentSectionGroupBox = ((Button)sender).Parent;

            //locate littleBox and add the "Code" GroupBox
            Control littleCodeBox = currentSectionGroupBox.Controls.Find("littleBox", false)[0];

            //assuming that littleCodeBox is a GroupBox - I know its dirty, to be FIXED
            GroupBox lb = (GroupBox)littleCodeBox;
            lb.AutoSize = true;
            lb.Controls.Add(newCodeGroupBox);

            //litteBox.Controls.Add(newCodeGroupBox);

            //currentSectionGroupBox.Controls.Add(newCodeGroupBox);

            //sectionEntryGroupBox.Controls.Add(newCodeGroupBox);

            //moving the "Add Code" button down, depending on nextCodeNumber
            //again, might need adjusting
            //Button currentButton = (Button)sender;

            //currentButton.Location = new Point(180, 185 + nextCodeNumber * 150);

            //addSectionButton.Location = new Point(15, 250 + 100);

            currentSectionGroupBox.Refresh();
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
            //newCodeGroupBox.Location = new Point(5, 5);

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
            Button btRemoveCode = new Button();
            btRemoveCode.Location = new Point(410, 25);
            btRemoveCode.Text = "Remove Code";
            btRemoveCode.AutoSize = true;
            newCodeGroupBox.Controls.Add(btRemoveCode);

            //setting up what to do when "Remove Code" button is clicked
            btRemoveCode.Click += new System.EventHandler(btRemoveCode_Click);

            newCodeGroupBox.Name = "codeGroupBox" + nextCodeNumber;

            newCodeGroupBox.AutoSize = false;
            newCodeGroupBox.Dock = DockStyle.Bottom;
        
            return newCodeGroupBox;
        }

        internal GroupBox getNewSectionGroupBox(int nextSectionNumber)
        {

            Label newLabel;
            TextBox newTxtBox;
            Button newButton;
            GroupBox newCodeGroupBox;
            GroupBox littleCodeBox = new GroupBox();

            //setting up the new Group Box, to contain all dialogs related to section entry
            GroupBox newSectionGroupBox = new GroupBox();
            newSectionGroupBox.Size = new Size(835, 224);

            newButton = new Button();
            newButton.Text = "Colapse";
            newButton.Name = "btColapseSection";
            newButton.Location = new Point(6, 10);
            newButton.Size = new Size(54, 24);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Colapse" button is clicked
            newButton.Click += new System.EventHandler(btColapseSection_Click);

            newButton = new Button();
            newButton.Text = "Expand";
            newButton.Name = "btExpandSection";
            newButton.Location = new Point(6, 10);
            newButton.Size = new Size(54, 24);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Expand" button is clicked
            newButton.Click += new System.EventHandler(btExpandSection_Click);
            newButton.Visible = false;

            
            newButton = new Button();
            newButton.Text = "UP";
            newButton.Location = new Point(66, 10);
            newButton.Size = new Size(35, 23);
            newButton.Visible = true;
            newSectionGroupBox.Controls.Add(newButton);
            newButton.Click += new System.EventHandler(btMoveSectionUp_Clicked);

            newButton = new Button();
            newButton.Text = "Down";
            newButton.Location = new Point(107, 10);
            newButton.Size = new Size(50, 23);
            newSectionGroupBox.Controls.Add(newButton);
            newButton.Click += new System.EventHandler(btMoveSectionDown_Clicked);

            newButton = new Button();
            newButton.Text = "Remove";
            newButton.Location = new Point(766, 16);
            newButton.Size = new Size(63, 23);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Remove Code" button is clicked
            newButton.Click += new System.EventHandler(btRemoveSection_Click);

            newButton = new Button();
            newButton.Text = "Add Code";
            newButton.Location = new Point(50, 50);
            newButton.Size = new Size(63, 23);
            

            //littleBox.Controls.Add(newButton);
            newSectionGroupBox.Controls.Add(newButton);
            //setting up what to do when "Add Code" button is clicked
            newButton.Click += new System.EventHandler(btAddCode_Click);



            newLabel = new Label();
            newLabel.Text = "Section title";
            newLabel.Location = new Point(188, 22);
            newLabel.Size = new Size(62, 13);
            newSectionGroupBox.Controls.Add(newLabel);

            newTxtBox = new TextBox();
            newTxtBox.Location = new Point(256, 19);
            newTxtBox.Size = new Size(283, 20);
            newSectionGroupBox.Controls.Add(newTxtBox);

            
            littleCodeBox.Location = new Point(150, 55);
            littleCodeBox.Size = new Size(535, 0);
            littleCodeBox.Name = "littleBox";
            littleCodeBox.AutoSize = true;
            littleCodeBox.AutoSizeMode = AutoSizeMode.GrowOnly;
            newSectionGroupBox.Controls.Add(littleCodeBox);


            newCodeGroupBox = getNewCodeGroupBox(nextCodeNumber); //change to nextCodeNumber if it doesn't work
            newCodeGroupBox.Dock = DockStyle.Bottom;
            newCodeGroupBox.Name = "codeGroupBox" + nextCodeNumber;

            littleCodeBox.Controls.Add(newCodeGroupBox);

            newSectionGroupBox.AutoSize = true;

            return newSectionGroupBox;
        }



        private void btColapseSection_Click(object sender, EventArgs e)
        {

            // Finds the current GroupBox by locating the parent of the button clicked
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;

            // change the "Colapse" button into "Expand" button
            ((Button)sender).Visible = false;

            //looking for "Expand" button
            Control btExpandSection = currentSectionGroupBox.Controls.Find("btExpandSection", true)[0];

            btExpandSection.Visible = true;

            //currentSectionGroupBox.Controls.btExpand.

            //((Button)sender).Text = "Expand";
            //((Button)sender).Click += new System.EventHandler(btExpandSection_Click);

            currentSectionGroupBox.Size = new Size(835, 50);
            currentSectionGroupBox.AutoSize = false;

            // I could make individual controls invisible, but above solutions works so will leave it for now
            // I have noticed the program slows down after colapsing/expanding multiple times
            // So something it eating up the resources. Need to investigate...

        }

        private void btExpandSection_Click(object sender, EventArgs e)
        {
            // Finds the current GroupBox by locating the parent of the button clicked
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;

            // change the "Expand" button into "Colapse" button
            //((Button)sender).Text = "Colapse";
            //((Button)sender).Click += new System.EventHandler(btColapseSection_Click);
            ((Button)sender).Visible = false;

            Control btColapseSection = currentSectionGroupBox.Controls.Find("btColapseSection", true)[0];

            btColapseSection.Visible = true;

            currentSectionGroupBox.AutoSize = true;
            currentSectionGroupBox.Size = new Size(835, 224);

        }

        private void btAddSection_Click(object sender, EventArgs e)
        {
            //nextSectionNumber is a temporary solution
            //once the ui is binded with the back end, should use indexes of objects in sectionList
            GroupBox newSectionGroupBox = getNewSectionGroupBox(nextSectionNumber);

            //setting its location so it can dynamicaly move down depending on nextCodeNumber
            //this part might need some adjusting so the box will be created where we want it
            newSectionGroupBox.Location = new Point(100, 230 * nextSectionNumber);

            newSectionGroupBox.Dock = DockStyle.Bottom;
            templateEditGroupBox.Controls.Add(newSectionGroupBox);

            //moving the "Add Code" button down, depending on nextCodeNumber
            //again, might need adjusting
            //addCodeButton.Location = new Point(180, 185 + nextCodeNumber * 150);

            // addSectionButton.Location = new Point(15, 250 + 100);

            templateEditGroupBox.Refresh();
            nextSectionNumber++;
        }

        private void btRemoveSection_Click(object sender, EventArgs e)
        {
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;

            templateEditGroupBox.Controls.Remove(currentSectionGroupBox);
            templateEditGroupBox.Refresh();
            nextSectionNumber--;
        }

        private void btMoveSectionUp_Clicked(object sender, EventArgs e)
        {
            GroupBox currentSectionGroupBox = (GroupBox)((Button)sender).Parent;
            int currentIndex = templateEditGroupBox.Controls.GetChildIndex(currentSectionGroupBox);


            //if the section is not on top
            if (currentIndex > 0)

                //call section parrent to move it up

                templateEditGroupBox.Controls.SetChildIndex(currentSectionGroupBox, currentIndex - 1);

            templateEditGroupBox.Refresh();

        }




    }
}
