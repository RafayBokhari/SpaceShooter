using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;
    [SerializeField] float bulletSpawnTime = 0.5f;
    [SerializeField] GameObject flash;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

 
    // Update is called once per frame
    void Update()
    {
                    
    }

    void Fire()
    {
        {
            Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
            Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            flash.SetActive (true);
            yield return new WaitForSeconds(0.05f);
            flash.SetActive (false);
        }
    }

}
