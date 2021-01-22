import java.util.Locale;
import java.util.Random;

public class RNG {

    static Random RNG = new Random();

    public static int nextInt( int incMin, int incMax ){

        return incMin + RNG.nextInt(incMax - incMin + 1);

    }

}
