package apas;

import java.util.LinkedList;

public class AddTwoNumbers {

    public static void main(String[] args) {
        LinkedList<Integer> list1 = new LinkedList<Integer>() {};
        LinkedList<Integer> list2 = new LinkedList<Integer>() {};
        list1.add(2);
        list1.add(4);
        list1.add(3);
        list2.add(5);
        list2.add(6);
        list2.add(4);

        System.out.println(Challenge(list1, list2));
    }
    
    public static LinkedList<Integer> Challenge(LinkedList<Integer> num1, LinkedList<Integer> num2) {
        Integer result1 = 0;
        Integer result2 = 0;
        String resultString;
        int size;

        size = num1.size();
        for (int i = 0; i < size; i++) {
            result1 += num1.removeLast() * (int)(Math.pow(10, i));
        }
        size = num2.size();
        for (int i = 0; i < size; i++) {
            result1 += num2.removeLast() * (int)(Math.pow(10, i));
        }
        
        resultString = String.valueOf((int)(result1 + result2));
        LinkedList<Integer> listResult = new LinkedList<Integer>();

        for (int i = 0; i < resultString.length(); i++) {
            listResult.addFirst(Integer.parseInt(resultString.substring(i, i + 1)));
        }
        return listResult;
    }
}
