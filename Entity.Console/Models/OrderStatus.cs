namespace Entity.Console.Models;

/// <summary>
/// The status of an order.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// Initial state after an order is placed.
    /// </summary>
    Pending,

    /// <summary>
    /// The vendor acknowledged and is currently processing.
    /// </summary>
    Processing,

    /// <summary>
    /// The vendor has done packaging and shipped.
    /// </summary>
    Shipping,

    /// <summary>
    /// The order is canceled by the customer.
    /// </summary>
    Canceled,

    /// <summary>
    /// The order has been received by the customer.
    /// </summary>
    Fulfilled,
}
