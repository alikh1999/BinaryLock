using UnityEngine;

namespace ScriptableObjects
{
    //suggested name: LockButtonStyle 
    //also it does not have to be a ScriptableObject, it can be simple serializable class used as field in your views 
    [CreateAssetMenu(fileName = "LockButtonPreference", menuName = "SO/LockButtonPreference")]
    public class LockButtonPreference : ScriptableObject
    {
        public Color PressedColor => _pressedColor;
        
        //this color is not applied when the game starts!
        public Color Unpressed => _unpressedColor;
        
        [SerializeField]
        private Color _pressedColor;
        [SerializeField]
        private Color _unpressedColor;
    }
}