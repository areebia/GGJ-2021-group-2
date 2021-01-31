using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health;

    void Start()
    {
        health = 1f;
    }
    void Update()
    {
        if (health < 1) {
            Destroy(gameObject);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "drop" && health < 2)
        {
            health += .1f;

            transform.localScale = new Vector2(transform.localScale.x + .1f, transform.localScale.y + .1f);

            collision.gameObject.GetComponent<ParticleSystem>().Play();

            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            Destroy(collision.gameObject,.5f);
        }
    }
}
