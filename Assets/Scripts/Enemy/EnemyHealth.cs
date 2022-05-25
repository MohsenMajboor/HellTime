using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

        [SerializeField] AudioClip enemyHurtSound;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    //parameters
    [SerializeField] private float _initialHealth;

    //state
    private float _currentHealth;

    //cache
    private float _storedInitialHealth;


    //events
    public delegate void HealthZeroEventHandler();
    public event HealthZeroEventHandler OnHealthZero;

    private void Awake() 
    {
        _storedInitialHealth = _initialHealth;
        _currentHealth = _initialHealth;    
    }

    public float GetInitialHealth()
    {
        return _initialHealth;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void SetCurrentHealth(float newHealth)
    {
        _currentHealth = newHealth;

        audioSource.PlayOneShot(enemyHurtSound);

        if(_currentHealth <= 0f && OnHealthZero != null)    
        {
            OnHealthZero();
        }
    }
}
    

