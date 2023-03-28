using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MeltdownGame.Results;
using MeltdownGame.Player;
using MeltdownGame.PlayerSelection;
using MeltdownGame.Player.Conditions;

namespace MeltdownGame.Core
{
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResultsView _resultsView = null;
        [SerializeField] private CanvasGroup _playerSelectionCanvasGroup = null;
        [SerializeField] private PlayerController _playerControllerBase = null;
        [SerializeField] private float _offsetYBase = 0;
        [SerializeField] private Transform[] _bases = null;
        [SerializeField] private PlayerSelectorView[] _selectorsView = null;
        [SerializeField] private ObjectRotator _objectRotator = null;
        [SerializeField] private GameObject _pauseButton = null;
        private List<Transform> _playersTransform = new List<Transform>();
        private float _playersActive;
        private void Start() 
        {
            _resultsView.ToggleCanvasGroup(false);    
        }
        private void OnEnable() 
        {
            ObjectTouchingChecker.OnPlayerTouchingLava += UpdatePlayerAlive;
            PlayerSelectionController.OnPlayersReady += StartGame;
        }
        private void OnDisable() 
        {
            ObjectTouchingChecker.OnPlayerTouchingLava -= UpdatePlayerAlive;
            PlayerSelectionController.OnPlayersReady -= StartGame;
        }
        private void StartGame()
        {
            BuildPlayers();
            ToggleCanvasGroup(false);
            _objectRotator.enabled = true;
            _pauseButton.SetActive(true);
        }

        private void BuildPlayers()
        {
            for (int i = 0; i < _selectorsView.Length; i++)
            {
                PlayerBuilder playerBuilder = new PlayerBuilder();
                playerBuilder.FromPlayerControllerPrefab(_playerControllerBase);
                playerBuilder.WithJumpKey(_selectorsView[i].JumpKey);
                playerBuilder.WithDuckKey(_selectorsView[i].DuckKey);
                playerBuilder.WithPlayerColor(_selectorsView[i].PlayerColor);
                var player = playerBuilder.Build();
                _playersTransform.Add(player.transform);
                Vector3 initialPosition = new Vector3(_bases[i].position.x, _bases[i].position.y + _offsetYBase, _bases[i].position.z);
                player.transform.position = initialPosition;

            }
        }
        private void UpdatePlayerAlive(Transform playerTouchingLava)
        {
            if (_playersTransform.Contains(playerTouchingLava))
            {
                playerTouchingLava.gameObject.SetActive(false);
                _playersTransform.Remove(playerTouchingLava);
            }
            if (_playersTransform.Count == 1)
            {
                var playerTransform = _playersTransform[0];
                playerTransform.GetComponent<Rigidbody>().isKinematic = true;
                playerTransform.GetComponent<Rigidbody>();
                _resultsView.ShowVictory();
                _objectRotator.enabled = false;
            }
        }

        public void ToggleCanvasGroup(bool state)
        {
            float alpha = state ? 1 : 0;
            _playerSelectionCanvasGroup.interactable = state;
            _playerSelectionCanvasGroup.alpha = alpha;
            _playerSelectionCanvasGroup.blocksRaycasts = state;
        }

        public void LoadScene(int index)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(index);
        }
    
    }
}