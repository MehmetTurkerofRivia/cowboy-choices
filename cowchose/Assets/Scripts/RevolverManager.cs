using UnityEngine;
using System.Collections;


public class RevolverManager : MonoBehaviour
{
    [Header("Revolver")]
    public Transform revolverChamber;
    public Transform[] bulletSlots; // 6 slot
    public GameObject bulletPrefab;

    [Header("Rotation")]
    public float rotationDuration = 0.2f;

    private int currentIndex = 0; // aktif mermi
    private bool isRotating = false;

    // ===================== DO (ATEŞ)
    public void DoShoot()
    {
        if (isRotating) return;

        // Slotta mermi var mı?
        if (bulletSlots[currentIndex].childCount > 0)
        {
            Destroy(bulletSlots[currentIndex].GetChild(0).gameObject);
            StartCoroutine(RotateSmooth(-60f));

            currentIndex++;
            if (currentIndex >= bulletSlots.Length)
                currentIndex = 0;
        }
        else
        {
            Debug.Log("Bu slot boş!");
        }
    }

    // ===================== DONT (LOAD)
    public void DontLoad()
    {
        if (isRotating) return;

        // Slot boş mu?
        if (bulletSlots[currentIndex].childCount == 0)
        {
            Instantiate(
                bulletPrefab,
                bulletSlots[currentIndex].position,
                bulletSlots[currentIndex].rotation,
                bulletSlots[currentIndex]
            );

            StartCoroutine(RotateSmooth(60f));

            currentIndex--;
            if (currentIndex < 0)
                currentIndex = bulletSlots.Length - 1;
        }
        else
        {
            Debug.Log("Bu slot dolu!");
        }
    }

    // ===================== ROTATION
    IEnumerator RotateSmooth(float angle)
    {
        isRotating = true;

        Quaternion startRot = revolverChamber.rotation;
        Quaternion targetRot = startRot * Quaternion.Euler(0f, 0f, angle);

        float time = 0f;

        while (time < rotationDuration)
        {
            revolverChamber.rotation = Quaternion.Slerp(
                startRot,
                targetRot,
                time / rotationDuration
            );

            time += Time.deltaTime;
            yield return null;
        }

        revolverChamber.rotation = targetRot;
        isRotating = false;
    }
}