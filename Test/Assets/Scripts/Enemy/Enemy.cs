using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Initialized(Transform player);

    //public static Vector2 FindRoad(Vector3 player, Vector3 enemy)
    //{
    //    Vector2 direction = Vector2.zero;
    //    RaycastHit2D hit = Physics2D.Raycast(enemy, player - enemy, Vector2.Distance(player, enemy), _obstacle);
    //    Debug.DrawRay(enemy, player - enemy, Color.red);
    //    if (hit.collider == null)
    //    {
    //        Debug.Log("Default");
    //        direction = player - enemy;
    //    }
    //    else
    //    {
    //        if (Vector2.Distance(enemy, hit.point) < DistanceToFlip)
    //        {
    //            Vector3 up = new Vector3(enemy.x, enemy.y + 5f, 0);
    //            Vector3 down = new Vector3(enemy.x, enemy.y - 5f, 0);
    //            Vector3 right = new Vector3(enemy.x + 5f, enemy.y, 0);
    //            Vector3 left = new Vector3(enemy.x - 5f, enemy.y, 0);
    //            RaycastHit2D hitUp = Physics2D.Raycast(up, player - up, Vector2.Distance(player, up), _obstacle);
    //            Debug.Log("Up");
    //            if (hitUp.collider == null)
    //                direction = up - enemy;
    //            else
    //            {
    //                Debug.Log("Down");
    //                RaycastHit2D hitDown = Physics2D.Raycast(down, player - down, Vector2.Distance(player, down), _obstacle);
    //                if (hitDown.collider == null)
    //                    direction = down - enemy;
    //                else
    //                {
    //                    Debug.Log("Right");
    //                    RaycastHit2D hitRight = Physics2D.Raycast(right, player - right, Vector2.Distance(player, right), _obstacle);
    //                    if (hitRight.collider == null)
    //                        direction = right - enemy;
    //                    else
    //                    {
    //                        Debug.Log("Left");
    //                        RaycastHit2D hitLeft = Physics2D.Raycast(left, player - left, Vector2.Distance(player, left), _obstacle);
    //                        if (hitLeft.collider == null)
    //                            direction = left - enemy;
    //                        else
    //                        {
    //                            Vector3 doubleUp = new Vector3(enemy.x, enemy.y + 10f, 0);
    //                            Vector3 doubleDown = new Vector3(enemy.x, enemy.y - 10f, 0);
    //                            Vector3 doubleRight = new Vector3(enemy.x + 10f, enemy.y, 0);
    //                            Vector3 doubleLeft = new Vector3(enemy.x - 10f, enemy.y, 0);
    //                            Debug.Log("DoubleUp");
    //                            RaycastHit2D hitDoubleUp = Physics2D.Raycast(doubleUp, player - doubleUp, Vector2.Distance(player, doubleUp), _obstacle);
    //                            if (hitDoubleUp.collider == null)
    //                                direction = doubleUp - enemy;
    //                            else
    //                            {
    //                                Debug.Log("DoubleDown");
    //                                RaycastHit2D hitDoubleDown = Physics2D.Raycast(doubleDown, player - doubleDown, Vector2.Distance(player, doubleDown), _obstacle);
    //                                if (hitDoubleDown.collider == null)
    //                                    direction = doubleDown - enemy;
    //                                else
    //                                {
    //                                    Debug.Log("DoubleRight");
    //                                    RaycastHit2D hitDoubleRight = Physics2D.Raycast(doubleRight, player - doubleRight, Vector2.Distance(player, doubleRight), _obstacle);
    //                                    if (hitDoubleRight.collider == null)
    //                                        direction = doubleRight - enemy;
    //                                    else
    //                                    {
    //                                        Debug.Log("DoubleLeft");
    //                                        RaycastHit2D hitDoubleLeft = Physics2D.Raycast(doubleLeft, player - doubleLeft, Vector2.Distance(player, doubleLeft), _obstacle);
    //                                        if (hitDoubleLeft.collider == null)
    //                                            direction = doubleLeft - enemy;
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        else direction = player - enemy;
    //    }

    //    return direction;
    //}

}
