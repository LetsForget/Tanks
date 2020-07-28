using Commands;
using UnityEngine;

namespace InputHandling
{
    public class InputHandler
    {
        public AbstractCommand[] Commands;

        public InputHandler(AbstractCommand[] commands)
        {
            Commands = commands;
        }

        public void UpdateCommands()
        {
            foreach(AbstractCommand command in Commands)
            {
                if (command.Type == CommandType.Single)
                {
                    if (Input.GetKeyDown(command.Key))
                    {
                        command.Execute();
                    }
                }
                else
                {
                    if (Input.GetKey(command.Key))
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}