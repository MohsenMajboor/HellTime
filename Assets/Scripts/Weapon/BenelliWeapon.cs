using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BenelliWeapon : Weapon
{
       //parameters
    [SerializeField] int _initialAmmo;
    [SerializeField] GameObject _muzzleFlashEffect;
    [SerializeField] GameObject _objectHitEffect;
    [SerializeField] Transform _muzzleFlashEffectPosition;
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] int _ammoUsePerShot;
    [SerializeField] AudioClip shootAudio;

    //cache
    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public float GetAmmo()
    {
        throw new System.NotImplementedException();
    }

    ////state
    //int _currentAmmo;
    //float _ammoFontSize;

    ////cache
    //float _initialAmmoStored;

    //private void Awake() 
    //{
    //    _initialAmmoStored = _initialAmmo;
    //    _currentAmmo = _initialAmmo;
    //}

    //private void Start()
    //{
    //    UpdateAmmoText();
    //    _ammoFontSize = _ammoText.fontSize;
    //}

    //private void UpdateAmmoText()
    //{
    //    if(_currentAmmo == 1)
    //    {
    //        _ammoText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    //        _ammoText.fontSize = _ammoFontSize * 4;
    //        _ammoText.color = Color.red;
    //        _ammoText.text = "ONE AMMO LEFT";
    //    }
    //    else
    //    {
    //        _ammoText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    //        _ammoText.fontSize = _ammoFontSize;
    //        _ammoText.text = "Ammo:" + _currentAmmo.ToString();
    //        _ammoText.color = Color.white;
    //    }
    //}

    //public float GetAmmo()
    //{
    //    return _currentAmmo;
    //}

    //public void DecreaseAmmo(int amount)
    //{
    //    if (_currentAmmo - amount >= 0)
    //    {
    //        _currentAmmo -= amount;
    //    }
    //    else if (_currentAmmo - amount < 0)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        _currentAmmo = 0;
    //    }

    //    UpdateAmmoText();
    //}

    //private void Update()
    //{
    //    if(_currentAmmo <= 0)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }
    //}

    //public void IncreaseAmmo(int amount)
    //{
    //    _currentAmmo += amount;
    //    UpdateAmmoText();
    //}

    public void Use()
    {
        //if(GetAmmo() > 0f)
        {
            RaycastHit hit;
            bool raycastHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);

            if(raycastHit)
            {
                Instantiate(_objectHitEffect, hit.point, Quaternion.LookRotation(-hit.normal));

                if(hit.transform.gameObject.tag == "Enemy")
                {
                    var enemyHealth = hit.transform.GetComponent<IHealth>();
                    enemyHealth.SetCurrentHealth(enemyHealth.GetCurrentHealth() - enemyHealth.GetInitialHealth()/2);
                }
            }

            Instantiate(_muzzleFlashEffect, _muzzleFlashEffectPosition.position, Quaternion.LookRotation(transform.forward));

            audioSource.PlayOneShot(shootAudio);
            //DecreaseAmmo(_ammoUsePerShot);
        }
    }
}
