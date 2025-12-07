using UnityEngine;
using UnityEngine.Playables;

public class TimelineIntroController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Drag your Alien object with an Animator Component here")]
    public Animator alienAnimator;

    [Tooltip("Drag your PlayableDirector here")]
    public PlayableDirector director;
    
    [Tooltip("Drag the Component that has the AlienController script")]
    public MonoBehaviour alienControllerScript;

    [Tooltip("Drag your TimlineIntroText object here")]
    public GameObject introOverlay;

    [Tooltip("Drag your GameplayText object here")]
    public GameObject gameplayOverlay;

    private void Start()
    {
        // Show intro UI
        if (introOverlay != null)
            introOverlay.SetActive(true);

        // Hide gameplay UI
        if (gameplayOverlay != null)
            gameplayOverlay.SetActive(false);

        // Disable gameplay attack during intro
        if (alienControllerScript != null)
           alienControllerScript.enabled = false;

        // Start running
        alienAnimator.SetBool("IsRunning", true);

        // Play the Timeline
        director.Play();
        director.stopped += OnIntroFinished;
    }

    private void OnIntroFinished(PlayableDirector d)
    {
        director.stopped -= OnIntroFinished;

        // Back to idle
        alienAnimator.SetBool("IsRunning", false);

        // Hide intro UI
        if (introOverlay != null)
            introOverlay.SetActive(false);

        // Show gameplay UI
        if (gameplayOverlay != null)
            gameplayOverlay.SetActive(true);

        // Enable gameplay (Tab attack)
        if (alienControllerScript != null)
            alienControllerScript.enabled = true;
    }
}
