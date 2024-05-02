package apas;

public class MedianTwoSortedArrays {

    public static void main(String[] args) {
        
        int[] arr1 = new int[] {1, 2};
        int[] arr2 = new int[] {3, 4};

        System.out.println(Challenge(arr1, arr2));
    }

    public static float Challenge(int[] arr1, int[] arr2) {

        int totalSize = arr1.length + arr2.length;
        int[] arr3 = new int[totalSize];

        int current1 = 0;
        int current2 = 0;

        for (int i = 0; i < totalSize; i++) {
            if(current1 < arr1.length && current2 < arr2.length) {
                if(arr1[current1] < arr2[current2]) {
                    arr3[i] = arr1[current1];
                    current1++;
                } else if(arr1[current1] > arr2[current2]) {
                    arr3[i] = arr2[current2];
                    current2++;
                }
            } else {
                if(current1 == arr1.length) {
                    for (int j = i + 1; j < arr3.length; j++) {
                        arr3[i] = arr2[current2];
                        current2++;
                    }
                    break;
                } else if (current2 == arr2.length) {
                    for (int j = i; j < arr3.length; j++) {
                        arr3[i] = arr1[current1];
                        current1++;
                    }
                    break;
                }
            }
        }

        if(totalSize % 2 == 0) {
            return (float)((arr3[totalSize / 2] + arr3[(totalSize / 2) - 1]) / 2.0);
        } else {
            return arr3[(totalSize - 1) / 2];
        }
    }
}