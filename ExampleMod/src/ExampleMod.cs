using System;

// This class is the "main" mod class. ETGMod will run the methods inside it as required.
// The name and version is in the metadata.txt in the .zip, not here just as with the backends.
public class ExampleMod : ETGModule {

    public ExampleMod() {
        /* Initialization happens in Start! */
    }
    
    public override void Start() {
        // Initialization code goes in here.

        // Let's hook onto the hook offered by the ExampleAPI.

        // First, we (optionally) want to get rid of the default hook.
        ExampleBackend.SpeedrunText -= ExampleBackend.DefaultSpeedrunTextHook;

        // Now, we add our own hooks.
        // Example 1: methods
        ExampleBackend.SpeedrunText += ExampleSpeedrunTextHook;
        // Example 2: delegates
        ExampleBackend.SpeedrunText += delegate (string text) {
            return "(delegate) " + text + " (after)";
        };

        // As we first hook with the method, then with the delegate, the final output is:
        // (delegate) TIME (method) (after)
        // Delegate hooks cannot be removed, unless...
        // ExampleBackend.SpeedrunText = ExampleSpeedrunTextHook; // ... we replace all hooks.
        // But we're nice and don't replace everything, right?
    }

    public override void Update() {
        // Update code goes in here.
    }

    public override void Exit() {
        // Disposal code goes in here.
    }

    public static string ExampleSpeedrunTextHook(string text) {
        return text + " (method)";
    }

}
