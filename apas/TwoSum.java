package apas;

// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
// You may assume that each input would have exactly one solution, and oyu may not use the same element twice

// Example: 
// Given nums = [2, 7, 11, 15], target = 9,
// Because nums[0] + nums[1] = 2 + 7 = 9, return [0, 1]

public class TwoSum {

    public static int[] Challenge(int[] arr, int expected) {
        
        int[] result = new int[2];

        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr.length; j++) {
                if(i == j) continue;
                if(arr[i] + arr[j] == expected) {
                    result[0] = j;
                    result[1] = i;
                }
            }
        }
        return result;
    }
}
