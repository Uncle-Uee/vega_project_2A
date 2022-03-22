using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    #region UNITY METHODS

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Enter - {other.gameObject.name}");
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Stay - {other.gameObject.name}");
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Exit - {other.gameObject.name}");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Enter - {other.name}");
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Stay - {other.name}");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Exit - {other.name}");
    }

    #endregion
}