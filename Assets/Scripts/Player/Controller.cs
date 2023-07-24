using Assets.Scripts.Multiplayer;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            _player.SetInputs(horizontal, vertical);
            
            SendMove();
        }

        private void SendMove()
        {
            _player.GetMove(out Vector3 position);
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "x", position.x },
                { "y", position.z }
            };

            MultiplayerManager.Instance.SendMessage("move", data);
        }
    }
}
