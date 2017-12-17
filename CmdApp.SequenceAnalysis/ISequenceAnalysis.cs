namespace CmdApp.SequenceAnalysis {
    public interface ISequenceAnalysis {
        /// <summary>
        /// Find the uppercase words in a string, and order all characters in these words alphabetically.
        /// </summary>
        /// <param name="input">input text</param>
        /// <returns>all uppercase caracters alphabetically</returns>
        string Execute(string input);
    }
}