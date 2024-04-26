package apas;

public class MedianTwoSortedArrays {

    public static float Challenge(int[] arr1, int[] arr2) {

        int current = 0;
        int arr1Index = 0;
        int arr2Index = 0;
        int totalSize = arr1.length + arr2.length;

        System.out.println(totalSize / 2);

        if(totalSize % 2 == 0) {
            int last = 0;

            for (int i = 0; i <= (totalSize / 2) - 1; i++) {
                if(arr1Index == arr1.length - 1) {
                    current = arr2[arr2Index];
                    arr2Index++;
                } else if(arr2Index == arr2.length - 1) {
                    current = arr1[arr1Index];
                    arr1Index++;
                } else if(arr1[arr1Index] < arr2[arr2Index]) {
                    current = arr1[arr1Index];
                    arr1Index++;
                } else {
                    current = arr2[arr2Index];
                    arr2Index++;
                }

                if(i == totalSize / 2 - 1) {
                    last = current;
                }
            }
            System.out.println(current);
            System.out.println(last);
            return (float)((current + last) / 2.0);
        }

        for (int i = 0; i <= (totalSize - 1) / 2; i++) {
            if(arr1Index == arr1.length - 1) {
                current = arr2[arr2Index];
                arr2Index++;
            } else if(arr2Index == arr2.length - 1) {
                current = arr1[arr1Index];
                arr1Index++;
            } else if(arr1[arr1Index] < arr2[arr2Index]) {
                current = arr1[arr1Index];
                arr1Index++;
            } else {
                current = arr2[arr2Index];
                arr2Index++;
            }
        }
        return current;
    }
}