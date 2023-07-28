using Colyseus.Schema;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private Vector3 _newPosition;
        private Vector3 _direction = Vector3.zero;
        private Vector3 _averageDirection = Vector3.zero;
        private List<Vector3> _pingDirectionList = new List<Vector3>();
        private int _pingDirectionListCountMax = 5;
        private float _lerpPower = 15f;

        private void Awake()
        {
            _newPosition = transform.position;
        }

        public void OnChange(List<DataChange> changes)
        {
            foreach (var dataChange in changes)
            {
                switch (dataChange.Field)
                {
                    case "x":
                        _newPosition.x = (float)dataChange.Value;
                        _direction.x = (float)dataChange.Value - (float)dataChange.PreviousValue;
                        break;

                    case "y":
                        _newPosition.z = (float)dataChange.Value;
                        _direction.z = (float)dataChange.Value - (float)dataChange.PreviousValue;
                        break;

                    default:
                        Debug.Log("Что-то не заполнил? " + dataChange.Field);
                        break;
                }
            }

            _pingDirectionList.Add(_direction);
            if (_pingDirectionList.Count > _pingDirectionListCountMax)
                _pingDirectionList.RemoveAt(0);

            Vector3 averageDirection = Vector3.zero;

            foreach (Vector3 vector in _pingDirectionList)
                averageDirection += vector;

            _averageDirection = (averageDirection /= 5) * 2;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _newPosition + _averageDirection, _lerpPower * Time.deltaTime);
        }
    }
}