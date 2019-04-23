using UnityEngine;
using System.Collections;

public class StarSpeed : MonoBehaviour
{
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public float WinSpeed = 50;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }
    public void WinVelo()
    {
        var main = ps.main;
        main.simulationSpeed = WinSpeed;
        var main2 = ps2.main;
        main2.simulationSpeed = WinSpeed;
    }
}
    