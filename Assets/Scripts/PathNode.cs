using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] PathNode nextPathNode;
    
    public PathNode GetNextPathNode() {
        return nextPathNode;
    }
}
