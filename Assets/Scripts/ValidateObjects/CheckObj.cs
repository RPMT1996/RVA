using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckObj : MonoBehaviour
{
    private List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();
    private string[] palavrasChave = { "carroca", "cavalo", "comboio" };
    private bool carrocaMesa = false;
    private bool acabou = false;
    private int err = 0;
    public TimerController timerController;
    private bool verificacao = false;
    public Text carrocaError;
    public GameObject cavalo;
    public GameObject carroca;
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

        if (tagDoObjetoAssociado.Contains(palavrasChave[0]))
        {
            carrocaMesa = true;
        }

        if (carrocaMesa)
        {
            carrocaError.text = "";
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
                if (carrocaError != null)
                {
                    carrocaError.text = "Objeto bem montado";
                    carrocaError.color = Color.green;
                    cavalo.SetActive(true);
                    carroca.SetActive(false);
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
                // Obt�m os sockets diretamente no objeto montado
                XRSocketInteractor[] socketsDoObjeto = objetoMontado.GetComponentsInChildren<XRSocketInteractor>();

                foreach (XRSocketInteractor socketDoObjeto in socketsDoObjeto)
                {
                    if (socketDoObjeto.selectTarget != null)
                    {
                        GameObject pecas = socketDoObjeto.selectTarget.gameObject;
                        // Verifica se a tag do socket do objeto � igual � tag do socket na mesa
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