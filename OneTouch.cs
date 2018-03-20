using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTouch : MonoBehaviour {

    private float LineOfTilesLength = 6.0f;

    public GameObject YouWonText;
    public GameObject GameOverText;
    public Text GameOverScoreText;
    public GameObject GameOverPanel;
    public Text UsernameText;

    private Tile[,] AllTiles = new Tile[6, 6];  //[one] == [two]
    private List<Tile[]> columns = new List<Tile[]>();
    private List<Tile[]> rows = new List<Tile[]>();
    private List<Tile> EmptyTiles = new List<Tile>();
    // Use this for initialization

    void Start()
    {
        UsernameText.text = PlayerPrefs.GetString("Username");
        Tile[] AllTilesOneDim = GameObject.FindObjectsOfType<Tile>();
        foreach (Tile t in AllTilesOneDim)
        {
            t.Number = 0;
            AllTiles[t.indRow, t.indCol] = t;  //1 2 == 1 2
            EmptyTiles.Add(t);  //put Tile to List
        }

        //columns and row to a List . We have two List is columns and rows
        columns.Add(new Tile[] { AllTiles[0, 0], AllTiles[1, 0], AllTiles[2, 0], AllTiles[3, 0], AllTiles[4, 0], AllTiles[5, 0] });
        columns.Add(new Tile[] { AllTiles[0, 1], AllTiles[1, 1], AllTiles[2, 1], AllTiles[3, 1], AllTiles[4, 1], AllTiles[5, 1] });
        columns.Add(new Tile[] { AllTiles[0, 2], AllTiles[1, 2], AllTiles[2, 2], AllTiles[3, 2], AllTiles[4, 2], AllTiles[5, 2] });
        columns.Add(new Tile[] { AllTiles[0, 3], AllTiles[1, 3], AllTiles[2, 3], AllTiles[3, 3], AllTiles[4, 3], AllTiles[5, 3] });
        columns.Add(new Tile[] { AllTiles[0, 4], AllTiles[1, 4], AllTiles[2, 4], AllTiles[3, 4], AllTiles[4, 4], AllTiles[5, 4] });
        columns.Add(new Tile[] { AllTiles[0, 5], AllTiles[1, 5], AllTiles[2, 5], AllTiles[3, 5], AllTiles[4, 5], AllTiles[5, 5] });

        rows.Add(new Tile[] { AllTiles[0, 0], AllTiles[0, 1], AllTiles[0, 2], AllTiles[0, 3], AllTiles[0, 4], AllTiles[0, 5] });
        rows.Add(new Tile[] { AllTiles[1, 0], AllTiles[1, 1], AllTiles[1, 2], AllTiles[1, 3], AllTiles[1, 4], AllTiles[1, 5] });
        rows.Add(new Tile[] { AllTiles[2, 0], AllTiles[2, 1], AllTiles[2, 2], AllTiles[2, 3], AllTiles[2, 4], AllTiles[2, 5] });
        rows.Add(new Tile[] { AllTiles[3, 0], AllTiles[3, 1], AllTiles[3, 2], AllTiles[3, 3], AllTiles[3, 4], AllTiles[3, 5] });
        rows.Add(new Tile[] { AllTiles[4, 0], AllTiles[4, 1], AllTiles[4, 2], AllTiles[4, 3], AllTiles[4, 4], AllTiles[4, 5] });
        rows.Add(new Tile[] { AllTiles[5, 0], AllTiles[5, 1], AllTiles[5, 2], AllTiles[5, 3], AllTiles[5, 4], AllTiles[5, 5] });

        for (int i = 0; i < LineOfTilesLength * LineOfTilesLength; i++)
            Generate();
    }

    // Update is called once per frame

    public void Move(int RowTile, int ColTile)
    {
        Tile TouchTile = AllTiles[RowTile, ColTile];
        int CurrenNumber = TouchTile.Number;
        bool MakeMove = false;
        bool MakeDelLeft = false;
        bool MakeDelRight = false;
        bool MakeDelUp = false;
        bool MakeDelDown = false;
        bool MakeDelOneDown = false;

        if (ColTile + 1 < LineOfTilesLength)
        {
            AllTiles[RowTile, ColTile].PlayMergedAnimation();
            if (AllTiles[RowTile, ColTile + 1].Color == AllTiles[RowTile, ColTile].Color)
            {
                CurrenNumber += AllTiles[RowTile, ColTile + 1].Number;
                ScoreTracker.Instance.Score += AllTiles[RowTile, ColTile + 1].Number;
                AllTiles[RowTile, ColTile + 1].PlayMergedAnimation();
                AllTiles[RowTile, ColTile + 1].Number = 0;
                MakeMove = true;
                if (TouchTile.Number == 16)
                    MakeDelRight = true;
            }
        }

        if (ColTile - 1 >= 0)
        {
            if (AllTiles[RowTile, ColTile - 1].Color == AllTiles[RowTile, ColTile].Color)
            {
                CurrenNumber += AllTiles[RowTile, ColTile - 1].Number;
                ScoreTracker.Instance.Score += AllTiles[RowTile, ColTile - 1].Number;
                AllTiles[RowTile, ColTile - 1].PlayMergedAnimation();
                AllTiles[RowTile, ColTile - 1].Number = 0;
                MakeMove = true;
                if (TouchTile.Number == 16)
                    MakeDelLeft = true;
            }
        }
        if (RowTile - 1 >= 0)
        {
            if (AllTiles[RowTile - 1, ColTile].Color == AllTiles[RowTile, ColTile].Color)
            {
                CurrenNumber += AllTiles[RowTile - 1, ColTile].Number;
                ScoreTracker.Instance.Score += AllTiles[RowTile - 1, ColTile].Number;
                AllTiles[RowTile - 1, ColTile].PlayMergedAnimation();
                AllTiles[RowTile - 1, ColTile].Number = 0;
                MakeMove = true;
                if (TouchTile.Number == 16)
                    MakeDelUp = true;
            }
        }
        if (RowTile + 1 < LineOfTilesLength)
        {
            if (AllTiles[RowTile + 1, ColTile].Color == AllTiles[RowTile, ColTile].Color)
            {
                CurrenNumber += AllTiles[RowTile + 1, ColTile].Number;
                ScoreTracker.Instance.Score += AllTiles[RowTile + 1, ColTile].Number;
                AllTiles[RowTile + 1, ColTile].PlayMergedAnimation();
                AllTiles[RowTile + 1, ColTile].Number = 0;
                MakeMove = true;
                MakeDelOneDown = true;
                if (TouchTile.Number == 16)
                    MakeDelDown = true;
            }
        }

        //Delete 
        if (TouchTile.Number == 16 && MakeMove == true)
        {
            if (MakeDelLeft)
                DelOneLine(columns[ColTile - 1]);
            if (MakeDelRight)
                DelOneLine(columns[ColTile + 1]);
            if (MakeDelUp)
                DelOneLine(rows[RowTile - 1]);
            if (MakeDelDown)
                DelOneLine(rows[RowTile + 1]);
            TouchTile.Number = 0;
        }

        //set touch.number
        else
        {
            if (CurrenNumber < 16)
            {
                TouchTile.PlayMergedAnimation();
                TouchTile.Number = CurrenNumber;
            }
            else
            {
                TouchTile.Number = 16;
                if (MakeDelOneDown == false)
                {
                    TouchTile.PlayBigAnimation();
                }
                else
                    AllTiles[RowTile + 1, ColTile].PlayBigAnimation();
            }

        }

        if (MakeMove)
        {
            MakeMoveDown();
            UpdateEmptyTile();
            for (int i = 0; i < 24; i++)
            {
                Generate();
            }
        }

        if (!CanMove())
        {
            GameOver();
        }
    }

    private bool MakeOneColumnDown(Tile[] LineOfTile)
    {
        for (int i = columns.Count - 1; i > 0; i--)
        {
            if (LineOfTile[i].Number == 0 && LineOfTile[i - 1].Number != 0)
            {
                LineOfTile[i].Number = LineOfTile[i - 1].Number;
                LineOfTile[i - 1].Number = 0;
                return true;
            }
        }
        return false;
    }

    private void DelOneLine(Tile[] LineDel)
    {
        for (int i = 0; i < LineDel.Length; i++)
        {
            LineDel[i].Number = 0;
            LineDel[i].PlayAppearAnimation();
        }
    }

    private void MakeMoveDown()
    {
        for (int i = 0; i < LineOfTilesLength; i++)
        {
            while (MakeOneColumnDown(columns[i])) ;
        }
    }

    private void GameOver()
    {

        GameOverScoreText.text = ScoreTracker.Instance.Score.ToString();
        GameOverPanel.SetActive(true);

    }

    private bool CanMove()
    {
        if (EmptyTiles.Count > 0)
            return true;
        else
        {
            //Kiểm Tra các cột
            for (int i = 0; i < columns.Count; i++)
                for (int j = 0; j < rows.Count - 1; j++)
                    if (AllTiles[j, i].Number == AllTiles[j + 1, i].Number)
                        return true;

            //Kiểm Tra các hàng
            for (int i = 0; i < rows.Count; i++)
                for (int j = 0; j < columns.Count - 1; j++)
                    if (AllTiles[i, j].Number == AllTiles[i, j + 1].Number)
                        return true;
        }
        return false;
    }

    private void Generate()
    {
        if (EmptyTiles.Count > 0)
        {
            int indexForNewNumber = Random.Range(0, EmptyTiles.Count);
            int randomNum = Random.Range(0, 16);
            if (randomNum == 0)
                EmptyTiles[indexForNewNumber].Number = 3;
            else if (randomNum == 1)
                EmptyTiles[indexForNewNumber].Number = 6;
            else if (randomNum == 2)
                EmptyTiles[indexForNewNumber].Number = 9;
            else if (randomNum == 3)
                EmptyTiles[indexForNewNumber].Number = 15;
            else
                EmptyTiles[indexForNewNumber].Number = 1;
            EmptyTiles[indexForNewNumber].PlayAppearAnimation();
            EmptyTiles.RemoveAt(indexForNewNumber);
        }
    }

    private void UpdateEmptyTile()
    {
        EmptyTiles.Clear();
        foreach (Tile t in AllTiles)
        {
            if (t.Number == 0)
            {
                EmptyTiles.Add(t);
            }
        }
    }

    /*public void NewGameButtonHandler()
    {
        Application.loadedLevel(Application.LoadLevel);
    }*/
}