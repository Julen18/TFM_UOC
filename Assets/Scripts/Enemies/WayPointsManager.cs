using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsManager : MonoBehaviour
{

    public class WayPoint
    {
        public int ID { get; set; }
        public Transform wayPoint { get; set; }
        public List<Transform> enemies { get; set; }
    }

    private WayPoint[] wayPoints;

    void Start()
    {
        Transform[] tChildren = GetComponentsInChildren<Transform>();
        wayPoints = new WayPoint[tChildren.Length -1];

        int i = 0;
        foreach(Transform t in tChildren)
        {
            if (t != transform)
            {
                WayPoint p = new WayPoint();
                p.ID = i;
                p.wayPoint = t;
                p.enemies = new List<Transform>();
                wayPoints[i] = p;
                i++;
            }
        }
    }

    public NextWayPoint GetNextWayPoint(Transform t, int lastWayPoint)
    {
        int min = wayPoints[0].enemies.Count;
        List<int> ids = new List<int>();
        
        foreach (WayPoint w in wayPoints)
        {
            if (w.enemies.Count < min)
            {
                min = w.enemies.Count;
                ids = new List<int>();
                ids.Add(w.ID);
            }
            else if (w.enemies.Count == min)
            {
                ids.Add(w.ID);
            }
        }

        //int num = (int)Random.Range(0, ids.Count -1);
        int num = (int)Random.Range(0, ids.Count);
        wayPoints[ids[num]].enemies.Add(t);
        if (lastWayPoint != -1) wayPoints[lastWayPoint].enemies.Remove(t);

        NextWayPoint nWayPoint = new NextWayPoint();
        nWayPoint.idNextWaypoint = ids[num];
        nWayPoint.nextPoint = wayPoints[ids[num]].wayPoint;

        return nWayPoint;
    }

}
