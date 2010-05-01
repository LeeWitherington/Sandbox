namespace MyShop.Bus
{
    /// <summary>
    /// A message that can be send over the <see cref="IBus{T}"/>.
    /// </summary>
    /// <remarks>A message should allways be serializable.</remarks>
    public interface IMessage
    {
    }
}