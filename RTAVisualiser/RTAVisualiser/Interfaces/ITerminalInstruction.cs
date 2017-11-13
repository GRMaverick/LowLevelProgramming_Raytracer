namespace RTAVisualiser.Interfaces
{
    public interface ITerminalInstruction
    {
        void Launch(string arguments = "");
        System.Diagnostics.Process Task { get; set; }
    }
}
