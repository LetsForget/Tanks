using Commands;
using InputHandling;
using Mirror;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(TankMovement))]
    public class TankPlayerController : NetworkBehaviour
    {
        public TankMovement Mover;
        public TankGun Gun;
        private InputHandler Controller;

        private void Start()
        {
            AbstractCommand[] commands = new AbstractCommand[]
            {
                new TankMoveCommand(Mover, Vector2.up, KeyCode.W),
                new TankMoveCommand(Mover, Vector2.down, KeyCode.S),
                new TankMoveCommand(Mover, Vector2.left, KeyCode.A),
                new TankMoveCommand(Mover, Vector2.right, KeyCode.D),
                new TankShootCommand(Gun, KeyCode.Mouse0)
            };

            Controller = new InputHandler(commands);
        }

        private void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            Controller.UpdateCommands();
        }
    }
}