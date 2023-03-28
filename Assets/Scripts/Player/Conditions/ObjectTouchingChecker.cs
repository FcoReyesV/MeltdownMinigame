using UnityEngine;
namespace MeltdownGame.Player.Conditions
{
    public class ObjectTouchingChecker : MonoBehaviour 
    {
        [SerializeField] private string _objectToCheckTag = null;
        private bool _touchingObject = false;
        public bool TouchingObject => _touchingObject;
        private void OnCollisionStay(Collision other)
        {
            if(!other.transform.CompareTag(_objectToCheckTag)) return;
            _touchingObject = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _touchingObject = false;
        }
    }

}
