using UnityEngine;
using Scripts.Data.Unit;

namespace Scripts.Behaviour.Unit
{
    class PlayerBaseTankMovement : UnitMovement
    {
        #region Fields

        protected Transform _tankTransform;

        #endregion


        #region ClassLifeCycle

        public PlayerBaseTankMovement(UnitData unitData, Transform tankTransform) : base(unitData)
        {
            _tankTransform = tankTransform;
        }

        #endregion


        #region Methods

        public override void Move(float movingInput)
        {
            base.Move(movingInput);
            _tankTransform.Translate(Vector3.forward * movingInput * (Time.deltaTime * _unitData.Speed.BaseValue));
        }

        public override void Rotate(float rotatingInput)
        {
            base.Rotate(rotatingInput);
            _tankTransform.transform.Rotate(Vector3.up * rotatingInput, (Time.deltaTime * _unitData.RotateSpeed.BaseValue));
        }

        #endregion
    }
}
