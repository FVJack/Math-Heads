﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //This string array of sheet names MUST MATCH EXACTLY
    //to the sheet names on the Google Sheets spreadsheet
    public string[] sheetNames = { 
                    "users", 
                    "p1-1", 
                    "p2-1", 
                    "p2-2", 
                    "p3-1", 
                    "p4-1", 
                    "p4-2", 
                    "p4-3" };



    // Each struct corresponds to a Worksheet on Google Sheets.
    // If you wish to add additional worksheets, the struct name
    // does not have to match the Worksheet name, but be sure to
    // add the EXACT name to the string array above.
    // IMPORTANT:
    // properties inside the struct must be named EXACTLY how they
    // appear as headers in Worksheet.  This means that  
    // properties/headers must follow C# naming syntax.
    // NO dashes, periods, special characters, etc.


    [System.Serializable]
    public struct tbl_Users
    {
        public string username;
        public string hash;
        public string salt;
        public string first_last;
        public int ID_num;
        public string education;
        public string last_login;
        public float tot_time;
        public float p1_1clear_time;
        public float p2_1clear_time;
        public float p2_2clear_time;
        public float p3_1clear_time;
        public float p4_1clear_time;
        public float p4_2clear_time;
        public float p4_3clear_time;
        public bool admin;
        public bool isClass;
        public bool isExpo;
        public string expires;
    }
    [System.Serializable]
    public struct tbl_P1_1
    {
        public string username;

    }
    [System.Serializable]
    public struct tbl_P2_1
    {
        public string username;
    }
    [System.Serializable]
    public struct tbl_P2_2
    {
        public string username;
    }
    [System.Serializable]
    public struct tbl_P3_1
    {
        public string username;
    }
    [System.Serializable]
    public struct tbl_P4_1
    {
        public string username;
        public float obs1_time;
        public float obs2_time;
        public float obs3_time;
        public float obs4_time;
        public float obs5_time;
        public float obs6_time;
        public float obs7_time;
        public float obs8_time;
        public float obs9_time;
        public Puzzle04Controller.obsData obs1;
        public Puzzle04Controller.obsData obs2;
        public Puzzle04Controller.obsData obs3;
        public Puzzle04Controller.obsData obs4;
        public Puzzle04Controller.obsData obs5;
        public Puzzle04Controller.obsData obs6;
        public Puzzle04Controller.obsData obs7;
        public Puzzle04Controller.obsData obs8;
        public Puzzle04Controller.obsData obs9;
    }
    [System.Serializable]
    public struct tbl_P4_2
    {
        public string username;
        public float obs1_time;
        public float obs2_time;
        public float obs3_time;
        public float obs4_time;
        public float obs5_time;
        public float obs6_time;
        public float obs7_time;
        public float obs8_time;
        public Puzzle04Controller.obsData obs1;
        public Puzzle04Controller.obsData obs2;
        public Puzzle04Controller.obsData obs3;
        public Puzzle04Controller.obsData obs4;
        public Puzzle04Controller.obsData obs5;
        public Puzzle04Controller.obsData obs6;
        public Puzzle04Controller.obsData obs7;
        public Puzzle04Controller.obsData obs8;
    }
    [System.Serializable]
    public struct tbl_P4_3
    {
        public string username;
        public float obs1_time;
        public float obs2_time;
        public float obs3_time;
        public float obs4_time;
        public float obs5_time;
        public Puzzle04Controller.obsData obs1;
        public Puzzle04Controller.obsData obs2;
        public Puzzle04Controller.obsData obs3;
        public Puzzle04Controller.obsData obs4;
        public Puzzle04Controller.obsData obs5;

    } 

    public tbl_Users users;
    public tbl_P1_1 p1_1;
    public tbl_P2_1 p2_1;
    public tbl_P2_2 p2_2;
    public tbl_P3_1 p3_1;
    public tbl_P4_1 p4_1;
    public tbl_P4_2 p4_2;
    public tbl_P4_3 p4_3;

    //PlayerData Constructor
    public PlayerData()
    {
        users = new tbl_Users();
        p1_1 = new tbl_P1_1();
        p2_1 = new tbl_P2_1();
        p2_2 = new tbl_P2_2();
        p3_1 = new tbl_P3_1();
        p4_1 = new tbl_P4_1();
        p4_2 = new tbl_P4_2();
        p4_3 = new tbl_P4_3();

        //TODO: Table Value Initilaztions

        //player.users INIT
        users.username = "default";
        users.isExpo = false;
        users.ID_num = -1;
        users.last_login = System.DateTime.Now.ToString();
        users.p1_1clear_time = 0.0f;
        users.p2_1clear_time = 0.0f;
        users.p2_2clear_time = 0.0f;
        users.p3_1clear_time = 0.0f;
        users.p4_1clear_time = 0.0f;
        users.p4_2clear_time = 0.0f;
        users.p4_3clear_time = 0.0f;
        users.admin = false;

        //player.p1_1 INIT

        //player.p2_1 INIT

        //player.p2_2 INIT

        //player.p3_1 INIT

        //player.p4_1 INIT
        p4_1.obs1_time = 0.0f;
        p4_1.obs2_time = 0.0f;
        p4_1.obs3_time = 0.0f;
        p4_1.obs4_time = 0.0f;
        p4_1.obs5_time = 0.0f;
        p4_1.obs6_time = 0.0f;
        p4_1.obs7_time = 0.0f;
        p4_1.obs8_time = 0.0f;
        p4_1.obs9_time = 0.0f;

        //player.p4_2 INIT
        p4_2.obs1_time = 0.0f;
        p4_2.obs2_time = 0.0f;
        p4_2.obs3_time = 0.0f;
        p4_2.obs4_time = 0.0f;
        p4_2.obs5_time = 0.0f;
        p4_2.obs6_time = 0.0f;
        p4_2.obs7_time = 0.0f;
        p4_2.obs8_time = 0.0f;

        //player.p4_3 INIT
        p4_3.obs1_time = 0.0f;
        p4_3.obs2_time = 0.0f;
        p4_3.obs3_time = 0.0f;
        p4_3.obs4_time = 0.0f;
        p4_3.obs5_time = 0.0f;

    }

    public void SetUserName(string new_name)
    {
        users.username = new_name;
        p1_1.username = new_name;
        p2_1.username = new_name;
        p2_2.username = new_name;
        p3_1.username = new_name;
        p4_1.username = new_name;
        p4_2.username = new_name;
        p4_3.username = new_name;
    }

}