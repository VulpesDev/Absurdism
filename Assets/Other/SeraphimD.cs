using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeraphimD : MonoBehaviour
{
    void Update()
    {
        if(transform.GetChild(0).GetComponent<Dialog>().finished)
        {
            Instantiate(Resources.Load<GameObject>("Puff"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
