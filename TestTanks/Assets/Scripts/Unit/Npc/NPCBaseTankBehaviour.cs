using UnityEngine;
using UnityEngine.AI;
using Scripts.Helpers;

namespace Scripts.Behaviour.Unit
{
    [RequireComponent(typeof(NavMeshAgent))]
    class NPCBaseTankBehaviour : UnitBehaviour
    {
        #region Fields

        [SerializeField] protected NavMeshAgent _meshAgent;

        protected Transform _poolTransform;

        private Collider[] _bufferColliders = new Collider[128];
        private bool _isOnTarget;


        #endregion


        #region Properties

        public NavMeshAgent MeshAgent { get { return _meshAgent; } set { _meshAgent = value; } }

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _meshAgent = GetComponent<NavMeshAgent>();

            _unitMovement = new NPCBaseTankMovement(_unitData, _meshAgent);

            _meshAgent.autoRepath = true;
            _unitRigidbody.isKinematic = true;
            _meshAgent.speed = 0.4f;
        }

        protected virtual void Update()
        {
            if (!_meshAgent.hasPath&&!FindTarget())
            {
                MovingOnLevel();
            }
            else if (FindTarget())
            {
                GoToTarget();
            }
        }
        #endregion


        #region Methods

        private void MovingOnLevel()
        {
            var point = Patrol.GenericPoint(transform.position);
            _unitMovement.Move(point);
            _meshAgent.stoppingDistance = 0f;
        }
        private bool FindTarget()
        {
            var isFindTarget = Physics.CheckSphere(transform.position, 20f, LayersManager.PlayerLayer);
            return isFindTarget;
        }

        private void GoToTarget()
        {
            var targets = Physics.OverlapSphere(transform.position, 20f, LayersManager.PlayerLayer);
            for (int i = 0; i < targets.Length; i++)
            {
                PlayerBaseTankBehaviour character = targets[i].GetComponent<PlayerBaseTankBehaviour>();
                if (character != null)
                {
                    _meshAgent.stoppingDistance = 0.1f;
                    _unitMovement.Move(character.transform.position);
                    break;
                }
            }
        }

        protected override void OnDeath()
        {
            base.OnDeath();

        }
        protected override void Revive()
        {
            base.Revive();

        }

        #endregion


        #region IDamageable

        public override void ReciveDamage(float damage)
        {
            base.ReciveDamage(damage);
        }

        #endregion

    }
}
