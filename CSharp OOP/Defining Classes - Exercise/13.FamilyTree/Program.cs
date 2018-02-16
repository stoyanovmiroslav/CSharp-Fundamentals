using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        Queue<string> queue = new Queue<string>();
        FamilyTree tree = new FamilyTree();

        string personTreeInput = Console.ReadLine();
        input = ReadInputLines(queue, tree);

        FindPerson(queue, tree, personTreeInput);

        int count = 0;
        while (queue.Count >= count && queue.Count > 0)
        {
            string line = queue.Dequeue();
            bool childrenFound = false;
            bool parentFound = false;

            string[] splitLine = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (splitLine.Length > 1)
            {
                childrenFound = splitLine[0] == tree.Person.Name || splitLine[0] == tree.Person.Birthday;
                parentFound = splitLine[1] == tree.Person.Name || splitLine[1] == tree.Person.Birthday;
            }

            if (childrenFound)
            {
                FindChildrenInfo(queue, tree, splitLine);
            }
            else if (parentFound)
            {
                FindParentInfo(queue, tree, splitLine);
            }

            if (!parentFound && !childrenFound)
            {
                queue.Enqueue(line);
                count++;
            }
            else
            {
                count = 0;
            }
        }

        PrintFamilyTree(tree);
    }

    private static void PrintFamilyTree(FamilyTree tree)
    {
        Console.WriteLine($"{tree.Person.Name} {tree.Person.Birthday}");
        Console.WriteLine("Parents:");
        tree.Parents.ForEach(p => Console.WriteLine($"{p.Name} {p.Birthday}"));
        Console.WriteLine("Children:");
        tree.Childrens.ForEach(c => Console.WriteLine($"{c.Name} {c.Birthday}"));
    }

    private static void FindPerson(Queue<string> queue, FamilyTree tree, string personTreeInput)
    {
        string name = "";
        string birthday = "";

        if (Char.IsLetter(personTreeInput[0]))
        {
            string personInfo = FindFamilyMemberInfo(queue, personTreeInput, "birthday");
            string[] splitPersonInfo = personInfo.Split();
            name = personTreeInput;
            birthday = splitPersonInfo[2];
        }
        else
        {
            string personInfo = FindFamilyMemberInfo(queue, personTreeInput, "name");
            string[] splitPersonInfo = personInfo.Split();
            name = $"{splitPersonInfo[0]} {splitPersonInfo[1]}";
            birthday = personTreeInput;
        }
        PersonTree personTree = new PersonTree(name, birthday);
        tree.Person = personTree;
    }

    private static void FindParentInfo(Queue<string> queue, FamilyTree tree, string[] splitLine)
    {
        string currentBirthday = "";
        string currentName = "";

        if (Char.IsLetter(splitLine[0][0]))
        {
            currentName = splitLine[0];
            string childrenInfo = FindFamilyMemberInfo(queue, currentName, "birthday");
            string[] splitchildrenInfo = childrenInfo.Split();
            currentBirthday = splitchildrenInfo[2];
        }
        else
        {
            currentBirthday = splitLine[0];
            string childrenInfo = FindFamilyMemberInfo(queue, currentBirthday, "name");
            string[] splitchildrenInfo = childrenInfo.Split();
            currentName = $"{splitchildrenInfo[0]} {splitchildrenInfo[1]}";
        }
        Parent parent = new Parent(currentName, currentBirthday);
        tree.Parents.Add(parent);
    }

    private static void FindChildrenInfo(Queue<string> queue, FamilyTree tree, string[] splitLine)
    {
        string currentName = "";
        string currentBirthday = "";
        if (Char.IsLetter(splitLine[1][0]))
        {
            currentName = splitLine[1];
            string childrenInfo = FindFamilyMemberInfo(queue, currentName, "birthday");
            string[] splitChildrenInfo = childrenInfo.Split();
            currentBirthday = splitChildrenInfo[2];
        }
        else
        {
            currentBirthday = splitLine[1];
            string childrenInfo = FindFamilyMemberInfo(queue, currentBirthday, "name");
            string[] splitChildrenInfo = childrenInfo.Split();
            currentName = $"{splitChildrenInfo[0]} {splitChildrenInfo[1]}";
        }

        Children children = new Children(currentName, currentBirthday);
        tree.Childrens.Add(children);
    }

    private static string FindFamilyMemberInfo(Queue<string> queue, string wantedInfo, string neededInfo)
    {
        bool personIsFind = false;
        string line = "";

        while (!personIsFind)
        {
          line = queue.Dequeue();

            string[] splitLine = line.Split();
            string currentName = $"{splitLine[0]} {splitLine[1]}";
            string birthday = splitLine[2];
            string find = "";

            if (neededInfo == "birthday")
            {
                find = currentName;
            }
            else if (neededInfo == "name")
            {
                find = birthday;
            }

            int IsPersonInfo = find.IndexOf(wantedInfo);
            int IsPersonLine = line.IndexOf("-");

            if (IsPersonInfo >= 0 && IsPersonLine == -1)
            {
                personIsFind = true;
                break;
            }

            queue.Enqueue(line);
        }
        return line;
    }

    private static string ReadInputLines(Queue<string> queue, FamilyTree tree)
    {
        string input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            queue.Enqueue(input);
        }
        return input;
    }
}