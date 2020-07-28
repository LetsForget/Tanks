using Mirror;
using Tools;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankMovement : NetworkBehaviour
    {
        public Rigidbody2D Rigidbody;

        public float Speed;
        public float Accel;
        public float Decel;
        public float BodyRotateSpeed;

        private Vector2 CurrentDirection;
        private bool IsAccelerating;
        private bool IsDiagonalMove;
        private const float AntiDiagonalBoost = 1.41421356237f;

        private void Update()
        {
            //if (!isLocalPlayer)
            //{
            //    return;
            //}

            Vector2 newVelocity;

            if (IsAccelerating)
            {
                Accelerate(out newVelocity);
            }
            else
            {
                Decelerate(out newVelocity);
            }

            Rigidbody.velocity = newVelocity;
            CurrentDirection = Vector2.zero;
        }

        private void Accelerate(out Vector2 newVelocity)
        {
            Vector2 shouldVel = transform.up * Speed;
            newVelocity = AccelerationCalculator.Vector(Rigidbody.velocity, shouldVel, Accel);

            Quaternion needRot = InDirectionRotator.Rotate(CurrentDirection);
            transform.rotation = StraightQuaternionSwitcher.Get(transform.rotation, needRot, BodyRotateSpeed * Time.fixedDeltaTime);

            IsAccelerating = false;
            IsDiagonalMove = false;
        }

        private void Decelerate(out Vector2 newVelocity)
        {
            newVelocity = AccelerationCalculator.Vector(Rigidbody.velocity, Vector2.zero, Decel);
        }

        public void Move(Vector2 direction)
        {
            IsAccelerating = true;
            CurrentDirection += direction;

            if (IsDiagonalMove)
            {
                CurrentDirection /= AntiDiagonalBoost;
            }
            else
            {
                IsDiagonalMove = true;
            }
        }
    }
}