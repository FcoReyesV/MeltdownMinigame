using MeltdownGame.FSM;
using UnityEngine;

namespace MeltdownGame.Player.Conditions
{
    public class CooldownCondition : TransitionCondition
    {
        [SerializeField] private float _cooldownTime = 1.5f;
        private float _currentTime = 0;
        public override bool CheckCondition()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime < _cooldownTime) return false;
            _currentTime = 0;
            return true;
        }
    }
}
