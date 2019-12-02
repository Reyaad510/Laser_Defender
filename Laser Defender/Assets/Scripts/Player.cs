using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Movement done here because want to check movement every frame
    void Update()
    {
        Move();
    }


    private void Move() {
        // can use var to know it will be a float
        // Look below for Time.deltaTime explanation
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector2(newXPos, newYPos);
       

    }


}


//Time.deltaTime
// Game will behave same on fast and slow computers
// Says "how long did it take for that frame take to execute"
 // something multiplied by Time.deltaTime will make it frame independent
