package apas;

import java.security.InvalidParameterException;

public class LongestPalindromic {

    public static void main(String[] args) {
        System.out.println();
        System.out.println(Challenge("asdsdthrcfasdffdsalkjhb"));
    }

    public static String Challenge(String str) {
        int[] longestIndexs = new int[] {0, 0};
        boolean even = false;

        for (int i = 1; i < str.length() - (even ? 2 : 1); i++) {
            int[] currentIndexs = new int[] {i - 1, i + (even ? 3 : 2)};
            boolean side = true;
            
            while(true) {
                boolean strIsPalindromic = isPalindromic(str.substring(currentIndexs[0], currentIndexs[1])); 
                if(!strIsPalindromic && side) break;
                
                if(currentIndexs[1] - currentIndexs[0] > longestIndexs[1] - longestIndexs[0] && strIsPalindromic) {
                    longestIndexs[0] = currentIndexs[0];
                    longestIndexs[1] = currentIndexs[1];
                }

                if(side) {
                    currentIndexs[0] = currentIndexs[0] > 0 ? currentIndexs[0] - 1 : 0;
                } else {
                    currentIndexs[1] = currentIndexs[1] < str.length() - 1 ? currentIndexs[1] + 1 : str.length() - 1;
                }
                side = !side;
            }

            if(!even) {
                even = true;
                i--;
            } else {
                even = false;
            }
        }

        if(longestIndexs[0] - longestIndexs[1] == 0)
            throw new InvalidParameterException();
        return str.substring(longestIndexs[0], longestIndexs[1]);
    }

    public static boolean isPalindromic(String str) {
        int length = str.length();
        for (int i = 0; i < length; i++) {
            if(str.charAt(i) != str.charAt(length - 1 - i)) return false;
        }
        return true;
    }
}
