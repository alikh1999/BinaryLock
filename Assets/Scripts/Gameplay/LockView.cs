using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    //since we might change the view later, its best you put the interface in a different file 
    public interface ILockView
    {
        void ResetView();
    }
    public class LockView : MonoBehaviour,ILockView
    {
        //you don't have to initialize a SerializeField because it would be overriden by unity when it deserializes this mono behaviour  
        //also the naming convention is violated, suggested name: _lockViews;
        //your List T is LockButtonView, what if we use another implementation later? 
        [SerializeField] 
        private List<LockButtonView> lockViews = new List<LockButtonView>();
        
        //i would strongly recommend a null reference check in awake method for this field 
        [SerializeField]
        private Button _resetButton;
        private LockPresenter _presenter;

        private void Awake()
        {
            _presenter = GetComponent<LockPresenter>();
        }

        
        //it makes more sense to subscribe/ unsubscribe in the awake/destroy methods instead 
        //this point is specially important if we have tab control and would need to disable/enable different views frequently 
        private void OnEnable()
        {
            //use i for a loop counter, it is the short for index after all 
            for (int index = 0; index < lockViews.Count; index++)
            {
                //i don't understand why you did this!? 
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
