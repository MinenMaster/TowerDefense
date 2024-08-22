/* Includes parts of this source code
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=8
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=9
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=11
*/

using UnityEngine;

public class Shop : MonoBehaviour{

    public Turret_Blueprint standard_turret;
    public Turret_Blueprint missile_launcher;

    Build_Manager build_manager;

    void Start(){
        build_manager = Build_Manager.instance;
    }

    public void Select_Standard_Turret(){
        Debug.Log("Standard Turret Selected");
        build_manager.Select_Turret_To_Build(standard_turret);
    }

    public void Select_Missile_Launcher(){
        Debug.Log("Missile Launcher Selected");
        build_manager.Select_Turret_To_Build(missile_launcher);
    }
}
