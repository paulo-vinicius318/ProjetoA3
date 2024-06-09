using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPedra : MonoBehaviour
{
    public GameObject pedraPrefab;

    public float delayInicial;

    public float delayEntrePedras;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GerarPedra", delayInicial, delayEntrePedras);
    }

    private void GerarPedra()
    {
        Instantiate(pedraPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
