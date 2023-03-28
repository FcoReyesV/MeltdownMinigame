using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MeltdownGame.PlayerSelection
{
    public class PlayerSelectionController : MonoBehaviour
    {
        [SerializeField] private Button[] _readyButtons = null;
        [SerializeField] private Button[] _setPlayerButtons = null;
        [SerializeField] private CanvasGroup _playerSelectionCanvasGroup = null;
        public static Action OnPlayersReady;
        private int _currentPlayersReady = 0;

        private void Start() 
        {
            foreach (var readyButton in _readyButtons)
            {
               readyButton.onClick.AddListener(AddPlayerReady);
            }
            foreach (var setPlayerButton in _setPlayerButtons)
            {
                setPlayerButton.onClick.AddListener(RemovePlayerReady);
            }
        }

        private void AddPlayerReady()
        {
            _currentPlayersReady++;
            CheckIfAllPlayersReady();
        }
        private void RemovePlayerReady()
        {
            _currentPlayersReady--;
            CheckIfAllPlayersReady(); 
        }

        private void CheckIfAllPlayersReady()
        {
            if (_currentPlayersReady == 4)
            {
                OnPlayersReady?.Invoke();
            }
        }
       
    }
}