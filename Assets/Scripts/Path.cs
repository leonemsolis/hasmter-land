using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] PathNode currentPathNode;    
    
    public PathNode GetNextPathNode() {
        PathNode toReturn = currentPathNode;
        currentPathNode = currentPathNode.GetNextPathNode();
        return toReturn;
    }
}
