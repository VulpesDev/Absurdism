using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Dialogue2 : P_DialogueBase
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
        if (interact.activeSelf && pressedE && collision.gameObject.name == "Portal")
        {
            GetComponent<Player>().NextScene();
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
