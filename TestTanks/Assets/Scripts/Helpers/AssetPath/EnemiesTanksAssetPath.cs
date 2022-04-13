using System.Collections.Generic;


namespace Scripts.Helpers
{
    sealed class EnemiesTanksAssetPath
    {
        #region Fields

        public static readonly Dictionary<EnemyTankTypes, string> EnemiesTanksPath = new Dictionary<EnemyTankTypes, string>
        {
            {
                EnemyTankTypes.BaseEnemyTank, "Prefabs/NPCTanks/Prefabs_NPCTanks_BaseNPCTanks"
            },
            {
                EnemyTankTypes.FastEnemyTank,"Prefabs/NPCTanks/Prefabs_NPCTanks_FastNPCTank"
            }
        };

        #endregion
    }
}
