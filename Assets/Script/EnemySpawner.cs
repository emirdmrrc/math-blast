using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Düþman prefab'ý
    public float spawnInterval = 2.0f;  // Düþmanlarýn oluþturulma aralýðý
    public float initialDelay = 1.0f;  // Baþlangýçtaki gecikme süresi

    private Coroutine spawnCoroutine;

    void Start()
    {
        spawnCoroutine = StartCoroutine(StartSpawningWithDelay());
    }

    void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    IEnumerator StartSpawningWithDelay()
    {
        // Baþlangýçta belirli bir süre bekle
        yield return new WaitForSeconds(initialDelay);
        // Daha sonra düþmanlarý üretmeye baþla
        spawnCoroutine = StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Debug.Log("Spawning enemy...");
            if (enemyPrefab != null)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        // Düþmaný spawner'ýn bulunduðu konumda oluþtur
        Vector3 spawnPosition = transform.position;

        // Düþmaný oluþtur
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
