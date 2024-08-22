
/* Includes parts of this source code
 Quellcode https://www.youtube.com/watch?v=aFxucZQ_5E4&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=2 */

 /* Good to know
 Transform = https://docs.unity3d.com/ScriptReference/Transform.html */

using UnityEngine;

public class Waypoints : MonoBehaviour
{

    // Create a loop that passes through each child and determines the position of the next child.

    public static Transform[] waypoints;
    void Awake (){
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++){
            waypoints[i] = transform.GetChild(i);
        }
    }
}
