using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PenguinCounter : MonoBehaviour
{
    public int penguinCount;
    public TMP_Text penguinText;
    public TMP_Text penguinGoal;

    [SerializeField] private int goal;
    [SerializeField] private GameObject block;

    void Start() { 
        penguinGoal.text = "/" + goal;
        penguinCount = 0;
    }
    
    // Update is called once per frame
    void Update() {
        penguinText.text = ":" + penguinCount.ToString();

        if (penguinCount == goal) {
            block.SetActive(false);
        }
    }
}
