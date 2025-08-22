using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;


/*References:
Title: You can (FINALLY) Use Shadergraph for UI - Unity Health Bar Tutorial [Video]
Author: Sasquatch B Studios
Date: 2025, January 16
Code version: 6000.0.51f1
Availability: https://www.youtube.com/watch?v=9loSIyth5aU
*/

public class HealthBar : MonoBehaviour
{
    //put the following into player script when able to
    [Header("Input System")]
    [SerializeField] public InputActionAsset inputActions;

    [Header("Input system settings")]
    private InputAction m_HealthDrainButton;

    [SerializeField] private Image healthBarFill;
    [SerializeField] private Image healthBarTrailingFill;
    [SerializeField] private float trailDelay = 0.4f;

    [SerializeField] private float maxHealth;

    private float currentHealth;

    //put following into player script when able to
    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        m_HealthDrainButton = InputSystem.actions.FindAction("HealthDrainDemo");

        currentHealth = maxHealth;

        healthBarFill.fillAmount = 1f;
        healthBarTrailingFill.fillAmount = 1f;
    }

    private void Update()
    {
        if (m_HealthDrainButton.WasPerformedThisFrame())
        {
            HealthBarDrain();
        }
    }

    private void HealthBarDrain()
    {
        currentHealth -= 10f;
        float ratio = currentHealth / maxHealth;

        Sequence healthSequence = DOTween.Sequence();
        healthSequence.Append(healthBarFill.DOFillAmount(ratio, 0.25f))
            .SetEase(Ease.InOutSine);
        healthSequence.AppendInterval(trailDelay);
        healthSequence.Append(healthBarTrailingFill.DOFillAmount(ratio, 0.3f))
            .SetEase(Ease.InOutSine);

        healthSequence.Play();
    }
}
