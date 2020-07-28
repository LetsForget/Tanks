using UnityEngine;

namespace Commands
{
    public abstract class AbstractCommand
    {
        public KeyCode Key { get; private set; }
        public CommandType Type { get; private set; }
        public abstract void Execute();

        public AbstractCommand(KeyCode key, CommandType type = CommandType.Continuous)
        {
            Key = key;
            Type = type;
        }
    }
}