using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float duration = 2.0f; // Patlama efektinin süresi

    void Start()
    {
        // Belirtilen süre sonunda patlama efektini yok et
        Destroy(gameObject, duration);
    }
}
