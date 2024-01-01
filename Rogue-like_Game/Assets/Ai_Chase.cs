using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Chase : MonoBehaviour
{
    //object for the player
    public GameObject player;

    //speed at which the Ai chases
    public float speed;
    public float distanceBetween;


    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This will take 2 transform and will calculate the distance (return as a float)
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //If the player is at a certain distance, the enemy will chase. If not, it wont chase
        if (distance < distanceBetween)
        {
            //This makes the enemy move toward the player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //This makes the enemy rotate to face the player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        //link to video:https://www.youtube.com/watch?v=2SXa10ILJms
    }
}
