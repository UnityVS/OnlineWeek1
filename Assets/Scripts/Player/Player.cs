using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed; //�������� ������. ���� ��� �����, ��� ��� ��� �������� ��������, ����� ���� �������� �������������� ���� ��� ������ ����� �� ����. ��������� �� ��� ������ ��� ��� ����� ����� ����� ������������� ����?
        private float _inputHorizontal;
        private float _inputVertical;
        private Vector3 averagePredicitonPosition;

        public void SetInputs(float horizontal, float vertical)
        {
            _inputHorizontal = horizontal;
            _inputVertical = vertical;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 direction = new Vector3(_inputHorizontal, 0, _inputVertical).normalized;
            transform.position += direction * Time.deltaTime * _speed;
        }

        public void GetMove(out Vector3 position)
        {
            position = transform.position;
        }
    }
}