using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Variables")]

    public float speed = 1;

    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddPoint();
        }
    }
}
