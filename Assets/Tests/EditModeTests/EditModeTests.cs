using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTests : MonoBehaviour
{
    [Test]
    public void SimpleEditorTest()
    {
        Debug.Log("First Test.");
        Assert.That(5 * 20, Is.EqualTo(100));
    }

    [Test]
    public void SimpleEditorTestShouldFail()
    {
        Debug.Log("Here is test two.");
        Assert.That(3, Is.InRange(5, 10));
    }
}