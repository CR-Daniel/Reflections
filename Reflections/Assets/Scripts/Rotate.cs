using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // public GameObject camera;
    private bool moving = false;
    
    private void Update(){

            if(Input.GetMouseButtonDown(0)){
                
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f) && hit.collider.tag == "platform"){

                    while(moving == false){
                        if(hit.transform != null){
                            StartCoroutine(Rotation(hit.transform.gameObject, 0, 22.5f, 0, 0.25f));
                        }
                    }
                }
            }
    }

    IEnumerator Rotation(GameObject obj, float x, float y, float z, float duration)
    {
        float timeElapsed = 0;
        float lerpDuration = duration;
        moving = true;

        Quaternion startRotation = obj.transform.rotation;
        Quaternion targetRotation = obj.transform.rotation * Quaternion.Euler(x, y, z);

        while (timeElapsed < lerpDuration)
        {
            obj.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = targetRotation;
        moving = false;
    }
}
