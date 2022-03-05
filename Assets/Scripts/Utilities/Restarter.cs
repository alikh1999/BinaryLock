using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class Restarter : MonoBehaviour
    {
        public void Restart()
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
