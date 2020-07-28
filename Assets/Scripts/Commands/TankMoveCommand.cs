using Tanks;
using UnityEngine;

namespace Commands
{
    public class TankMoveCommand : AbstractCommand
    {
        private TankMovement Mover;
        private Vector2 Direction;

        public TankMoveCommand(TankMovement mover, Vector2 direction, KeyCode keyCode) : base(keyCode)
        {
            Mover = mover;
            Direction = direction;
        }

        public override void Execute()
        {
            Mover.Move(Direction);
        }
    }
}