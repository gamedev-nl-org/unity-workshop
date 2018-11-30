using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform bar;
    [SerializeField] private float widthMax;

    public void SetValue(HealthManager healthManager)
    {
        bar.sizeDelta = new Vector2(healthManager.GetFraction() * widthMax, bar.sizeDelta.y);
    }
}
