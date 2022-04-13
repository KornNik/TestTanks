using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Helpers
{
    public static class Patrol
    {
        public static Vector3 GenericPoint(Vector3 position)
        {
            Vector3 result;

            var dis = Random.Range(10, 100);
            var randomPoint = Random.insideUnitSphere * dis;

            NavMesh.SamplePosition(position + randomPoint, out var hit, dis, NavMesh.GetAreaFromName(NavMeshAreasManager.RESPAWN));
            result = hit.position;

            return result;
        }
    }
}