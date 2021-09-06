using UnityEngine;

public class Uhs : MonoBehaviour
{
    void Update()
    {
        if(!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
