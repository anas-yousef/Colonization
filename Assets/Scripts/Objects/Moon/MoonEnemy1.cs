using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonEnemy1 : MonoBehaviour
{
    public float speed;
    public float timeCounter;
    public float radius;
    private float initX;
    private float initY;
    public int layer;


    // Start is called before the first frame update
    void Start()
    {
        layer = 1;
        this.initX = CanvasDimensions.originPositionEnemy.x;
        this.initY = CanvasDimensions.originPositionEnemy.y;
        CalculateRadius();
        speed = 8f;
        this.timeCounter = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        this.timeCounter += Time.deltaTime * speed;
        float x = this.initX + Mathf.Cos(Mathf.Deg2Rad*(-this.timeCounter + 45)) * radius;
        float y = this.initY + Mathf.Sin(Mathf.Deg2Rad*(-this.timeCounter + 45)) * radius;
        transform.position = new Vector3(x, y, 0);

        if (y + 1 < CanvasDimensions.cornerVectors[0].y)
        {
            Destroy(gameObject);
        }

    }

    void CalculateRadius()
    {
        float x = CanvasDimensions.cornerVectors[1].x + CanvasDimensions.canvasWidth / 50.5f;
        float y = CanvasDimensions.cornerVectors[1].y;
        radius = Mathf.Sqrt(Mathf.Pow(this.initX - x, 2f) + Mathf.Pow(this.initY - y, 2f));
    }

}
