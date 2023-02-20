using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
  private Rigidbody rb;
  private AudioSource audioSource;

  [SerializeField] float mainThrust = 1000f;
  [SerializeField] float rotationThrust = 45f;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    ProcessInput();
  }

  void ProcessInput()
  {
    ProcessThrust();
    ProcessRotation();
  }

  /// <summary>
  /// 
  /// </summary>
  void ProcessThrust()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
      if (!audioSource.isPlaying)
      {
        audioSource.Play();
      }
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      if (audioSource.isPlaying)
      {
        audioSource.Stop();
      }
    }
  }

  /// <summary>
  /// 
  /// </summary>
  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ApplyRotation(rotationThrust);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ApplyRotation(-rotationThrust);
    }
  }

  void ApplyRotation(float rotateThisFrame)
  {

    // freezing rotation to apply manual rotation

    rb.freezeRotation = true;

    Vector3 rotation = rotateThisFrame * Time.deltaTime * Vector3.forward;
    transform.Rotate(rotation);

    // un-freezing rotation
    rb.freezeRotation = false;
  }
}
