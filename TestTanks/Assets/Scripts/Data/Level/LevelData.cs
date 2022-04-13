using UnityEngine;

namespace Scripts.Data.Level
{
    [CreateAssetMenu(fileName = " LevelData",menuName ="Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _enemiesCount;
        [SerializeField] private Vector3 _playerPosition;

        #endregion


        #region Properties

        public int EnemiesCount => _enemiesCount;
        public Vector3 PlayerPosition => _playerPosition;

        #endregion
    }
}
