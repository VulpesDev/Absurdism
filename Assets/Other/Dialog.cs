using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    GameObject player;

    //voices
    GameObject playerEh;
    //\voices

    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI textInfo;
    public GameObject panel;
    public string[] sentences;
    private int index = 0;
    float base_t_Speed;
    float typingSpeed;
    bool finDis;
    string actor;

    public bool finished;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEh = Resources.Load<GameObject>("PlayerEh");
        index = 0;
        finDis = false;
        if (!panel.activeSelf) panel.SetActive(true);
        if (!textDisplay.gameObject.activeSelf) textDisplay.gameObject.SetActive(true);
        if (textInfo != null) textInfo.gameObject.SetActive(true);
        base_t_Speed = 0.02f;
        typingSpeed = base_t_Speed;
        StartCoroutine(Type());
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    IEnumerator Type()
    {
        if (sentences[index][0] == '-')
        {
            textDisplay.color = Color.red;
            actor = "Player";
        }
        else
        {
            textDisplay.color = Color.white;
            if(player.GetComponent<P_Dialogue>() != null)
            actor = player.GetComponent<P_Dialogue>().actor;
            else if (player.GetComponent<P_Dialogue2>() != null)
                actor = player.GetComponent<P_Dialogue2>().actor;
            else if (player.GetComponent<P_Dialogue3>() != null)
                actor = player.GetComponent<P_Dialogue3>().actor;
            else if (player.GetComponent<P_Dialogue4>() != null)
                actor = player.GetComponent<P_Dialogue4>().actor;
        }
        foreach (char letter in sentences[index].ToCharArray())
        {
            Sounds();
            textDisplay.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Sounds()
    {
        if (actor == "Player" && Random.Range(0,2) == 0)
        {
            Instantiate(playerEh);
        }
        else if (actor == "John" && Random.Range(0, 2) == 0)
        {
            Instantiate(Resources.Load<GameObject>("JohnEh"));
        }
        else if (actor == "Denail_Sasha_Dog" && Random.Range(0, 2) == 0)
        {
            Instantiate(Resources.Load<GameObject>("JohnEh"));
        }
        else if (actor == "Seraphim" && Random.Range(0, 2) == 0)
        {
            Instantiate(Resources.Load<GameObject>("JohnEh"));
        }
        else if (actor == "Unknown" && Random.Range(0, 2) == 0)
        {
            Instantiate(Resources.Load<GameObject>("JohnEh"));
        }
    }


    public void NextSentence()
    {
        typingSpeed = base_t_Speed;
        finDis = false;
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            panel.SetActive(false);
            textDisplay.gameObject.SetActive(false);
            if (textInfo != null) textInfo.gameObject.SetActive(false);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            finished = true;
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            finDis = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (finDis)
                NextSentence();
            else
                typingSpeed = 0;

        }
    }
}
