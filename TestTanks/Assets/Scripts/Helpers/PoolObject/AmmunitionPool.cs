using System;
using UnityEngine;
using System.Linq;
using Scripts.Interface;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using Scripts.Behaviour.Projectile;

namespace Scripts.Helpers.PoolObject
{
    sealed class AmmunitionPool : PoolObjects<AmmunitionType>
    {
        #region ClassLifeCycle

        public AmmunitionPool(int capacityPool, Transform poolTransform) : base (capacityPool, poolTransform)
        {
            _objectPool = new Dictionary<AmmunitionType, HashSet<IPoolable>>();
        }

        public override IPoolable GetObject(AmmunitionType type)
        {
            IPoolable result;
            switch (type)
            {
                case AmmunitionType.Bullet:
                    result = GetSimpleProjectile(GetListObject(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private IPoolable GetSimpleProjectile(HashSet<IPoolable> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            if (ammunition == null)
            {
                var bullet = CustomResources.Load<SimpleProjectile>(ProjectileAssetPath.ProjectilesPath[AmmunitionType.Bullet]);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(bullet);
                    ReturnToPool(instantiate.transform);
                    instantiate.PoolTransform = _poolTransform;
                    ammunitions.Add(instantiate);
                }

                GetSimpleProjectile(ammunitions);
            }
            ammunition = ammunitions.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            return ammunition;
        }

        #endregion
    }
}
