

using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using DataStructuresAndAlgos.LinkedLists;
using NUnit.Framework;

namespace DataStructuresAndAlgos.Playground;

// To execute C#, please define "static void Main" on a class
// named Solution.

public class ThreadingAndAsync
{
    private List<int> result = new List<int>();
    [Test]
    public void Test_SleepSort()
    {
        var task = Task.Run(async() => await SleepSort(new int[]{3,1,5,4,2}));
        task.Wait();
        
        Console.Write(string.Join(',', result));
    }


    private async Task SleepSort(int[] inputArray)
    {
        /*List<Thread> threads = new List<Thread>();
        foreach(var num in inputArray)
        {
            var newThread = new Thread(SleepAndReturnAfter);
            threads.Add(newThread);
            newThread.Start(num);
        }

        while(threads.Any(t => t.IsAlive))
        {
        }

        Console.Write(string.Join(',', result));*/

        var tasks = new List<Task>();

        foreach(var num in inputArray)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(1000 * num);
                result.Add(num);
            });

            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }

    private void SleepAndReturnAfter(Object num)
    {
        if(num == null) return;    
        Thread.Sleep(1000 * (int)num);
        result.Add((int)num);
    } 
}