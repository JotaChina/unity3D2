using UnityEngine;

public class player : MonoBehaviour {

    CharacterController controlador;
    //forças nos eixos
    Vector3 z; 
    Vector3 x; 
    Vector3 y; 
    
    //velocidade padrão de deslocamento 
    float zSpeed = 6.7f;
    float xSpeed = 6.7f;

    float gravidade; 
    float velocidadePulo; 
    float hMaxPulo = 2f; 
    float tempoMax = 0.5f; //tempo até ponto máximo do pulo

    void Start(){
        //controlador é o personagem que foi passado como referência no Unity
        controlador = GetComponent<CharacterController>();

        //forças necessárias para movimentações
        gravidade = (-2 * hMaxPulo) / (tempoMax * tempoMax);
        velocidadePulo = (2 * hMaxPulo) / tempoMax;
    }

    void Update(){
        //parâmetros para detecção de força de movimentação através do input
        float zInput = Input.GetAxisRaw("Vertical"); //w=1 e s=-1
        float xInput = Input.GetAxisRaw("Horizontal"); //a=-1 e d=1

        //força = entrada do teclado * velocidade definida * direção em que deseja se mover
        z = zInput * zSpeed * transform.forward; //movimentando para frente/trás
        x = xInput * xSpeed * transform.right; //movimentando para esquerda/direita

        y += gravidade * Time.deltaTime * Vector3.up; //altura do pulo

        if(controlador.isGrounded) //se o player estiver tocando o chão
            y = Vector3.down;
        
        //efetuando o pulo utilizando a barra de espaço
        if(Input.GetKeyDown(KeyCode.Space) && controlador.isGrounded)
            y = velocidadePulo * Vector3.up;
        
        //suavização do pulo.
        //quando o personagem encosta no teto de algum lugar, a velocidade será zerada
        //e cai no momento da colisão. 
        if(y.y > 0 && (controlador.collisionFlags & CollisionFlags.Above) != 0){ 
            //se há uma colisão em y e alguma flag do controlador
            //for != 0, quer dizer que houve impacto.
            y = Vector3.zero;
        }

        //forças definidas em cada orientação
        Vector3 finalVelocity = z + x + y;
        
        //efetuando o movimento
        controlador.Move(finalVelocity * Time.deltaTime);
    }

}