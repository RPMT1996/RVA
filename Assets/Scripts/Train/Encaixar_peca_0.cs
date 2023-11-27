using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encaixar_peca_0 : MonoBehaviour
{
    // Ponto específico onde o objeto deve ligar
    public Transform pontoDeConexao;

    // Distância máxima para ligar
    //TEMOS QUE VER
    public float distanciaMaxima = 0.5f;

    // Verifica se um objeto está conectado
    private bool estaConectado = false;

    // Referência para o objeto conectado 
    private GameObject objetoConectado;

    void Update()
    {

        TentarEncaixar();

    }

    void TentarEncaixar()
    {
        if (!estaConectado)
        {
            Collider[] colliders = Physics.OverlapSphere(pontoDeConexao.position, distanciaMaxima);

            foreach (Collider collider in colliders)
            {
                // Verifica se o objeto pode ser conectado 
                if (collider.gameObject.CompareTag("peca_0"))
                {
                    // Encaixa o objeto
                    Conectar(collider.gameObject);
                    break;
                }
            }
        }
        else
        {
            // Desconecta o objeto
            Desconectar();
        }
    }

    void Conectar(GameObject objeto)
    {
        objeto.transform.position = pontoDeConexao.position;
        objeto.transform.rotation = pontoDeConexao.rotation;

        // Desativa a física do objeto para evitar problemas de colisão
        objeto.GetComponent<Rigidbody>().isKinematic = true;

        // Atualiza o estado da conexão
        estaConectado = true;
        objetoConectado = objeto;

    }

    void Desconectar()
    {

        // Ativa a física do objeto
        objetoConectado.GetComponent<Rigidbody>().isKinematic = false;

        // Atualiza o estado da conexão
        estaConectado = false;
        objetoConectado = null;

    }
}
