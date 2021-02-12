using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private AudioSource audio;

    private float forceUp = 2f;
    private bool isRigidbody = false;

    void Start()
    {
        isRigidbody = TryGetComponent<Rigidbody>(out rigidbody);
        audio = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isRigidbody)
            {
                rigidbody.isKinematic = false;
            }
            if (!audio.isPlaying)
            {
                audio.Play();
            }

            // Throw object up
            rigidbody.AddForce(Vector3.up * forceUp, ForceMode.Impulse);

            // Turn object by random
            //float randomAngular = Random.Range(-3, 3);
            //rigidbody.angularVelocity = Vector3.one * randomAngular;

            Destroy(gameObject, 3f);
        }
    }
}
