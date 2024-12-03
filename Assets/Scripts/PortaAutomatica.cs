using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Vector3 posicaoAberta; 
    public Vector3 posicaoFechada; 
    public float velocidade = 2f;
    public Vector3 posicaoPorta;
    private bool jogadorProximo = false; 

    private void Start()
    {
        transform.localPosition = posicaoFechada;
    }


    private void Update()
    {


        if (jogadorProximo) 
        { 
        
            transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, posicaoAberta, Time.deltaTime * velocidade);
        }
        else
        {
            transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, posicaoFechada, Time.deltaTime * velocidade);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jogadorProximo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    { 
    
        if (other.gameObject.tag == "Player")
        {
        
            jogadorProximo = false;
        }
    }
}
