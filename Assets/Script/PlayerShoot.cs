
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Animator animator;
    public GameObject shot;

    private Animator shotAnimator;

    public int municao = 28;
    public int municaoMaxima = 28;

    void Start()
    {
        shotAnimator = shot.GetComponent<Animator>();
        shot.SetActive(false);
    }

    void Update()
    {
        // ATIRAR
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (municao > 0)
            {
                municao--;

                Debug.Log("Munição restante: " + municao);

                animator.Play("shot_gangster");

                shot.SetActive(true);

                shotAnimator.Play("shot_animation");

                CancelInvoke("EsconderShot");
                Invoke("EsconderShot", 0.3f);
            }
            else
            {
                Debug.Log("SEM MUNIÇÃO!");
            }
        }

        // RECARREGAR COM R
        if (Keyboard.current.rKey.wasPressedThisFrame && municao < municaoMaxima)
        {
            municao = municaoMaxima;

            Debug.Log("Munição recarregada!");
        }
    }

    void EsconderShot()
    {
        shot.SetActive(false);
    }
}


