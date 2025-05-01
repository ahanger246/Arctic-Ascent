using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start() {
        timerText.text = Timer.timer.ToString("F2") + " seconds";
    }

    public void ReturnToStart() {
        SceneManager.LoadScene(0);
    }
}
