/* Includes parts of this source code
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=5
Quellcode https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=10
*/

using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public float explosion_radius = 0f;
    public GameObject impact_effect;

    public void Seek(Transform _target){
        target = _target;
    }

    void Update(){
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance_this_frame = speed * Time.deltaTime;

        if(direction.magnitude <= distance_this_frame){
            Hit_Target();
            return;
        }

        transform.Translate(direction.normalized * distance_this_frame, Space.World);
        transform.LookAt(target);
    }

    void Hit_Target(){
        GameObject effect_instance = (GameObject)Instantiate(impact_effect, transform.position, transform.rotation);
        Destroy(effect_instance, 5f);

        if(explosion_radius > 0f){
            Explode();
        } else {
            Damage(target);
        }

        
        Destroy(gameObject);
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion_radius);
        foreach (Collider collider in colliders){
            if(collider.tag == "Enemy"){
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy){
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion_radius);
    }
}
