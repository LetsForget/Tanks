using Mirror;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.GunClasses
{
    public class ShellPool
    {
        private static Vector2 FarAway = new Vector2(999, 999);
        private Queue<Shell> Pool;

        public ShellPool(GameObject prefab, int poolLength)
        {
            Pool = new Queue<Shell>(poolLength);

            for (int i = 0; i < poolLength; i++)
            {
                GameObject shellInstance = GameObject.Instantiate(prefab);
                NetworkServer.Spawn(shellInstance);

                shellInstance.name = "Shell " + i;
                shellInstance.transform.position = FarAway;

                Shell shell = shellInstance.GetComponent<Shell>();
                shell.Source = this;

                Pool.Enqueue(shell);
            }
        }

        public Shell TakeFrom()
        {
            return Pool.Dequeue();
        }

        public void TakeBack(Shell shell)
        {
            Pool.Enqueue(shell);
            shell.transform.position = FarAway;
        }
    }
}