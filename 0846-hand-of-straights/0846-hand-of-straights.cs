public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0){
            return false;
        }

        SortedDictionary<int, int> map = new SortedDictionary<int, int>();

        foreach(int h in hand){
            if(!map.ContainsKey(h)){
                map.Add(h, 0);                
            }

            map[h]++;
        }

        while(map.Count > 0){
            // take smallest card
            int currCard = map.First().Key;

            for(int i = 0; i < groupSize; i++){
                if(!map.ContainsKey(currCard + i)){
                    return false;
                }

                map[currCard + i]--;

                if(map[currCard + i] == 0){
                    map.Remove(currCard + i);
                }
            }
        }

        return true;
    }
}