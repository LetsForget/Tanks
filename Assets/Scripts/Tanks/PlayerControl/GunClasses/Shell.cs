using Mirror;
using System.Collections;
using Tools;
using UnityEngine;

namespace Tanks.GunClasses
{
    public class Shell : NetworkBehaviour
    {
        public ShellPool Source;

        public float Speed;

        public BoxCollider2D Collider;
        public Rigidbody2D Rigidbody;
        public float Damage;
        public bool Active;

        private Coroutine BackCoroutine;

        public void SetRotation(Vector2 direction)
        {
            transform.rotation = InDirectionRotator.Rotate(direction);
        }

        public void Launch()
        {
            Rigidbody.velocity = transform.up * Speed;
            BackCoroutine = StartCoroutine(GetBackTillTime());
            Active = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!Active)
            {
                return;
            }

            TankHealth hittedTank = collision.gameObject.GetComponent<TankHealth>();
            if (hittedTank != null)
            {
                hittedTank.GetHit(this);
            }

            StopCoroutine(BackCoroutine);
            Source.TakeBack(this);
        }

        private IEnumerator GetBackTillTime()
        {
            yield return new WaitForSeconds(10);
            Source.TakeBack(this);
        }
    }
}