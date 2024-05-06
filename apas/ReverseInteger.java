package apas;

public class ReverseInteger {
    
    public static void main(String[] args) {
        System.out.println(" ");
        System.out.println(Challenge(-123));
    }

    public static int Challenge(int input) {

        int size = 0;
        int reversed = 0;

        for (int i = input; i != 0; i/=10) size++;

        for (int i = 1; i <= size; i++) {
            reversed += ( (input % Math.pow(10, i)) - (input % Math.pow(10, i - 1)) ) / Math.pow(10, i - 1) * Math.pow(10, size - i);
        }

        return reversed;
    }
}
