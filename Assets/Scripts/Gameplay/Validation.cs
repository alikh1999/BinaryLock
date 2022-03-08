using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay
{
    public class Validation : MonoBehaviour
    {
        //unrequired initialization 
        [SerializeField] 
        private List<ScriptableObject> scriptableObjects
            = new List<ScriptableObject>();

        //it might be too late to validate sth at this point
        //BUG: what if this mono behaviour is disabled? 
        private void Start()
        {
            var validators
                = scriptableObjects.Select(x => x as IValidator)
                    .Where(x => x != null);

            foreach (var validator in validators)
                validator.Validate();
        }
    }
}