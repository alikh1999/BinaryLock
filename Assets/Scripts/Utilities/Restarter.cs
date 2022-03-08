using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    //suggested name: SceneUtility 
    public class Restarter : MonoBehaviour
    {
        //suggested name: ReloadScene
        //BUG: what if there are multiple scenes open already? 
        public void Restart()
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
