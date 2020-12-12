using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class AsteroidsScript : MonoBehaviour
{
    private GameObject[] asteroids;
    private float asteroidsNum; // Number of asteroids on screen in each layer.
    private float asteroidsDistance;
    private float layersNum;
    private float layersWidth;
    private float layersDistance;
    private float[] asteroidsLinearSpeed;
    private float[,] asteroidAngularSpeed;
    private float initialYpos;
    private float scale;
    private Sprite asteroidSprite0;
    private Sprite asteroidSprite1;
    private Sprite asteroidSprite2;
    private Sprite[] asteroidsSprites;

    // Start is called before the first frame update
    void Start()
    {
        //asteroidsNum = 4;
        //asteroidsDistance = CanvasDimensions.canvasHeight / asteroidsNum;
        //layersNum = 3;
        //layersWidth = 0.125f * CanvasDimensions.canvasWidth;
        //layersDistance = layersWidth / (layersNum - 1);
        //asteroidsLinearSpeed = new float[3];
        //asteroidAngularSpeed = new float[(int)layersNum, (int)(asteroidsNum + 1)];
        //initialYpos = -(asteroidsDistance + CanvasDimensions.canvasHeight) / 2;
        //scale = 0.15f;
        //asteroidSprite0 = Resources.Load("_steroid1", typeof(Sprite)) as Sprite;
        //asteroidSprite1 = Resources.Load("_steroid2", typeof(Sprite)) as Sprite;
        //asteroidSprite2 = Resources.Load("_steroid3", typeof(Sprite)) as Sprite;
        //asteroidsSprites = new Sprite[] { asteroidSprite0, asteroidSprite1, asteroidSprite2 };

        //// Creating a pool of asteroids.
        //for (int xp = 0; xp < layersNum; ++xp)
        //{
        //    float xPos = -layersWidth / 2 + xp * layersDistance;
        //    asteroidsLinearSpeed[xp] = Mathf.Pow(-1, xp) * 2f / (Mathf.Abs(xPos) + 1);
        //    for (int a = 0; a < asteroidsNum + 1; ++a)
        //    {
        //        // Instantiating.
        //        GameObject asteroidObj = Instantiate(Resources.Load("Asteroid")) as GameObject;
        //        asteroidObj.GetComponent<SpriteRenderer>().sprite = asteroidsSprites[(xp + a) % 3];
        //        // Positioning.
        //        float yPos = initialYpos + a * asteroidsDistance;
        //        asteroidObj.transform.position = new Vector3(xPos, yPos, 0f);
        //        // Scaling.
        //        asteroidObj.transform.localScale = new Vector3(scale, scale, 1);
        //        asteroidAngularSpeed[xp, a] = Mathf.Pow(-1, a) * Random.Range(25f, 40f);
        //    }
        //}
        //asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the asteroids position.
        //for (int i = 0; i < asteroids.Length; ++i)
        //{
        //    GameObject ast = asteroids[i];

        //    int curLayer = (int)Mathf.Floor(i / (int)(asteroidsNum + 1));
        //    int curAsteroidIdx = i % (int)(asteroidsNum + 1);
        //    float curAsteroidSpeed = asteroidsLinearSpeed[curLayer];
        //    float directionUp = curAsteroidSpeed / Mathf.Abs(curAsteroidSpeed);

        //    // Posiotion.
        //    float x = ast.transform.position.x;
        //    float y = ast.transform.position.y;
        //    float z = ast.transform.position.z;
        //    // Rotation.
        //    float xr = ast.transform.localEulerAngles.x;
        //    float yr = ast.transform.localEulerAngles.y;
        //    float zr = ast.transform.localEulerAngles.z;
        //    if (Mathf.Abs(y) > -initialYpos) // If the asteroid left the screen it is reposisioned at the opposite side.
        //    {
        //        y = directionUp * initialYpos;
        //    }
        //    else
        //    {
        //        y += curAsteroidSpeed * Time.deltaTime;
        //        zr += asteroidAngularSpeed[curLayer, curAsteroidIdx] * Time.deltaTime;
        //    }
        //    ast.transform.position = new Vector3(x, y, z);
        //    ast.transform.localEulerAngles = new Vector3(xr, yr, zr);
        //}

        //if (Input.GetKeyDown("backspace"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //}
    }
}
