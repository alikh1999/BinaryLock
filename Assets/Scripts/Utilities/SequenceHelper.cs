using System.Collections.Generic;

namespace Gameplay
{
    public static class SequenceHelper
    {
        public static bool AreSequencesEqual(this List<int> list1 , List<int> list2)
        {
            var set = new HashSet<int>(list1);
            return set.SetEquals(list2);
        }
    }
}