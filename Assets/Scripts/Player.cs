using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float padding = 0.8f;
    [SerializeField] GameObject explosion;
    [SerializeField] float health = 10f;
    [SerializeField] PlayerHealthBar playerHealthBar;
    [SerializeField] GameObject damageEffect;
    [SerializeField] CoinCount coinCount;
    [SerializeField] GameController gameController;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip coinSound;
    private float barfillAmount =1f;
    private float damage = 0f;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
        damage = barfillAmount / health;
    }

    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1,0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }


    // Update is called once per frame
    void Update()
    {
       // float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float newXpos =Mathf.Clamp( transform.position.x ,minX,maxX);
        float newYpos = Mathf.Clamp( transform.position.y ,minY,maxY);
        transform.position = new Vector2(newXpos,newYpos);

        if (Input.GetMouseButton(0)) 

          {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position, newPos, speed*Time.deltaTime);
          }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            damagePlayerHealth();
            Destroy(collision.gameObject);
            GameObject damageVfx = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVfx, 0.05f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                gameController.GameOver();
                Destroy(gameObject);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, 1f);
            Destroy(collision.gameObject);
            coinCount.AddCount();
        }
    }

    void damagePlayerHealth()
    {
        if (health > 0)
        {
            health -= 1;
            barfillAmount = barfillAmount - damage;
            playerHealthBar.SetAmount(barfillAmount);
        }

    }
}
