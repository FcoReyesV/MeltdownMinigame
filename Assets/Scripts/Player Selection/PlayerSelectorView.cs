using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MeltdownGame.PlayerSelection
{
    public class PlayerSelectorView : MonoBehaviour 
    {
        [SerializeField] private TMP_Dropdown _jumpDropdown;
        [SerializeField] private TMP_Dropdown _duckDropdown;
        [SerializeField] private CanvasGroup _playerSetCanvasGroup = null;
        [SerializeField] private Button _NPCButton = null;
        [SerializeField] private Button _playerButton = null;
        [SerializeField] private Button _readyButton = null;
        [SerializeField] private GameObject _readyText = null;
        private bool _npcSelected = false;
        public Color PlayerColor;
        public KeyCode JumpKey;
        public KeyCode DuckKey;
        private void Start()
        {
            FillDropdown(_jumpDropdown);
            FillDropdown(_duckDropdown);
            _NPCButton.onClick.AddListener(()=> 
            {
                ToggleConfiguration(false);
            });
            _playerButton.onClick.AddListener(()=> ToggleConfiguration(true));
            _readyButton.onClick.AddListener(()=>
            {
                ToggleCanvasGroup(false);
                _readyText.SetActive(true);
                JumpKey = UpdateKeyDropdown(_jumpDropdown);
                DuckKey = UpdateKeyDropdown(_duckDropdown);
            });
        }

        private KeyCode UpdateKeyDropdown(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;
            string selectedOption = dropdown.options[index].text;
            return (KeyCode)Enum.Parse(typeof(KeyCode), selectedOption);
        }

        private void ToggleConfiguration(bool state)
        {
            _playerButton.gameObject.SetActive(!state);
            _npcSelected = !state;
            ToggleCanvasGroup(state);
        }

        private void FillDropdown(TMP_Dropdown dropdown)
        {
            List<string> options = new List<string>();

            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                options.Add(key.ToString());
            }

            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }
        public void ToggleCanvasGroup(bool state)
        {
            float alpha = state ? 1 : 0;
            _playerSetCanvasGroup.interactable = state;
            _playerSetCanvasGroup.alpha = alpha;
            _playerSetCanvasGroup.blocksRaycasts = state;
        }
    }
}