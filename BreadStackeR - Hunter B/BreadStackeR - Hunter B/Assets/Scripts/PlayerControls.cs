using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 10f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float footstepDelay = 0.2f;

    [SerializeField] private GameObject shieldObject;
    [SerializeField] private AudioSource shieldAudio;
    [SerializeField] private AudioClip shieldClip;
    [SerializeField] private AudioSource walkingAudio;
    [SerializeField] private AudioClip walkingClip;

    private Rigidbody2D rb2d;
    private bool footstepScheduled = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shieldObject.SetActive(false);
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        rb2d.velocity = new Vector2(xInput * currentSpeed, yInput * currentSpeed);

        // Footstep only triggers when moving and nothing already scheduled
        if ((xInput != 0 || yInput != 0) && !footstepScheduled)
        {
            PlayFootstep();
        }
        else if (xInput == 0 && yInput == 0 && walkingAudio.isPlaying)
        {
            walkingAudio.Stop();
        }

        // Shield plays once per click, not every frame
        if (Input.GetMouseButtonDown(0))
        {
            shieldObject.SetActive(true);
            shieldAudio.PlayOneShot(shieldClip);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            shieldObject.SetActive(false);
        }
    }

    void PlayFootstep()
    {
        StartCoroutine(PlayFootstepCoroutine());
    }

    IEnumerator PlayFootstepCoroutine()
    {
        footstepScheduled = true;
        yield return new WaitForSeconds(footstepDelay);
        walkingAudio.PlayOneShot(walkingClip);
        footstepScheduled = false;
    }
}