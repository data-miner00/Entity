namespace Entity.Console.Models;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The base class for entities within the application.
/// </summary>
public class ECommerceEntity
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the record was created.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the record was last updated.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column(TypeName = "datetime2")]
    public DateTime UpdatedAt { get; set; }
}
