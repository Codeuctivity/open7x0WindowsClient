namespace Open7x0Client
{
    internal enum EncodingState
    {
        Qued, Encoding, concating, writingMetadata, error, done,
        readyForConcating
    }
}