using System.Collections.Generic;

namespace Scripts.Helpers
{
    sealed class ProjectileAssetPath
    {
        #region Fields

        public static readonly Dictionary<AmmunitionType, string> ProjectilesPath = new Dictionary<AmmunitionType, string>
        {
            {
                AmmunitionType.Bullet, "Prefabs/Projectiles/Prefabs_Projectiles_SimpleProjectile"
            }

        };

        #endregion
    }
}
