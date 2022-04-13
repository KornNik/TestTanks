using UnityEngine;
using Scripts.Data.Unit;

namespace Scripts.Behaviour.Unit
{
    abstract class UnitMovement
    {
        #region Fields

        protected UnitData _unitData;

        #endregion


        #region ClassLifeCycle

        public UnitMovement(UnitData unitData)
        {
            _unitData = unitData;
        }

        #endregion


        #region Mehtods

        public virtual void Move(float movingInput)
        {

        }

        public virtual void Rotate(float rotatingInput)
        {

        }
        public virtual void Move(Vector3 target)
        {

        }

        public virtual void Rotate(Vector3 rotatingInput)
        {

        }

        #endregion
    }
}

