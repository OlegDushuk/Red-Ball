using UnityEngine;

namespace _Project.Scripts
{
  public class Key : MonoBehaviour
  {
    [SerializeField] private GameObject particle;
    
    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.TryGetComponent<Player>(out var player)) return;
      player.AddKey();
      Destroy(gameObject);
      Instantiate(particle, transform.position, Quaternion.identity);
    }
  }
}