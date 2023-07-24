using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed; //�������� ������. ���� ��� �����, ��� ��� ��� �������� ��������, ����� ���� �������� �������������� ���� ��� ������ ����� �� ����. ��������� �� ��� ������ ��� ��� ����� ����� ����� ������������� ����?
        private float _inputHorizontal;
        private float _inputVertical;

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
            Vector3 direction = new Vector3(_inputHorizontal, 0, _inputVertical);
            transform.position += direction * Time.deltaTime * speed;
        }
    }
}