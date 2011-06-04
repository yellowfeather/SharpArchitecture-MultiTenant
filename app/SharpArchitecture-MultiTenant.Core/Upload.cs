using System;
using NHibernate.Validator.Constraints;
using SharpArch.Domain.DomainModel;
using SharpArchitecture.MultiTenant.Framework.Contracts;

namespace SharpArchitecture.MultiTenant.Core
{
  /// <summary>
  /// 
  /// </summary>
  public class Upload : Entity, IMultiTenantEntity
  {
    // required by ORM
    protected Upload() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Upload"/> class.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <param name="uploadedBy">The uploaded by.</param>
    public Upload(string filename, string uploadedBy)
      : this(filename, null, uploadedBy) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Upload"/> class.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <param name="groupId">The group id.</param>
    /// <param name="uploadedBy">The uploaded by.</param>
    public Upload(string filename, Guid? groupId, string uploadedBy)
    {
      UploadedFilename = Guid.NewGuid().ToString();
      Filename = filename;
      GroupId = groupId;
      UploadedBy = uploadedBy;
      UploadedAt = DateTime.Now;
    }

    /// <summary>
    /// Gets or sets the name of the uploaded file.
    /// </summary>
    /// <value>The uploaded filename.</value>
    [DomainSignature]
    [NotNull]
    public virtual string UploadedFilename { get; private set; }

    /// <summary>
    /// Gets or sets the path to the uploaded file.
    /// </summary>
    /// <value>The uploaded path.</value>
    [DomainSignature]
    [NotNull]
    public virtual string UploadedPath { get; set; }

    /// <summary>
    /// Gets or sets the filename.
    /// </summary>
    /// <value>The filename.</value>
    [NotNullNotEmpty]
    public virtual string Filename { get; private set; }

    /// <summary>
    /// Gets or sets the group id.
    /// Optional group id to allow grouping of a number of uploads.
    /// </summary>
    /// <value>The group id.</value>
    public virtual Guid? GroupId { get; private set; }

    /// <summary>
    /// Gets or sets the user who uploaded the file.
    /// </summary>
    /// <value>The uploaded by.</value>
    [NotNull]
    public virtual string UploadedBy { get; private set; }

    /// <summary>
    /// Gets or sets the timestamp the file was uploaded.
    /// </summary>
    /// <value>The timestamp the file was uploaded.</value>
    [NotNull]
    public virtual DateTime UploadedAt { get; private set; }
  }
}