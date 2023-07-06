using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject invetoryPanel;
    bool activInvetory = false;
    private void Start()
    {
        invetoryPanel.SetActive(activInvetory);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activInvetory = !activInvetory;
            invetoryPanel.SetActive(activInvetory);
        }
    }
}
