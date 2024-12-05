using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Vector3 posicaoAberta;
    public Vector3 posicaoFechada;
    public float velocidade = 2f;
    private bool jogadorProximo = false;

    public AudioClip somAbrindo;
    public AudioClip somFechando;
    private AudioSource audioSource;

    private bool jaTocouSomFechando = false;

    private void Start()
    {
        transform.localPosition = posicaoFechada;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (jogadorProximo)
        {
            if (audioSource != null && !audioSource.isPlaying && somAbrindo != null)
            {
                audioSource.Stop();
                audioSource.clip = somAbrindo;
                audioSource.Play();
            }

            transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, posicaoAberta, Time.deltaTime * velocidade);

            jaTocouSomFechando = false;
        }
        else
        {
            if (audioSource != null && !audioSource.isPlaying && somFechando != null && !jaTocouSomFechando)
            {
                audioSource.Stop();
                audioSource.clip = somFechando;
                audioSource.Play();
                jaTocouSomFechando = true;
            }

            transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, posicaoFechada, Time.deltaTime * velocidade);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jogadorProximo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jogadorProximo = false;
        }
    }
}
