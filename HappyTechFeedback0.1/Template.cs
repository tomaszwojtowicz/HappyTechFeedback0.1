using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HappyTechFeedback
{
    class Template
    {
        //defining allowed section types
        public enum sectionTypes { commentBox, complexSection };

        private string name;
        private string description;

        // creating a list to hold all the sections
        // the sections will have composition relationship with the Template

        internal List<Section> sectionList;
        //Section newSection;
        //static List<Section> staticSectionList;
        internal static Template currentTemplate;

        //setting up a dummy template
        internal static Template getDummyTemplate()
        {
            //instantiate dummy template
            Template dummyTemplate = new Template();

            //fill its attributes with data
            dummyTemplate.name = "Dummy Template No 1.";
            dummyTemplate.description = "The following template is to be used for testing only";


            //create its sections
            dummyTemplate.AddSection(sectionTypes.complexSection);
            dummyTemplate.sectionList[0].Title = "Dummy Section 0";
            dummyTemplate.AddSection(sectionTypes.complexSection);
            dummyTemplate.sectionList[1].Title = "Dummy Section 1";
            dummyTemplate.AddSection(sectionTypes.commentBox);
            dummyTemplate.sectionList[2].Title = "Dummy Comment Box 0";

            //fill sections with codes
            dummyTemplate.sectionList[0].AddCode();
            dummyTemplate.sectionList[0].CodeList()[0].Title = "Dummy Code 0.0";
            dummyTemplate.sectionList[0].CodeList()[0].Content = "Dummy Code 0.0 content ..............";
            dummyTemplate.sectionList[0].AddCode();
            dummyTemplate.sectionList[0].CodeList()[1].Title = "Dummy Code 0.1";
            dummyTemplate.sectionList[0].CodeList()[1].Content = "Dummy Code 0.1 content ..............";

            //just the test:
            //MessageBox.Show(dummyTemplate.sectionList[0].Title + Environment.NewLine +
            //         dummyTemplate.sectionList[1].Title + Environment.NewLine +
            //        dummyTemplate.sectionList[2].Title, "Section Titles");



            return dummyTemplate;
        }




        public Template()
        {
            sectionList = new List<Section>();
        }


        //this method only accepts predefined section types
        internal void AddSection(sectionTypes sectionType)
        {
            Section newSection;
            switch (sectionType)
            {
                case sectionTypes.complexSection:
                    newSection = new ComplexSection();
                    this.sectionList.Add(newSection);
                    break;

                case sectionTypes.commentBox:
                    newSection = new CommentBox();
                    this.sectionList.Add(newSection);
                    break;
            }

        }

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }




        //trying to access sectionList via the property, so it can be displayed by different class
        public static List<Section> Sections()
        {
            return currentTemplate.sectionList;
        }

        public static Template CurrentTemplate()
        {
            //using singleton pattern to have only 1 currentTemplate at any time 
            if (currentTemplate == null)

                //for testing purposes, returning prefilled dummyTemplate, rather than create new, blank one
                currentTemplate = getDummyTemplate();

            //currentTemplate = new Template();


            return currentTemplate;
        }

        #endregion


    }
}
