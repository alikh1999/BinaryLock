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
                return _passCode.Select(x => Convert.ToInt32(x.ToString()))
                    .ToList();
            }
        }
        
        [SerializeField] 
        private string _passCode;

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