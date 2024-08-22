/* Includes parts of this source code
 Quellcode https://www.youtube.com/watch?v=n2DXF1ifUbU&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=4 
 Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=5
 */

 /* Good to know
 Transform = https://docs.unity3d.com/ScriptReference/Transform.html
 OnDrawGizmosSelected = https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
 */

using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fire_rate = 1f;
    private float fire_countdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemy_tag = "Enemy";
    public Transform part_to_rotate;
    public float turn_speed = 10f;

    public GameObject bullet_prefab;
    public Transform fire_point;
    
    void Start(){
        InvokeRepeating("Update_Target", 0f, 0.5f);
    }

    void Update_Target (){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        float shortest_distanc = Mathf.Infinity;
        GameObject nearest_enemy = null;

        foreach (GameObject enemy in enemies){
            float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance_to_enemy < shortest_distanc){
                shortest_distanc = distance_to_enemy;
                nearest_enemy = enemy;
            }
        }

        if(nearest_enemy != null && shortest_distanc <= range){
            target = nearest_enemy.transform;
        } else {
            target = null;
        }
    }

    void Update(){
        if(target == null)
            return;

        // Target lock on
        Vector3 direction = target.position - transform.position;
        Quaternion look_rotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(part_to_rotate.rotation, look_rotation, Time.deltaTime * turn_speed).eulerAngles;
        part_to_rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fire_countdown <= 0f){
            Shoot();
            fire_countdown = 1f / fire_rate;
        }

        fire_countdown -= Time.deltaTime;

    }

    void Shoot(){
        GameObject bullet_game_object = (GameObject)Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
        Bullet bullet = bullet_game_object.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    // To Show the Turret Range on Unity for us
    void OnDrawGizmosSelected (){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
