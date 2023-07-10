using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rota90 : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    bool una = true;

    private void OnTriggerEnter(Collider other)
    {
        una = true;
        Debug.Log("unaa:" + una);
        if(other.gameObject.tag == "player1"){
            if(una){
                StartCoroutine(InterpolarGiro(player1));
                una = false;
            }
        }

        if(other.gameObject.tag == "player2"){

            if(una){
                StartCoroutine(InterpolarGiro(player2));
                una = false;
            }
        }

        if(other.gameObject.tag == "player3"){

            if(una){
                StartCoroutine(InterpolarGiro(player3));
                una = false;
            }
        }

        if(other.gameObject.tag == "player4"){
            if(una){
                StartCoroutine(InterpolarGiro(player4));
                una = false;
            }
        }
    }


    IEnumerator InterpolarGiro(GameObject player){
        float _tiempotrans = 0f;
        float animTime = 1.5f;

        Quaternion rotacionDeseada = Quaternion.Euler(player.transform.eulerAngles.x, player.transform.eulerAngles.y -65f, player.transform.eulerAngles.z);
        
        float _ratio = 0;
        while(_tiempotrans < animTime){
            _tiempotrans += Time.deltaTime;
            _ratio = _tiempotrans / animTime;

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotacionDeseada,_ratio);

            yield return new WaitForSeconds(1f / 60f);

            _tiempotrans +=1f/60f;
        }

        yield return null;
    }
}
