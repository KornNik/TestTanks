using UnityEngine;
using Scripts.Helpers;
using Scripts.Behaviour.Unit;

namespace Scripts.Builder
{
    abstract class TankBuilder : IEngineer
    {
        #region Fields

        protected UnitBehaviour _unitBehaviour;
        protected Vector3 _tankPosition;
        protected ChooseRandomWeapon _randomWeapon;

        #endregion


        #region ClassLifeCycle

        public TankBuilder(Vector3 tankSpawnPosition)
        {
            _randomWeapon = new ChooseRandomWeapon();
            _tankPosition = tankSpawnPosition;
        }

        #endregion


        #region Properties

        public Vector3 TankTransform => _tankPosition;

        #endregion


        #region IEngineer

        public virtual void CreateBody()
        {

        }
        public virtual void CreateWeaponry()
        {
            for (int i = 0; i < _unitBehaviour.Weaponry.Weapons.Length; i++)
            {
                var weapon = _randomWeapon.RandomWeaponSelector();
                _unitBehaviour.Weaponry.SetWeapon(weapon, i);

                _unitBehaviour.Weaponry.Weapons[i] = Object.Instantiate(weapon, _unitBehaviour.WeaponPlace.position,
                    _unitBehaviour.WeaponPlace.rotation, _unitBehaviour.WeaponPlace);
            }
        }
        public virtual UnitBehaviour GetTank()
        {
            return _unitBehaviour;
        }

        #endregion


    }
}
