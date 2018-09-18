package com.company.Training;
import java.util.List;

public class CommonMethods {
        public static <T extends Number> Integer getSum(List<T> list)  {
            return list.stream().mapToInt(Number::intValue).sum();
        }
}
