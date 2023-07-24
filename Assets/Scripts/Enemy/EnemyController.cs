using Colyseus.Schema;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Vector3 _newPosition;
        public void OnChange(List<DataChange> changes)
        {
            foreach (var dataChange in changes)
            {
                switch (dataChange.Field)
                {
                    case "x":
                        _newPosition.x = (float)dataChange.Value;
                        break;
                    case "y":
                        _newPosition.z = (float)dataChange.Value;
                        break;
                    default:
                        Debug.Log("Что-то не заполнил? " + dataChange.Field);
                        break;
                }
            }
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _newPosition, 5f * Time.deltaTime);
        }
    }
}
