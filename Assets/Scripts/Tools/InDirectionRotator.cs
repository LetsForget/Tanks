using UnityEngine;

namespace Tools
{
    public static class InDirectionRotator
    {
        public static Quaternion Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}