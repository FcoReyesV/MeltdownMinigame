using UnityEngine;
namespace MeltdownGame.FSM
{
    public abstract class TransitionCondition : MonoBehaviour
    {
        public abstract bool CheckCondition();
    }
}
