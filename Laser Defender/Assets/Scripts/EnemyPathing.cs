using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
    // type transform because looking at position of enemies
    List<Transform> waypoints;
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
 
        Move();
    }

    // waveConfig in this isnt equal to the one above
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        // this.waveConfig is referring to the this Class Config. = waveConfig is equal to whatever is passed in
        this.waveConfig = waveConfig;
    }

    private void Move()
    {       // .Count used for lists(array uses Length)
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.MoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
