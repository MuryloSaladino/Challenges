package apas;

public class ZigZagConversion {
    
    public static void main(String[] args) {
        System.out.println(" ");
        System.out.println(Challenge("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz", 7));
    }

    public static String Challenge(String str, int rows) {
        String[] output = new String[rows];
        for (int i = 0; i < output.length; i++) output[i] = "";

        int current = 0, blanks = rows - 2;
        boolean directionUp = false;

        for (int i = 0; i < str.length(); i++) {
            output[current] += str.charAt(i);
            output[current] += new String(new char[blanks]).replace("\0", " ");

            current += directionUp ? -1 : 1;

            if(current == rows - 1 || current == 0) 
                directionUp = !directionUp;

            blanks = blanks == 0 ? rows - 2 : blanks - 1;
        }

        return String.join("\n", output);
    }
}
