using UnityEngine;
using Scripts.Helpers;
using Scripts.Helpers.PoolObject;

namespace Scripts.Behaviour.Guns
{
    class BaseProjectileWeapon : Weapon
    {
        #region Fields

        [SerializeField] protected Transform _poolTransform;

        protected PoolObjects<AmmunitionType> _projectilePool;
        protected AmmunitionType _projectileType = AmmunitionType.Bullet;


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _projectilePool = new AmmunitionPool(3, _poolTransform);
        }

        #endregion


        #region Methods

        public override void Fire()
        {
            base.Fire();
            if (!_isReady) return;
            var tempAmmunition = _projectilePool.GetObject(_projectileType);
            tempAmmunition.ActiveObject();

            _isReady = false;
            Invoke(nameof(ReadyShoot), _weaponData.ShotsDelay);
        }

        #endregion
    }
}
