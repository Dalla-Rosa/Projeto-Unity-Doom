using System;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPos;
    private Vector3 targetDir;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private float angle;
    public int lastIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Tenta encontrar o jogador
        var playerObj = FindFirstObjectByType<PlayerMovement>();
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("PlayerMovement não encontrado na cena.");
            return; // Interrompe para evitar erros.
        }

        // Tenta pegar o SpriteRenderer
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer não encontrado no objeto ou nos filhos.");
        }

        // Verifica se os sprites foram atribuídos
        if (sprites == null || sprites.Length == 0)
        {
            Debug.LogError("Sprites não atribuídos no inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || spriteRenderer == null || sprites == null || sprites.Length == 0)
        {
            return; // Evita continuar se algo estiver faltando.
        }

        // Get Target Position and Direction
        targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;

        // Get Angle
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        // Flip Sprite if needed
        Vector3 tempScale = spriteRenderer.transform.localScale;
        tempScale.x = Mathf.Abs(tempScale.x) * (angle > 0 ? -1f : 1f);
        spriteRenderer.transform.localScale = tempScale;

        // Get Index and Update Sprite
        lastIndex = GetIndex(angle);

        if (lastIndex >= 0 && lastIndex < sprites.Length)
        {
            spriteRenderer.sprite = sprites[lastIndex];
        }
    }

    private int GetIndex(float angle)
    {
        // front
        if (angle > -22.5f && angle < 22.6f)
            return 0;
        if (angle >= 22.5f && angle < 67.5f)
            return 7;
        if (angle >= 67.5f && angle < 112.5f)
            return 6;
        if (angle >= 112.5f && angle < 157.5f)
            return 5;

        // back
        if (angle <= -157.5f || angle >= 157.5f)
            return 4;
        if (angle >= -157.4f && angle < -112.5f)
            return 3;
        if (angle >= -112.5f && angle < -67.5f)
            return 2;
        if (angle >= -67.5f && angle <= -22.5f)
            return 1;

        return lastIndex; // Mantém o último índice como fallback.
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
