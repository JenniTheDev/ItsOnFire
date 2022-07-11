using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Variables;

public class PracticeTests
{
    private GameObject playerPrefab;

    [SetUp]
    public void Setup()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Character");
        SceneManager.LoadScene("Scenes/SceneOne");
    }

    [TearDown]
    public void TearDown()
    {
        playerPrefab = null;
        // tear down, clean up between tests
        // runs after every test
        // reset state, delete chars etc.
    }

    [Test]
    public void CheckPlayersIsCreated()
    {
        var player = SpawnPlayer();
        Assert.That(player, Is.Not.Null);
    }

    [Test]
    public void IsPlayersStartingHealthNotNull()
    {
        Assert.IsNotNull(playerPrefab.GetComponent<HealthPoints>()?.MaxHealthPoints);
    }

    [Test]
    public void CheckPlayersStartingHealth()
    {
        var player = SpawnPlayer();
        var maxHealth = Resources.Load<IntVariable>("PlayerMaxHealth");
        // assert that max health SO is equal to the Characters currentHealth
        // Assert.IsTrue((player.GetComponent<HealthPoints>().MaxHealthPoints?.IntValue ?? 0) == maxHealth.IntValue);
        Assert.IsTrue(player.GetComponent<HealthPoints>().MaxHealthPoints?.IntValue == maxHealth.IntValue);
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