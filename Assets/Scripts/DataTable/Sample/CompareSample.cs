using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Person A = new Person();
        A.age = 10;
        A.name = "A";
        Person B = new Person();
        B.age = 9;
        B.name = "B";
        Person C = new Person();
        C.age = 5;
        C.name = "C";

        Debug.LogError(A.CompareTo(B));

        List<Person> persons = new List<Person>();
        persons.Add(B);

        persons.Add(A);
        persons.Add(C);
        CustumCompare custumCompare = new CustumCompare();
        persons.Sort(custumCompare);
        foreach (Person e in persons)
        {
            Debug.LogError(e.name);
        }
        int p = persons.BinarySearch(new Person { name = "C" });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Person : IComparable
{
    public int age;
    public string name;

    public int CompareTo(object obj)
    {
        Person other = (Person)obj;
        return name.CompareTo(other.name);
    }
}

public class CustumCompare : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {

        return x.CompareTo(y);
    }
}