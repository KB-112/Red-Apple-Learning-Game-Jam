using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineGen : MonoBehaviour
{
    public List<GameObject> lineObjects = new List<GameObject>();
    public GameObject linePrefab;
    public List<Vector2> linepos = new List<Vector2>();

    void Update()
    {
        UpdateLineMechanic();
        ClearLine();
    }

    void UpdateLineMechanic()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 lastPoint = linepos.LastOrDefault(); // Get the last recorded point
            Vector2 currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get the current mouse position

            if (lastPoint != currentPoint)
            {
                List<Vector2> interpolatedPoints = InterpolatePoints(lastPoint, currentPoint);

                foreach (Vector2 point in interpolatedPoints)
                {
                    GameObject obj = Instantiate(linePrefab, point, Quaternion.identity);
                    linepos.Add(point);
                    lineObjects.Add(obj);
                }
            }
        }
    }

    List<Vector2> InterpolatePoints(Vector2 start, Vector2 end)
    {
        List<Vector2> interpolatedPoints = new List<Vector2>();
        float distance = Vector2.Distance(start, end);
        float segments = Mathf.Max(distance / 0.5f, 1); 

       
        for (float i = 0.5f; i < segments; i++)
        {
            float t = i / segments;
            Vector2 point = Vector2.Lerp(start, end, t);
            interpolatedPoints.Add(point);
        }
        return interpolatedPoints;
    }

    void ClearLine()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject obj in lineObjects)
            {
                Destroy(obj);
            }
            lineObjects.Clear();
            linepos.Clear();
        }
    }
}

//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;


//public class LineGen : MonoBehaviour
//{
//    public List<GameObject> lineObjects = new List<GameObject>();
//    public GameObject linePrefab;
//    public List<Vector2> linepos = new List<Vector2>();
//    void Update()
//    {
//        UpdateLineMechanic();
//        ClearLine();

//    }

//    void UpdateLineMechanic()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            Vector2 roundedMidpoint = MidpointDetection.instance.RoundOffMidpoint();
//            // Debug.Log("Button clicked");

//            if (!linepos.Contains(roundedMidpoint))
//            {
//                if (linepos.Count > 0)
//                {
//                    Vector2 lastPoint = linepos.Last();
//                    List<Vector2> interpolatedPoints = InterpolatePoints(linepos.First(), lastPoint);
//                    foreach (Vector2 point in interpolatedPoints)
//                    {
//                        GameObject obj = Instantiate(linePrefab, point, Quaternion.identity);
//                        linepos.Add(point);
//                        lineObjects.Add(obj);
//                    }
//                }
//                else
//                {
//                    GameObject obj = Instantiate(linePrefab, roundedMidpoint, Quaternion.identity);
//                    linepos.Add(roundedMidpoint);
//                    lineObjects.Add(obj);
//                }
//            }
//            else
//            {
//                //Debug.LogWarning("Duplicate created");
//            }
//        }
//    }

//    List<Vector2> InterpolatePoints(Vector2 start, Vector2 end)
//    {
//        List<Vector2> interpolatedPoints = new List<Vector2>();
//        float distance = Vector2.Distance(start, end);
//        Debug.Log("distance :" + distance);
//        float segments = distance / 0.5f;
//        for (float i = 0.5f; i <= segments; i++)
//        {
//            float t = i / segments;
//            Vector2 point = Vector2.Lerp(start, end, t);
//            interpolatedPoints.Add(point);
//        }
//        return interpolatedPoints;
//    }


//    void ClearLine()
//    {
//        if (Input.GetMouseButtonUp(0))
//        {

//            for (int i = 0; i < lineObjects.Count; i++)
//            {
//                if (lineObjects != null)
//                {
//                    Destroy(lineObjects[i]);
//                }
//            }
//            lineObjects.Clear();
//            linepos.Clear();
//        }
//    }


//}
