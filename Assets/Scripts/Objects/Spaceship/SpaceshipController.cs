using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private List<GameObject> moonCandidates; 
    private GameObject moonToLandOn;
    private GameObject currentMoon;
    private GameObject arrow;
    private Vector3 initialPos;
    public float initX;
    public float initY;
    public float speed;
    public bool canJump;
    public bool pressedForward;
    public bool onMoon;
    public bool moveBackward;

    // Start is called before the first frame update
    void Start()
    {
        this.moonCandidates = new List<GameObject>();
        speed = 5f;
        canJump = false;
        onMoon = false;
        arrow = transform.GetChild(1).GetChild(0).gameObject;
        this.initX = transform.position.x;
        this.initY = transform.position.y;
        this.initialPos = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow) || moveBackward)
        {
            transform.parent = null;
            moveBackward = true;
            Vector3 pos = transform.position;
            transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, this.initialPos, 25f), speed * Time.deltaTime);
            if ((transform.position - this.initialPos).magnitude == 0f)
            {
                moveBackward = false;         
            }
        }

        if (canJump && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Confirm candidate here
            if (pressedForward == false && this.moonCandidates.Count != 0)
            {
                moonToLandOn = this.ReturnClosest(transform.position);
                pressedForward = true;
            }
            
        }

        if (pressedForward)
        {
            //transform.parent = null;
            //this.moonCandidates.Clear();
            //Vector3 pos = transform.position;
            //transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, moonToLandOn.transform.position, 25f), speed * Time.deltaTime);
            //if ((transform.position - moonToLandOn.transform.position).magnitude == 0f)
            //{
            //    transform.parent = moonToLandOn.transform;
            //    pressedForward = false;
            //    moonToLandOn = null;
            //}
            this.MoveForward();
          
        }
        
        
    }

    private void MoveForward()
    {
        transform.parent = null;
        Vector3 pos = transform.position;
        transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, moonToLandOn.transform.position, 25f), speed * Time.deltaTime);
        if ((transform.position - moonToLandOn.transform.position).magnitude == 0f)
        {
            transform.parent = moonToLandOn.transform;
            currentMoon = moonToLandOn;
            this.moonCandidates.Remove(moonToLandOn);
            pressedForward = false;
            moonToLandOn = null;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         //&& collision.gameObject != currentMoon - Might Add later
        if (collision.gameObject.tag.Equals("Moon"))
        {
            this.moonCandidates.Add(collision.gameObject);
            canJump = true;
            arrow.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Moon"))
        {
            this.moonCandidates.Remove(collision.gameObject);
            if (this.moonCandidates.Count == 0)
            {
                arrow.GetComponent<SpriteRenderer>().color = Color.white;
                canJump = false;
            }
        }
    }

    private GameObject ReturnClosest(Vector3 pos)
    {
        GameObject closestMoon = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject moon in this.moonCandidates)
        {
            float disToTarget = (moon.transform.position - pos).sqrMagnitude;
            if (disToTarget == 0)
            {
                int x = 0;
            }
            if (disToTarget < minDist)
            {
                minDist = disToTarget;
                closestMoon = moon;
            }
        }
        return closestMoon;
    }

    public void Hit()
    {
        Debug.Log("Hit the player, should restart");

    }
}
