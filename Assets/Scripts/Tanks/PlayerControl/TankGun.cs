using Mirror;
using System.Collections;
using Tanks.GunClasses;
using UnityEngine;

namespace Tanks
{
    public class TankGun : NetworkBehaviour
    {
        public GameObject ShellPrefab;
        public Transform TankTower;

        public Vector3 OutPos;
        private Vector3 OutPosGlobal => TankTower.TransformPoint(OutPos);

        public float ReloadTime;

        private ShellPool ShellPool;
        private bool Loaded;

        private void Start()
        {
            ShellPool = new ShellPool(ShellPrefab, 4);
            Loaded = true;
        }

        [Command]
        public void CmdShoot()
        {
            if (Loaded)
            {
                Loaded = false;

                Shell shell = ShellPool.TakeFrom();
                shell.SetRotation(TankTower.up);
                shell.transform.position = OutPosGlobal;
                shell.Launch();

                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(ReloadTime);
            Loaded = true;
        }
    }
}