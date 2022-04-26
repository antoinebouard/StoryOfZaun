using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    public GameObject[] hearts;
    private int life;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        life = hearts.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision) {
        const int damage = 1;
        if (collision.gameObject.CompareTag("Trap")) {
            if (life >= 1) {
                if (life > 1) {
                    anim.SetTrigger("hurt");
                    yield return new WaitForSeconds(0.3f);
                    spriteRenderer.color = Color.clear;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.color = Color.white;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.color = Color.clear;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.color = Color.white;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.color = Color.clear;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.color = Color.white;
                }
                life -= damage;
                Destroy(hearts[life].gameObject);
            }
            if (life < 1) {
                Die();
            }
        }
    }

    private void Die() {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
