using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public interface ILockButtonView
    {
        void UpdateView(bool buttonPressed);
    }

    public class LockButtonView : MonoBehaviour, ILockButtonView
    {
        //properties should be defined after all private fields based on the project convention 
        public Button Button
        {
            get
            {
                if (_button == null)
                {
                    //consider adding [RequireComponent] attr to enforce it 
                    return _button = GetComponent<Button>();
                }

                return _button;
            }
        }
        
        private Button _button;
        [SerializeField] private LockButtonPreference _preference;
        private LockButtonPresenter _presenter;

        private void Awake()
        {
            _presenter = GetComponent<LockButtonPresenter>();
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(_presenter.OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.AddListener(_presenter.OnButtonClicked);
        }

        public void UpdateView(bool buttonPressed)
        {
            _button.image.color = buttonPressed
                ? _preference.PressedColor
                : _preference.Unpressed;
        }

        public void ResetView()
        {
            _presenter.ResetObject();
        }
        
    }
}