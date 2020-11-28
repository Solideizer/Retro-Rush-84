using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeGenerator : MonoBehaviour
{
	#region Variable Declarations
#pragma warning disable 0649
	[SerializeField] private GameObject[] _shapePrefabs;
	[SerializeField] int numObjectsToSpawn = 512;
	[SerializeField] public float itemXSpread = 50f;
	[SerializeField] public float itemYSpread = 50f;
	[SerializeField] public float itemZSpread = 50f;
	[SerializeField] private float scaleMultiplier;
	[SerializeField] private float moveSpeed;

#pragma warning restore 0649
	private GameObject[] cubes = new GameObject[512];
	private AudioVisualization _audioVisualization;

	#endregion
	private void Awake ()
	{
		_audioVisualization = GetComponent<AudioVisualization> ();

		CreateShapes ();

	}

	private void CreateShapes ()
	{
		for (int i = 0; i < numObjectsToSpawn; i++)
		{
			GameObject instancedCube = Instantiate (_shapePrefabs[Random.Range (0, 2)]) as GameObject;
			Vector3 pos = new Vector3 (
				Random.Range (-itemXSpread, itemXSpread),
				Random.Range (itemYSpread, 2 * itemYSpread),
				Random.Range (-itemZSpread, itemZSpread)
			);

			Vector3 randPosition = new Vector3 (0, 0, 20) + pos;
			Quaternion randRotation = Quaternion.Euler (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));

			instancedCube.transform.position = randPosition;
			instancedCube.transform.rotation = randRotation;

			cubes[i] = instancedCube;
		}
	}

	private void Update ()
	{
		for (int i = 0; i < 512; i++)
		{
			cubes[i].transform.localScale = new Vector3 (
				_audioVisualization.Samples[i] * scaleMultiplier,
				_audioVisualization.Samples[i] * scaleMultiplier,
				_audioVisualization.Samples[i] * scaleMultiplier
			);
			cubes[i].transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
		}

	}

}