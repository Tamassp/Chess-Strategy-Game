using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//// THIS IS AN OLD APPROACH. IT WAS NOT USED IN THE FINAL SOLUTION
//// IT WAS SWAPPED WITH NAVMESH
/// I just lef it as reference, but navmesh was a better solution in the game's usecase
public class Move : MonoBehaviour
{
    //public Transform destionation;
    SelectedDictionary selected_table;
    private RaycastHit hit;
    private bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        selected_table = GetComponent<SelectedDictionary>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray landingRay = new Ray(Input.mousePosition.normalized, Vector3.down);
        //Debug.DrawRay(Input.mousePosition.normalized, Vector3.down);
        
        if (Input.GetMouseButton(1))
        {
            

            Physics.Raycast(ray, out hit, 50000f);
            isMoving = true;
            
            //GetComponent<Rigidbody>().AddForce((destionation.position-transform.position).normalized * 100f);
        }

        if (isMoving)
        {
            // if (selected_table.containsGameObject(gameObject))
            // {
                
                GetComponent<Rigidbody>().AddForce(5000f * Time.deltaTime * (hit.point - transform.position).normalized);
            //}
        }

        // if (Input.GetKey("space"))
        // {
        //     transform.position = destination.position;
        // }
    }
}
