using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private readonly string horizontal = "Horizontal";
    private readonly string vertical = "Vertical";
    private GameObject moonToLandOn;
    public float speed;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //float yPos = transform.position.y + Input.GetAxisRaw(vertical) * speed * Time.deltaTime;
        float yPos = Input.GetAxisRaw(horizontal);
        //float xPos = transform.position.x + Input.GetAxisRaw(horizontal) * speed * Time.deltaTime;

        if (canJump && yPos == -1)
        {
            Vector3 dirVector =  (moonToLandOn.transform.position - transform.position).normalized;
            transform.position = dirVector;
        }

        //transform.position = new Vector3(xPos, yPos, 0);
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Moon"))
        {
   
            canJump = true;
            moonToLandOn = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Moon"))
        {
            canJump = false;
        }
    }

    public void Hit()
    {
        Debug.Log("Hit the player, should restart");

    }
}
