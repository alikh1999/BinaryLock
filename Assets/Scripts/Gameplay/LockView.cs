using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public interface ILockView
    {
        void ResetView();
    }
    public class LockView : MonoBehaviour,ILockView
    {
        [SerializeField] 
        private List<LockButtonView> lockViews = new List<LockButtonView>();
        [SerializeField] 
        private Button _resetButton;
        private LockPresenter _presenter;

        private void Awake()
        {
            _presenter = GetComponent<LockPresenter>();
        }

        private void OnEnable()
        {
            for (int index = 0; index < lockViews.Count; index++)
            {
                var index1 = index;
                lockViews[index].Button.onClick.AddListener(
                    () => _presenter.OnButtonLockClicked(index1));
            }
            _resetButton.onClick.AddListener(_presenter.OnResetLockButtonClick);
        }

        private void OnDisable()
        {
            lockViews.ForEach(x 
                => x.Button.onClick.RemoveAllListeners());
            _resetButton.onClick.RemoveListener(_presenter.OnResetLockButtonClick);
        }

        public void ResetView()
        {
            lockViews.ForEach(x => x.ResetView());
        }
    }
}
