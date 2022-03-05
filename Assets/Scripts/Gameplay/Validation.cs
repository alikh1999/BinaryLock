using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay
{
    public class Validation : MonoBehaviour
    {
        [SerializeField] 
        private List<ScriptableObject> scriptableObjects
            = new List<ScriptableObject>();

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