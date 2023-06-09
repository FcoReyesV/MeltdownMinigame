using UnityEngine;
using MeltdownGame.FSM;

namespace MeltdownGame.Player
{   
    public class NPCController : MonoBehaviour 
    {
        [SerializeField] private State _defaultState = null;
        [SerializeField] private Transition[] _transitions = null;
        [SerializeField] private MeshColorChangerBase _meshColorChangerBase = null;
        private FSMBase _fsm;
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