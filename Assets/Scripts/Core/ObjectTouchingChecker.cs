using System;
using UnityEngine;

namespace MeltdownGame.Core
{
    public class ObjectTouchingChecker : MonoBehaviour 
    {
        [SerializeField] private string _objectToCheckTag = null;
        private bool _touchingObject = false;
        public bool TouchingObject => _touchingObject;
        public static Action<Transform> OnPlayerTouchingLava;
        private void OnCollisionEnter(Collision other)
        {
            if(!other.transform.CompareTag(_objectToCheckTag)) return;
            _touchingObject = true;
            OnPlayerTouchingLava?.Invoke(other.transform);
        }

        private void OnCollisionExit(Collision other)
        {
            _touchingObject = false;
        }
    }

}
