using System.Windows;

namespace HappyTechFeedback
{
    public class Code
    {
        private string title;
        private string content;

        
        public Code()
        {
            //MessageBoxResult result = MessageBox.Show("Just created Code" , "Class: Code");
        }


        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }



    }


}