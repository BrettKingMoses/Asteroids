using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Classes
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        float spawnRate = 1f;
        float spawnRadius = 1f;
        float force = 300f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);

        }
        // Use this for initialization
        void Start()
        {
            //InvokeRepeating(functionName, time, repeatRate);
            InvokeRepeating("Spawn", 0, spawnRate);
        }
        // Update is called once per frame
        void Spawn()
        {
            //Instantiate a new GameObject
            GameObject enemy = Instantiate(enemyPrefab);
            //Position it to a random place within the spawn radius
            enemy.transform.position = Random.insideUnitCircle * spawnRadius;
            //Apply force to a rigidbody randomly
            Rigidbody2D rigid2D = enemy.GetComponent<Rigidbody2D>();
            rigid2D.AddForce(Random.insideUnitCircle * force);

        }
    }
}