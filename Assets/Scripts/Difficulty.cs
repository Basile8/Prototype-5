using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Difficulty : MonoBehaviour
{

    private Button difficultyButton;
    private GameManager gManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
    //    Debug.Log(difficultyButton.gameObject.name + " a ete sélectionne");
        gManager.titleScreen.SetActive(false);
        gManager.StartGame(difficulty);
    }
}
