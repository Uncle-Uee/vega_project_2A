using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    #region UNITY METHODS

    #region 3D COLLISION

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Enter - {other.gameObject.name}");
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Stay - {other.gameObject.name}");
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) print($"On Collision Exit - {other.gameObject.name}");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Enter - {other.name}");
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Stay - {other.name}");
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) print($"On Trigger Exit - {other.name}");
    }

    #endregion


    #region 2D COLLISION

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

    #endregion
}