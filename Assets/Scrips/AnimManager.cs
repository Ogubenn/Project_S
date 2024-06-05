using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator animator; // Animator bile�eni
    public float speed; // Karakterin h�z�
    public float walkSpeedThreshold = 0.1f; // Y�r�me animasyonuna ge�i� i�in h�z e�i�i

    void Update()
    {
        speed = Input.GetAxis("Vertical");

        // Animator parametresini ayarlay�n
        animator.SetFloat("speed", Mathf.Abs(speed));
    }
}
