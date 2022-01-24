using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManagement : MonoBehaviour
{
    public static bool hasHitTop(Collision2D collision) {
        return new ArrayList{Direction.UP, Direction.DOWN}.Contains(collisionDirection(collision));
    }

    private static Direction collisionDirection(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Collider2D playerCollider = collision.otherCollider;
        Direction direction = Direction.UP;
        
        float RectWidth = playerCollider.bounds.size.x - 2;
        float RectHeight = playerCollider.bounds.size.y - 2;
        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collider.bounds.center;

        if (contactPoint.y > center.y && //checks that circle is on top of rectangle
            (contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2))
        {
            direction = Direction.UP;
        }
        else if (contactPoint.y < center.y &&
            (contactPoint.x < center.x + RectWidth / 2 && contactPoint.x > center.x - RectWidth / 2))
        {
            direction = Direction.DOWN;

        }
        else if (contactPoint.x > center.x &&
            (contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2))
        {
            direction = Direction.RIGHT;

        }
        else if (contactPoint.x < center.x &&
            (contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2))
        {
            direction = Direction.LEFT;

        }

        return direction;
    }
}
