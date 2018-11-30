using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUIManager : MonoBehaviour
{
    [SerializeField] private PickupUI template;

    public void Display(Pickup pickup)
    {
        PickupUI pickupUI = Instantiate(template, this.transform);
        pickupUI.gameObject.SetActive(true);
        pickupUI.Display(pickup);
    }
}
