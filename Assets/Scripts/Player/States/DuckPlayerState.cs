using MeltdownGame.FSM;
using UnityEngine; 

namespace MeltdownGame.Player.States
{
    public class DuckPlayerState : State
    {
        [SerializeField] private Transform _playerTransform = null;
        [SerializeField] private Vector3 _playerDuckScale = Vector3.one;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _duckDrag = 0.1f;
        private float _initialDrag;
        private Vector3 _defaultScale;
        public override void Enter()
        {
            _defaultScale = _playerTransform.localScale;
            _playerTransform.localScale = _playerDuckScale;
            _initialDrag = _rigidbody.drag;
            _rigidbody.drag = _duckDrag;  
        }

        public override void Tick() {}
        public override void Exit() 
        {
            _playerTransform.localScale = _defaultScale;
            _rigidbody.drag = _initialDrag;
        }

    }
}