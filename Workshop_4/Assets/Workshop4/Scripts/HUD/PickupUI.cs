using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float lifetime = 5f;

    public void Display(Pickup pickup)
    {
        image.sprite = pickup.GetSprite();
        image.color = pickup.GetColor();
        StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
