
using UnityEngine;

namespace Tools
{
    public static class AccelerationCalculator
    {
        public static Vector3 Euler(Vector3 from , Vector3 to, float acceleration)
        {
            float x = Angle(from.x, to.x, acceleration);
            float y = Angle(from.y, to.y, acceleration);
            float z = Angle(from.z, to.z, acceleration);

            return new Vector3(x, y, z);
        }

        public static Vector3 Vector(Vector3 from, Vector3 to, float acceleration)
        {
            float x = Value(from.x, to.x, acceleration);
            float y = Value(from.y, to.y, acceleration);
            float z = Value(from.z, to.z, acceleration);

            return new Vector3(x, y, z);
        }

        public static Vector2 Vector(Vector2 from, Vector2 to, float acceleration)
        {
            float x = Value(from.x, to.x, acceleration);
            float y = Value(from.y, to.y, acceleration);
            return new Vector2(x, y);
        }

        public static float Angle(float from, float to, float acceleration)
        {        
            float plusWay, minusWay;

            if (from < to)
            {
                plusWay = to - from;
                minusWay = from + (360 - to);
            }
            else
            {
                plusWay = to + (360 - from);
                minusWay = from - to;
            }

            float offsetedFrom = from + 720;
            float offsetedTo;

            if (plusWay > minusWay)
            {
                offsetedTo = offsetedFrom - minusWay;
                return ValueDecrease(offsetedFrom, offsetedTo, acceleration) - 720;
            }
            else
            {
                offsetedTo = offsetedFrom + plusWay;
                return ValueIncrease(offsetedFrom, offsetedTo, acceleration) - 720;
            }
        }

        public static float Value(float from, float to, float acceleration)
        {
            if (from > to)
            {
                return ValueDecrease(from, to, acceleration);
            }
            else
            {
                return ValueIncrease(from, to, acceleration);
            }
        }

        private static float ValueIncrease(float from, float to, float acceleration)
        {
            float newVal = from + acceleration;
            return newVal < to ? newVal : to;
        }

        private static float ValueDecrease(float from, float to, float acceleration)
        {
            float newVal = from - acceleration;
            return newVal > to ? newVal : to;
        }
    }
}