using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public Text storytext;
    private enum States
    {
        origin_0, origin_1, cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom,
        corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, stairs_2, corridor_2, corridor_3, stairs_3, courtyard_free
    };
    private States currState;
    private bool _canContinue;

    // Use this for initialization
    void Start()
    {
        storytext.text = "Welcome to Escape Adventure!\n\n " +
            "Escape Adventure \n " +
            "By Stephanie Hong (2018) \n " +
            "Unity 2017.3.1f1\n\n " +
            "Press Space to Continue";

        currState = States.origin_0;
        _canContinue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currState == States.origin_0 && _canContinue == false)
        {
            print(currState);
            StartCoroutine("Origin_0");
        }
        if (Input.GetKeyDown(KeyCode.Space) && _canContinue == true)
        {
            currState = States.origin_1;
        }
        if      (currState == States.origin_1)          { Origin_1(); }
        else if (currState == States.cell)              { Cell(); }
        else if (currState == States.sheets_0)          { Sheet_0(); }
        else if (currState == States.mirror)            { Mirror(); }
        else if (currState == States.lock_0)            { Lock_0(); }
        else if (currState == States.sheets_1)          { Sheet_1(); }
        else if (currState == States.cell_mirror)       { Cell_Mirror(); }
        else if (currState == States.lock_1)            { Lock_1(); }
        else if (currState == States.corridor_0)        { Corridor_0(); }
        else if (currState == States.stairs_0)          { Stairs_0(); }
        else if (currState == States.floor)             { Floor(); }
        else if (currState == States.closet_door)       { Closet_Door(); }
        else if (currState == States.stairs_1)          { Stairs_1(); }
        else if (currState == States.corridor_1)        { Corridor_1(); }
        else if (currState == States.in_closet)         { In_Closet(); }
        else if (currState == States.stairs_2)          { Stairs_2(); }
        else if (currState == States.corridor_2)        { Corridor_2(); }
        else if (currState == States.stairs_3)          { Stairs_3(); }
        else if (currState == States.corridor_3)        { Corridor_3(); }
        else if (currState == States.courtyard_free)    { Courtyard_Free(); }
        else if (currState == States.freedom)           { Freedom(); }
    }

    IEnumerator Origin_0()
    {
        storytext.text = "Where did everything go wrong...\n\n " +
               "Press Space to Continue";
        print("before yield");
        yield return new WaitForSeconds(1f);
        _canContinue = true;
        print("after yield");

    }

    void Origin_1()
    {
        storytext.text = "Where did everything go wrong...\n\nYou were at home when the police " +
                        "came barging in and arresting you. You plead innocent, but they found you " +
                        "guilty and sentence you to death. Your only hope is to escape this prison " +
                        "cell. \n\nYou are sitting on a bed with sheets. On your left is a mirror on the " +
                        "concrete wall and on your right is the prison bars with a locked door.\n\n" +
                        "Press S to view Sheets, Press M to view Mirror, Press L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            currState = States.mirror;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            currState = States.lock_0;
        }

    }

    void Cell()
    {
        storytext.text = "On your left is a mirror on the concrete wall and on your right " +
            "is the prison bars with a locked door.\n\n" +
            "Press S to view Sheets, Press M to view Mirror, Press L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            currState = States.mirror;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            currState = States.lock_0;
        }

    }

    void Sheet_0()
    {
        storytext.text = "These sheets were originally white, now they're yellow.\n\n Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.cell;
        }
    }

    void Lock_0()
    {
        storytext.text = "There is a keyhole in this door. You will need some kind of key to open it. \n\n Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.cell;
        }
    }

    void Mirror()
    {
        storytext.text = "You are staring at a square mirror. It looks like someone smashed " +
            "it to pieces. You notice at the bottom right hand corner there is a piece of " +
            "mirror that is easily removable.\n\n " +
            "Press T to Take the mirror, Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.cell;
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            currState = States.cell_mirror;
        }
    }

    void Cell_Mirror()
    {
        storytext.text = "You have obtained a piece of mirror.\n\nYou go back " +
            "and sit on the bed. On your left is a mirror on the concrete wall " +
            "and on your right is the prison bars with a locked door.\n\n " +
            "Press S to view Sheets, Press L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.sheets_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            currState = States.lock_1;
        }
    }

    void Sheet_1()
    {
        storytext.text = "These sheets were originally white, now they're yellow.\n\n Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.cell_mirror;
        }
    }

    void Lock_1()
    {
        storytext.text = "There is a keyhole in this door. You will need some kind of key to open it. \n\n " +
            "Press O to Open lock with mirror, Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.cell_mirror;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            currState = States.corridor_0;
        }
    }

    void Freedom()
    {
        storytext.text = "You got caught! You aren't very sneaky.\n\n " +
            "Press Spacebar to Play again";
        currState = States.origin_0;
        _canContinue = false;
    }

    void Corridor_0()
    {
        storytext.text = "You're out of the cell room and in a narrow corridor! Now " +
            "you need to hurry and get out of here before the guards come back!\n\n " +
            "On your left are staircases and on your right is a custodial closet.\n\n" +
            "Press S to view the Stairs, Press F to view the floor, Press C to view the Closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.stairs_0;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            currState = States.floor;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            currState = States.closet_door;
        }
    }

    void Stairs_0()
    {
        storytext.text = "There is noise coming from upstairs. That must be the " +
            "guard control room. Maybe you can sneak by them.\n\n " +
            "Press R to Return, Press S to Sneak past the guards";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.freedom;
        }
    }

    void Floor()
    {
        storytext.text = "You see a small shiny object so you decide to inspect the " +
            "floor. You realize it is a hairclip. You wonder why that is here on a " +
            "prison floor...\n\nThere is no time to wonder about that.\n\n " +
            "Press H to pick up the Hairclip, Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_0;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            currState = States.corridor_1;
        }
    }

    void Closet_Door()
    {
        storytext.text = "Darn, the closet door is locked. You thought it might " +
            "have something useful in it. The mirror piece isn't working. You will " +
            "need something else to open it.\n\n " +
            "Press R to Return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_0;
        }
    }

    void Corridor_1()
    {
        storytext.text = "You obtained a hairclip.\n\n" +
            "On your left are staircases and on your right is a custodial closet.\n\n" +
            "Press S to view the Stairs, Press P to Pick the closet door";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.stairs_1;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            currState = States.in_closet;
        }
    }

    void Stairs_1()
    {
        storytext.text = "There is noise coming from upstairs. That must be the " +
            "guard control room. Maybe you can sneak by them with your hairclip.\n\n " +
            "Press R to Return, Press S to Sneak past the guards";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.freedom;
        }
    }

    void In_Closet()
    {
        storytext.text = "You unlock the door with the hairclip and go into the small closet. " +
            "You see a yellow bucket with a mop, a large yellow caution wet sign, and a " +
            "stack of custodial uniforms.\n\n " +
            "Press R to Return, Press D to Dress up in custodial uniform";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currState = States.corridor_3;
        }
    }

    void Stairs_2()
    {
        storytext.text = "There is noise coming from upstairs. That must be the " +
            "guard control room. Maybe you can sneak by them with your hairclip.\n\n " +
            "Press R to Return, Press S to Sneak past the guards";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_2;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.freedom;
        }
    }

    void Corridor_2()
    {
        storytext.text = "On your left are staircases and on your right is a custodial closet.\n\n" +
            "Press S to view the Stairs, Press B to go back into the closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.stairs_2;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            currState = States.in_closet;
        }
    }

    void Corridor_3()
    {
        storytext.text = "On your left are staircases and on your right is a custodial closet.\n\n" +
            "Press S to view the Stairs, Press U to Undress";
        if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.stairs_3;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            currState = States.in_closet;
        }
    }

    void Stairs_3()
    {
        storytext.text = "There is noise coming from upstairs. That must be the " +
            "guard control room. Maybe you can sneak by them with your new uniform.\n\n " +
            "Press R to Return, Press S to Sneak past the guards";
        if (Input.GetKeyDown(KeyCode.R))
        {
            currState = States.corridor_2;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currState = States.courtyard_free;
        }
    }

    void Courtyard_Free()
    {
        storytext.text = "The guards didn't recognize you. You waltzed on by past them and out the door. You're FREE! \n\n " +
            "Press Spacebar to play again";
        currState = States.origin_0;
        _canContinue = false;
    }
}
