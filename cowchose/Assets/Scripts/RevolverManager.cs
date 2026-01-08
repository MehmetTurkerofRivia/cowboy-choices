using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RevolverManager : MonoBehaviour
{
    [Header("Revolver")]
    public Transform revolverChamber;
    public Transform[] bulletSlots; // 0 üst, saat yönü
    public GameObject bulletPrefab;

    [Header("Settings")]
    public float rotationDuration = 0.2f;
    public float buttonCooldown = 2f;
    public int maxBullets = 6;

    [Header("UI")]
    public Button doButton;
    public Button dontButton;

    private int currentIndex = 0;
    private int currentBullets;
    private bool isRotating = false;
    private bool buttonsLocked = false;

    // ===================== START
    void Start()
    {
        currentBullets = maxBullets;

        for (int i = 0; i < bulletSlots.Length; i++)
        {
            Instantiate(
                bulletPrefab,
                bulletSlots[i].position,
                bulletSlots[i].rotation,
                bulletSlots[i]
            );
        }

        UpdateButtons();
    }

    // ===================== DO (ATEŞ)
    public void DoShoot()
    {
        if (!CanPress() || currentBullets <= 0) return;

        // 1️⃣ MERMİYİ SİL
        if (bulletSlots[currentIndex].childCount > 0)
        {
            Destroy(bulletSlots[currentIndex].GetChild(0).gameObject);
            currentBullets--;
        }

        // 2️⃣ INDEX İLERLET
        currentIndex++;
        if (currentIndex >= bulletSlots.Length)
            currentIndex = 0;

        // 3️⃣ GÖRSEL DÖNÜŞ
        StartCoroutine(RotateSmooth(-60f));
        StartCoroutine(ButtonCooldown());

        UpdateButtons();
    }

    // ===================== DONT (LOAD)
    public void DontLoad()
    {
        if (!CanPress()) return;

        // 1️⃣ INDEX GERİ AL
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = bulletSlots.Length - 1;

        // 2️⃣ MERMİ EKLE (GEREKİRSE)
        if (currentBullets < maxBullets &&
            bulletSlots[currentIndex].childCount == 0)
        {
            Instantiate(
                bulletPrefab,
                bulletSlots[currentIndex].position,
                bulletSlots[currentIndex].rotation,
                bulletSlots[currentIndex]
            );

            currentBullets++;
        }

        // 3️⃣ GÖRSEL DÖNÜŞ
        StartCoroutine(RotateSmooth(60f));
        StartCoroutine(ButtonCooldown());

        UpdateButtons();
    }

    // ===================== ROTATION
    IEnumerator RotateSmooth(float angle)
    {
        isRotating = true;
        UpdateButtons();

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
        UpdateButtons();
    }

    // ===================== COOLDOWN (SPAM ENGEL)
    IEnumerator ButtonCooldown()
    {
        buttonsLocked = true;
        UpdateButtons();

        yield return new WaitForSeconds(buttonCooldown);

        buttonsLocked = false;
        UpdateButtons();
    }

    // ===================== HELPERS
    bool CanPress()
    {
        return !buttonsLocked && !isRotating;
    }

    void UpdateButtons()
    {
        if (doButton != null)
            doButton.interactable = CanPress() && currentBullets > 0;

        if (dontButton != null)
            dontButton.interactable = CanPress();
    }
}