using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // D��man prefab'�
    public float spawnInterval = 2.0f;  // D��manlar�n olu�turulma aral���
    public float initialDelay = 1.0f;  // Ba�lang��taki gecikme s�resi

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
        // Ba�lang��ta belirli bir s�re bekle
        yield return new WaitForSeconds(initialDelay);
        // Daha sonra d��manlar� �retmeye ba�la
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
        // D��man� spawner'�n bulundu�u konumda olu�tur
        Vector3 spawnPosition = transform.position;

        // D��man� olu�tur
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
