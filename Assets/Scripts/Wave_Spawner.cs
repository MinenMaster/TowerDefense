/* Includes parts of this source code
 Quellcode https://www.youtube.com/watch?v=n2DXF1ifUbU&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=3
  Quellcode https://www.youtube.com/watch?v=n2DXF1ifUbU&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=12
 */

 /* Good to know
 Transform = https://docs.unity3d.com/ScriptReference/Transform.html 
 Coroutine time delay = https://docs.unity3d.com/Manual/Coroutines.html */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave_Spawner : MonoBehaviour
{
    public Transform enemy_prefab;

    public Transform spawn_point;

    public float time_between_waves = 5f;
    private float countdown = 2f;

    public Text wave_countdown_text;

    private int wave_index = 0;

    void Update(){

        // we make a countdown that decresses over time, if we reach 0 we spawn a wave and after that we reset it again
        if (countdown <= 0f){
            StartCoroutine(Spawn_Wave());
            countdown = time_between_waves;

        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        // remove all floats values for the string
        wave_countdown_text.text = string.Format("{0:00.00}", countdown);
    }

    // we make a coroutine delay to make sure that the enemys don't spawn to fast ower each other
    // for each wave we spwan one more enemy
    // over time the enemys gone spawn again over each other because they reach the end of the wave before, -- we need to fix this... and implement our ideas...
    IEnumerator Spawn_Wave(){

        wave_index++;

        for (int i = 0; i < wave_index; i++){
            Spawn_Enemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void Spawn_Enemy(){
        Instantiate(enemy_prefab, spawn_point.position, spawn_point.rotation);
    }
}
