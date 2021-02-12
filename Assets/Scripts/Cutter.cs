using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    // Extreme points
    private float floorY = 0.3f;
    private float leftX = -3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            animator.SetTrigger("StartCutter");
            if (!audio.isPlaying)
            {
                audio.Play();
            }

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                MoveObjectFromInput(touch.position);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                animator.SetTrigger("StopCutter");
                audio.Stop();
            }
        }
    }

    private void FixedUpdate()
    {
        // Move for editor
        //MoveObjectFromInput(Input.mousePosition);
    }

    private void MoveObjectFromInput(Vector3 input)
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(input);

        // Interpolate screen position to local position
        pos.x = Mathf.Lerp(-4f, 4f, pos.x);
        pos.y = Mathf.Lerp(-1f, 3.5f, pos.y);

        // Extreme points, so that the object is always on the screen
        if (pos.y < floorY) pos.y = floorY;
        if (pos.x < leftX)  pos.x = leftX;

        transform.position = new Vector3(pos.x, pos.y, 0.0f);
    }
}
