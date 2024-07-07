using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float raycastDistance = 5f;  
    public GameObject uiPanel;         

    void Update()
    {

        RaycastHit hit;

        Vector3 forwardDirection = transform.forward;

        Debug.DrawRay(transform.position, forwardDirection * raycastDistance, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {   
            Chest chest;
            if (hit.collider.TryGetComponent<Chest>(out chest))
            {
                Debug.Log("chest bulundu");
                uiPanel.SetActive(true);
            }
            else
            {
                uiPanel.SetActive(false);
            }
        }
        else
        {
            uiPanel.SetActive(false);
        }
    }
}
