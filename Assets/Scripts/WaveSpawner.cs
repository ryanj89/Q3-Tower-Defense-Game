using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;
  	public int numberOfEnemies;
  	public float timeBetweenWaves;
  	public float spawnRate;
	public List<Transform> enemies;
  	private float timer = 2f;
	private bool hasSpawned = false;
	
	public void SpawnWave (int numberEnemies, float rate)
  	{
      for (int i = 0; i < numberEnemies; i++)
      {
			Invoke("SpawnEnemy", rate);
      }
  	}

  void SpawnEnemy ()
  {
      // Get a random point on the wave spawner
      Vector3 randomPoint = new Vector3(Random.Range (-22f, 22f), transform.position.y, transform.position.z);
      // Create enemy at that random point
      Instantiate(enemyPrefab, randomPoint, transform.rotation);
  }
}
