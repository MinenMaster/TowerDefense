/* Includes parts of this source code
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=6
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=8
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=9
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=11
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=12
*/

using UnityEngine;

public class Build_Manager : MonoBehaviour{

    public static Build_Manager instance;

    void Awake(){
        if(instance != null){
            Debug.LogError("More than one Build_Manager in scene!!!");
            return;
        }
        instance = this;
    }

    public GameObject standard_turret_prefab;
    public GameObject missile_launcher_prefab;

    public GameObject build_effect;

    private Turret_Blueprint turret_to_build;

    public bool Can_Build {get { return turret_to_build != null; }}
    public bool Has_Money {get { return Player_Stats.Money >= turret_to_build.cost; }}

    public void Build_Turret_On(Node node){

        if(Player_Stats.Money < turret_to_build.cost){
            Debug.Log("Not enough money to build that!");
            return;
        }

        Player_Stats.Money -= turret_to_build.cost;

        GameObject turret = (GameObject)Instantiate(turret_to_build.prefab, node.Get_Build_Position(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(build_effect, node.Get_Build_Position(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money left: " + Player_Stats.Money);
    }

    public void Select_Turret_To_Build(Turret_Blueprint turret){
        turret_to_build = turret;
    }
}
