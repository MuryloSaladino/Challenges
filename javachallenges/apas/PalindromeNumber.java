package apas;

public class PalindromeNumber {
    
    public static void main(String[] args) {
        System.out.println(" ");
        System.out.println(Challenge(2223));
    }

    public static boolean Challenge(int input) {

        int size = 0;

        for (int i = input; i != 0; i/=10) size++;

        for (int i = 1; i <= size / 2; i++) {
            if(
                ((input % Math.pow(10, i)) - (input % Math.pow(10, i - 1))) / Math.pow(10, i - 1) 
                != ((input % Math.pow(10, size - i + 1)) - (input % Math.pow(10, size - i))) / Math.pow(10, size - i)
            ) return false;
        }

        return true;
    }
}
