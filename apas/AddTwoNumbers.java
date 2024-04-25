package apas;

import java.util.LinkedList;

// You are given two non-empty linked lists representing two non-negative integers.
// The digits are stored in reverse order and each of their nodes contain a single digit.
// Add the two numbers and return it as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number zero itself.

//Example:
// Input: (2 -> 4 -> 3), (5 -> 6 -> 4)
// Output: (7 -> 0 -> 8)
// Because 342 + 465 = 807

public class AddTwoNumbers {

    
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
            listResult.add(Integer.parseInt(resultString.substring(i, i + 1)));
        }
        return listResult;
    }
}
