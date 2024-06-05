using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator animator; // Animator bileþeni
    public float speed; // Karakterin hýzý
    public float walkSpeedThreshold = 0.1f; // Yürüme animasyonuna geçiþ için hýz eþiði

    void Update()
    {
        speed = Input.GetAxis("Vertical");

        // Animator parametresini ayarlayýn
        animator.SetFloat("speed", Mathf.Abs(speed));
    }
}
