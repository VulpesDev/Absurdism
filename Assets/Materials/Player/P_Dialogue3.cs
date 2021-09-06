using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Dialogue3 : P_DialogueBase
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) pressedE = true;
        if (Input.GetKeyUp(KeyCode.E)) pressedE = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            interact.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interact.activeSelf && pressedE && collision.gameObject.name == "Seraphim")
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            actor = "Seraphim";
        }
        if (interact.activeSelf && pressedE && collision.gameObject.name == "Gorilla")
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            actor = "John";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            interact.SetActive(false);
        }
    }
}
