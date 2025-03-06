using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour,IDataPersistence
{
    public static GameplayManager SINGLETON;

    [Header("Links")] 
    public GameObject CoinsPrefab;
    public GameObject CanvasPrefab;
    public TextMeshProUGUI piecesText;
    public TextMeshProUGUI deathText;
    public GameObject PieceCountainers;
    public float timeToRestart = 5f;
    public PlayerMovement PM;
    public CollisionDetection CD;

    private int piecesCount = 0;
    private int deathCount = 0;

    private void Start()
    {
        PieceCountainers = Instantiate(PieceCountainers, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject currentCanvas = Instantiate(CanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        DontDestroyOnLoad(PieceCountainers.gameObject);

        deathText = currentCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        piecesText = currentCanvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(deathText.gameObject.transform.root);
    }



    private void Awake()
    {
        if (SINGLETON != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            SINGLETON = this;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
       
    }

    public void UpdatePiecesUI()
    {
        piecesCount++;
        piecesText.text = "Piece : " + piecesCount + " / " + PieceCountainers.transform.childCount;
    }

    private void UpdateDeathUI()
    {
        deathCount++;
        deathText.text = "Death : " + deathCount;
    }

    public void KillPlayer()
    {
        gameObject.SetActive(false);
        UpdateDeathUI();
        PM.canMove = false;
        PM.Rigidbody.velocity = new Vector3(0, 0, 0);
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(timeToRestart);
        SceneManager.LoadScene(0);
    }

    public void LoadData(GameData data)
    {
        this.deathCount = data.DeathCount;
    }

    public void SaveData(ref GameData data)
    {
        data.DeathCount = this.deathCount;
    }
}
