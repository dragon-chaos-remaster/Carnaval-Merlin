using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public float duracao = 1f;
    float duracaoPendente = 0;
    bool isFrozen = false;
  
    void Update()
    {
        if(duracaoPendente < 0 && !isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }

    public void Congelar()
    {
        duracaoPendente = duracao;
    }

    IEnumerator DoFreeze()
    {
        isFrozen = true;
        var original = Time.timeScale;
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(duracao);

        duracaoPendente = 0;
        isFrozen = false;
    }
}
