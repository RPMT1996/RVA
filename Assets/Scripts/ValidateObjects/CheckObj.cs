using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckObj : MonoBehaviour
{
    private List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();
    private bool objetoNaMesa = false;
    private int err;
    private string currentObjeto;

    void Update()
    {
        if (objetoNaMesa)
        {
            FindSockets();
            Errors();
        }
    }

    void FindSockets()
    {
        sockets.Clear();
        sockets.AddRange(GetComponentsInChildren<XRSocketInteractor>());
    }

    void OnTriggerEnter(Collider other)
    {
        string tagDoObjetoAssociado = other.tag;
        string[] palavrasChave = { "carroca", "rena", "cavalo" };

        if (tagDoObjetoAssociado.Contains(palavrasChave[0]))
        {
            objetoNaMesa = true;
            currentObjeto = palavrasChave[0];
        }else if(tagDoObjetoAssociado.Contains(palavrasChave[1]))
        {
            objetoNaMesa = true;
            currentObjeto = palavrasChave[1];
        }
        else if (tagDoObjetoAssociado.Contains(palavrasChave[2]))
        {
            objetoNaMesa = true;
            currentObjeto = palavrasChave[2];
        }
    }

    void OnTriggerExit(Collider other)
    {
        objetoNaMesa = false;
        currentObjeto = null;
    }

    void Errors()
    {
        err = 0;
        foreach (XRSocketInteractor socket in sockets)
        {
            if (socket.selectTarget != null)
            {
                GameObject objetoMontado = socket.selectTarget.gameObject;
                // Obtém os sockets diretamente no objeto montado
                XRSocketInteractor[] socketsDoObjeto = objetoMontado.GetComponentsInChildren<XRSocketInteractor>();

                foreach (XRSocketInteractor socketDoObjeto in socketsDoObjeto)
                {
                    if(socketDoObjeto.selectTarget != null)
                    {
                        GameObject pecas = socketDoObjeto.selectTarget.gameObject;
                        Debug.Log("-------------------------------------------");
                        Debug.Log("--------Objeto montado: " + pecas.name);
                        Debug.Log("--------TAG -> Objeto montado: " + pecas.tag);
                        Debug.Log("--------TAG -> socket: " + socketDoObjeto.name+"------- " + socketDoObjeto.tag);
                        // Verifica se a tag do socket do objeto é igual à tag do socket na mesa
                        if (!socketDoObjeto.CompareTag(pecas.tag))
                        {
                            err++;
                        }
                    }else
                    {
                        err++;
                    }
                   
                }
            }
            
        }

        if (err == 0)
        {
            Debug.Log("Montado com sucesso!");
        }

        Debug.Log("----------------------------------");
        Debug.Log("Objeto: " + currentObjeto + "\nTotal de peças mal montadas: " + err);
    }
}
