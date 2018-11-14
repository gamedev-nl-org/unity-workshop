using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class MergeLevel : MonoBehaviour {

    void Awake()
    {
        LastBakeState = BakeMeshes;
    }

    [SerializeField]
    bool BakeMeshes = false;
    bool LastBakeState = false;

    [HideInInspector]
    [SerializeField]
    private string PrefabName = "";

    void ResetLocalTransform(Transform TransformToReset)
    {
        TransformToReset.localPosition = Vector3.zero;
        TransformToReset.localRotation = Quaternion.identity;
        TransformToReset.localScale = Vector3.one;
    }
	
	// Update is called once per frame
	void Update () {
        if (BakeMeshes != LastBakeState)
        {
            if(BakeMeshes)
            {
                if (PrefabName.Length == 0)
                {
                    PrefabName = System.Guid.NewGuid().ToString();
                    Debug.Log(PrefabName);
                }

                List<MeshFilter> meshFilters = new List<MeshFilter>(GetComponentsInChildren<MeshFilter>());
                meshFilters.Remove(transform.GetComponent<MeshFilter>());
                CombineInstance[] combine = new CombineInstance[meshFilters.Count];

                for (int i = 0; i < meshFilters.Count; i++)
                {
                    MeshFilter meshFilter = meshFilters[i];
                    if (meshFilter.gameObject == gameObject)
                    {
                        continue;
                    }
                    combine[i].mesh = meshFilter.sharedMesh;
                    combine[i].transform = Matrix4x4.TRS(meshFilter.transform.localPosition, meshFilter.transform.localRotation, meshFilter.transform.localScale);
                    combine[i].lightmapScaleOffset = meshFilter.GetComponent<Renderer>().lightmapScaleOffset;
                    combine[i].realtimeLightmapScaleOffset = meshFilter.GetComponent<Renderer>().realtimeLightmapScaleOffset;
                    meshFilters[i].gameObject.SetActive(false);
                }
                transform.GetComponent<MeshFilter>().sharedMesh = new Mesh();
                transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine, true, true, true);
                GetComponent<Renderer>().material = meshFilters[0].GetComponent<Renderer>().sharedMaterial;

                Unwrapping.GenerateSecondaryUVSet(transform.GetComponent<MeshFilter>().sharedMesh);
                transform.gameObject.SetActive(true);

                Transform MainTransform = gameObject.transform;
                if(MainTransform.childCount > 0)
                {
                    GameObject NewGameObject = new GameObject("BakedMesh");

                    List<Transform> ChildTransforms = new List<Transform>();
                    for(int i = 0; i < MainTransform.childCount; i++)
                    {
                        ChildTransforms.Add(MainTransform.GetChild(i));
                    }

                    NewGameObject.transform.SetParent(transform);
                    ResetLocalTransform(NewGameObject.transform);

                    foreach (Transform ChildTransform in ChildTransforms)
                    {
                        ChildTransform.gameObject.SetActive(true);
                        ChildTransform.SetParent(NewGameObject.transform);
                    }

                    Object Prefab = PrefabUtility.CreatePrefab("Assets/" + PrefabName + ".prefab", NewGameObject);
                    PrefabUtility.ReplacePrefab(NewGameObject, Prefab, ReplacePrefabOptions.ConnectToPrefab);
                    DestroyImmediate(NewGameObject);
                }
            }
            else
            {
                GameObject AssetAtPath = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/" + PrefabName + ".prefab");
                GameObject NewPrefab = Instantiate(AssetAtPath);
                NewPrefab.transform.SetParent(transform);
                ResetLocalTransform(NewPrefab.transform);
                while (NewPrefab.transform.childCount > 0)
                {
                    Transform ChildTransform = NewPrefab.transform.GetChild(0);
                    ChildTransform.SetParent(transform);
                }
                DestroyImmediate(NewPrefab);
                transform.GetComponent<MeshFilter>().mesh = null;
            }
        }
        LastBakeState = BakeMeshes;
    }
}
