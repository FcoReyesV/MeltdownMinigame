using UnityEngine;
namespace MeltdownGame.FSM
{
    public class Transition : MonoBehaviour
    {
        public State FromState;
        public State ToState;
        public TransitionCondition Condition;
    }
}
