using UnityEngine;

namespace Gameplay
{
    public class LockButtonPresenter : MonoBehaviour
    {
        private bool _isButtonPressed;
        private ILockButtonView _view;

        private void Start()
        {
            _view = GetComponent<LockButtonView>();
        }

        public void OnButtonClicked()
        {
            _isButtonPressed = !_isButtonPressed;
            _view.UpdateView(_isButtonPressed);
        }

        public void ResetObject()
        {
            _isButtonPressed = false;
            _view.UpdateView(false);
        }
    }
}