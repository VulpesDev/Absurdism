using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Dialogue : P_DialogueBase
{
    [SerializeField] GameObject dialogDenail;
    [SerializeField] GameObject timeline2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) pressedE = true;
        if (Input.GetKeyUp(KeyCode.E)) pressedE = false;
        if(dialogDenail.GetComponent<Dialog>().finished)
        {
            timeline2.SetActive(true);
        }
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
        if(interact.activeSelf && collision.gameObject.name == "John"
            && pressedE)
        {
            actor = "John";
            interact.SetActive(false);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (interact.activeSelf && collision.gameObject.name == "Denail_Sasha_Dog"
            && pressedE)
        {
            actor = "Denail_Sasha_Dog";
            interact.SetActive(false);
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
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
