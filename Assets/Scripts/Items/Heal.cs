using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public GameObject ShinePrefab;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
        rig.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.OnHeal();

            GameObject shine = Instantiate(ShinePrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(shine, 1f);
        }
    }
}
