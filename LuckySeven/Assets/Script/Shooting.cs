using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;  //발사할 탄환 
    public float waitTerm = 1f;  //발사 주기
    float shootTimer = 0; //시간을 잴 타이머
    bool canShoot = true;

    IEnumerator ShootBullet()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);

            while (shootTimer < waitTerm)
            {
                shootTimer += Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
            shootTimer = 0;
        }
        canShoot = true;
    }

    void Update()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                canShoot = false;
                StartCoroutine(ShootBullet());
            }
        }
    }
}
