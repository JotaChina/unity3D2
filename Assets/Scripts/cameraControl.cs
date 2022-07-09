using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    public GameObject cabeca;
    public GameObject[] posicoes;
    private int indice = 0;
    public float VelocidadeDeMovimento = 2;
    private RaycastHit hit;
    
    void FixedUpdate () {
        transform.LookAt (cabeca.transform);
        //CHECAR SE TEM COLISOR
        if (!Physics.Linecast (cabeca.transform.position, posicoes[indice].transform.position))
            transform.position = Vector3.Lerp(transform.position, posicoes[indice].transform.position,VelocidadeDeMovimento*Time.deltaTime);                    
        
        else if(Physics.Linecast(cabeca.transform.position, posicoes[indice].transform.position,out hit))
            transform.position = Vector3.Lerp(transform.position, hit.point,(VelocidadeDeMovimento*2)*Time.deltaTime);
        
    }

    void Update (){
    }
}