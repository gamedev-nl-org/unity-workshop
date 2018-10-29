using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGreen : MonoBehaviour {

    [SerializeField]
    TestScript testScript;

    [SerializeField]
    GameObject coloredWalls;

    Color oldWallColor;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.color = testScript.enterColor;
        oldWallColor = coloredWalls.GetComponent<Renderer>().material.color;
        coloredWalls.GetComponent<Renderer>().material.color = testScript.enterColor;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().material.color = testScript.exitColor;
        coloredWalls.GetComponent<Renderer>().material.color = oldWallColor;
    }
}
