using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace NervUI;

//Not working for some reason
#if false
public sealed class NervTexture : IDisposable
{
    public readonly string Path;
    
    private readonly uint _handle;

    private int Width, Height;

    public unsafe NervTexture(string path)
    {
        Path = path;

        using var image = new Bitmap(path);
        image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        
        _handle = (uint)GL.GenTexture();
        Bind();
        
        var rect = new Rectangle(0, 0, image.Width, image.Height);
        var data = image.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        var length = data.Stride * data.Height;
        var bytes = new byte[length];
        
        Marshal.Copy(data.Scan0, bytes, 0, length);
        image.UnlockBits(data);

        Width = image.Width;
        Height = image.Height;

        fixed (void* pixels = &bytes[0])
        {
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, (IntPtr)pixels);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
        
        Console.WriteLine(_handle);
    }
    
    public void Bind(TextureUnit textureSlot = TextureUnit.Texture0)
    {
        GL.ActiveTexture(textureSlot);
        GL.BindTexture(TextureTarget.Texture2D, _handle);
    }

    public uint GetHandle() => _handle;

    public Point GetSize() => new Point(Width, Height);

    /// <inheritdoc />
    public void Dispose() => GL.DeleteTexture(_handle);
}
#endif