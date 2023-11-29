using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontarRodas : MonoBehaviour
{
    public Transform pontoDeMontagem;
    public float toleranciaDistancia = 0.1f;
    public float toleranciaRotacao = 2f;

    private bool montada = false;

    void Update()
    {
        if (!montada)
        {
            // Verificar se a roda está próxima do ponto de encaixe
            float distancia = Vector3.Distance(transform.position, pontoDeMontagem.position);

            // Calcula a diferença de rotação em todos os eixos
            float anguloDiferenca = Quaternion.Angle(transform.rotation, pontoDeMontagem.rotation);

            // Adicione essas linhas para depuração
            Debug.Log("Distância: " + distancia);
            Debug.Log("Ângulo Diferença: " + anguloDiferenca);

            // Verificar se a roda está na posição correta
            bool posicaoCorreta = distancia <= toleranciaDistancia && anguloDiferenca <= toleranciaRotacao;

            if (posicaoCorreta)
            {
                montada = true;
                ConectarRoda();
            }
        }
    }

    void ConectarRoda()
    {
        transform.parent = pontoDeMontagem;
    }
}
