using System;
using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        private const int BytesSize = 12;
        public static byte[] ToBytes(this Vector3 vec3)
        {
            byte[] bytes = new byte[BytesSize];

            ConvertPart(ref bytes, vec3.x, 0);
            ConvertPart(ref bytes, vec3.y, 1);
            ConvertPart(ref bytes, vec3.z, 2);

            return bytes;
        }

        private static void ConvertPart(ref byte[] array, float part, int order)
        {
            byte[] partBytes = BitConverter.GetBytes(part);
            Array.Copy(partBytes, 0, array, order * 4, 4);
        }

        public static Vector3 OutBytes(byte[] array, int offset = 0)
        {
            float x = BitConverter.ToSingle(array, 0 + offset);
            float y = BitConverter.ToSingle(array, 4 + offset);
            float z = BitConverter.ToSingle(array, 8 + offset);

            return new Vector3(x, y, z);
        }
    }
}