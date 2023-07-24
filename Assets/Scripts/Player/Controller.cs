using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            player.SetInputs(horizontal, vertical);
        }
    }
}
