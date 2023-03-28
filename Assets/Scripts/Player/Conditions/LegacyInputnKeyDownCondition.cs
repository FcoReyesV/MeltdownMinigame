using UnityEngine;
using MeltdownGame.FSM;

namespace MeltdownGame.Player.Conditions
{
    public class LegacyInputnKeyDownCondition : TransitionCondition
    {
        [SerializeField] private KeyCode _key;
        public KeyCode Key { get => _key; set => _key = value; }

        public override bool CheckCondition()
        {
            return Input.GetKeyDown(_key);
        }
    }

}
