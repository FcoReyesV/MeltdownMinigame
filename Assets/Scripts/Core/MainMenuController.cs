using UnityEngine;
using UnityEngine.SceneManagement;
namespace MeltdownGame.Core
{    
    public class MainMenuController : MonoBehaviour 
    {
        public void LoadScene(int index)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(index);
        }
    }
}
