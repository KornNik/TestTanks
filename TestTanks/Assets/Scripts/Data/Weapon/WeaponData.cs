using UnityEngine;

namespace Scripts.Data.Guns
{
    [CreateAssetMenu(fileName = "WeaponData",menuName = "Data/Weapon/WeaponData")]
    class WeaponData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _damage;
        [SerializeField] private float _force;
        [SerializeField] private float _shotsDelay;

        #endregion


        #region Properties

        public float Damage => _damage;
        public float Force => _force;
        public float ShotsDelay => _shotsDelay;

        #endregion

    }
}
