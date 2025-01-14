using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform[] gunPoint;
    [SerializeField] float enemySpawnTime = 0.5f;
    [SerializeField] GameObject enemyflash;
    [SerializeField] GameObject enemyExplosionPrefab;
    [SerializeField] float health = 10f;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject damageEffect;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bulletSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip explosionSound;
        
    private float barsize = 1f;
    private float damage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyflash.SetActive(false);
        StartCoroutine(EnemyShoot());
        damage = barsize/health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Playerbullet")

        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVfx = Instantiate(damageEffect,collision.transform.position,Quaternion.identity);
            Destroy(damageVfx, 0.05f);

            if(health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Instantiate(coinPrefab,transform.position,Quaternion.identity);
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.4f);
            }
           
        }


    }
    void DamageHealthBar()
    {
        if(health> 0)
        {
            health = health - 1;
            barsize = barsize - damage;
            healthBar.SetSize(barsize);
        }
    }

    void EnemyFire()
    {
        for(int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);

        }
        //Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);
    }

    IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            enemyflash.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            enemyflash.SetActive(false);
        }
    }

}
