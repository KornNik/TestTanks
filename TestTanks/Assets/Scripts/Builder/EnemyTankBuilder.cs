using UnityEngine;
using Scripts.Helpers;

namespace Scripts.Builder
{
    class EnemyTankBuilder : TankBuilder
    {
        #region Fields

        private ChooseRandomEnemy _randomEnemy;

        #endregion


        #region ClassLifeCycle

        public EnemyTankBuilder(Vector3 tankSpawnPosition) : base(tankSpawnPosition)
        {
            _tankPosition = tankSpawnPosition;
            _randomEnemy = new ChooseRandomEnemy();
        }

        #endregion


        #region IEngineer

        public override void CreateBody()
        {
            base.CreateBody();
            var enemyTank = _randomEnemy.RandomEnemySelector();
            _unitBehaviour = Object.Instantiate(enemyTank, _tankPosition, Quaternion.identity);
        }

        #endregion
    }
}
