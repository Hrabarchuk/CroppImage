using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyGelleryExample
{
    public class Photo
    {
        public Photo(string path)
        {
            _path = path;
            _source = new Uri(path);

            _image = BitmapFrame.Create(_source);
        }

        public override string ToString()
        {
            return _source.ToString();
        }

        private string _path;

        private Uri _source;

        private BitmapFrame _image;
        public BitmapFrame Image { get { return _image; }  }

        //private ExifMetadata _metadata;
        //public ExifMetadata Metadata { get { return _metadata; } }

    }

    
    /// <summary>
    /// This class represents a collection of photos in a directory.
    /// </summary>
    public class PhotoCollection : ObservableCollection<Photo>
    {
        private DirectoryInfo _directory;
        public PhotoCollection() { }

        public PhotoCollection(string path) : this(new DirectoryInfo(path)) { }

        public PhotoCollection(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }
        private void Update()
        {
            this.Clear();
            try
            {
                foreach (FileInfo f in _directory.GetFiles("*.jpg"))
                    Add(new Photo(f.FullName));

            }
            catch (DirectoryNotFoundException)
            {
                System.Windows.MessageBox.Show("No Such Directory");
            }
        }

        
    }
    


}

