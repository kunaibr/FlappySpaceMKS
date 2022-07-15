using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    IDLE,
    FLYING,
    DEAD,
}

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    Animator anim;
    PlayerState state;

    [Header("Variables")]
    public float force;

    void Start()
    {
        state = PlayerState.IDLE;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case PlayerState.IDLE:
                anim.SetBool("fly", true);

                break;
            case PlayerState.FLYING:
                rb2d.gravityScale = 2;
                 
                if (Input.anyKeyDown)
                    Fly();
                else
                    anim.SetBool("fly", false);

                break;
            case PlayerState.DEAD:
                break;
        }
      
    }

    void Fly()
    {
        rb2d.velocity *= 0;
        rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        anim.SetBool("fly", true);
       
    }

    public void SetPlayerState()
    {
        state = PlayerState.FLYING;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            state = PlayerState.DEAD;
            GameManager.instance.GameOver();
        }
    }
}
