using Assets.Scripts.Enemy;
using Colyseus;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
    public class MultiplayerManager : ColyseusManager<MultiplayerManager>
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private EnemyController _enemyPrefab;
        private Dictionary<string, EnemyController> _playerList = new Dictionary<string, EnemyController>();

        private ColyseusRoom<State> _room;

        protected override void Awake()
        {
            base.Awake();

            Instance.InitializeClient();
            Connect();
        }

        private async void Connect()
        {
            _room = await Instance.client.JoinOrCreate<State>("state_handler");
            _room.OnStateChange += OnChange;
        }

        private void CreatePlayer(Player player)
        {
            Vector3 position = new Vector3(player.x, 0, player.y);
            Instantiate(_playerPrefab, position, Quaternion.identity);
        }

        private void CreateEnemy(string key, Player player)
        {
            Vector3 position = new Vector3(player.x, 0, player.y);
            EnemyController newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            player.OnChange += newEnemy.OnChange;
            _playerList.Add(key, newEnemy);
        }

        private void OnChange(State state, bool isFirstState)
        {
            if (!isFirstState) return;

            state.players.ForEach((key, player) =>
            {
                if (key == _room.SessionId)
                    CreatePlayer(player);
                else
                    CreateEnemy(key, player);
            });

            _room.State.players.OnAdd += CreateEnemy;
            _room.State.players.OnRemove += RemoveEnemy;
        }

        private void RemoveEnemy(string key, Player player)
        {
            Destroy(_playerList[key].gameObject);
            _playerList.Remove(key);

        }

        public void SendMessage(string key, Dictionary<string, object> data)
        {
            _room.Send(key, data);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _room.Leave();
        }
    }
}
