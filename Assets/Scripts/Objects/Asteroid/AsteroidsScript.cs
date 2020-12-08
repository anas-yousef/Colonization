using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScript : MonoBehaviour
{
    private GameObject[] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        // Creating a pool of asteroids.
        float initialYpos = 0f;
        float xPos = 0f;
        for (int a = 0; a < 3; ++a)
        {
            // Instantiating.
            GameObject asteroidObj = Instantiate(Resources.Load("Asteroid")) as GameObject;
            // Positioning.
            float yPos = initialYpos - a * 5f;
            asteroidObj.transform.position = new Vector3(xPos, yPos, 0f);
        }
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the asteroids position.
        foreach (GameObject ast in asteroids)
        {
            float x = ast.transform.position.x;
            float y = ast.transform.position.y;
            float z = ast.transform.position.z;
            if (y > 6) // If the asteroid left the screen it is reposisioned at the opposite side.
            {
                y = -6f;
            }
            else
            {
                y += 2f * Time.deltaTime;
            }
            ast.transform.position = new Vector3(x, y, z);
        }
    }
}
