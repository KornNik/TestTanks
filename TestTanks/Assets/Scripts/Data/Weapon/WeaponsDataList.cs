using UnityEngine;
using Scripts.Behaviour.Guns;

namespace Scripts.Data.Guns
{
    [CreateAssetMenu(fileName = "WeaponsList",menuName ="Data/Weapon/WeaponsList")]
    class WeaponsDataList : ScriptableObject
    {
        [SerializeField] private Weapon[] _weapons = new Weapon[2];

        public Weapon[] Weapons => _weapons;

    }
}
