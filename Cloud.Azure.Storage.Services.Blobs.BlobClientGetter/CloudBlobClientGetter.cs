// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using Cloud.Azure.Storage.Services.Blobs.Interfaces.CloudBlobClientGetter;
using Cloud.Azure.Storage.Services.Blobs.Interfaces.CloudStorageAccountGetter;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace Cloud.Azure.Storage.Services.Blobs.BlobClientGetter
{
    /// <summary>Service responsible for getting a reference to an existing blob container</summary>
    public class CloudBlobClientGetter : IBlobContainerReferenceGetter
    {
        private readonly ICloudStorageAccountGetter _storageAccountGetter;

        public CloudBlobClientGetter(ICloudStorageAccountGetter storageAccountGetter)
        {
            _storageAccountGetter = storageAccountGetter ?? throw new ArgumentNullException(nameof(storageAccountGetter));
        }

        /// <summary>Returns a CloudBlobClient reference</summary>
        public CloudBlobClient BlobClient
        {
            get
            {
                if (BlobClient == null) BlobClient = _storageAccountGetter.GetAccount().CreateCloudBlobClient();
                return BlobClient;
            }

            private set => BlobClient = value;
        }
    }
}
