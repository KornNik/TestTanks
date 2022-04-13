using UnityEngine;
using Scripts.Interface;
using Scripts.Data.Projectile;

namespace Scripts.Behaviour.Projectile
{
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	abstract class BaseProjectile : MonoBehaviour, IDamager, IPoolable
	{
		#region Fields


		[SerializeField] protected ProjectileData _projectileData;
		[SerializeField] protected Collider _collider;
		[SerializeField] protected Rigidbody _rigidbody;

		protected Transform _poolTransform;

		#endregion


		#region Properties

		public Transform PoolTransform {  get { return _poolTransform; } set { _poolTransform = value; } }

		public GameObject PoolableObject { get { return gameObject; } set { PoolableObject.SetActive(value); } }

		#endregion


		#region UnityMethods

		protected virtual void Awake()
		{
			_collider = GetComponent<Collider>();
			_rigidbody = GetComponent<Rigidbody>();
		}

		#endregion


		#region Methods

		private void AddForce()
		{
			if (!_rigidbody) return;
			_rigidbody.AddForce(PoolTransform.forward * _projectileData.Force, ForceMode.Impulse);

		}

		#endregion


		#region IPoolable

		public void ReturnToPool()
		{
			transform.SetParent(PoolTransform);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			gameObject.SetActive(false);
			CancelInvoke(nameof(ReturnToPool));
			_rigidbody.velocity = Vector3.zero;

			if (!PoolTransform)
			{
				Destroy(gameObject);
			}
		}

		public void ActiveObject()
		{
			gameObject.SetActive(true);
			Invoke(nameof(ReturnToPool), _projectileData.TimeToDistract);
			transform.SetParent(null);
			AddForce();
		}

		#endregion


		#region IDamager

		public void InflictDamage(IDamageable damageable)
		{
			damageable.ReciveDamage(_projectileData.Damage);
		}

        #endregion
    }
}
