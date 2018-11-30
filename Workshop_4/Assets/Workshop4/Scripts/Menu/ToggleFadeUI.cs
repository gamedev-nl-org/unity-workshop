using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleFadeUI : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float initialAlpha;
    private bool isFaded = false;
    [SerializeField] private float fadeAlpha;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleAlpha()
    {
        if (isFaded)
            canvasGroup.alpha = initialAlpha;
        else
        {
            initialAlpha = canvasGroup.alpha;
            canvasGroup.alpha = fadeAlpha;
        }
        isFaded = !isFaded;
    }
}
