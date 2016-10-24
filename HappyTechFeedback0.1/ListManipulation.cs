using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTechFeedback
{
    //http://stackoverflow.com/questions/15133577/linq-list-moving-elements-up-and-down
    public static class ListManipulation
    {
        public enum MoveDirection { Up, Down }



        public static void Move<Section>(this List<Section> list, int iIndexToMove, MoveDirection direction)
        {

            if (direction == MoveDirection.Up)
            {
                var old = list[iIndexToMove - 1];
                list[iIndexToMove - 1] = list[iIndexToMove];
                list[iIndexToMove] = old;
            }
            else
            {
                var old = list[iIndexToMove + 1];
                list[iIndexToMove + 1] = list[iIndexToMove];
                list[iIndexToMove] = old;
            }
        }

    }
}


