using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //parameters
    [SerializeField] private float _health;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void Start()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        _healthText.text = "HP:" + _health.ToString();
    }

    public void IncreaseHealth()
    {
        _health++;
        _healthText.text = "HP:" + _health.ToString();
    }

    public void DecreaseHealth(float damageAmount)
    {
        _health -= damageAmount;

        if(_health >=0)
        {
            _healthText.text = "HP:" + _health.ToString();
        }

        if (_health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

