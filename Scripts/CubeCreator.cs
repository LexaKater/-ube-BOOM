using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeCreator : MonoBehaviour
{
    [SerializeField] private ClickReader _click;

    private int _devider = 2;
    private int _percentDivision = 100;

    private void OnEnable() => _click.MousePressed += HandleEvent;

    private void OnDisable() => _click.MousePressed -= HandleEvent;

    private void HandleEvent()
    {
        float maxPercentForDivision = 101;
        float percentForDivision = Random.Range(0, maxPercentForDivision);

        if (percentForDivision <= _percentDivision)
        {
            CreateCubes();
            _percentDivision /= _devider;
        }

        Destroy(gameObject);
    }

    private void CreateCubes()
    {
        int minCountCubes = 2;
        int maxCountCubes = 7;

        int countCubes = Random.Range(minCountCubes, maxCountCubes);
        Vector3 newScale = transform.localScale / _devider;

        for (int i = 0; i < countCubes; i++)
        {
            GameObject newCube = Instantiate(this.gameObject);
            newCube.transform.localScale = newScale;
            newCube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
