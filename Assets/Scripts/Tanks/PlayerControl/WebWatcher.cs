using Network;
using UnityEngine;

namespace Tanks
{
    public class WebWatcher : MonoBehaviour
    {
        public Transform BodyTransform;
        public Transform TowerTransform;
        public Rigidbody2D Rigidbody;

        [System.Obsolete]
        private void FixedUpdate()
        {
            byte[] data = TankTransformConfigurator.ToBytes(BodyTransform, TowerTransform, Rigidbody.velocity);
            NetworkConnection.Instance.SendData(data);
        }
    }
}