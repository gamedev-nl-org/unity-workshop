using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGreen : MonoBehaviour {

    [SerializeField]
    Color enterColor = Color.green;

    [SerializeField]
    Color exitColor = Color.red;

    [SerializeField]
    GameObject coloredWalls;

    Color oldWallColor;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.color = enterColor;
        oldWallColor = coloredWalls.GetComponent<Renderer>().material.color;
        coloredWalls.GetComponent<Renderer>().material.color = enterColor;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().material.color = exitColor;
        coloredWalls.GetComponent<Renderer>().material.color = oldWallColor;
    }
}
