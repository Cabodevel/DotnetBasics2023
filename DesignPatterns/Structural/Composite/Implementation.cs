namespace Composite;

public abstract class FileSystemItem
{
    protected FileSystemItem(string name) => Name = name;

    public string Name { get; set; }

    public abstract long GetSize();
}

public class File : FileSystemItem
{
    private readonly long _size;

    public File(string name, long size) : base(name)
    {
        _size = size;
    }

    public override long GetSize() => _size;
}

public class Directory : FileSystemItem
{
    private readonly long _size;
    private readonly List<FileSystemItem> _fileSystemItems = new();

    public Directory(string name, long size) : base(name)
    {
        _size = size;
    }

    public void Add(FileSystemItem item)
    {
        _fileSystemItems.Add(item);
    }

    public void Remove(FileSystemItem item)
    { _fileSystemItems.Remove(item); }

    public override long GetSize()
    {
        var treeSize = _size;

        foreach(var item in _fileSystemItems)
        {
            treeSize += item.GetSize();
        }

        return treeSize;
    }
}