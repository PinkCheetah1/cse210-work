using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("cats", "cats", 2000, 2005);
        job1._jobTitle = "Software Engineer";

        
        Job job2 = new Job("dogs", "dogs", 1900, 1905);
        job2._jobTitle = "Software Engingeer";  

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._name = "John";

        myResume.DisplayResume();
    }
}