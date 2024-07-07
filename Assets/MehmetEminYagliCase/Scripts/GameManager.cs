using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject myInventoryPanel;
    private bool isInventoryPanelOpen = false;

    void Start()
    {
        myInventoryPanel.SetActive(false);
    }

    public void ToggleInventoryPanel()
    {
        isInventoryPanelOpen = !isInventoryPanelOpen;

        if (isInventoryPanelOpen)
        {
            InventoryPanelOpen();
        }
        else
        {
            InventoryPanelClose();
        }
    }

    public void InventoryPanelOpen()
    {
        myInventoryPanel.SetActive(true);
    }

    public void InventoryPanelClose()
    {
        myInventoryPanel.SetActive(false);
    }
}
