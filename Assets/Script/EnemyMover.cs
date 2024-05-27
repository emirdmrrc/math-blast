using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMover : MonoBehaviour
{
    public float speed = 2.0f;  // Hareket hýzý
    public Text operationText;  // Düþman üzerindeki Text bileþeni

    void Start()
    {
        // Rastgele bir dört iþlem üret
        string operation = GenerateRandomOperation();
        operationText.text = operation;
    }

    void Update()
    {
        // Düþmaný aþaðýya hareket ettir
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Ekranýn altýna geldiðinde düþmaný yok et
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        if (transform.position.y < screenBottom)
        {
            Debug.Log("Last enemy reached the bottom. Game over!");
            SceneManager.LoadScene("GameOverScene"); // Oyun bitirme sahnesine geçiþ
        }
    }

    string GenerateRandomOperation()
    {
        int num1 = Random.Range(5, 15);
        int num2 = Random.Range(5, 15);
        int operationType = Random.Range(0, 3);  // 0: Toplama, 1: Çýkarma, 2: Çarpma

        switch (operationType)
        {
            case 0:
                return $"{num1} + {num2}";
            case 1:
                return $"{num1} - {num2}";
            case 2:
                return $"{num1} * {num2}";
            default:
                return $"{num1} + {num2}";
        }
    }

    // Düþman yok edildiðinde ScoreManager'a puan ekle
    private void OnDestroy()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(5);
        }
    }
}
