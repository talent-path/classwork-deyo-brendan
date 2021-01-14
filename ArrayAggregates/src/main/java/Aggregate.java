public class Aggregate {

    public static int max(int[] arr) {

        int temp = arr[0];

        for (int i = 1; i < arr.length; i++) {
            if (arr[i] > temp)
                temp = arr[i];
        }

        return temp;

    }

    public static int min(int[] arr) {

        int temp = arr[0];

        for (int i = 1; i < arr.length; i++) {
            if (arr[i] < temp)
                temp = arr[i];
        }

        return temp;

    }

    public static int sum(int[] arr) {

        int sum = 0;

        for (int i : arr) {
            sum += i;
        }

        return sum;

    }

    public static double avg(int[] arr) {

        double toDouble = sum(arr);
        double avg = toDouble / arr.length;
        return avg;

    }

    public static double stdDev(int[] arr) {

        double sum = sum(arr);
        double deviation = 0.0;
        double avg = avg(arr);

        for (double i : arr) {
            deviation += Math.pow(i - avg, 2);
        }

        double stdDev = Math.sqrt(deviation / arr.length);

        return stdDev;


    }

}
