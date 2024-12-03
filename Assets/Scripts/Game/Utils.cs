public static class Utils {
    public static double CalculateMultiplier(int level, double linearFactor, double exponentialFactor) {
        double mul = 1;
        for (int i = 0; i < level; i++) {
            mul += linearFactor;
            mul *= exponentialFactor;
        }
        return mul;
    }
}
