using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    

    public BoxCollider2D box;
    [SerializeField]public GameObject obj;

  
    public int length;
    public int count;
    private void Start()
    {

        ShowPattern();
    }


    void ShowPattern()
    {

      
        for (int j = 0; j < length; j++)
        {
            if (j >= count)
            {
                length = length -1;
            }
            for (int i = 0; i < length; i++)
            {
                Vector2 pos = new Vector2(j, i);
                Instantiate(obj, pos, Quaternion.identity);
                Debug.Log(pos);
            }
        }
       

    }
}

