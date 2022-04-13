using UnityEngine;
using Scripts.Interface;

namespace Scripts.Behaviour.Projectile
{
    class SimpleProjectile : BaseProjectile
    {
        #region UnityMethods

        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<IDamageable>();

            if (tempObj != null)
            {
                InflictDamage(tempObj);
            }

            ReturnToPool();
        }

        #endregion
    }
}
