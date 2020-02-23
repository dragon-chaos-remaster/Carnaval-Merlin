using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    Rigidbody fisica;
    public Transform flecha;
    public float velocidadeProjetil;

    float tempoViva = 0;
    float tempoAtual = 1;
    public float tempoDestruicao;

    public GameObject hitFlecha;
    public Transform ondeNasce;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        flecha = GetComponent<Transform>();

        fisica.AddForce(flecha.forward * velocidadeProjetil);

    }

    // Update is called once per frame
    void Update()
    {
        tempoViva += tempoAtual * Time.deltaTime;
        if (tempoViva >= tempoDestruicao)
        {
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Instantiate(hitFlecha, ondeNasce.position, ondeNasce.rotation);
            Destroy(gameObject);

        }

    }
}
