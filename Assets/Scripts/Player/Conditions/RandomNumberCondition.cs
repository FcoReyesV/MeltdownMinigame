using UnityEngine;
using MeltdownGame.FSM;

namespace MeltdownGame.Player.Conditions
{
    public class RandomNumberCondition : TransitionCondition
    {
        [SerializeField] private float _percentage = 50;
        [SerializeField] private float _delayNumberGeneration = 2f;
        private float _currentCounter = 0;
        public override bool CheckCondition()
        {
            _currentCounter += Time.deltaTime;
            if(_currentCounter < _delayNumberGeneration) return false;
            _currentCounter = 0;
            int randomNumber = Random.Range(0, 101);
            return randomNumber > _percentage;
        }
    }

}
