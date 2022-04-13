using UnityEngine;

namespace Scripts.Data.Guns
{
    [CreateAssetMenu(fileName = "WeaponryData", menuName = "Data/Weapon/WeaponryData")]
    class WeaponryData : ScriptableObject
    {
        [SerializeField] private int _weaponsCount;

        public int WeaponsCount => _weaponsCount;
    }
}
