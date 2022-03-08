using System.Collections.Generic;

namespace Gameplay
{
    public static class SequenceHelper
    {
        //you can improve this function by taking IEnumerable instead of List, since you are comparing sets not sequences 
        public static bool AreSequencesEqual(this List<int> list1 , List<int> list2)
        {
            //you are allocating a new HashSet every time this function is called!
            var set = new HashSet<int>(list1);
            return set.SetEquals(list2);
        }
    }
}