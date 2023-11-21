using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    private List<List<string>> algorightms;
    [SerializeField] GameObject canvas;
    private bool isCanvas;
    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if(isCanvas && Input.GetKey(KeyCode.Escape)){
            canvas.SetActive(false);
        }
    }

    void OnMouseDown(){
        Debug.Log("Clicked");
        canvas.SetActive(true);
        isCanvas = true;
        DatabaseManager.SetConnection();
        // string building_id = DatabaseManager.ExecuteQueryWithAnswer($"SELECT id FROM buildings WHERE building_name = Нагреватель");
        // Debug.Log(building_id);
    }
}
