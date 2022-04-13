using System;
using Scripts.Data.Guns;
using Scripts.Behaviour.Guns;

namespace Scripts.Helpers
{
    class ChooseRandomWeapon
    {
        #region Fields

        private Random _randomNumber;
        private WeaponsDataList _weaponsDataList;

        #endregion


        #region ClassLifeCycle

        public ChooseRandomWeapon()
        {
            _weaponsDataList = CustomResources.Load<WeaponsDataList>(DatasAssetPath.DatasPath[DataTypes.WeaponDataList]);
            _randomNumber = new Random();
        }

        #endregion


        #region Methods

        public Weapon RandomWeaponSelector()
        {
            var weapon = _weaponsDataList.Weapons[_randomNumber.Next(0, _weaponsDataList.Weapons.Length)];
            return weapon;
        }

        #endregion
    }
}
