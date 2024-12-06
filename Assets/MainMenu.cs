using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void IniciarJogo()
    {
        Debug.Log("O botão Play foi clicado!");
        SceneManager.LoadScene("Doom");
    }
}