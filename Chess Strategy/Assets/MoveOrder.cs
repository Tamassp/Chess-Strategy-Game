using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrder : MonoBehaviour
{
    private RaycastHit hit;

    public GameObject moveOrderGO;
    // Start is called before the first frame update
    void Start()
    {
        // moveOrderGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        // moveOrderGO.SetActive(false);
        Instantiate(moveOrderGO);
        moveOrderGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        //gameObject.SetActive(false);
        //print("MOVEORDER: " + !moveOrderGO.activeSelf);
        // if (Input.GetMouseButton(1) && !moveOrderGO.activeSelf)
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     Physics.Raycast(ray, out hit, 50000f);
        //     //moveOrderGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //     Instantiate(moveOrderGO,hit.transform.position, Quaternion.identity);
        //     moveOrderGO.SetActive(true);
        //     print(hit.transform.position);
        // }
    }
}
