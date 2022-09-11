// Author: raymai97
// Execute in PowerShell: Measure-Command { java Ques3.java > output.txt }
// Intel Core i5-8300H (laptop) took 23059 milliseconds.

import java.util.ArrayList;
import java.util.Locale;

public class Ques3 {
    private static boolean isFactor(int n, int f) {
        return ((n / f) * f) == n;
    }

    private static void describe(int count, int number, ArrayList<Integer> factors) {
        final StringBuilder sb = new StringBuilder();
        final Locale l = Locale.ENGLISH;
        sb.append("Count: ").append(String.format(l, "%4d", count));
        sb.append(" :number: ").append(String.format(l, "%9d", number)).append(" : ");
        for (int i = 0; i < factors.size(); ++i) {
            if (i > 0) sb.append(", ");
            sb.append(factors.get(i));
        }
        System.out.println(sb);
    }

    public static void main(String[] args) {
        final ArrayList<Integer> factors = new ArrayList<>(50);
        for (int number = 2, count = 0; count < 1500; ++number) {
            factors.clear();
            for (int temp = number;;) {
                if (isFactor(temp, 2)) {
                    factors.add(2); temp /= 2;
                    continue;
                }
                if (isFactor(temp, 3)) {
                    factors.add(3); temp /= 3;
                    continue;
                }
                if (isFactor(temp, 5)) {
                    factors.add(5); temp /= 5;
                    continue;
                }
                if (temp != 1) factors.clear();
                break;
            }
            if (factors.isEmpty()) continue;
            describe(++count, number, factors);
        }
    }
}
