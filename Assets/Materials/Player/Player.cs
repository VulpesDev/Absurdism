using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ////////////////////// INITIATIVE \\\\\\\\\\\\\\\\\\\\\\\\\
    void Start()
    {
        animeF = transform.GetChild(0).GetComponent<Animator>();
        animeS = transform.GetChild(1).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        base_gravityscale = rb.gravityScale;
        layerMask = LayerMask.GetMask("Ground");
        StartCoroutine(WSounds());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.ReloadScene();
        }
        Walking();
        Jumping();
        if (playerCanvas.activeSelf) CanvasAllignment();
        if (isGrounded && canPlay) 
        {
            landing.Play();
            canPlay = false;
        }
    }

    ////////////////////// MOVEMENT \\\\\\\\\\\\\\\\\\\\\\\\\

    Rigidbody2D rb;
    Animator animeF, animeS;
    [SerializeField] int acceleration, jumpForce, friction;
    [SerializeField] float speed;
    [SerializeField] GameObject idle, run;
    private float base_gravityscale, jumpTimeCounter;
    private bool isGrounded, isJumping;
    public float jumpTime, checkRadius;
    public Transform feetPos;

    #region Jumping
    void Jumping()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, layerMask);

        if(isGrounded)
        {
            Animatorr.Set(animeF, "Jump", false);
            Animatorr.Set(animeS, "Jump", false);
        }
        else
        {
            canPlay = true;
            Animatorr.Set(animeF, "Jump", true);
            Animatorr.Set(animeS, "Jump", true);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
        }
        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }

    void Jump() =>
        rb.velocity = new Vector2(rb.velocity.x ,jumpForce);

    #endregion
    #region Walking
    void Walking()
    {

        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            if (isGrounded) walking = true; else walking = false;

            rb.gravityScale = base_gravityscale;
            if (idle.activeSelf)
            {
                idle.SetActive(false);
            }
            if (!run.activeSelf)
            {
                run.SetActive(true);
            }

            if (horizontal > 0)
            {
                if (rb.velocity.x < speed)
                 rb.velocity += new Vector2(acceleration * Time.deltaTime, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                if(rb.velocity.x > -speed)
                    rb.velocity -= new Vector2(acceleration * Time.deltaTime, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            walking = false;

            if (rb.velocity.x > 0)
            {
                rb.velocity -= new Vector2(friction, 0) * Time.deltaTime;
            }
            else if (rb.velocity.x < 0)
            {
                rb.velocity += new Vector2(friction, 0) * Time.deltaTime;
            }
            if (isGrounded)
            {
                rb.gravityScale = 0;
                if (!idle.activeSelf)
                {
                    idle.SetActive(true);
                }
                if (run.activeSelf)
                {
                    run.SetActive(false);
                }
            }
            else
            {
                walking = false;
                rb.gravityScale = base_gravityscale;
            }
        }
    }
    #endregion

    ////////////////////// MANAGEMENT \\\\\\\\\\\\\\\\\\\\\\\\

    [SerializeField] GameObject playerCanvas;
    [SerializeField] Animator blinder;
    int layerMask;
    [SerializeField] AudioSource landing;
    bool canPlay;
    #region UI
    void CanvasAllignment()
    {
        playerCanvas.transform.position = transform.position;
    }
    #endregion
    #region Sounds
    int i = 0;
    [SerializeField] AudioSource[] steps = new AudioSource[4];
    bool walking;
    IEnumerator WSounds()
    {
        //Walking
        if (walking)
        {
            steps[i].Play();
            i++;
        }
        if (i > steps.Length - 1) i = 0;
        yield return new WaitForSeconds(0.3f);
        //\Walking
        yield return new WaitForEndOfFrame();
        StartCoroutine(WSounds());
    }
    #endregion
    #region Scenes
    IEnumerator ExitScene()
    {
        blinder.SetBool("BlendIn", true);
        yield return new WaitForSeconds(0.45f);
        LoadNextScene();
    }
    void LoadNextScene()
    {
        SceneManager.LoadNextScene();
    }
    public void NextScene()
    {
        StartCoroutine(ExitScene());
    }
    #endregion

    ////////////////////// COLLISIONS \\\\\\\\\\\\\\\\\\\\\\\\\
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ExitScene")
        {
            NextScene();
        }
    }
}
