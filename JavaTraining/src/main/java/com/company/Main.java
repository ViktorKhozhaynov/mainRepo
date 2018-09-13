package com.company;

import javafx.util.Pair;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.util.List;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.function.Supplier;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.stream.LongStream;

public class Main {

    private static Logger logger = LogManager.getFormatterLogger(Main.class.getName());

    public static void main(String[] args) {
        // Predicate to check if a variable is divisible by the given value
        Predicate<Pair<Integer, Integer>> isDivisibleBy = (v) -> v.getKey() % v.getValue() == 0;

        // Function to calculate a sum of the given List of integer values
        Function<List<Integer>, Integer> getSum = (v) -> v.stream().mapToInt(Integer::intValue).sum();

        // Initialize the list of Integer values that are divisible by 5F
        List<Integer> testIntList = IntStream.range(1, 100).filter(x -> isDivisibleBy.test(new Pair<>(x, 5))).boxed().collect(Collectors.toList());
        testIntList.forEach(x -> logger.info(x + " "));

        // Initialize the list of Long values
        List<Long> testLongList = LongStream.range(100, 200).boxed().collect(Collectors.toList());

        // Initialize the supplier with integer stream acquired from testIntList
        Supplier<IntStream> testIntStream = () -> testIntList.stream().mapToInt(Integer::intValue);

        // Calculate the sum of the int list using streams
        Integer sum = testIntStream.get().sum();
        logger.info("The result is %d", sum);

        // Calculate the avg of the int list using streams
        Double avg = testIntStream.get().average().orElse(0.0d);
        logger.info("The avg value is %.2f", avg);

        // Calculate the sum of each Integer and Long lists using generic method
        logger.info("The result of method for int list is %d", CommonMethods.getSum(testIntList));
        logger.info("The result of method for long list is %d", CommonMethods.getSum(testLongList));

        // Calculate the sum of the same Integer list using Function defined above
        logger.info("The result of the same method but as Function is %d", getSum.apply(testIntList));
    }
}

class CommonMethods{
    public static <T extends Number> Integer getSum(List<T> list)  {
        return list.stream().mapToInt(Number::intValue).sum();
    }
}
