using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    //Serialized field so we can set it in the editor
    //[SerializeField] 
    //private Transform movePositionTransform;
    private RaycastHit hit;
    private NavMeshAgent navMeshAgent;

    private Vector3 destination;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
       
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(1) && gameObject.GetComponent<SelectionComponent>() != null)
        {
            //Vector3 destination;
            Physics.Raycast(ray, out hit, 50000f);
            destination = hit.point;
            
        }

        if (!destination.Equals(Vector3.zero))
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        if (destination != Vector3.zero && (navMeshAgent.transform.position - destination).magnitude < 3)
        {
            destination = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
       
           
    }

    public void SetDestination(Vector3 _destination)
    {
        navMeshAgent.destination = _destination;
    }
}
