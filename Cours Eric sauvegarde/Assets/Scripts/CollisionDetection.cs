using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameplayManager GpManager;

    private void Start()
    {
        GameplayManager.SINGLETON.CD = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Piece"))
        {
            other.gameObject.SetActive(false);
            GameplayManager.SINGLETON.UpdatePiecesUI();
        }
        else if (other.CompareTag("Piege"))
        {
            GameplayManager.SINGLETON.KillPlayer();
        }
    }
}
