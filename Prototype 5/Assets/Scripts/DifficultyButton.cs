using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDIfficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void SetDIfficulty()
    {
        gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
