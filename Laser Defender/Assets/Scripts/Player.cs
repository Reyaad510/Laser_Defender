using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // config params
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.05f;

    // Coroutine
    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    // Movement done here because want to check movement every frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //StopAllCoroutines();
            StopCoroutine(firingCoroutine);
        }
    }


    // Coroutine 
    IEnumerator FireContinously()
    {
        while (true)
        {
            // Quaternion.identity just saying use whatever rotation already is
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }


    private void Move() {
        // can use var to know it will be a float
        // Look below for Time.deltaTime explanation
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Mathf.Clamp so player cant go off screen top, bottom, left, right
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
       

    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        // Creates barriers on the side of the wall.
        // barrier for left and right
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        // Barrier for top and bottom of camera
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;


    }


}


//Time.deltaTime
// Game will behave same on fast and slow computers
// Says "how long did it take for that frame take to execute"
 // something multiplied by Time.deltaTime will make it frame independent


 // RigidBody2d for laser change to kinematic so gravity doeosnt effect it

// Coroutine is a method which can suspend(yield) its execution until the yield instructions you gave it are met
// Dont put Coroutine in Update()
// Ex when player gets to zero health, start the KillPlayer coroutine -> trigger death animation, Yield(wait) for 3 second -> restart level
// If yield wasnt there the death animation would happen same time as restart level so wouldnt see it

/* StartCoroutine(NameOfCoroutine())
 * 
  IEnumerator NameOfCoroutine(){
  Things to do,
  yield return SomeCondition
  things to do
    }

WaitForSeconds(3) wait for how many seconds you put

*/


    // List is dynamically sized while array is fixed in size
    // List<Enemy> enemies = {1, 3, 5, 7, 9} first number starts as 0
