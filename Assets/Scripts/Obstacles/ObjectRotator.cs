using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MeltdownGame.Player.Conditions
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private Transform _objectToRotate = null;
        [SerializeField] private float _speedRotation = 5f;
        
        private void Update() 
        {
            _objectToRotate.Rotate(0f, _speedRotation * Time.deltaTime, 0f);
        }
    }
}