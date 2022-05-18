using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;

    private Rigidbody2D rig;
    public Animator anim;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject impulsePrefab;

    public float speed;
    public float maxSpeed;
    public float speedUp;
    public float timeToSpeedUp;
    private float speedUpCooldown;
    private bool isMaxSpeed;

    public float jumpForce;
    private bool isJumping;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    void Update()
    {
        if (speed >= maxSpeed && !isMaxSpeed)
        {
            GameController.instance.ShowMaxSpeedAlert();
            isMaxSpeed = true;
        }

        if (speed < maxSpeed)
        {
            OnSpeedUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            OnJump();
        }
    }

    public void OnSpeedUp()
    {
        speedUpCooldown += Time.deltaTime;

        if (speedUpCooldown >= timeToSpeedUp)
        {
            speed += speedUp;
            speedUpCooldown = 0f;
            jumpForce -= speedUp;
        }
    }

    public void OnShoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Audio.current.Play();
    }

    public void OnJump()
    {
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        anim.SetBool("jumping", true);
        isJumping = true;

        GameObject explosion = Instantiate(impulsePrefab, transform.position, transform.rotation);
        Destroy(explosion, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 && isJumping)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }

    public void OnHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameController.instance.ShowGameOver();
        }

        GameController.instance.UpdateLifeBar(health);

    }

    public void OnHeal()
    {
        if (health < 10)
        {
            health += 1;
        }
    }
}
