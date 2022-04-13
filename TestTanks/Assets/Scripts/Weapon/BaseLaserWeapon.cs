using UnityEngine;
using Scripts.Interface;
using System.Collections;

namespace Scripts.Behaviour.Guns
{
    [RequireComponent(typeof(LineRenderer))]
    class BaseLaserWeapon : Weapon
    {
        #region Fields

        [SerializeField] protected LineRenderer _laserRenderer;

        protected WaitForSeconds _laserDisplayTime = new WaitForSeconds(0.1f);

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _laserRenderer = GetComponent<LineRenderer>();
        }

        #endregion


        #region Methods

        public override void Fire()
        {
            base.Fire();
            if (!_isReady) return;
            RaycastHit hit;
            if (Physics.Raycast(_barrel.position, _barrel.forward, out hit, 100f))
            {
                DrawLaser(hit.point);
                var victim = hit.transform.GetComponent<IDamageable>();
                if (victim != null)
                {
                    victim.ReciveDamage(_weaponData.Damage);
                }
            }
            else
            {
                DrawLaser(_barrel.forward * 100f);
            }
            _isReady = false;
            Invoke(nameof(ReadyShoot), _weaponData.ShotsDelay);
        }

        protected virtual void DrawLaser(Vector3 endLaserPosition)
        {

            _laserRenderer.SetPosition(0, _barrel.position);
            _laserRenderer.SetPosition(1, endLaserPosition);
            StartCoroutine(nameof(LaserEnableCoroutine));
        }

        private IEnumerator LaserEnableCoroutine()
        {
            _laserRenderer.enabled = true;
            yield return _laserDisplayTime;
            _laserRenderer.enabled = false;
        }

        #endregion
    }
}
