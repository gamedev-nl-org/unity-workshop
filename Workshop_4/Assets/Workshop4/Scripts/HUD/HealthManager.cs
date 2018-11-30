using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [Serializable]
    public class HealthChangedEvent : UnityEvent<HealthManager> { }

    public HealthChangedEvent HealthChanged;

    [SerializeField] private float max, startingValue;

    public float Max
    {
        get { return max; }
        private set { max = value; }
    }

    private float current;
    public float Current
    {
        get { return current; }
        private set { current = value; }
    }

    private void Awake()
    {
        Current = startingValue;
    }

    public void ModifyStat(float healthDelta)
    {
        Current = Mathf.Clamp(Current + healthDelta, 0f, Max);
        HealthChanged.Invoke(this);
    }

    public float GetFraction()
    {
        return Current / Max;
    }
}
