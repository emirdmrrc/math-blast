using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunaGecis : MonoBehaviour
{
    public AudioSource ClickEffect;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

        ClickEffect.Play();

    }

}

