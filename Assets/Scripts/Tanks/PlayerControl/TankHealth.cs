using Mirror;
using Tanks.GunClasses;

namespace Tanks
{
    public class TankHealth : NetworkBehaviour
    {
        public float StartHealth;
        private float CurrentHealth;

        private void Start()
        {
            CurrentHealth = StartHealth;
        }

        public void GetHit(Shell shell)
        {
            CurrentHealth -= shell.Damage;
            if (CurrentHealth < 0)
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }

}