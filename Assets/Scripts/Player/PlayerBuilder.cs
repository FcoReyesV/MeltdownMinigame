using UnityEngine;
namespace MeltdownGame.Player
{    
    public class PlayerBuilder
    {
        private PlayerController _prefab;
        private KeyCode _jumpKey;
        private KeyCode _duckKey;
        private Color _color;
        public PlayerBuilder FromPlayerControllerPrefab(PlayerController prefab)
        {
            _prefab = prefab;
            return this;
        }
        public PlayerBuilder WithJumpKey(KeyCode key)
        {
            _jumpKey = key;
            return this;
        }
        public PlayerBuilder WithDuckKey(KeyCode key)
        {
            _duckKey = key;
            return this;
        }
        public PlayerBuilder WithPlayerColor(Color color)
        {
            _color = color;
            return this;
        }

        public PlayerController Build()
        {
            var player = Object.Instantiate(_prefab);
            player.JumpInputCondition.Key = _jumpKey;
            player.DuckInputCondition.Key = _duckKey;
            player.SetColor(_color);
            return player;
        }
    }
}