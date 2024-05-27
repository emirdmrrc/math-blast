using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSound; // Patlama ses efekti

    public void PlayExplosionSound()
    {
        // Ses efekti çal
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }
}
