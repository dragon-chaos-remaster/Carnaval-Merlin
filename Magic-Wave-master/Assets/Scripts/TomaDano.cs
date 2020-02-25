using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    public int vida = 100;

    public BarraDeVida barraVida;
    
    // Start is called before the first frame update

    private void Start()
    {
        //barraVida = GetComponentInChildren<BarraDeVida>();
        barraVida.SetVidaMaxima(vida);
    }
    public void TomarDanos(int quantidade)
    {
        vida -= quantidade;

        barraVida.SetVida(vida);
        if (vida <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }
}
