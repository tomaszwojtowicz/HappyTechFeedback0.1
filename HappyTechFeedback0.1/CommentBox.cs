using System;

namespace HappyTechFeedback
{
    class CommentBox : Section
    {
        private string content;
        //private string type;

        public CommentBox()
        {
            this.Type = "CommentBox";
        }


        #region Properties
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        //public override void AddCode()
        //{
        //    //CommentBox is not meant to have codes
        //    //this workarround is necessary because I was not able to call AddCode method of ComplexSection,
        //    //without declaring abstract method in superclass - Section
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}