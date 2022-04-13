using System;
using UnityEngine;

namespace Scripts.Helpers
{
    static class LayersManager
    {
        #region Fields

        private const string UI = "UI";
        private const string ENEMY = "Enemy";
        private const string PLAYER = "Player";
        private const string DEFAULT = "Default";

        public const int DEFAULT_LAYER = 0;

        #endregion


        #region Proeprties

        public static int DefaultLayer { get; }
        public static int UiLayer { get; }
        public static int EnemyLayer { get; }
        public static int PlayerLayer { get; }

        #endregion



        #region Class lifecycle

        static LayersManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            UiLayer = LayerMask.GetMask(UI);
            EnemyLayer = LayerMask.GetMask(ENEMY);
            PlayerLayer = LayerMask.GetMask(PLAYER);
        }

        #endregion
    }
}
