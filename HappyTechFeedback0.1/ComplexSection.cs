﻿using System.Collections.Generic;
using System.Windows;

namespace HappyTechFeedback
{
    class ComplexSection : Section
    {
        private List<Code> codeList = new List<Code>();
        private Code currentCode;
        //private string type;

        public ComplexSection()
        {
            //MessageBoxResult result = MessageBox.Show("Just created Complex Section", "Class: ComplexSection");
            this.Type = "ComplexSection";
            codeList = new List<Code>();
        }


        public override void AddCode()
        {
            currentCode = new Code();
            this.codeList.Add(currentCode);
        }

        public override List<Code> CodeList()
        {
            return this.codeList;
        }


    }

}