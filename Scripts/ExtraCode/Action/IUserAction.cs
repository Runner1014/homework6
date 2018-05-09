using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction : int { forward, backward, left, right }

public interface IUserAction
{
    //void movePlayer(Direction direction, float speed);
    //void changeDirection(float offsetX);
    //void stopPlayer();
    bool getGameOver();
}