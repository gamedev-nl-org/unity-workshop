using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform cachedTransform;
    [SerializeField] private float rotationSpeed;

    [Header("Effects")]
    [SerializeField]
    private float healthDelta;

    public float HealthDelta { get { return healthDelta; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cachedTransform = transform;
        cachedTransform.Rotate(0f, 0f, Random.value * 360f); // random number of degrees
    }

    private void Update()
    {
        cachedTransform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupActor actor = collision.GetComponent<PickupActor>();
        if (actor != null)
        {
            actor.PickUp(this);
        }
    }

    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }

    public Color GetColor()
    {
        return spriteRenderer.color;
    }
}
