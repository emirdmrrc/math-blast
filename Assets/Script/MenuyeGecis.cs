using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuyeGecis : MonoBehaviour
{
    public AudioSource ClickEffect;
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");

        ClickEffect.Play();
    }
}
