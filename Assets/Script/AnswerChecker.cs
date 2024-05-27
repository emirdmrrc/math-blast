using UnityEngine;
using TMPro;

public class AnswerChecker : MonoBehaviour
{
    public TMP_InputField cevapInputField; // Oyuncunun cevabý girdiði TMP_InputField
    public EnemyMover enemyMover; // Referans edilen düþman gemisi
    public GameObject explosionPrefab; // Patlama efekti prefab'ý
    public SoundManager soundManager; // SoundManager referansý

    private bool isDestroyed = false; // Gemi zaten yok edildi mi?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Oyuncu Enter tuþuna bastýðýnda
        {
            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        // Oyuncunun girdiði cevabý al
        string playerAnswer = cevapInputField.text;

        // Düþman gemisinin üzerindeki iþlemi alýn
        string operation = enemyMover.operationText.text;

        // Oyuncunun cevabýný ve iþlemi kontrol et
        if (IsOperationCorrect(playerAnswer, operation))
        {

            // Doðru cevap verilirse puan ekle
            ScoreManager.instance.AddScore(5);

            if (isDestroyed) return; // Eðer zaten yok edilmiþse, iþlemi durdur
            isDestroyed = true;


            // Patlama efektini oluþtur
            GameObject explosion = Instantiate(explosionPrefab, enemyMover.transform.position, Quaternion.identity);
            Destroy(explosion, 2.0f); // Patlama efektini 2 saniye sonra yok et

            // Ses efektini çal
            soundManager.PlayExplosionSound();


            Destroy(enemyMover.gameObject); // Doðru cevap verilirse düþmaný yok et
            cevapInputField.text = ""; // InputField'ý temizle

            // InputField'ý yeniden odakla
            cevapInputField.ActivateInputField();
        }
    }

    bool IsOperationCorrect(string playerAnswer, string operation)
    {
        // Ýþlemi ayýr ve doðru cevabý hesapla
        string[] parts = operation.Split(' ');
        int num1 = int.Parse(parts[0]);
        string op = parts[1];
        int num2 = int.Parse(parts[2]);
        int correctResult = 0;

        switch (op)
        {
            case "+":
                correctResult = num1 + num2;
                break;
            case "-":
                correctResult = num1 - num2;
                break;
            case "*":
                correctResult = num1 * num2;
                break;
        }

        // Oyuncunun cevabý doðru mu kontrol et
        return int.TryParse(playerAnswer, out int playerResult) && playerResult == correctResult;
    }
}
