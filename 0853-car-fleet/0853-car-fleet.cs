public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        (int, int)[] pairs = new (int, int)[position.Length];

        for(int i = 0; i < position.Length; i++){
            pairs[i] = (position[i], speed[i]);
        }

        Array.Sort(pairs, (a, b) => b.Item1.CompareTo(a.Item1));

        Stack<double> stack = new Stack<double>();

        foreach(var p in pairs){
            // speed = distance / time
            double time = (target - p.Item1) / (double)p.Item2;
            stack.Push(time);

            if(stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1)){
                stack.Pop();
            }
        }

        return stack.Count;
    }
}

/*

1. It starts by creating an array of tuples (position[i], speed[i]) for each car. 
2. Each tuple represents a car's position and speed. It then sorts the array of tuples in
 decreasing order based on the car's position. This is because cars starting closer to the 
 target may catch up with cars that started further away.
3. Next, it creates a stack to keep track of the cars' arrival times at the target. 
The arrival time is calculated as (target - position) / speed for each car.
4. It then iterates over each car (in the sorted array of tuples). For each car, 
it calculates the arrival time and pushes it onto the stack.
5. If the stack has at least two arrival times and the time at the top of the stack 
(for the car most recently processed) is less than or equal to the time below it 
(for the car processed before), it means the car most recently processed will 
catch up with the car processed before. In this case, these two cars form a fleet,
 so the code pops the time at the top of the stack, effectively merging the two fleets into one.
6. Finally, the code returns the count of the stack, which represents the number of 
car fleets that will reach the target.



*/