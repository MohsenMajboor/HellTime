using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    [SerializeField] BenelliWeapon _currentWeapon = null;
    [SerializeField] float shootInterval = 0.5f;


    float nextShootTime;

    private void Start() {
        nextShootTime = Time.time + shootInterval;
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextShootTime)
        {
            UseWeapon();
            nextShootTime = Time.time + shootInterval;
        }
    }

    private void UseWeapon()
    {
        _currentWeapon.Use();
    }
}
