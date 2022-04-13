using System.Collections.Generic;

namespace Scripts.Helpers
{
    sealed class DatasAssetPath
    {
        #region Fields

        public static readonly Dictionary<DataTypes, string> DatasPath = new Dictionary<DataTypes, string>
        {
            {
                DataTypes.WeaponDataList, "Data/Weapon/WeaponsList"
            },
            {
                DataTypes.EnemyDataList, "Data/Unit/EnemyList/EnemyDataList"
            }
        };

        #endregion
    }
}
