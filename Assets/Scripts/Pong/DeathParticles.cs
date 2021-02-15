using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    private ParticleSystem deathParticles;
    // Start is called before the first frame update
    void Start()
    {
        deathParticles = this.gameObject.GetComponent<ParticleSystem>();
    }

    public void PlayDeathParticles (Vector3 deathPosition)
    {
        this.transform.position = deathPosition;
        deathParticles.Play();
    }
}
