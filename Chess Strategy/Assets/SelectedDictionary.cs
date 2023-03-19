using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedDictionary : MonoBehaviour
{

    public static Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!selectedTable.ContainsKey(id))
        {
            selectedTable.Add(id, go);
            go.AddComponent<SelectionComponent>();
            Debug.Log("Added " + id + " to selected dictionary");
        }

    }

    public void deselect(int id)
    {
        selectedTable.Remove(id);
    }

    public void deselectAll()
    {
        foreach (KeyValuePair<int, GameObject> kvp in selectedTable)
        {
            if (kvp.Value != null)
            {
                Destroy(selectedTable[kvp.Key].GetComponent<SelectionComponent>());
            }
        } 
        selectedTable.Clear();
    }

    public bool containsGameObject(GameObject go)
    {
        if (selectedTable.ContainsValue(go))
        {
            return true;
        }

        return false;
    }
}
