/* Includes parts of this source code
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=7
*/

using UnityEngine;

public class Camera_Controller : MonoBehaviour{
    
    private bool do_movement = true;

    public float pan_speed = 30f;
    public float pan_border_thickness = 10f;

    public float scroll_speed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    
    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape))
            do_movement = !do_movement;

        if(!do_movement)
            return;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - pan_border_thickness){
            transform.Translate(Vector3.forward * pan_speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= pan_border_thickness){
            transform.Translate(Vector3.back * pan_speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - pan_border_thickness){
            transform.Translate(Vector3.right * pan_speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= pan_border_thickness){
            transform.Translate(Vector3.left * pan_speed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 position = transform.position;

        position.y -= scroll * 1000 * scroll_speed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
