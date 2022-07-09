using UnityEngine;

public class primeiraPessoa : MonoBehaviour{
    
    //personagem
    public Transform corpoPersona; 
    //cabeça para referência na câmera de primeira pessoa
    public Transform cabecaPersona; 

    //sensibilidade do mouse
    float sensibilidadeX = 1f;
    float sensibilidadeY = 1f;

    //inicializado na origem
    float rotacaoX = 0;
    float rotacaoY = 0;
    //apenas 90º
    float anguloMinY = -90;
    float anguloMaxY = 90;

    //suavização da rotação da câmera
    float suavizaX = 0;
    float suavizaY = 0;
    float coefX = 0.75f;
    float coefY = 0.75f;

    void Start(){
        //removendo o cursor do mouse da tela durante a execução
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate(){
    //lateUpdate, pois deve seguir o personagem com a posição devidamente atualizada
        transform.position = cabecaPersona.position;
        //câmera fixa na cabeça.
    }

    void Update() {
        //parâmetros para a detecção de movimento do mouse com a sensibilidade definida
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensibilidadeY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensibilidadeX;
        
        //suavização da movimentação da câmera
        suavizaX = Mathf.Lerp(suavizaX, horizontalDelta, coefX);
        suavizaY = Mathf.Lerp(suavizaY, verticalDelta, coefY);
        
        //atualizando rotações de acordo com o movimento do mouse 
        rotacaoX += suavizaX;
        rotacaoY += suavizaY;

        //limitando a rotação do mouse de acordo com os ângulos máximos e mínimos que foram passados
        rotacaoY = Mathf.Clamp(rotacaoY, anguloMinY, anguloMaxY);

        //fazendo com que o personagem acompanhe a direção que o mouse aponta, dessa forma ele segue
        //a orientação do mesmo. Ou seja, o player acompanha a direção do mouse, juntamente com a câmera
        corpoPersona.localEulerAngles = new Vector3(0, rotacaoX, 0);
        
        //atualizando os novos ângulos de rotação da câmera de acordo com a posição do mouse na tela
        transform.localEulerAngles = new Vector3(-rotacaoY, rotacaoX, 0);

    }

}