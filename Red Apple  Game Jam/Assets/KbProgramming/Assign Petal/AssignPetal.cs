using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPetal : MonoBehaviour
{
    public List<Transform> assignPetalPos;
    public GameObject prefab;

    private void Start()
    {
        InstantiatePrefabs();
    }

    void InstantiatePrefabs()
    {
        foreach (Transform pos in assignPetalPos)
        {
            Instantiate(prefab, pos.position, Quaternion.identity);
        }
    }
}
