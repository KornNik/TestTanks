using System.Collections.Generic;

namespace Scripts.Helpers
{
    sealed class LevelsAssetPath
    {
        #region Fields

        public static readonly Dictionary<LevelTypes, string> LevelsPath = new Dictionary<LevelTypes, string>
        {
            {
                LevelTypes.Level1, "Prefabs/Levels/Prefabs_Levels_Level_1"
            }
        };

        #endregion
    }
}
