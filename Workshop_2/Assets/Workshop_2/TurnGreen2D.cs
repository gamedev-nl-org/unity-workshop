using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGreen2D : MonoBehaviour {
    [SerializeField]
    Color enterColor = Color.green;

    [SerializeField]
    Color exitColor = Color.red;

    [SerializeField]
    GameObject coloredWalls;

    Color oldWallColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Renderer>().material.color = enterColor;
        oldWallColor = coloredWalls.GetComponent<Renderer>().material.color;
        coloredWalls.GetComponent<Renderer>().material.color = enterColor;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Renderer>().material.color = exitColor;
        coloredWalls.GetComponent<Renderer>().material.color = oldWallColor;
    }
}
