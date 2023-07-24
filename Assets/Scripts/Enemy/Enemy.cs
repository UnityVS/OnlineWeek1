using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
