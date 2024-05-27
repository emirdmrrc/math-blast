using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMover : MonoBehaviour
{
    public float speed = 2.0f;  // Hareket h�z�
    public Text operationText;  // D��man �zerindeki Text bile�eni

    void Start()
    {
        // Rastgele bir d�rt i�lem �ret
        string operation = GenerateRandomOperation();
        operationText.text = operation;
    }

    void Update()
    {
        // D��man� a�a��ya hareket ettir
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Ekran�n alt�na geldi�inde d��man� yok et
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        if (transform.position.y < screenBottom)
        {
            Debug.Log("Last enemy reached the bottom. Game over!");
            SceneManager.LoadScene("GameOverScene"); // Oyun bitirme sahnesine ge�i�
        }
    }

    string GenerateRandomOperation()
    {
        int num1 = Random.Range(5, 15);
        int num2 = Random.Range(5, 15);
        int operationType = Random.Range(0, 3);  // 0: Toplama, 1: ��karma, 2: �arpma

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

    // D��man yok edildi�inde ScoreManager'a puan ekle
    private void OnDestroy()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(5);
        }
    }
}
