using UnityEngine;
using MeltdownGame.FSM;
using MeltdownGame.Player.Conditions;

namespace MeltdownGame.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private State _defaultState = null;
        [SerializeField] private Transition[] _transitions = null;
        [SerializeField] private LegacyInputnKeyDownCondition _jumpInputCondition = null;
        [SerializeField] private LegacyInputnKeyDownCondition _duckInputCondition = null;
        [SerializeField] private MeshColorChangerBase _meshColorChangerBase = null;
        private FSMBase _fsm;
        public LegacyInputnKeyDownCondition JumpInputCondition => _jumpInputCondition;
        public LegacyInputnKeyDownCondition DuckInputCondition => _duckInputCondition; 

        private void Start()
        {
            _fsm = new FSMBase();

            for (int i = 0; i < _transitions.Length; i++)
            {
                _fsm.AddTransition(_transitions[i]);
            }

            _fsm.InitState(_defaultState);
        }

        private void Update()
        {
            _fsm.Update();
        }
        public void SetColor(Color color)
        {
            _meshColorChangerBase.Meshcolor = color;
        }
    }
}