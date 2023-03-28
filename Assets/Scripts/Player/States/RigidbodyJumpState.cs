using UnityEngine;
using MeltdownGame.FSM;

namespace MeltdownGame.Player.States
{
    public class RigidbodyJumpState : State
    {
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _jumpForce = 10f;
        public override void Enter()
        {
            _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            //Play Jump Animation
        }
        public override void Tick() { }

        public override void Exit() { }
        
    }
}