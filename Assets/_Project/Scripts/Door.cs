using UnityEngine;

namespace _Project.Scripts
{
  public class Door : MonoBehaviour
  {
    private Animator animator;
    private static readonly int Error = Animator.StringToHash("Error");
    private static readonly int Open = Animator.StringToHash("Open");
    
    private void Awake()
    {
      animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
      if (!other.gameObject.TryGetComponent<Player>(out var player)) return;
      if (!player.IsAllKeys)
      {
        animator.SetTrigger(Error);
        return;
      }
      animator.SetTrigger(Open);
    }
  }
}