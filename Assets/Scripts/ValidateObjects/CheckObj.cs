using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckObj : MonoBehaviour
{
    private List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();
    private string[] palavrasChave = { "carroca", "rena", "cavalo" };
    private bool objetoNaMesa = false;
    private bool carrocaMesa = false;
    private bool acabou = false;
    private int err = 0;
    public TimerController timerController;
    private string currentObjeto;
    private bool verificacao = false;
    public Text carrocaError;
    public GameObject horse;

    void Update()
    {
        if (carrocaMesa)
        {
            FindSockets();
            Errors();

            Debug.Log(acabou);
            if (acabou == true)
            {
                // Stop the timer if there are no errors
                timerController.StopTimer();
                // Display the number of errors in the Text component
                if (carrocaError != null)
                {
                    carrocaError.text = "Objeto bem montado";
                    carrocaError.color = Color.green;
                    horse.SetActive(true);
                }
            }
            else
            {
                if (err != 0)
                {
                    if (carrocaError != null)
                    {
                        carrocaError.text = "Erros no objecto: " + err;
                        carrocaError.color = Color.red;
                    }
                }

            }
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

        if (tagDoObjetoAssociado.Contains(palavrasChave[0]))
        {
            carrocaMesa = true;
        }
        else if (tagDoObjetoAssociado.Contains(palavrasChave[1]))
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
        if (other.CompareTag(palavrasChave[0]))
        {
            carrocaMesa = false;
            carrocaError.text = "";
        }
    }

    void Errors()
    {
        int erros = -1;
        foreach (XRSocketInteractor socket in sockets)
        {
            if (socket.selectTarget != null)
            {
                GameObject objetoMontado = socket.selectTarget.gameObject;
                // Obtém os sockets diretamente no objeto montado
                XRSocketInteractor[] socketsDoObjeto = objetoMontado.GetComponentsInChildren<XRSocketInteractor>();

                foreach (XRSocketInteractor socketDoObjeto in socketsDoObjeto)
                {
                    if (socketDoObjeto.selectTarget != null)
                    {
                        GameObject pecas = socketDoObjeto.selectTarget.gameObject;
                        Debug.Log("-------------------------------------------");
                        Debug.Log("--------Objeto montado: " + pecas.name);
                        Debug.Log("--------TAG -> Objeto montado: " + pecas.tag);
                        Debug.Log("--------TAG -> socket: " + socketDoObjeto.name + "------- " + socketDoObjeto.tag);
                        // Verifica se a tag do socket do objeto é igual à tag do socket na mesa
                        if (!socketDoObjeto.CompareTag(pecas.tag))
                        {
                            erros++;
                        }
                    }
                    else
                    {
                        erros++;
                    }

                }
                verificacao = true;
            }

        }

        Debug.Log(erros);

        if (erros == -1 && verificacao == true)
        {
            acabou = true;

        }
        else
        {
            acabou = false;
            err = erros + 1;

        }
    }
}