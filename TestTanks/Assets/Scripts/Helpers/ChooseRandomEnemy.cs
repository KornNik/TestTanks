using System;
using Scripts.Data.Unit;
using Scripts.Behaviour.Unit;

namespace Scripts.Helpers
{
    class ChooseRandomEnemy
    {
        #region Fields

        private Random _randomNumber;
        private EnemyDataList _enemyDataList;

        #endregion


        #region ClassLifeCycle

        public ChooseRandomEnemy()
        {
            _enemyDataList = CustomResources.Load<EnemyDataList>(DatasAssetPath.DatasPath[DataTypes.EnemyDataList]);
            _randomNumber = new Random();
        }

        #endregion


        #region Methods

        public UnitBehaviour RandomEnemySelector()
        {
            return _enemyDataList.ListUnits[_randomNumber.Next(0, _enemyDataList.ListUnits.Length)]; ;
        }

        #endregion
    }
}
