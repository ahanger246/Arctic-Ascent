using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Transform dest;
    [SerializeField] private GameObject pointA, pointB;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] private char direction;

    // Start is called before the first frame update
    void Start() {
        dest = pointA.transform;
    }

    // Update is called once per frame
    void Update() {
        Vector2 point = dest.position - transform.position;

        if (direction == 'X') {
            if (dest == pointB.transform) {
                body.velocity = new Vector2(moveSpeed, 0);
            }
            else {
                body.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        else {
            if (dest == pointB.transform) {
                body.velocity = new Vector2(0, -moveSpeed);
            }
            else {
                body.velocity = new Vector2(0, moveSpeed);
            }
        }

        if (Vector2.Distance(transform.position, dest.position) < 0.5f && dest == pointB.transform) {
            flip();
            dest = pointA.transform;
        }
        if(Vector2.Distance(transform.position, dest.position) < 0.5f && dest == pointA.transform) {
            flip();
            dest = pointB.transform;
        }
    }

    private void flip() {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(pointA.transform.position, 1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 1f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}