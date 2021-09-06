using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : MonoBehaviour
{
   public void Shake()
    {
        StartCoroutine(CameraEffect.Shaker(2,10,0.2f));
    }
}
