using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LockPassCode", menuName = "SO/LockPassCode")]
    public class LockPassCode : ScriptableObject, IValidator
    {
        public List<int> PassCodeSequence
        {
            get
            {
                //there is a faster way to parse a character instead of allocating it to a string first, research about it
                return _passCode.Select(x => Convert.ToInt32(x.ToString()))
                    .ToList();
            }
        }
        
        [SerializeField] 
        private string _passCode;

        //your validate API is ambiguous, the norm is to return a string if it finds any error instead of throwing exceptions 
        //your approach is specially slow if we have to catch every single possible exception when validating a large data set 
        public void Validate()
        {
            if (_passCode.All(char.IsDigit))
                return;
            if (_passCode != null)
            {
                throw new Exception("some elements of passCode" +
                                    " aren't digit");
            }

            throw new Exception("passcode is empty");
        }
    }
}