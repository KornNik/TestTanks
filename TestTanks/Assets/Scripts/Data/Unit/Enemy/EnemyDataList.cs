using UnityEngine;
using Scripts.Behaviour.Unit;

namespace Scripts.Data.Unit
{
    [CreateAssetMenu(fileName ="EnemyDataList",menuName ="Data/Unit/EnemyDataList")]
    class EnemyDataList : ScriptableObject
    {
        [SerializeField] private UnitBehaviour[] _listUnits = new UnitBehaviour[2];

        public UnitBehaviour[] ListUnits => _listUnits;
    }
}
