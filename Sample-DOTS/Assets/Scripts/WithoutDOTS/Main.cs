using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WithoutDOTS
{
    public class Main : MonoBehaviour
    {
        public int playerNumber = 10000;
        public GameObject playerPrefab;

        List<PlayerData> playerTransforms = new List<PlayerData>();

        void Start()
        {
            System.Random rand = new System.Random(111);

            for (int i = 0; i < playerNumber; i++)
            {
                var instance = Instantiate(playerPrefab).AddComponent<PlayerData>();
                playerTransforms.Add(instance);

                instance.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
                instance.moveSpeed = Random.Range(1f, 3f);
            }
        }

        private void Update()
        {
            for (int i = 0, l  = playerTransforms.Count; i < l; i++)
            {
                var player = playerTransforms[i];
                player.transform.position += new Vector3(player.moveSpeed * Time.deltaTime, 0, 0);
                if (player.transform.position.x > 5) player.moveSpeed = -Mathf.Abs(player.moveSpeed);
                if (player.transform.position.x < -5) player.moveSpeed = Mathf.Abs(player.moveSpeed);
            }
        }
    }
}
