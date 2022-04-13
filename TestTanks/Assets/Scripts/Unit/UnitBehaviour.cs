using UnityEngine;
using Scripts.Interface;
using Scripts.Data.Unit;
using Scripts.Data.Guns;
using Scripts.Behaviour.Guns;

namespace Scripts.Behaviour.Unit
{
    [RequireComponent(typeof(Rigidbody), (typeof(Collider)))]
    abstract class UnitBehaviour : MonoBehaviour, IDamageable
    {
        #region Fields

        [SerializeField] protected Transform _weaponPlace;
        [SerializeField] protected UnitData _unitData;
        [SerializeField] protected WeaponryData _weaponryData;
        [SerializeField] protected Rigidbody _unitRigidbody;
        [SerializeField] protected float _health;

        protected UnitMovement _unitMovement;
        protected Weaponry _weaponry;
        protected Transform _spawnPlace;

        #endregion


        #region Properties

        public Transform WeaponPlace => _weaponPlace;
        public UnitData UnitData => _unitData;
        public UnitMovement UnitMovement => _unitMovement;
        public Weaponry Weaponry => _weaponry;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _weaponry = new Weaponry(_weaponryData);
            _unitRigidbody = GetComponent<Rigidbody>();
            _unitData.Death += OnDeath;
            _spawnPlace = transform;
        }

        #endregion


        #region Methods

        protected void UnitVisibility(bool visibilityValue)
        {
            var tempRenderer = GetComponent<Renderer>();
            if (tempRenderer)
            {
                tempRenderer.enabled = visibilityValue;
            }
            if (transform.childCount <= 0) { return; }
            foreach (Transform item in transform)
            {
                tempRenderer = item.GetComponentInChildren<Renderer>();
                if (tempRenderer)
                {
                    tempRenderer.enabled = visibilityValue;
                }
            }
        }
        protected void ColliderActivity(bool activityValue)
        {
            var tempCollider = GetComponent<Collider>();
            if (tempCollider)
            {
                tempCollider.enabled = activityValue;
            }
            if (transform.childCount <= 0) { return; }
            foreach (Transform item in transform)
            {
                tempCollider = item.GetComponentInChildren<Collider>();
                if (tempCollider)
                {
                    tempCollider.enabled = activityValue;
                }
            }
        }
        protected virtual void OnDeath()
        {
            ColliderActivity(false);
            UnitVisibility(false);
            Revive();
        }
        protected virtual void Revive()
        {
            _unitData.SetHealthToMax();
            Invoke(nameof(Respawn), _unitData.TimeToRespawn);
        }

        protected virtual void Respawn()
        {
            transform.localPosition = _spawnPlace.position;
            transform.localRotation = _spawnPlace.rotation;
            ColliderActivity(true);
            UnitVisibility(true);
        }

        #endregion


        #region IDamageable

        public virtual void ReciveDamage(float damage)
        {
            _unitData.TakeDamage(damage);
            _health = UnitData.CurrentHealth;
        }

        #endregion

    }
}
