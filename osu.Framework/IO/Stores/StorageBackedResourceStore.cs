// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.IO;
using osu.Framework.Platform;

namespace osu.Framework.IO.Stores
{
    /// <summary>
    /// A resource store that uses an underlying <see cref="Storage"/> backing.
    /// </summary>
    public class StorageBackedResourceStore : IResourceStore<byte[]>
    {
        private readonly Storage storage;

        public StorageBackedResourceStore(Storage storage)
        {
            this.storage = storage;
        }

        public byte[] Get(string name)
        {
            using (Stream stream = storage.GetStream(name))
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public Stream GetStream(string name)
        {
            return storage.GetStream(name);
        }
    }
}
