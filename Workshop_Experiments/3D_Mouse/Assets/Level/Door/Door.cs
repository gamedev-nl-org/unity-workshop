using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField]
    private GameObject door;

    bool enteredArea = false;

    float currentRotation;

    private void OnTriggerEnter(Collider other)
    {
        enteredArea = true;
        door.GetComponent<Collider>().enabled = false;
    }

    private void Start()
    {
        currentRotation = door.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update () {
		if(enteredArea)
        {
            if(currentRotation < 359)
            {
                currentRotation = currentRotation + 100.0f * Time.deltaTime;
                if(currentRotation > 359)
                {
                    currentRotation = 359;
                }
                door.transform.localEulerAngles = new Vector3(door.transform.localEulerAngles.x, currentRotation, door.transform.localEulerAngles.z);
            }
        }
	}
}
