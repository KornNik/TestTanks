using UnityEngine;
using Scripts.Helpers;
using Scripts.Builder;
using Scripts.Data.Level;
using Scripts.Behaviour.Unit;
using System.Collections.Generic;

namespace Scripts.Controller
{
    class LevelController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelData _levelData;

        private IEngineer _tankBuilder;
        private UnitBehaviour _player;
        private List<NPCBaseTankBehaviour> _enemies;

        private GameObject _level;

        #endregion


        #region Properties

        public UnitBehaviour Player => _player;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _enemies = new List<NPCBaseTankBehaviour>(_levelData.EnemiesCount);

            CreateLevel();
            CreatePlayer();
            CreateEnemies();
        }

        #endregion


        #region Methods

        private void CreatePlayer()
        {
            _tankBuilder = new PlayerTankBuilder(_levelData.PlayerPosition);
            _tankBuilder.CreateBody();
            _tankBuilder.CreateWeaponry();
            _player = _tankBuilder.GetTank();
        }
        private void CreateEnemies()
        {
            for (int i = 0; i < _levelData.EnemiesCount; i++)
            {
                _tankBuilder = new EnemyTankBuilder(Patrol.GenericPoint(_player.transform.position));
                _tankBuilder.CreateBody();
                _tankBuilder.CreateWeaponry();
                _enemies.Add((NPCBaseTankBehaviour)_tankBuilder.GetTank());
                _enemies[i].MeshAgent.avoidancePriority = i;
            }
        }
        private void CreateLevel()
        {
            var level = CustomResources.Load<GameObject>(LevelsAssetPath.LevelsPath[LevelTypes.Level1]);
            _level = Object.Instantiate(level, Vector3.zero, Quaternion.identity);
        }

        #endregion

    }
}
