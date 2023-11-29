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
            // Verificar se a roda est� pr�xima do ponto de encaixe
            float distancia = Vector3.Distance(transform.position, pontoDeMontagem.position);

            // Calcula a diferen�a de rota��o em todos os eixos
            float anguloDiferenca = Quaternion.Angle(transform.rotation, pontoDeMontagem.rotation);

            // Adicione essas linhas para depura��o
            Debug.Log("Dist�ncia: " + distancia);
            Debug.Log("�ngulo Diferen�a: " + anguloDiferenca);

            // Verificar se a roda est� na posi��o correta
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
