using System;
using UnityEngine;
using Scripts.Data.Guns;

namespace Scripts.Behaviour.Guns
{
    abstract class Weapon : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected WeaponData _weaponData;
        [SerializeField] protected Transform _barrel;

        protected bool _isReady = true;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            WeaponVisibility(false);
        } 

        #endregion


        #region Methods

        public virtual void Fire()
        {
        }

        public void WeaponVisibility(bool visibilityValue)
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
        protected void ReadyShoot()
        {
            _isReady = true;
        }
        #endregion
    }
}
