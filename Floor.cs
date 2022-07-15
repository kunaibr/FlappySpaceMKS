using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    [Header("Variables")]

    public float speed = 1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        spriteRenderer.size += new Vector2(speed * Time.deltaTime,0);
    }
}
