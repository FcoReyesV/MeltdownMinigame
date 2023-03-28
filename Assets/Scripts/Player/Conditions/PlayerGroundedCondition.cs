using MeltdownGame.FSM;
using UnityEngine;

namespace MeltdownGame.Player.Conditions
{
    public class PlayerGroundedCondition : TransitionCondition
    {
        [SerializeField] private ObjectTouchingChecker _objectTouchinChecker = null;

        public override bool CheckCondition()
        {
            return _objectTouchinChecker.TouchingObject;
        }

    }

}
