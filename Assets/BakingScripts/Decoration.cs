using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base class for all decorations that can be added to a pastry. The idea will
 * be that every decoration will have a unique way to attach to a pastry and
 * will have a unique tag used for testing a submission.
 */
abstract public class Decoration : MonoBehaviour
{
    abstract public void attachToPastry(GameObject pastry);
}
