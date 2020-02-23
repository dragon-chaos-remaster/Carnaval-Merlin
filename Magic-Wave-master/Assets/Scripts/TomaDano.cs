using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    public int vida = 100;

    // Start is called before the first frame update

    private void Start()
    {

    }
    public void TomarDanos(int quantidade)
    {
        vida -= quantidade;
        if (vida <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }
}
