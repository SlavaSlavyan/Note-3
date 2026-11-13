import java.util.Stack;

public class History {
    private static final Stack<Action> undoStack = new Stack<>();
    private static final Stack<Action> redoStack = new Stack<>();
    
    public static void pushAction(Action newAction) {
        undoStack.push(newAction);
        redoStack.clear();
    }

    public static void undo() {
        UI.clearConsole();

        if (undoStack.isEmpty()) {
            System.out.println("No actions to undo!");
            return;
        }

        Action _undoAction = undoStack.pop();
        redoStack.push(_undoAction);

        System.out.println("Last action undo.");
    }

    public static void redo() {
        UI.clearConsole();
        
        if (redoStack.isEmpty()) {
            System.out.println("No actions to redo!");
            return;
        }

        Action _redoAction = redoStack.pop();
        undoStack.push(_redoAction);

        System.out.println("Last action redo.");
    }

    public static void print() {
        UI.clearConsole();
        System.out.println("===============[HISTORY]===============\n");

        if (undoStack.isEmpty()) {
            System.out.println("  No history found.");
            return;
        }
        
        for (Action act : undoStack) {
            System.out.println("  Action >> " + act + ';');
        }
    }
}
