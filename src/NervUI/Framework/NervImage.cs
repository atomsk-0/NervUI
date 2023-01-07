using OpenTK.Graphics.OpenGL;
using StbImageSharp;

namespace NervUI;
//TODO THIS HAS TO BE FIXED IN IMGUI RENDER THE IMAGE RESULT IS JUST BLANK BLACK no idea why.
/*
 * Here some resourced used for  this
 * https://github.com/ocornut/imgui/wiki/Image-Loading-and-Displaying-Examples
 * https://opentk.net/learn/chapter1/5-textures.html?tabs=load-texture-opentk4
 */

//Disabled for now because no idea if this works
#if false
public unsafe class NervImage
{
    public int texture;

    public int Width, Height;

    public NervImage(string imagePath)
    {
        GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
        
        GL.GenTextures(1, out texture);
        GL.BindTexture(TextureTarget.Texture2D, texture);
        
        StbImage.stbi_set_flip_vertically_on_load(1);

        ImageResult image = ImageResult.FromStream(File.OpenRead(imagePath), ColorComponents.RedGreenBlueAlpha);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
        
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);
        
        Width = image.Width;
        Height = image.Height;
    }
}
#endif