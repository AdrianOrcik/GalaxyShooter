using UnityEngine;

public class EnemyPathBehaviour : MonoBehaviour
{
    public EdgeCollider2D[] Paths;

    public EdgeCollider2D GetPath(int id)
    {
        if (id < Paths.Length)
        {
            return Paths[id];
        }

        return null;
    }
}