using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //public Transform Target;
    public float Speed = 1000f;

    private Coroutine LookCoroutine;
    // Start is called before the first frame update
    public void StartRotation(GameObject gameobject, Transform target)
    {
        if(LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt_(gameobject, target));
    }

    private IEnumerator LookAt_(GameObject gameobject, Transform target)
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - gameobject.transform.position);

        while (gameobject.transform.rotation != targetRotation)
        {
            gameobject.transform.rotation = Quaternion.RotateTowards(gameobject.transform.rotation, targetRotation, Time.deltaTime * Speed);
            yield return null;
        }
    }
}
