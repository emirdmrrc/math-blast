using UnityEngine;
using TMPro;

public class AnswerChecker : MonoBehaviour
{
    public TMP_InputField cevapInputField; // Oyuncunun cevab� girdi�i TMP_InputField
    public EnemyMover enemyMover; // Referans edilen d��man gemisi
    public GameObject explosionPrefab; // Patlama efekti prefab'�
    public SoundManager soundManager; // SoundManager referans�

    private bool isDestroyed = false; // Gemi zaten yok edildi mi?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Oyuncu Enter tu�una bast���nda
        {
            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        // Oyuncunun girdi�i cevab� al
        string playerAnswer = cevapInputField.text;

        // D��man gemisinin �zerindeki i�lemi al�n
        string operation = enemyMover.operationText.text;

        // Oyuncunun cevab�n� ve i�lemi kontrol et
        if (IsOperationCorrect(playerAnswer, operation))
        {

            // Do�ru cevap verilirse puan ekle
            ScoreManager.instance.AddScore(5);

            if (isDestroyed) return; // E�er zaten yok edilmi�se, i�lemi durdur
            isDestroyed = true;


            // Patlama efektini olu�tur
            GameObject explosion = Instantiate(explosionPrefab, enemyMover.transform.position, Quaternion.identity);
            Destroy(explosion, 2.0f); // Patlama efektini 2 saniye sonra yok et

            // Ses efektini �al
            soundManager.PlayExplosionSound();


            Destroy(enemyMover.gameObject); // Do�ru cevap verilirse d��man� yok et
            cevapInputField.text = ""; // InputField'� temizle

            // InputField'� yeniden odakla
            cevapInputField.ActivateInputField();
        }
    }

    bool IsOperationCorrect(string playerAnswer, string operation)
    {
        // ��lemi ay�r ve do�ru cevab� hesapla
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

        // Oyuncunun cevab� do�ru mu kontrol et
        return int.TryParse(playerAnswer, out int playerResult) && playerResult == correctResult;
    }
}
