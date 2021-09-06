using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneActivator : MonoBehaviour
{
    [SerializeField] GameObject Timeline1;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(gameObject.name == "Cutscene1")
            {
                Timeline1.SetActive(true);
            }
        }
    }
}
