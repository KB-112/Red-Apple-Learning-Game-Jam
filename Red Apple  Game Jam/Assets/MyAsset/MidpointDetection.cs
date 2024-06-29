using UnityEngine;
using TMPro;
using System.Net;

public class MidpointDetection : MonoBehaviour
{
    Camera cam;
    public static MidpointDetection instance; 
    private void Awake()
    {
        cam = GetComponent<Camera>();
        if(instance == null)
        {
            instance= this;
        }
    }
   
  

   public Vector2 RoundOffMidpoint()
    {
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 midpoint = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        
            float roundedX = Mathf.Floor(midpoint.x) + 0.5f;
            float roundedY = Mathf.Floor(midpoint.y) + 0.5f;
          
            midpoint.x = roundedX;
            midpoint.y = roundedY;
        
       // Debug.Log("Rounded : " + midpoint);
        return midpoint;
       
    }

}

//Test Position
//public TextMeshProUGUI midpointText;
//public GameObject mouseObj;
//mouseObj.transform.position = mouseWorldPos;
//midpointText.text = "(X:" + mouseWorldPosInt.x + "," + "Y:" + mouseWorldPosInt.y + ")";

