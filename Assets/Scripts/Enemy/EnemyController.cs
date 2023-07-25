using Colyseus.Schema;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Vector3 _newPosition;
        private Vector3 _oldPosition = Vector3.zero;
        public void OnChange(List<DataChange> changes)
        {
            foreach (var dataChange in changes)
            {
                switch (dataChange.Field)
                {
                    case "x":
                        _oldPosition.x = (float)dataChange.PreviousValue; //(float)dataChange.Value;
                        _newPosition.x = (float)dataChange.Value;
                        break;
                    case "y":
                        _oldPosition.z = (float)dataChange.PreviousValue; //(float)dataChange.Value;
                        _newPosition.z = (float)dataChange.Value;
                        break;
                    default:
                        Debug.Log("Что-то не заполнил? " + dataChange.Field);
                        break;
                }
            }
        }

        private void Update() => transform.position = Vector3.Lerp(transform.position, _newPosition, 20f * Time.deltaTime);
    }
}
