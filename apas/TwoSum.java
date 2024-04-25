package apas;

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
