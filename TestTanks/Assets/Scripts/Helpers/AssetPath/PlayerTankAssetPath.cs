using System.Collections.Generic;

namespace Scripts.Helpers
{
    sealed class PlayerTankAssetPath
    {
        #region Fields

        public static readonly Dictionary<PlayerTankTypes, string> PlayerTanksPath = new Dictionary<PlayerTankTypes, string>
        {
            {
                PlayerTankTypes.BaseTank, "Prefabs/PlayerTanks/Prefabs_PlayerTanks_BaseTank"
            }

        };

        #endregion
    }
}
