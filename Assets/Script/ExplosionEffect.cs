using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float duration = 2.0f; // Patlama efektinin s�resi

    void Start()
    {
        // Belirtilen s�re sonunda patlama efektini yok et
        Destroy(gameObject, duration);
    }
}
