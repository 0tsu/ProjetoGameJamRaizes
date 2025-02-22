using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoviment : MonoBehaviour
{
    //Ponto para o qual o personagem ir� se mover
    private Vector3 point;
    //Vari�vel NavMeshAgent Para configurar A movimenta��o do personagem
    private NavMeshAgent agent;
    private float playerScale;
    
    void Start()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Variaveis setadas como False para N�o utilizar os eixos Y Baseado em 3 dimens�es
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        point = transform.position;
        playerScale = transform.localScale.x;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetFlip();
        }
        //Faz o personagem se locomover pelo cenario at� o point
        if(!transform.position.Equals(point))
        {
            agent.SetDestination(new Vector3 (point.x, transform.position.y));
        }
    }

    void SetFlip()
    {
        if(point.x < transform.position.x)
            transform.localScale = new Vector3(-1 * playerScale, playerScale, playerScale);
        else if(point.x > transform.position.x)
            transform.localScale = new Vector3(playerScale,playerScale,playerScale);
    }
}
