using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private List<GameObject> moonCandidates; 
    private GameObject moonToLandOn;
    private GameObject currentMoon;
    private GameObject arrow;
    private GameObject spaceship;
    //private Vector3 initialPos;
    //private bool goHome;
    public float initX;
    public float initY;
    public bool canEnterShip;
    public float speed;
    public bool canJump;
    public bool pressedForwarnMoon;
    public bool pressedForwarnShip;
    public bool onMoon;
    public bool moveBackward;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        this.moonCandidates = new List<GameObject>();
        canJump = false;
        onMoon = false;
        canEnterShip = false;
        pressedForwarnMoon = false;
        pressedForwarnShip = false;
        arrow = transform.GetChild(1).GetChild(0).gameObject;
        
        this.initX = transform.position.x;
        this.initY = transform.position.y;
        //this.initialPos = new Vector3(transform.position.x, transform.position.y, 0f);
        //goHome = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.position.y) > (CanvasDimensions.canvasHeight / 2))
        {
            Debug.Log("spaceship got out of the canvas");
            Hit();
        }

        Vector3 scale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            transform.localScale = new Vector3(scale.x, -scale.y, scale.z);
            //transform.eulerAngles += new Vector3(0f, 0f, 180f); // TODO Change to negative scale (Y)
        }


        //if (Input.GetKeyDown(KeyCode.RightArrow) && goHome)
        //{
        //    this.GoToInitialPos();
        //}

        if (canJump && ((Input.GetKeyDown(KeyCode.LeftArrow) && scale.y > 0f) || (Input.GetKeyDown(KeyCode.RightArrow) && scale.y < 0f)))
        {

                // Confirm candidate here
            if (pressedForwarnMoon == false && this.moonCandidates.Count != 0)
            {
                moonToLandOn = this.ReturnClosest(transform.position);
                pressedForwarnMoon = true;
            }
            
        }

        if (canEnterShip && (Input.GetKeyDown(KeyCode.LeftArrow) && scale.y > 0f))
        {
            pressedForwarnShip = true;
        }


        if (pressedForwarnMoon)
        {
        
            this.MoveForward();
          
        }

        if (pressedForwarnShip)
        {
            this.MoveTowardShip();
        }


    }

    private void MoveTowardShip()
    {
        transform.parent = null;
        Vector3 pos = transform.position;
        Vector3 targetPos = this.spaceship.transform.position;
        transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, targetPos, 5f), speed * Time.deltaTime);
        if ((transform.position - targetPos).magnitude == 0f)
        {
            spaceship.GetComponent<SpaceShipMovement>().enableMovement = true;
            Destroy(gameObject);
        }
    }

   

    private void MoveForward()
    {
        transform.parent = null;
        Vector3 pos = transform.position;
        Vector3 targetPos = moonToLandOn.transform.position;
        transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, targetPos, 25f), speed * Time.deltaTime);
        if ((transform.position - targetPos).magnitude == 0f)
        {
            transform.parent = moonToLandOn.transform;
            currentMoon = moonToLandOn;
            this.moonCandidates.Remove(moonToLandOn);
            pressedForwarnMoon = false;
            moonToLandOn = null;
            if (this.moonCandidates.Count == 0)
            {
                arrow.GetComponent<SpriteRenderer>().color = Color.white;
                canJump = false;
            }

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

        if(collision.gameObject.tag.Equals("Spaceship1"))
        {
            this.spaceship = collision.gameObject;
            canEnterShip = true;
            arrow.GetComponent<SpriteRenderer>().color = Color.green;
        }
        //else if (collision.gameObject.tag.Equals("PlanetBlue"))
        //{
        //    goHome = true;
        //}
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

        if (collision.gameObject.tag.Equals("Spaceship1")) // Might make it Spaceship 1-2
        {
            canEnterShip = false;
            this.spaceship = null;
            arrow.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private GameObject ReturnClosest(Vector3 pos)
    {
        GameObject closestMoon = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject moon in this.moonCandidates)
        {
            float disToTarget = (moon.transform.position - pos).sqrMagnitude;
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
        // Need to respawn
        transform.position = new Vector3(initX, initY, 0f);
        transform.parent = null;
        this.moonCandidates = new List<GameObject>();
        canJump = false;
        onMoon = false;
        canEnterShip = false;
        pressedForwarnMoon = false;
        pressedForwarnShip = false;

    }

    //private void GoToInitialPos()
    //{
    //    transform.parent = null;
    //    //moveBackward = true;
    //    Vector3 pos = transform.position;
    //    transform.position = Vector3.MoveTowards(pos, Vector3.Lerp(pos, this.initialPos, 25f), speed * Time.deltaTime);
    //    if ((transform.position - this.initialPos).magnitude == 0f)
    //    {
    //        goHome = false;
    //        transform.eulerAngles = new Vector3(0f, 0f, 90f);
    //    }
    //}
}
