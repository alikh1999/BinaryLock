using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay
{
    public class LockPresenter : MonoBehaviour
    {
        [SerializeField] 
        private LockPassCode _passCode;
        private ILockView _view;
        [SerializeField] 
        private GameObject _winPanel;
        private List<int> sequence = new List<int>();

        private void Start()
        {
            _view = GetComponent<LockView>();
        }

        public void OnButtonLockClicked(int index)
        {
            Debug.Log("digit: "+ index + " entered");
            sequence.Add(index);

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