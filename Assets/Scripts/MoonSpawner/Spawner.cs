using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] moonPrefabs;
    private float xPos;
    private float yPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(10, 9);
        this.xPos = transform.position.x;
        this.yPos = transform.position.y;
        this.timer = 4f;
        Invoke("SpawnMoonsLayer1", this.timer);

        Invoke("SpawnMoonsLayer2", this.timer);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void SpawnMoonsLayer1()
    {
        Vector3 position = new Vector3(this.xPos, this.yPos, 0f);

        GameObject moon1 = Instantiate(this.moonPrefabs[0],
            position, Quaternion.identity);

        GameObject moon2 = Instantiate(this.moonPrefabs[1],
            position, Quaternion.identity);

        moon1.AddComponent<MoonControllerLayer1>();
        moon2.AddComponent<MoonEnemy1>();

        Invoke("SpawnMoonsLayer1", this.timer);
    }

    void SpawnMoonsLayer2()
    {
        Vector3 position = new Vector3(this.xPos, this.yPos, 0f);

        GameObject moon1 = Instantiate(this.moonPrefabs[0],
            position, Quaternion.identity);

        GameObject moon2 = Instantiate(this.moonPrefabs[1],
            position, Quaternion.identity);

        moon1.AddComponent<MoonControllerLayer2>();
        moon2.AddComponent<MoonEnemy2>();

        Invoke("SpawnMoonsLayer2", this.timer);
    }
}
