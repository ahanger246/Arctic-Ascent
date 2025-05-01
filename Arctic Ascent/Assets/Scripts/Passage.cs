using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private LevelTransition transition;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            transition.nextLevel();
        }
    }
}
