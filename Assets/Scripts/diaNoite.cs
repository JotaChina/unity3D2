using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaNoite : MonoBehaviour
{
    public float intensidade;
    private float inclinacao;
    public bool noite;

    // Update is called once per frame
    void Update(){
        gameObject.transform.Rotate(intensidade * 355 / 60 * Time.deltaTime, 0, 0);
        inclinacao = gameObject.transform.eulerAngles.x;

        if(inclinacao >= 180){
            noite = true;
        }
        else{
            noite = false;
        }
    }
}
