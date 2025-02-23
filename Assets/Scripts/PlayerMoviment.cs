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
    void Start()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Variaveis setadas como False para N�o utilizar os eixos Y Baseado em 3 dimens�es
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        point = transform.position;

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
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
            transform.localScale = new Vector3(-1,1,1);
        else if(point.x > transform.position.x)
            transform.localScale = new Vector3(1,1,1);
    }
}
