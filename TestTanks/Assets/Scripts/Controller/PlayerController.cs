using UnityEngine;
using Scripts.Helpers;
using Scripts.Behaviour.Unit;

namespace Scripts.Controller
{
    class PlayerController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelController _levelController;

        private Vector2 _inputAxis;

        #endregion



        #region UnityMethods

        private void Update()
        {
            MovingPlayerTank();
            FirePlayerWeapon();
            ChangePlayerWeapon();
        }

        #endregion



        #region Methods

        private void MovingPlayerTank()
        {
            _inputAxis.x = Input.GetAxis(AxisManager.HORIZONTAL);
            _inputAxis.y = Input.GetAxis(AxisManager.VERTICAL);
            if (_inputAxis.y != 0)
            {
                _levelController.Player.UnitMovement.Move(_inputAxis.y);
            }
            if (_inputAxis.x != 0)
            {
                _levelController.Player.UnitMovement.Rotate(_inputAxis.x);
            }
        }
        private void FirePlayerWeapon()
        {
            if (Input.GetAxis(AxisManager.FIRE1) != 0)
            {
                _levelController.Player.Weaponry.FireCurrentWeapon();
            }
        }
        private void ChangePlayerWeapon()
        {
            if (Input.GetKeyDown(KeyManager.NEXT_WEAPON))
            {
                _levelController.Player.Weaponry.ChangeWeapon(KeyManager.NEXT_WEAPON);
            }
            else if (Input.GetKeyDown(KeyManager.PREVIOUS_WEAPON))
            {
                _levelController.Player.Weaponry.ChangeWeapon(KeyManager.PREVIOUS_WEAPON);
            }
        }

        #endregion



    }
}
