using System.Collections.Generic;

namespace HappyTechFeedback
{

    abstract class Section
    {
        private string title;
        private string type;


        public virtual void AddCode()
        {
            //code to be overriden by ComplexSection class
        }

        public virtual List<Code> CodeList()
        {
            //code to be overriden by ComplexSection class
            return null;
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}