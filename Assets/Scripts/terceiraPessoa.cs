using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terceiraPessoa : MonoBehaviour{

    public float velocidade;
    public Animator anim;

    float inputX; //a,d
    float inputZ;  //w,s
    Vector3 direcao;

    public Camera MainCamera;

    void Start(){

    }

    void Update(){
        inputX = Input.GetAxis("horizontal");
        inputZ = Input.GetAxis("vertical");
        direcao = new Vector3(inputX, 0, inputZ);

        if(inputX != 0 || inputZ != 0){
            var camrot = MainCamera.transform.rotation;
            camrot.x = 0;
            camrot.z = 0;

            transform.Translate(0, 0, velocidade*Time.deltaTime);
            anim.SetBool("walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcao) * camrot, 5*Time.deltaTime);
        }
        if(inputX != 0 || inputZ != 0)
            anim.SetBool("walk", false);
    }        
}