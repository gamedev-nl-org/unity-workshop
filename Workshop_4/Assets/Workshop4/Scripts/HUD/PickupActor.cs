using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupActor : MonoBehaviour
{
    [Serializable] public class PickupEvent : UnityEvent<Pickup> { }
    public PickupEvent OnPickedUp;

    [SerializeField] private HealthManager health;

    public void PickUp(Pickup pickup)
    {
        // do stuff
        pickup.gameObject.SetActive(false);
        if (health != null) health.ModifyStat(pickup.HealthDelta);
        OnPickedUp.Invoke(pickup);
    }
}
