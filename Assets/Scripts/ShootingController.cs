﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootingPoint;
    public GameObject bulletCasing;
    public float bulletSpeed;
    public LayerMask lm;
    public float YOffset = .5f;
    public GameObject player;
    public int ammo = 6, clipSize=6;
    public Camera cam;

    void Start()
    {
        lm = ~lm;
    }

    public void Reload() {
        ammo = clipSize;
    }

    void Update()
    {           
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 pos = hit.point;
            pos.y = transform.position.y;
            transform.LookAt(pos);            
            if (Input.GetMouseButtonDown(0) && ammo > 0)
            {
                Shoot(hit.point);   
                ammo--;
            }            
        }
        else
            transform.rotation = transform.rotation;

        if (Input.GetKeyDown(KeyCode.R))
            Reload();
    }

    void Shoot(Vector3 pos)
    {
        pos.y += YOffset;
        GameObject Bullet = Instantiate(bullet, shootingPoint.transform.position, transform.rotation);
        Bullet.name = "Bullet";
        Bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * transform.forward;
        GameObject BulletCasing = Instantiate(bulletCasing, shootingPoint.transform.position, Random.rotation);
        BulletCasing.GetComponent<Rigidbody>().velocity = transform.TransformPoint(new Vector3(1, 1, 0)) * Time.deltaTime * bulletSpeed/3; 
        GameManager.instance.CameraShake(0.05f);
    }
}
