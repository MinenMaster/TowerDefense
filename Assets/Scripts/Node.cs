/* Includes parts of this source code
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=6
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=8
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=12
*/

using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hover_color;
    public Color not_enough_money_color;
    public Vector3 position_offset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color start_color;

    Build_Manager build_manager;

    void Start (){
        rend = GetComponent<Renderer>();
        start_color = rend.material.color;

        build_manager = Build_Manager.instance;
    }

    public Vector3 Get_Build_Position(){
        return transform.position + position_offset;
    }

    void OnMouseDown(){
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(!build_manager.Can_Build)
            return;

        if(turret != null){
            Debug.Log("Can't build there! - TODO Display on screen.");
            return;
        }

        build_manager.Build_Turret_On(this);
    }

    void OnMouseEnter(){
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(!build_manager.Can_Build)
            return;

        if(build_manager.Has_Money){
            rend.material.color = hover_color;
        } else {
            rend.material.color = not_enough_money_color;
        }
    }

    void OnMouseExit(){
        rend.material.color = start_color;
    }
    
}
