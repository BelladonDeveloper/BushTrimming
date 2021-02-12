using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLeafs : MonoBehaviour
{
    public GameObject leaf;

    public float step = 0.1f;

    void Start()
    {
        float x = transform.localScale.x / 2;
        float y = transform.localScale.y;

        for (float i = x; i > -x; i -= step)
        {
            for (; y > 0.5f; y -= step)
            {
                float random = Random.Range(-0.2f, 0.2f);

                Instantiate(leaf, new Vector3(i + step, y + step * 2, 0f), 
                    Quaternion.Euler(random * 633f, 0, 0));
            }
            y = transform.localScale.y;
        }
    }
}
