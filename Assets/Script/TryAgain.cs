using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public AudioSource ClickEffect;
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");

        ClickEffect.Play();
    }
}
