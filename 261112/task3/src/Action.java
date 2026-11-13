public class Action {
    private String info;

    public Action(String initInfo) {
        if (initInfo.isBlank() || initInfo.isEmpty()) {
            throw new IllegalArgumentException();
        }

        info = initInfo;
    }

    @Override
    public String toString() {
        return "[" + info + "]";
    }
}
