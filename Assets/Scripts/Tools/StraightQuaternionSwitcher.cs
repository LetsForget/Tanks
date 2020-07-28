using UnityEngine;

namespace Tools
{
    public static class StraightQuaternionSwitcher
    {
        public static Quaternion Get(Quaternion from, Quaternion to, float step)
        {
            Vector3 fromEuler = from.eulerAngles;
            Vector3 toEuler = to.eulerAngles;

            float z = AccelerationCalculator.Angle(fromEuler.z, toEuler.z, step);
            Vector3 curEuler = new Vector3(0, 0, z);

            return Quaternion.Euler(curEuler);
        }
    }
}