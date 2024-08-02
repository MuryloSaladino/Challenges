package apas;

import java.security.InvalidParameterException;

public class TwoSum {

    public static void main(String[] args) {
        
        int[] arr = new int[] {2, 7, 11, 15};
        
        int[] challengeResult = Challenge(arr, 26);
        
        System.out.println("[ "+challengeResult[0]+", "+challengeResult[1]+" ]");
    }

    public static int[] Challenge(int[] arr, int expected) {
        
        int[] result = new int[] {0, arr.length - 1};

        while(result[0] != result[1]) {
            int diff = arr[result[0]] + arr[result[1]] - expected;

            if(diff == 0) {
                return result;
            } else if(diff < 0) {
                result[0]++;
            } else {
                result[1]--;
            }
        }

        throw new InvalidParameterException();
    }
}
