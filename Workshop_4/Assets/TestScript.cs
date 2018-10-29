using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testing123", menuName = "Inventory/List", order = 1)]
public class TestScript : ScriptableObject {

    [SerializeField]
    public Color enterColor = Color.blue;

    [SerializeField]
    public Color exitColor = Color.red;
}
