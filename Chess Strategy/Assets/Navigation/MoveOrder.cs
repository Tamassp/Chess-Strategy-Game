using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// THIS IS AN OLD APPROACH. IT WAS NOT USED IN THE FINAL SOLUTION
//// IT WAS SWAPPED WITH NAVMESH
/// I just lef it as reference, but navmesh was a better solution in the game's usecase
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
