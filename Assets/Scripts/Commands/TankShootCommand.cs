using Tanks;
using UnityEngine;

namespace Commands
{
    public class TankShootCommand : AbstractCommand
    {
        private TankGun Gun;

        public TankShootCommand(TankGun gun, KeyCode keyCode) : base(keyCode, CommandType.Single)
        {
            Gun = gun;
        }

        public override void Execute()
        {
            Gun.CmdShoot();
        }
    }
}