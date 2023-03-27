using System.Collections.Generic;
namespace MeltdownGame.FSM
{
    public class FSMBase
    {
        private Dictionary<State, List<Transition>> _transitions = new Dictionary<State, List<Transition>>();
        private State _currentState;
        public void InitState(State initialState)
        {
            _currentState = initialState;
            _currentState.Enter();
        }

        public void AddTransition(Transition transition)
        {
            if (!_transitions.ContainsKey(transition.FromState))
            {
                _transitions.Add(transition.FromState, new List<Transition>());
            }
            _transitions[transition.FromState].Add(transition);
        }

        public void Update()
        {

            foreach (Transition transition in _transitions[_currentState])
            {
                if (transition.Condition.CheckCondition())
                {
                    ChangeState(transition.ToState);
                    break;
                }
            }
            _currentState.Tick();
        }

        public void ChangeState(State newState)
        {
            _currentState.Exit();
            _currentState = newState;
            //Debug.Log("Current state: " + _currentState.name);
            _currentState.Enter();
        }
    }
}
