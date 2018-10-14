using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MergeLevel : MonoBehaviour {

    void Awake()
    {
        Debug.Log("Awake");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
    }

    [SerializeField]
    bool once = true;
	
	// Update is called once per frame
	void Update () {

        //if (once)
        //{
        //    CombineInstance[] combine = new CombineInstance[transform.childCount];
        //    for (int i = 1; i < transform.childCount; i++)
        //    {
        //        Transform childTransform = transform.GetChild(i);
        //        combine[i].mesh = childTransform.gameObject.GetComponent<MeshFilter>().sharedMesh;
        //        combine[i].transform = childTransform.localToWorldMatrix;
        //        childTransform.gameObject.SetActive(false);
        //    }

        //    MeshFilter meshFilter = transform.GetChild(0).GetComponent<MeshFilter>();
        //    meshFilter.mesh.CombineMeshes(combine);
        //    transform.gameObject.SetActive(true);
        //}
        //once = false;
    }
}
