using Mirror;
using Tools;
using UnityEngine;

namespace Tanks
{
    public class TankView : NetworkBehaviour
    {
        public Transform Tower;
        public float TowerRotationSpeed;
        public bool Frezed;


        private void Update()
        {
            if (!Frezed && isLocalPlayer)
            {
                WatchOnMouse();
            }
        }

        private void WatchOnMouse()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
            Quaternion needRot = InDirectionRotator.Rotate(direction);
            Tower.rotation = StraightQuaternionSwitcher.Get(Tower.rotation, needRot, TowerRotationSpeed * Time.fixedDeltaTime);
        }
    }
}