using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch");
        if(collision.gameObject.CompareTag("DeathCollider"))
        {
            SceneManager.ReloadScene();
        }
    }
}
