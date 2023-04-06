using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject obj;
    

    public void ExplosionPlay()
    {
        GameObject explosion = Instantiate(obj);
        explosion.transform.position = transform.position;
    }
}
