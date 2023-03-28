using UnityEngine;
namespace MeltdownGame.Player.Conditions
{
    public class ObjectPusher : MonoBehaviour 
    {
        [SerializeField] private float _pushForce = 10.0f;

        private void OnCollisionEnter(Collision other)
        {
            Rigidbody objectToPushRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (objectToPushRigidbody == null) return;
            Vector3 forceDirection = other.transform.position - transform.position;
            forceDirection.Normalize();
            objectToPushRigidbody.AddForce(forceDirection * _pushForce, ForceMode.Impulse);
        }
    }
}