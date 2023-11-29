using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarrocaController : MonoBehaviour
{
    private List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { FindSockets();
            DisplaySocketInformation();
        }
    }

    void FindSockets()
    {
        // Limpa a lista de sockets antes de procurar novamente
        sockets.Clear();

        // Encontra todos os XR Socket Interactors no objeto
        sockets.AddRange(GetComponentsInChildren<XRSocketInteractor>());
    }

    void DisplaySocketInformation()
    {
        int errors = 0;
        foreach (XRSocketInteractor socket in sockets)
        {
            Debug.Log("Socket: " + socket.name);

            if (socket.selectTarget != null)
            {
                // Se o socket está ocupado, exibe informações sobre o objeto montado
                GameObject objetoMontado = socket.selectTarget.gameObject;
                Debug.Log("--------Objeto montado: " + objetoMontado.name);
                Debug.Log("--------TAG -> Objeto montado: " + objetoMontado.CompareTag("roda"));
                Debug.Log("--------TAG -> socket: " + socket.tag);

                if (!objetoMontado.CompareTag(socket.tag))
                {
                    errors++;
                }
                
            }
            else
            {
                Debug.Log("--------Nenhum objeto montado no socket");
                errors++;
            }
        }

        Debug.Log("----------------------------------" );
        Debug.Log("Total de peças mal montadas: " + errors);
    }

    void findErrors()
    {

    }
}
