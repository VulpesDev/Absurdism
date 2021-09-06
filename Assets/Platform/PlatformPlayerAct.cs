using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerAct : MonoBehaviour
{
    Animator anime;
    bool ready = true;
    GameObject player;
    int rangeReady = 2;

    private void Start()
    {
        anime = transform.parent.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > rangeReady)
        {
            ready = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player && ready)
        {
            StartCoroutine(ActAnimation());
            ready = false;
        }
    }

    IEnumerator ActAnimation()
    {
        Animatorr.Set(anime, "Contact", true);
        yield return new WaitForSeconds(0.05f);
        Animatorr.Set(anime, "Contact", false);
    }
}
