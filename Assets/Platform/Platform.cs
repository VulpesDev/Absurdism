using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().SetInteger("Plat", Random.Range(0, 4));
    }
}
