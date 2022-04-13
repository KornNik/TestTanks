using UnityEngine;
using Scripts.Data.Guns;
using Scripts.Helpers;

namespace Scripts.Behaviour.Guns
{
    class Weaponry
    {
        #region Fields

        private Weapon[] _weapons;

        private int _weaponIndexSelect = 0;
        private bool _isWeapon;

        #endregion


        #region Properties

        public Weapon[] Weapons => _weapons;
        public int WeaponIndexSelect => _weaponIndexSelect;

        #endregion


        #region UnityMethods

        public Weaponry(WeaponryData weaponryData)
        {
            _weapons = new Weapon[weaponryData.WeaponsCount];
        }

        #endregion


        #region Methods

        public void FireCurrentWeapon()
        {
            _weapons[_weaponIndexSelect].Fire();
        }
        public void SetWeapon(Weapon weapon, int index)
        {
            _weapons[index] = weapon;
        }

        public void ChangeWeapon(KeyCode key)
        {
            var previousIndex = _weaponIndexSelect;

            if(key == KeyManager.NEXT_WEAPON)
            {
                if (_weaponIndexSelect < _weapons.Length - 1)
                {
                    _weaponIndexSelect++;
                }
                else
                {
                    _weaponIndexSelect = 0;
                }
                Off(previousIndex);
                On(_weaponIndexSelect);
            }
            else if(key == KeyManager.PREVIOUS_WEAPON)
            {
                if (_weaponIndexSelect <= 0)
                {
                    _weaponIndexSelect = _weapons.Length - 1;
                }
                else
                {
                    _weaponIndexSelect--;
                }
                Off(previousIndex);
                On(_weaponIndexSelect);
            }
        }
        private void On(int currentWeaponIndex)
        {
            if (_isWeapon) { return; }
            if (_weapons[currentWeaponIndex] == null) { return; }

            _isWeapon = true;
            _weapons[currentWeaponIndex].WeaponVisibility(true);
        }

        private void Off(int previouseWeaponIndex)
        {
            if (!_isWeapon) return;
            _isWeapon = false;
            _weapons[previouseWeaponIndex].WeaponVisibility(false);
        }

        #endregion
    }
}
