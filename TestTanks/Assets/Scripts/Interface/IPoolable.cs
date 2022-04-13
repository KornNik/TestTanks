using UnityEngine;

namespace Scripts.Interface
{
    interface IPoolable
    {
        Transform PoolTransform { get; set; }
        GameObject PoolableObject { get; set; }
        void ReturnToPool();
        void ActiveObject();
    }
}
