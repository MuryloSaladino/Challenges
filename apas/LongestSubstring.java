package apas;

public class LongestSubstring {

    public static void main(String[] args) {

        System.out.println(Challenge("abcabcbb"));
        System.out.println(Challenge("bbbbb"));
        System.out.println(Challenge("pwwkew"));
    }
    
    public static int Challenge(String str) {
        int longestLength = 0;
        int start = 0;

        for (int i = 1; i < str.length() + 1; i++) {
            String currentSub = str.substring(start, i);
            boolean hasDuplicates = false;

            for (int j = 0; j < currentSub.length(); j++) {
                char currentChar = currentSub.charAt(j);

                if(currentSub.indexOf(currentChar, j + 1) > 0) {
                    hasDuplicates = true;
                    start = i - 1;
                    break;
                }
            }

            if(!hasDuplicates && currentSub.length() > longestLength) {
                longestLength = currentSub.length();
            }
        }

        return longestLength;
    }
}
