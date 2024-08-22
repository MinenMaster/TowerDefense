/* Includes parts of this source code
 Quellcode https://www.youtube.com/watch?v=aFxucZQ_5E4&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=2 */

  /* Good to know
 Transform = https://docs.unity3d.com/ScriptReference/Transform.html 
 Vector3 = https://docs.unity3d.com/ScriptReference/Vector3.html
 Space.World = https://docs.unity3d.com/ScriptReference/Space.World.html
 */

using UnityEngine;

public class Enemy : MonoBehaviour{

    public float speed = 10f;

    private Transform target;
    private int wavepoint_index = 0;

    void Start (){
        // Set the target to the first waypoint
        target = Waypoints.waypoints[0];
    }

    
    void Update (){
        // Normalize the direction speed that we can make sure this will have always the same speed
        // Multiplay it also with Time.deltaTime to make sure the speed is not deppending on the Frame Rate
        // With Space.World we make sure that the space we want to move is Space.World
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // If enemy position is near waypoint position, get the next position from waypoints by counting wavepoint_index up, if reaching the end destroy enemy
        if (Vector3.Distance(transform.position, target.position) <= 0.2f){
            Get_Next_Waypoint();
        }

        void Get_Next_Waypoint(){
            if (wavepoint_index >= Waypoints.waypoints.Length - 1){
                Destroy(gameObject);
                return;
            }
            wavepoint_index++;
            target = Waypoints.waypoints[wavepoint_index];
        }
    }
}
