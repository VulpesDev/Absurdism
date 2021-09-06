using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaFinished : MonoBehaviour
{
    void Update()
    {
        if(transform.GetChild(0).GetComponent<Dialog>().finished)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().NextScene();
        }
    }
}
