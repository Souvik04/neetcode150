/*

Initialize Data Structure:

Create a dictionary (pointFrequency) to store the frequency of each point in the data structure.
Add Method:

Given a point [x, y], convert it to a string key, e.g., "x_y".
Increment the frequency of the key in the pointFrequency dictionary.
Count Method:

For each point in the data structure (point1):
Split the key into x and y coordinates.
Check if x and y are different from x1 and y1 (query point) and if |x - x1| == |y - y1| (forming a square).
Increment the result by the product of frequencies of point1, point2 ([x, y1]), and point3 ([x1, y]).
Return Result:

Return the final result.


*/

public class DetectSquares
{
    Dictionary<string, int> pointFrequency;

    public DetectSquares(){
        pointFrequency = new Dictionary<string, int>();
    }

    public void Add(int[] point){
        string key = $"{point[0]}_{point[1]}";
        pointFrequency[key] = pointFrequency.GetValueOrDefault(key) + 1;
    }

    public int Count(int[] point){
        int x = point[0];
        int y = point[1];
        int result = 0;

        foreach (var entry in pointFrequency){
            string[] coords = entry.Key.Split('_');
            int x2 = int.Parse(coords[0]);
            int y2 = int.Parse(coords[1]);

            if (x != x2 && y != y2 && Math.Abs(x - x2) == Math.Abs(y - y2)){
                result += entry.Value * pointFrequency.GetValueOrDefault($"{x}_{y2}", 0) *
                          pointFrequency.GetValueOrDefault($"{x2}_{y}", 0);
            }
        }

        return result;
    }
}

/**
 * Your DetectSquares object will be instantiated and called as such:
 * DetectSquares obj = new DetectSquares();
 * obj.Add(point);
 * int param_2 = obj.Count(point);
 */