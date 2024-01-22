using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class ScriptTestMode1
{
    private GameObject Esfera;
    private GameObject Cubo;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("SampleScene");
        Debug.Log("Cargando la escena");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EsferaSobreElCubo()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(5);
        Esfera = GameObject.Find("Sphere");
        Cubo = GameObject.Find("Cube");
        Assert.That(Esfera.transform.position.y > Cubo.transform.position.y);
    }

    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.UnloadSceneAsync("SampleScene");
    }
}
