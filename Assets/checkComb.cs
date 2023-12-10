using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class checkComb : MonoBehaviour
{
    private List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();
    private string[] palavrasChave = { "carroca", "Comboio", "Cavalo" };
    private bool comboioMesa = false;
    private bool acabou = false;
    private int err = 0;
    public TimerController timerController;
    private bool verificacao = false;
    public Text comboioError;
    public AudioClip rightAnswerSound;
    public AudioClip wrongAnswerSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FindSockets()
    {
        sockets.Clear();
        sockets.AddRange(GetComponentsInChildren<XRSocketInteractor>());
    }

    void OnTriggerEnter(Collider other)
    {
        string tagDoObjetoAssociado = other.tag;

        if (tagDoObjetoAssociado.Contains(palavrasChave[1]))
        {
            comboioMesa = true;
        }

        if (comboioMesa)
        {
            comboioError.text = "";
            acabou = false;
            verificacao = false;
            FindSockets();
            Errors();

            if (acabou == true)
            {
                // Stop the timer if there are no errors
                timerController.StopTimer();
                audioSource.clip = rightAnswerSound;
                audioSource.Play();
                // Display the number of errors in the Text component
                if (comboioError != null)
                {
                    comboioError.text = "Objeto bem montado";
                    comboioError.color = Color.green;
                }
            }
            else
            {
                if (err != 0)
                {
                    if (comboioError != null)
                    {
                        comboioError.text = "Erros no objecto: " + err;
                        comboioError.color = Color.red;
                        audioSource.clip = wrongAnswerSound;
                        audioSource.Play();
                    }
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(palavrasChave[0]))
        {
            comboioMesa = false;
            comboioError.text = "";
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
