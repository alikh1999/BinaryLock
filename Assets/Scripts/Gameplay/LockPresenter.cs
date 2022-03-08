using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay
{
    public class LockPresenter : MonoBehaviour
    {
        //reorder your fields in a way that first SerializeField fields comes then others to improve readability 
        [SerializeField] 
        private LockPassCode _passCode;
        private ILockView _view;
        [SerializeField] 
        private GameObject _winPanel;
        //naming issue
        private List<int> sequence = new List<int>();

        private void Start()
        {
            _view = GetComponent<LockView>();
        }

        public void OnButtonLockClicked(int index)
        {
            Debug.Log("digit: "+ index + " entered");
            sequence.Add(index);

            //there is difference between a sequence and a set, a set is unordered, like hashset, a sequence is ordered like an array or list. you are asking for sequence but compare it as a set! you need to change your terms to remove ambiguity 
            if (sequence.AreSequencesEqual(_passCode.PassCodeSequence))
            {
                Debug.Log("lock opened!!!!!!");
                _winPanel.SetActive(true);
            }
        }

        public void OnResetLockButtonClick()
        {
            sequence.Clear();
            _view.ResetView();
        }
    }
}