using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MeltdownGame.FSM
{
    public abstract class State : MonoBehaviour
    {
        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
    }
}
