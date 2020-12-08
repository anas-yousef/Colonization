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
        this.timer = 2f;
        Invoke("SpawnMoons", this.timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMoons()
    {
        Vector3 position = new Vector3(this.xPos, this.yPos, 0f);
        Instantiate(this.moonPrefabs[0],
            position, Quaternion.identity);

        Invoke("SpawnMoons", this.timer);
    }
}
