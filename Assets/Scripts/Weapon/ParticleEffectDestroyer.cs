using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectDestroyer : MonoBehaviour
{
    //parameters
    [SerializeField] private float _timeTillDestroy = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,_timeTillDestroy);
    }
}
