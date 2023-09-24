// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// Keeps track of the business logic in the game.
// Initializing a level, along with other state changes, such as game over or restarting the game. Keep track of scores and timer.

// public class GameManager : MonoBehaviour
// {
//     protected LineRenderer line;
//     protected Apple Apple;
//     public Text Text;
//     protected int Hits = 0;
//     protected NormalBall[] balls;

//     // Use this for initialization
//     void Start()
//     {
//         line = FindObjectOfType<LineRenderer>();
//         apple = FindObjectOfType<Apple>();
//         pebble = FindObjectsOfType<Pebble>();
//         worms = FindObjectsOfType<Worm>();
//         Text.text = "Hits: " + Hits;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         var direction = Vector3.zero;

//         if (Physics.Raycast(ray, out hit))
//         {
//             var applePos = new Vector3(
//                 Apple.transform.position.x,
//                 0.1f,
//                 Apple.transform.position.z
//             );
//             var mousePos = new Vector3(hit.point.x, 0.1f, hit.point.z);
//             line.SetPosition(0, mousePos);
//             line.SetPosition(1, ballPos);
//             direction = (mousePos - applePos).normalized;
//         }

//         if (Input.GetMouseButtonDown(0) && line.gameObject.activeSelf)
//         {
//             Hits++;
//             Text.text = "Hits: " + Hits;
//             line.gameObject.SetActive(false);
//             Apple.GetComponent<Rigidbody>().velocity = direction * 10f;
//         }

//         if (
//             !line.gameObject.activeSelf && Apple.GetComponent<Rigidbody>().velocity.magnitude < 0.3f
//         )
//         {
//             line.gameObject.SetActive(true);
//         }
//     }

//     // public void Reset()
//     // {
//     //     Apple.ResetBall();
//     //     foreach (var ball in balls)
//     //     {
//     //         ball.gameObject.SetActive(true);
//     //         ball.ResetBall();
//     //     }
//     //     Hits = 0;
//     // }
// }
