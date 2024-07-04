using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ddol;

    private void Start()
    { foreach (var ddoll in ddol)
        {
            DontDestroyOnLoad(ddoll.transform);
        } 
    }
}
