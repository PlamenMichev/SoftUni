﻿using System;

public class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.StealFieldInfo("Hacker", "username", "password", "heroin");
        Console.WriteLine(result);
    }
}

