using UnityEngine;
using UnityEngine.AI;
using Scripts.Data.Unit;

namespace Scripts.Behaviour.Unit
{
    class NPCBaseTankMovement : UnitMovement
    {
        #region Fields

        private NavMeshAgent _meshAgent;

        #endregion


        #region ClassLifeCycle

        public NPCBaseTankMovement(UnitData unitData, NavMeshAgent meshAgent) : base(unitData)
        {
            _meshAgent = meshAgent;
        }

        #endregion


        #region Methods

        public override void Move(Vector3 target)
        {
            base.Move(target);
            _meshAgent.SetDestination(target);
        }

        public override void Rotate(Vector3 rotatingInput)
        {
            base.Rotate(rotatingInput);
        }

        #endregion
    }
}
