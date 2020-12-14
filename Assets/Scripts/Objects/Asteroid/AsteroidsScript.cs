using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Sprite astSprt0;
    private Sprite astSprt1;
    private Sprite astSprt2;
    private Sprite astSprt3;
    private Sprite astSprt4;
    private Sprite astSprt5;
    private Sprite astSprt6;
    private Sprite astSprt7;
    private Sprite astSprt8;
    private Sprite astSprt9;
    private Sprite astSprt10;
    private Sprite astSprt11;
    private Sprite astSprt12;
    private Sprite astSprt13;
    private Sprite astSprt14;
    private Sprite astSprt15;
    private Sprite astSprt16;
    private Sprite astSprt17;
    private Sprite astSprt18;
    private Sprite astSprt19;
    private Sprite astSprt20;
    private Sprite astSprt21;
    private Sprite astSprt22;
    private Sprite astSprt23;
    private Sprite astSprt24;
    private Sprite[] asteroidsSprites;

    // Start is called before the first frame update
    void Start()
    {
        asteroidsNum = 4f;
        asteroidsDistance = CanvasDimensions.canvasHeight / asteroidsNum;
        layersNum = 3f;
        layersWidth = 0.125f * CanvasDimensions.canvasWidth;
        layersDistance = layersWidth / (layersNum - 1);
        asteroidsLinearSpeed = new float[3];
        asteroidAngularSpeed = new float[(int)layersNum, (int)(asteroidsNum + 1)];
        initialYpos = -(asteroidsDistance + CanvasDimensions.canvasHeight) / 2;
        scale = 0.45f;
        astSprt0 = Resources.Load("RockPurple1", typeof(Sprite)) as Sprite;
        astSprt1 = Resources.Load("RockPurple2", typeof(Sprite)) as Sprite;
        astSprt2 = Resources.Load("RockPurple3", typeof(Sprite)) as Sprite;
        astSprt3 = Resources.Load("RockPurple4", typeof(Sprite)) as Sprite;
        astSprt4 = Resources.Load("RockPurple5", typeof(Sprite)) as Sprite;
        astSprt5 = Resources.Load("RockPink1", typeof(Sprite)) as Sprite;
        astSprt6 = Resources.Load("RockPink2", typeof(Sprite)) as Sprite;
        astSprt7 = Resources.Load("RockPink3", typeof(Sprite)) as Sprite;
        astSprt8 = Resources.Load("RockPink4", typeof(Sprite)) as Sprite;
        astSprt9 = Resources.Load("RockPink5", typeof(Sprite)) as Sprite;
        astSprt10 = Resources.Load("RockOrange1", typeof(Sprite)) as Sprite;
        astSprt11 = Resources.Load("RockOrange2", typeof(Sprite)) as Sprite;
        astSprt12 = Resources.Load("RockOrange3", typeof(Sprite)) as Sprite;
        astSprt13 = Resources.Load("RockOrange4", typeof(Sprite)) as Sprite;
        astSprt14 = Resources.Load("RockOrange5", typeof(Sprite)) as Sprite;
        astSprt15 = Resources.Load("RockBrown1", typeof(Sprite)) as Sprite;
        astSprt16 = Resources.Load("RockBrown2", typeof(Sprite)) as Sprite;
        astSprt17 = Resources.Load("RockBrown3", typeof(Sprite)) as Sprite;
        astSprt18 = Resources.Load("RockBrown4", typeof(Sprite)) as Sprite;
        astSprt19 = Resources.Load("RockBrown5", typeof(Sprite)) as Sprite;
        astSprt20 = Resources.Load("RockBlue1", typeof(Sprite)) as Sprite;
        astSprt21 = Resources.Load("RockBlue2", typeof(Sprite)) as Sprite;
        astSprt22 = Resources.Load("RockBlue3", typeof(Sprite)) as Sprite;
        astSprt23 = Resources.Load("RockBlue4", typeof(Sprite)) as Sprite;
        astSprt24 = Resources.Load("RockBlue5", typeof(Sprite)) as Sprite;
        asteroidsSprites = new Sprite[] { astSprt0, astSprt1, astSprt2, astSprt3, astSprt4, astSprt5, astSprt6, astSprt7, astSprt8, astSprt9,
                                          astSprt10, astSprt11, astSprt12, astSprt13, astSprt14, astSprt15, astSprt16, astSprt17, astSprt18,
                                          astSprt19, astSprt20, astSprt21, astSprt22, astSprt23, astSprt24};

        // Creating a pool of asteroids.
        for (int xp = 0; xp < layersNum; ++xp)
        {
            float xPos = -layersWidth / 2 + xp * layersDistance;
            asteroidsLinearSpeed[xp] = Mathf.Pow(-1, xp) * 2f / (Mathf.Abs(xPos) + 1);
            for (int a = 0; a < asteroidsNum + 1; ++a)
            {
                // Instantiating.
                GameObject asteroidObj = Instantiate(Resources.Load("Asteroid")) as GameObject;
                asteroidObj.GetComponent<SpriteRenderer>().sprite = asteroidsSprites[Random.Range(0, asteroidsSprites.Length)];
                // Positioning.
                float yPos = initialYpos + a * asteroidsDistance;
                asteroidObj.transform.position = new Vector3(xPos, yPos, 0f);
                // Scaling.
                asteroidObj.transform.localScale = new Vector3(scale, scale, 1);
                asteroidAngularSpeed[xp, a] = Mathf.Pow(-1, a) * Random.Range(25f, 40f);
            }
        }
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the asteroids position.

        if (Input.GetKeyDown("backspace"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        for (int i = 0; i < asteroids.Length; ++i)
        {
            GameObject ast = asteroids[i];

            int curLayer = (int)Mathf.Floor(i / (int)(asteroidsNum + 1));
            int curAsteroidIdx = i % (int)(asteroidsNum + 1);
            float curAsteroidSpeed = asteroidsLinearSpeed[curLayer];
            float directionUp = curAsteroidSpeed / Mathf.Abs(curAsteroidSpeed);

            // Posiotion.
            float x = ast.transform.position.x;
            float y = ast.transform.position.y;
            float z = ast.transform.position.z;
            // Rotation.
            float xr = ast.transform.localEulerAngles.x;
            float yr = ast.transform.localEulerAngles.y;
            float zr = ast.transform.localEulerAngles.z;
            if (Mathf.Abs(y) > -initialYpos) // If the asteroid left the screen it is reposisioned at the opposite side.
            {
                y = directionUp * initialYpos;
            }
            else
            {
                y += curAsteroidSpeed * Time.deltaTime;
                zr += asteroidAngularSpeed[curLayer, curAsteroidIdx] * Time.deltaTime;
            }
            ast.transform.position = new Vector3(x, y, z);
            ast.transform.localEulerAngles = new Vector3(xr, yr, zr);
        }

    }
}



//if (Input.GetKeyDown("backspace"))
//{
//    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
//}