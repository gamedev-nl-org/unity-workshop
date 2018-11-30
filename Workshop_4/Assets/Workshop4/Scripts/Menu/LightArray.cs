using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class LightArray : MonoBehaviour
{
    [SerializeField] private Light templateLight;
    [Range(0, 1000), SerializeField] private int lightsCount;
    [Range(0f, 100f), SerializeField] private float spawnRadius;
    [Range(0f, 100f), SerializeField] private float blinkRate;
    [Range(0f, 2f), SerializeField] private float blinkVarianceMin, blinkVarianceMax;
    [Range(0f, 2f), SerializeField] private float lightRangeMax;

    private List<Light> lights;
    private Coroutine blinkCoroutine;
    private Light currentLight;

    private static T GetRandom<T>(List<T> elements)
    {
        int index = Random.Range(0, elements.Count);
        return elements[index];
    }

    private void Awake()
    {
        lights = new List<Light>(lightsCount);
        for (int i = 0; i < lightsCount; i++)
        {
            Light l = Instantiate(templateLight, this.transform);
            l.transform.position = Random.insideUnitSphere * spawnRadius;
            lights.Add(l);
            l.gameObject.SetActive(false);
            l.color = Random.ColorHSV();
        }
    }

    public void ToggleBlinking()
    {
        if (blinkCoroutine == null)
            blinkCoroutine = StartCoroutine(Blink());
        else
        {
            StopAllCoroutines();
            currentLight.gameObject.SetActive(false);
            currentLight = null;
            blinkCoroutine = null;
        }
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            currentLight = GetRandom(lights);
            currentLight.gameObject.SetActive(true);
            currentLight.range = 0f;
            yield return StartCoroutine(FadeLight(currentLight, 0f, lightRangeMax * Random.Range(blinkVarianceMin, blinkVarianceMax)));
            yield return StartCoroutine(FadeLight(currentLight, currentLight.range, 0f));
            currentLight.gameObject.SetActive(false);
        }
    }

    private IEnumerator FadeLight(Light light, float initial, float target)
    {
        float t = 0f;
        while (light.range != target)
        {
            yield return null;
            t += Time.deltaTime;
            light.range = Mathf.Lerp(initial, target, t * blinkRate);
        }
    }
}
