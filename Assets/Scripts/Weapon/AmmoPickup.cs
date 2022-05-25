using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //parameters
    [SerializeField] private int _ammoAmount;

    public int GetAmmo()
    {
        return _ammoAmount;
    }

    public void DestroyPickup()
    {
        Destroy(gameObject);
    }
}

