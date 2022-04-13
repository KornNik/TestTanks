using System;
using UnityEngine;

namespace Scripts.Data.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Data/Projectile/ProjectileData")]
    class ProjectileData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _speed;
        [SerializeField] private float _force;
        [SerializeField] private float _damage;
        [SerializeField] private float _timeToDistract;

        [Range(0,1)]
        [SerializeField] private float _penetration;

        #endregion


        #region Properties

        public float Speed => _speed;
        public float Force => _force;
        public float Damage => _damage;
        public float TimeToDistract => _timeToDistract;
        public float Penetration => _penetration;

        #endregion
    }
}
