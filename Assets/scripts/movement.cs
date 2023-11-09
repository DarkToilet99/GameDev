using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D player;
    public Collider2D collider;
    public Animator animator;

    float jumpHeight = 10f;
    float bounce = 4f;
    bool isJumping, isDead;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            player.velocity = Vector2.up * jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "floor")
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.transform.GetChild(1).gameObject.GetComponent<Collider2D>().IsTouching(collider))
            {
                Physics2D.IgnoreCollision(collision.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(collision.gameObject.transform.GetChild(1).GetComponent<Collider2D>(), collider);
                animator.SetBool("isDead", true);
                isJumping = false;
            }

            if (collision.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().IsTouching(collider))
            {
                player.velocity = Vector2.up * bounce;
                Physics2D.IgnoreCollision(collision.gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>(), collider);
                Physics2D.IgnoreCollision(collision.gameObject.transform.GetChild(1).gameObject.GetComponent<Collider2D>(), collider);
            }
        }
    }
}
