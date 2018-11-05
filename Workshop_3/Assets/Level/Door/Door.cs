using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField]
    private GameObject door;

    [SerializeField]
    bool isDoorOpened = false;

    bool enteredArea = false;

    float currentRotation;

    float startingRotation;

    private void OnTriggerEnter(Collider other)
    {
        enteredArea = true;
    }

    private void Start()
    {
        startingRotation = door.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update () {
		if(enteredArea)
        {
            GetComponent<BoxCollider>().enabled = false;

            if(currentRotation < 180)
            {
                currentRotation = startingRotation + 100.0 * Time.deltaTime;
                if(currentRotation > 180)
                {
                    currentRotation = 180;
                }
                door.transform.eulerAngles = new Vector3(door.transform.eulerAngles.x, doorRotation, door.transform.eulerAngles.z);
            }

        }
	}
}
