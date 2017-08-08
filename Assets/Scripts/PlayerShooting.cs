using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    float projectileSpeed = 10f;
    float fireRate = 0.1f;
    float recoil = 10f;
    private Rigidbody2D Rigid;
    private float shootTimer = 0f;
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && shootTimer >= fireRate)
        {
            Shooting();
            shootTimer = 0f;
        }
    }
    void Shooting()
    {
        GameObject projectile = Instantiate(bulletPrefab);
        projectile.transform.position = transform.position;
        Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.up * projectileSpeed, ForceMode2D.Impulse);
    }
}


