using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDimensions : MonoBehaviour
{
    public static float canvasHeight;
    public static float canvasWidth;
    public static Vector3[] cornerVectors;
    public static Vector2 originPosition;
    public static Vector2 originPositionEnemy;
    public float xOffset;

    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = 5.5f;
        rt = GetComponent<RectTransform>();
        cornerVectors = new Vector3[4];
        rt.GetWorldCorners(cornerVectors);
        DisplayWorldCorners();
        PositionRadius();
    }


    void DisplayWorldCorners()
    {
        canvasHeight = cornerVectors[1].y - cornerVectors[0].y;
        canvasWidth = cornerVectors[2].x - cornerVectors[1].x;
      
    }

    void PositionRadius()
    {
        originPosition = new Vector2(cornerVectors[2].x + xOffset, cornerVectors[3].y + canvasHeight/2);
        originPositionEnemy = new Vector2(cornerVectors[1].x - xOffset, cornerVectors[3].y + canvasHeight/2);
    }


    // Update is called once per frame
    //void Update()
    //{

    //}
}
