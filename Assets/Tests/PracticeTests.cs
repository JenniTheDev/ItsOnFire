using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Variables;
using Cinemachine;

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
        Assert.That(playerPrefab, Is.Not.Null);
    }

    [Test]
    public void CheckCharacterForAllParts()
    {
        Assert.That(playerPrefab.GetComponentInChildren<CinemachineVirtualCamera>()?.VirtualCameraGameObject, Is.Not.Null, "Virtual camera is null");

        Assert.That(playerPrefab.GetComponentInChildren<CinemachineBrain>(), Is.Not.Null, "Cinemachine Brain is missing.");

        Assert.That(playerPrefab.GetComponentInChildren<AudioListener>(), Is.Not.Null, "Audio listener missing.");

        Assert.That(playerPrefab.GetComponentInChildren<Animator>, Is.Not.Null, "Animator is missing.");

        Assert.That(playerPrefab.GetComponentInChildren<StarterAssets.ThirdPersonController>(), Is.Not.Null, "Third Person Controller is missing.");
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