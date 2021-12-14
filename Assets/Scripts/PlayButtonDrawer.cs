using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class PlayButtonDrawer : MonoBehaviour
{
    // Variables
    public static PlayButtonDrawer instance;
    public Animator drawAnimator;
    public bool drawerOpen;

    [Header("TextMeshPro Objects")]
    public TextMeshProUGUI selectedMode;
    public TextMeshProUGUI topMode;
    public TextMeshProUGUI midMode;
    public TextMeshProUGUI botMode;

    public int orderSet;
    public int selectedPosition;

    public int[] order;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        orderSet = 0;
        order = new int[] {1, 2, 3, 4};
    }

 
    public void SwitchOrderSet(int setNum)
    {
        switch (setNum)
        {
            case 0:
                // Set Order Solo
                order = new int[] { 1, 2, 3, 4 };
                break;
            case 1:
                // Set Order Duos
                order = new int[] { 2, 1, 3, 4 };
                break;
            case 2:
                // Set Order Trios
                order = new int[] { 3, 1, 2, 4 };
                break;
            case 3:
                // Set Order Teams
                order = new int[] { 4, 1, 2, 3 };
                break;
            default:
                break;
        }
    }

    public void OpenDrawer()
    {
        drawAnimator.SetBool("Close", false);
        drawAnimator.SetBool("Open", true);
    }

    public void CloseDrawer()
    {
        drawAnimator.SetBool("Close", true);
        drawAnimator.SetBool("Open", false);
    }

    public void DrawerPullClicked()
    {
        if (!drawerOpen)
        {
            OpenDrawer();
            drawerOpen = true;
        } else
        {
            CloseDrawer();
            drawerOpen = false;
        }
    }

    public void DrawerButtonPressed(int position)
    {
        // Get index of order for position entered
        selectedPosition = order[position];
        SwitchOrderSet(position);
        ModeSelect(selectedPosition);
        drawerOpen = false;
    }

    public void ModeSelect(int mode) {
        switch (mode) {
            case 1:
                // Change Selected
                selectedMode.text = "Solo - 1 Player";
                // Change Top TMP
                topMode.text = "Duos - 2 Player";
                // Change Mid TMP
                midMode.text = "Trio - 3 Player";
                // Change Bottom TMP
                botMode.text = "Team - 4 Player";
                // Close Drawer
                CloseDrawer();
                break;
            case 2:
                // Change Selected
                selectedMode.text = "Duos - 2 Player";
                // Change Top TMP
                topMode.text = "Solo - 1 Player";
                // Change Mid TMP
                midMode.text = "Trio - 3 Player";
                // Change Bottom TMP
                botMode.text = "Team - 4 Player";
                // Close Drawer
                CloseDrawer();
                break;
            case 3:
                // Change Selected
                selectedMode.text = "Trio - 3 Player";
                // Change Top TMP
                topMode.text = "Solo - 1 Player";
                // Change Mid TMP
                midMode.text = "Duos - 2 Player";
                // Change Bottom TMP
                botMode.text = "Team - 4 Player";
                // Close Drawer
                CloseDrawer();
                break;
            case 4:
                // Change Selected
                selectedMode.text = "Team - 4 Player";
                // Change Top TMP
                topMode.text = "Solo - 1 Player";
                // Change Mid TMP
                midMode.text = "Duos - 2 Player";
                // Change Bottom TMP
                botMode.text = "Trio - 3 Player";
                // Close Drawer
                CloseDrawer();
                break;
            default:
                break;
        }
    }
}
