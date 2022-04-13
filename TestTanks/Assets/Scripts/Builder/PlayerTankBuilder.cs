using UnityEngine;
using Scripts.Helpers;
using Scripts.Behaviour.Unit;

namespace Scripts.Builder
{
    class PlayerTankBuilder : TankBuilder
    {


        #region ClassLifeCycle

        public PlayerTankBuilder(Vector3 tankSpawnPosition) : base(tankSpawnPosition)
        {
            _tankPosition = tankSpawnPosition;
        }

        #endregion

        #region IEngineer

        public override void CreateBody() 
        {
            base.CreateBody();
            var tankBehaviour = CustomResources.Load<UnitBehaviour>(PlayerTankAssetPath.PlayerTanksPath[PlayerTankTypes.BaseTank]);
            _unitBehaviour = Object.Instantiate(tankBehaviour, _tankPosition, Quaternion.identity);
        }

        #endregion
    }
}
