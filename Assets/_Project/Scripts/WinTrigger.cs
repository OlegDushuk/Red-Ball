using UnityEngine;

namespace _Project.Scripts
{
  public class WinTrigger : MonoBehaviour
  {
    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.TryGetComponent<Player>(out var player)) return;
      player.Win();
    }
  }
}