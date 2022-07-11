using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PracticeTests
{
    private GameObject playerPrefab = Resources.Load<GameObject>("Character");

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Scenes/SceneOne");
    }

    [Test]
    public void CheckPlayersIsCreated()
    {
        var player = SpawnPlayer();
        Assert.That(player, Is.Not.Null);
    }

    [Test]
    public void CheckPlayersStartingHealth()
    {
        var player = SpawnPlayer();
        var maxHealth = Resources.Load<ScriptableObject>("PlayerMaxHealth");
        // assert that max health SO is equal to the Characters currentHealth
        // How do I get reference to a SO's value?
        // Assert.That(player.GetComponent<Character>().HealthPoints, Is.EqualTo(maxHealth);
    }

    [Test]
    public void CheckIfInputSystemMovesCharacter()
    {
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    private GameObject SpawnPlayer()
    {
        Vector3 playerPosition = new Vector3(0, (float)1.5, 0);
        Quaternion playerDir = Quaternion.identity;
        GameObject player = GameObject.Instantiate(playerPrefab, playerPosition, playerDir);
        return player;
    }
}