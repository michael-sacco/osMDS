using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementSoundController : MonoBehaviour
{
    [SerializeField] private PlayerController2D playerController;
    private AudioSource audioSource;
    private float audioSourceVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSourceVolume = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = audioSourceVolume * (0.8f * (playerController.Speed01 * playerController.Speed01) + 0.2f);
        audioSource.pitch = 1.0f - (0.5f - playerController.Speed01) * 0.2f;
    }
}
