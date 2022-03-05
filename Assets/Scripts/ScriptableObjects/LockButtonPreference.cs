using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LockButtonPreference", menuName = "SO/LockButtonPreference")]
    public class LockButtonPreference : ScriptableObject
    {
        public Color PressedColor => _pressedColor;
        public Color Unpressed => _unpressedColor;
        
        [SerializeField]
        private Color _pressedColor;
        [SerializeField]
        private Color _unpressedColor;
    }
}