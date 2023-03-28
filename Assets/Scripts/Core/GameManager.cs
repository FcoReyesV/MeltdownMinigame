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
        [SerializeField] private NPCController _NPCControllerBase = null;
        [SerializeField] private float _offsetYBase = 0;
        [SerializeField] private Transform[] _bases = null;
        [SerializeField] private PlayerSelectorView[] _selectorsView = null;
        [SerializeField] private ObjectRotator _objectRotator = null;
        [SerializeField] private GameObject _pauseButton = null;
        private List<Transform> _playersTransform = new List<Transform>();
        private float _playersActive;
        private void Start() 
        {
            Application.targetFrameRate = 60;
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
                if (_selectorsView[i].NpcSelected)
                {
                    BuildNPC(i);
                }else
                {
                    BuildPlayer(i);
                }

            }
        }

        private void BuildPlayer(int index)
        {
            PlayerBuilder playerBuilder = new PlayerBuilder();
            playerBuilder.FromPlayerControllerPrefab(_playerControllerBase);
            playerBuilder.WithJumpKey(_selectorsView[index].JumpKey);
            playerBuilder.WithDuckKey(_selectorsView[index].DuckKey);
            playerBuilder.WithPlayerColor(_selectorsView[index].PlayerColor);
            var player = playerBuilder.Build();
            SetInitialPosition(player.transform, index);
        }
        private void BuildNPC(int index)
        {
            NPCBuilder npcBuilder = new NPCBuilder();
            npcBuilder.FromNPCControllerPrefab(_NPCControllerBase);
            npcBuilder.WithNPCColor(_selectorsView[index].PlayerColor);
            var npc = npcBuilder.Build();
            SetInitialPosition(npc.transform, index);
        }
        private void SetInitialPosition(Transform playerTransform, int index)
        {
            _playersTransform.Add(playerTransform);
            Vector3 initialPosition = new Vector3(_bases[index].position.x, _bases[index].position.y + _offsetYBase, _bases[index].position.z);
            playerTransform.position = initialPosition;
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