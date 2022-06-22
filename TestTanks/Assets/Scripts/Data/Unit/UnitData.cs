using System;
using UnityEngine;

namespace Scripts.Data.Unit
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit/UnitData")]
    class UnitData : ScriptableObject
    {
        #region Fields

        [SerializeField] private float _maxHealth;
        [SerializeField] private float _timeToRespawn;
        [SerializeField] private Stat _protection;
        [SerializeField] private Stat _speed;
        [SerializeField] private Stat _rotateSpeed;

        public event Action Death;

        private float _currentHealth;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            SetHealthToMax();
        }

        #endregion


        #region Properties

        public float CurrentHealth => _currentHealth;
        public float TimeToRespawn => _timeToRespawn;
        public Stat Protection => _protection;
        public Stat Speed => _speed;
        public Stat RotateSpeed => _rotateSpeed;

        #endregion


        #region Methods

        public virtual void TakeDamage(float damage)
        {
            damage *= _protection.BaseValue;
            if (damage > 0)
            {
                _currentHealth -= damage;
                if (_currentHealth <= 0)
                {
                    _currentHealth = 0;
                    Death?.Invoke();
                }
            }
        }
        public void AddHealth(int amount)
        {
            _currentHealth += amount;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }

        public void SetHealthRate(float rate)
        {
            _currentHealth = rate == 0 ? 0 : (int)(_maxHealth / rate);
        }

        public void SetHealthToMax()
        {
            if (_currentHealth == 0)
            {
                _currentHealth = _maxHealth;
            }
        }

        #endregion

    }
}
