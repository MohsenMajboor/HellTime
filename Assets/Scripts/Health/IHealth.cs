using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float GetInitialHealth();
    public float GetCurrentHealth();
    public void SetCurrentHealth(float newHealth);
    public delegate void HealthZeroEventHandler();
}
