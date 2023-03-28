using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MeltdownGame.Results
{
    public class ResultsView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _resultCanvasGroup = null;

        public void ShowVictory()
        {
            ToggleCanvasGroup(true);
        }

        public void ToggleCanvasGroup(bool state)
        {
            float alpha = state ? 1 : 0;
            _resultCanvasGroup.interactable = state;
            _resultCanvasGroup.alpha = alpha;
            _resultCanvasGroup.blocksRaycasts = state;
        }
    }
}