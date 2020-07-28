using Extensions;
using System;
using UnityEngine;

namespace Network
{
    public static class TankTransformConfigurator
    {
        private const int MsgId = 1;
        private const int MsgSize = 56;

        private static byte[] MsgIdBytes = BitConverter.GetBytes(MsgId);
        private static byte[] MsgSizeBytes = BitConverter.GetBytes(MsgSize);

        public static byte[] ToBytes(Transform body, Transform tower, Vector3 velocity)
        {
            byte[] bodyPos = body.position.ToBytes();
            byte[] bodyRot = body.rotation.eulerAngles.ToBytes();
            byte[] towerRot = tower.rotation.eulerAngles.ToBytes();
            byte[] veloc = velocity.ToBytes();

            byte[] result = new byte[MsgSize];
            
            Array.Copy(MsgIdBytes, 0, result, 0, 4);
            Array.Copy(MsgSizeBytes, 0, result, 4, 4);

            Array.Copy(bodyPos, 0, result, 8, 12);
            Array.Copy(bodyRot, 0, result, 20, 12);
            Array.Copy(towerRot, 0, result, 32, 12);
            Array.Copy(veloc, 0, result, 44, 12);

            return result;
        }

        public static void OutBytes(byte[] msg, out Vector3 bodyPos, out Vector3 bodyRot, out Vector3 towerRot, out Vector3 veloc)
        {
            bodyPos = Vector3Extensions.OutBytes(msg, 8);
            bodyRot = Vector3Extensions.OutBytes(msg, 20);
            towerRot = Vector3Extensions.OutBytes(msg, 32);
            veloc = Vector3Extensions.OutBytes(msg, 44);
        }
    }
}