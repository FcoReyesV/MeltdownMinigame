using UnityEngine;
namespace MeltdownGame.Core
{
    public class PauseController : MonoBehaviour 
    {
        [SerializeField] private CanvasGroup _pauseCanvasGroup = null;
        [SerializeField] private GameObject _pauseButton = null;
        public void OnGamePaused()
        {
            _pauseButton.SetActive(false);
            ToggleCanvasGroup(true);
            Time.timeScale = 0;
        }
        public void OnGameUnpaused()
        {
            ToggleCanvasGroup(false);
            _pauseButton.SetActive(true);
            Time.timeScale = 1;
        }
        public void ToggleCanvasGroup(bool state)
        {
            float alpha = state ? 1 : 0;
            _pauseCanvasGroup.interactable = state;
            _pauseCanvasGroup.alpha = alpha;
            _pauseCanvasGroup.blocksRaycasts = state;
        }
    }
}
