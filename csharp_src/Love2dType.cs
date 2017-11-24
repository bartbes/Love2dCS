// Author : endlesstravel
// this part make interface with love object
// REMEMBER that :
// ** part of C resonse for retain **
// ** part of C# response for release **

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Love2d.Module;

namespace Love2d.Type
{
    public partial class LoveObject : IDisposable
    {
        // use factory design pattern
        public static T newObject<T>(IntPtr ip) where T : LoveObject, new()
        {
            if (IntPtr.Zero == ip)
            {
                return null;
            }

            var obj = new T();
            obj.p = ip;

            // part of C resonse for retain
            // part of C# response for release
            // Love2dDll.wrap_love_dll_retain_obj(ip);

            return obj;
        }

        // real pointer
        internal IntPtr p;

        // disable no-param construct
        internal LoveObject() { }

        // part of C resonse for retain
        // part of C# response for release
        public void Dispose()
        {
            Console.WriteLine("release : " + GetType());
            Love2dDll.wrap_love_dll_release_obj(p);
            p = IntPtr.Zero;
        }

        // if we release resource in ~LoveObject() we may encounter crash
        // when we exit program. I think the reason is that C# disorder the
        // time of release chance between openGL and opengGL resource (for example Texture)
    }

    public partial class Source : LoveObject
    {
        public enum Type : int
        {
            TYPE_STATIC = 0,
            TYPE_STREAM,
            TYPE_MAX_ENUM
        };

        public enum TimeUnit : int
        {
            UNIT_SECONDS = 0,
            UNIT_SAMPLES,
            UNIT_MAX_ENUM
        };

        public Source clone()
        {
            IntPtr out_clone = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Source_clone(p, out out_clone);
            return LoveObject.newObject<Source>(out_clone);
        }
        public bool play()
        {
            bool out_success = false;
            Love2dDll.wrap_love_dll_type_Source_play(p, out out_success);
            return out_success;
        }
        public void stop()
        {
            Love2dDll.wrap_love_dll_type_Source_stop(p);
        }
        public void pause()
        {
            Love2dDll.wrap_love_dll_type_Source_pause(p);
        }
        public void resume()
        {
            Love2dDll.wrap_love_dll_type_Source_resume(p);
        }
        public void rewind()
        {
            Love2dDll.wrap_love_dll_type_Source_rewind(p);
            return;
        }
        public void setPitch(float pitch)
        {
            Love2dDll.wrap_love_dll_type_Source_setPitch(p, pitch);
            return;
        }
        public float getPitch()
        {
            float out_pitch = 0;
            Love2dDll.wrap_love_dll_type_Source_getPitch(p, out out_pitch);
            return out_pitch;
        }
        public void setVolume(float volume)
        {
            Love2dDll.wrap_love_dll_type_Source_setVolume(p, volume);
        }
        public float getVolume()
        {
            float out_volume = 0;
            Love2dDll.wrap_love_dll_type_Source_getVolume(p, out out_volume);
            return out_volume;
        }
        public void seek(float offset, TimeUnit unit_type)
        {
            Love2dDll.wrap_love_dll_type_Source_seek(p, offset, (int)unit_type);
        }
        public float tell(TimeUnit unit_type)
        {
            float out_position = 0;
            Love2dDll.wrap_love_dll_type_Source_tell(p, (int)unit_type, out out_position);
            return out_position;
        }
        public float getDuration(TimeUnit unit_type)
        {
            float out_duration = 0;
            Love2dDll.wrap_love_dll_type_Source_getDuration(p, (int)unit_type, out out_duration);
            return out_duration;
        }
        public void setPosition(float x, float y, float z)
        {
            Love2dDll.wrap_love_dll_type_Source_setPosition(p, x, y, z);
        }
        public Float3 getPosition()
        {
            float out_x = 0, out_y = 0, out_z = 0;
            Love2dDll.wrap_love_dll_type_Source_getPosition(p, out out_x, out out_y, out out_z);
            return new Float3(out_x, out_y, out_z);
        }
        public void setVelocity(float x, float y, float z)
        {
            Love2dDll.wrap_love_dll_type_Source_setVelocity(p, x, y, z);
        }
        public Float3 getVelocity()
        {
            float out_x = 0, out_y = 0, out_z = 0;
            Love2dDll.wrap_love_dll_type_Source_getVelocity(p, out out_x, out out_y, out out_z);
            return new Float3(out_x, out_y, out_z);
        }
        public void setDirection(float x, float y, float z)
        {
            Love2dDll.wrap_love_dll_type_Source_setDirection(p, x, y, z);
            return;
        }
        public Float3 getDirection()
        {
            float out_x = 0, out_y = 0, out_z = 0;
            Love2dDll.wrap_love_dll_type_Source_getDirection(p, out out_x, out out_y, out out_z);
            return new Float3(out_x, out_y, out_z);
        }
        public void setCone(float innerAngle, float outerAngle, float outerVolume)
        {
            Love2dDll.wrap_love_dll_type_Source_setCone(p, innerAngle, outerAngle, outerVolume);
        }
        public void getCone(out float out_innerAngle, out float out_outerAngle, out float out_outerVolume)
        {
            Love2dDll.wrap_love_dll_type_Source_getCone(p, out out_innerAngle, out out_outerAngle, out out_outerVolume);
        }
        public void setRelative(bool relative)
        {
            Love2dDll.wrap_love_dll_type_Source_setRelative(p, relative);
        }
        public bool isRelative()
        {
            bool out_relative = false;
            Love2dDll.wrap_love_dll_type_Source_isRelative(p, out out_relative);
            return out_relative;
        }
        public void setLooping(bool looping)
        {
            Love2dDll.wrap_love_dll_type_Source_setLooping(p, looping);
        }
        public bool isLooping()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Source_isLooping(p, out out_result);
            return out_result;
        }
        public bool isStopped()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Source_isStopped(p, out out_result);
            return out_result;
        }
        public bool isPaused()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Source_isPaused(p, out out_result);
            return out_result;
        }
        public bool isPlaying()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Source_isPlaying(p, out out_result);
            return out_result;
        }
        public void setVolumeLimits(float vmin, float vmax)
        {
            Love2dDll.wrap_love_dll_type_Source_setVolumeLimits(p, vmin, vmax);
        }
        public void getVolumeLimits(out float out_vmin, out float out_vmax)
        {
            Love2dDll.wrap_love_dll_type_Source_getVolumeLimits(p, out out_vmin, out out_vmax);
        }
        public void setAttenuationDistances(float dref, float dmax)
        {
            Love2dDll.wrap_love_dll_type_Source_setAttenuationDistances(p, dref, dmax);
        }
        public void getAttenuationDistances(out float out_dref, out float out_dmax)
        {
            Love2dDll.wrap_love_dll_type_Source_getAttenuationDistances(p, out out_dref, out out_dmax);
        }
        public void setRolloff(float rolloff)
        {
            Love2dDll.wrap_love_dll_type_Source_setRolloff(p, rolloff);
        }
        public float getRolloff()
        {
            float out_rolloff = 0;
            Love2dDll.wrap_love_dll_type_Source_getRolloff(p, out out_rolloff);
            return out_rolloff;
        }
        public int getChannels()
        {
            int out_chanels = 0;
            Love2dDll.wrap_love_dll_type_Source_getChannels(p, out out_chanels);
            return out_chanels;
        }
        public Type getType()
        {
            int out_type = 0;
            Love2dDll.wrap_love_dll_type_Source_getType(p, out out_type);
            return (Type)out_type;
        }
    }

    public partial class File : LoveObject
    {
        public enum Mode : int
        {
            MODE_CLOSED,
            MODE_READ,
            MODE_WRITE,
            MODE_APPEND,
            MODE_MAX_ENUM
        };

        public enum BufferMode : int
        {
            BUFFER_NONE,
            BUFFER_LINE,
            BUFFER_FULL,
            BUFFER_MAX_ENUM
        };

        public double getSize()
        {
            double out_size = 0;
            Love2dDll.wrap_love_dll_type_File_getSize(p, out out_size);
            return out_size;
        }
        public void open(Mode mode_type)
        {
            Love2dDll.wrap_love_dll_type_File_open(p, (int)mode_type);
        }
        public bool close()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_File_close(p, out out_result);
            return out_result;
        }
        public bool isOpen()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_File_isOpen(p, out out_result);
            return out_result;
        }
        public byte[] read(long size)
        {
            IntPtr out_data = IntPtr.Zero;
            long out_readedSize = 0;
            Love2dDll.wrap_love_dll_type_File_read(p, size, out out_data, out out_readedSize);

            return DllTool.readBytesAndRelease(out_data, out_readedSize);
        }
        public void write(byte[] data, long datasize)
        {
            Love2dDll.wrap_love_dll_type_File_write_String(p, data, datasize);
        }
        public void write(Data data, long datasize)
        {
            Love2dDll.wrap_love_dll_type_File_write_Data_datasize(p, data.p, datasize);
        }
        public void flush()
        {
            Love2dDll.wrap_love_dll_type_File_flush(p);
        }
        public bool isEOF()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_File_isEOF(p, out out_result);
            return out_result;
        }
        public long tell()
        {
            long out_pos = 0;
            Love2dDll.wrap_love_dll_type_File_tell(p, out out_pos);
            return out_pos;
        }
        public void seek(long pos)
        {
            Love2dDll.wrap_love_dll_type_File_seek(p, pos);
        }
        public void setBuffer(BufferMode bufmode_type, long size)
        {
            Love2dDll.wrap_love_dll_type_File_setBuffer(p, (int)bufmode_type, size);
        }
        public void getBuffer(out BufferMode out_bufmode_type, out long out_size)
        {
            int bufmode_type = 0;
            Love2dDll.wrap_love_dll_type_File_getBuffer(p, out bufmode_type, out out_size);
            out_bufmode_type = (BufferMode)bufmode_type;
        }
        public Mode getMode()
        {
            int mode_type = 0;
            Love2dDll.wrap_love_dll_type_File_getMode(p, out mode_type);
            return (Mode)mode_type;
        }
        public string getFilename()
        {
            IntPtr out_filename = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_File_getFilename(p, out out_filename);
            return DllTool.WSToStringAndRelease(out_filename);
        }
        public string getExtension()
        {
            IntPtr out_extension = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_File_getExtension(p, out out_extension);
            return DllTool.WSToStringAndRelease(out_extension);
        }

    }

    public partial class FileData : Data
    {
        public enum Decoder
        {
            FILE,
            BASE64,
            DECODE_MAX_ENUM
        }; // Decoder

        public string getFilename()
        {
            IntPtr out_filename = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_FileData_getFilename(p, out out_filename);
            return DllTool.WSToStringAndRelease(out_filename);
        }
        public string getExtension()
        {
            IntPtr out_extension = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_FileData_getExtension(p, out out_extension);
            return DllTool.WSToStringAndRelease(out_extension);
        }
    }

    public partial class GlyphData : Data
    {
        public enum Format : int
        {
            FORMAT_LUMINANCE_ALPHA,
            FORMAT_RGBA,
            FORMAT_MAX_ENUM
        };

        public int getWidth()
        {
            int out_width = 0;
            Love2dDll.wrap_love_dll_type_GlyphData_getWidth(p, out out_width);
            return out_width;
        }
        public int getHeight()
        {
            int out_height = 0;
            Love2dDll.wrap_love_dll_type_GlyphData_getHeight(p, out out_height);
            return out_height;
        }
        public uint getGlyph()
        {
            uint out_glyph = 0;
            Love2dDll.wrap_love_dll_type_GlyphData_getGlyph(p, out out_glyph);
            return out_glyph;
        }
        public string getGlyphString()
        {
            IntPtr out_str = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_GlyphData_getGlyphString(p, out out_str);
            return DllTool.WSToStringAndRelease(out_str);
        }
        public int getAdvance()
        {
            int out_advance = 0;
            Love2dDll.wrap_love_dll_type_GlyphData_getAdvance(p, out out_advance);
            return out_advance;
        }
        public void getBearing(out int out_bearingX, out int out_bearingY)
        {
            Love2dDll.wrap_love_dll_type_GlyphData_getBearing(p, out out_bearingX, out out_bearingY);
        }
        public void getBoundingBox(out int out_minX, out int out_minY, out int out_width, out int out_height)
        {
            Love2dDll.wrap_love_dll_type_GlyphData_getBoundingBox(p, out out_minX, out out_minY, out out_width, out out_height);
        }
        public Format getFormat()
        {
            int out_format_type = 0;
            Love2dDll.wrap_love_dll_type_GlyphData_getFormat(p, out out_format_type);
            return (Format)out_format_type;
        }
    }

    public partial class Rasterizer : LoveObject
    {
        public int getHeight()
        {
            int out_heigth = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getHeight(p, out out_heigth);
            return out_heigth;
        }
        public int getAdvance()
        {
            int out_advance = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getAdvance(p, out out_advance);
            return out_advance;
        }
        public int getAscent()
        {
            int out_ascent = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getAscent(p, out out_ascent);
            return out_ascent;
        }
        public int getDescent()
        {
            int out_descent = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getDescent(p, out out_descent);
            return out_descent;
        }
        public int getLineHeight()
        {
            int out_lineHeight = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getLineHeight(p, out out_lineHeight);
            return out_lineHeight;
        }
        public GlyphData getGlyphData(uint glyph)
        {
            IntPtr out_glyphData = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Rasterizer_getGlyphData_uint32(p, glyph, out out_glyphData);
            return LoveObject.newObject<GlyphData>(out_glyphData);
        }
        public GlyphData getGlyphData(byte[] str)
        {
            IntPtr out_glyphData = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Rasterizer_getGlyphData_string(p, str, out out_glyphData);
            return LoveObject.newObject<GlyphData>(out_glyphData);
        }
        public int getGlyphCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_Rasterizer_getGlyphCount(p, out out_count);
            return out_count;
        }
        public bool hasGlyphs(uint glyph)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Rasterizer_hasGlyphs_uint32(p, glyph, out out_result);
            return out_result;
        }
        public bool hasGlyphs(byte[] str)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Rasterizer_hasGlyphs_string(p, str, out out_result);
            return out_result;
        }
    }

    public partial class Canvas : Texture
    {
        public enum Format : int
        {
            FORMAT_NORMAL,   // Usually SRGB, RGBA8 or a similar fallback. Always supported.
            FORMAT_HDR,      // Usually RGBA16F. Not always supported.
            FORMAT_RGBA4,    // RGBA with 4 bits per channel.
            FORMAT_RGB5A1,   // RGB with 5 bits per channel, and A with 1 bit.
            FORMAT_RGB565,   // RGB with 5, 6, and 5 bits each, respectively.
            FORMAT_R8,       // Single (red) 8-bit channel.
            FORMAT_RG8,      // Two-channel (red and green) with 8 bits per channel.
            FORMAT_RGBA8,    // RGBA with 8 bits per channel.
            FORMAT_RGB10A2,  // RGB with 10 bits each, and A with 2 bits.
            FORMAT_RG11B10F, // Floating point [0, +65024]. RG with 11 FP bits each, and B with 10 FP bits.
            FORMAT_R16F,     // Floating point [-65504, +65504]. R with 16 FP bits.
            FORMAT_RG16F,    // Floating point [-65504, +65504]. RG with 16 FP bits per channel.
            FORMAT_RGBA16F,  // Floating point [-65504, +65504]. RGBA with 16 FP bits per channel.
            FORMAT_R32F,     // Floating point [-65504, +65504]. R with 32 FP bits.
            FORMAT_RG32F,    // Floating point [-65504, +65504]. RG with 32 FP bits per channel.
            FORMAT_RGBA32F,  // Floating point [-65504, +65504]. RGBA with 32 FP bits per channel.
            FORMAT_SRGB,     // sRGB with 8 bits per channel, plus 8 bit linear A.
            FORMAT_MAX_ENUM
        };

        public ImageData newImageData()
        {
            IntPtr out_imageData = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Canvas_newImageData(p, out out_imageData);
            return newObject<ImageData>(out_imageData);
        }
        public ImageData newImageData(int x, int y, int w, int h)
        {
            IntPtr out_imageData = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Canvas_newImageData_xywh(p, x, y, w, h, out out_imageData);
            return newObject<ImageData>(out_imageData);
        }
        public Format getFormat()
        {
            int out_format_type = 0;
            Love2dDll.wrap_love_dll_type_Canvas_getFormat(p, out out_format_type);
            return (Format)out_format_type;
        }
        public int getMSAA()
        {
            int out_msaa = 0;
            Love2dDll.wrap_love_dll_type_Canvas_getMSAA(p, out out_msaa);
            return out_msaa;
        }
    }

    public partial class Font : LoveObject
    {
        public enum AlignMode
        {
            ALIGN_LEFT,
            ALIGN_CENTER,
            ALIGN_RIGHT,
            ALIGN_JUSTIFY,
            ALIGN_MAX_ENUM
        };

        public int getHeight()
        {
            int out_height = 0;
            Love2dDll.wrap_love_dll_type_Font_getHeight(p, out out_height);
            return out_height;
        }
        public int getWidth(byte[] str)
        {
            int out_width = 0;
            Love2dDll.wrap_love_dll_type_Font_getWidth(p, str, out out_width);
            return out_width;
        }
        public Tuple<string[], int> getWrap(byte[] str, float wrap_limit)
        {
            IntPtr out_pws = IntPtr.Zero;
            Int4[] coloredStringColor = new Int4[1];
            byte[][] coloredStringText = new byte[1][] { str };
            int out_maxWidth;
            Love2dDll.wrap_love_dll_type_Font_getWrap(p, coloredStringColor, coloredStringText, 1, wrap_limit, out out_maxWidth, out out_pws);

            var lines = DllTool.WSSToStringListAndRelease(out_pws);
            return new Tuple<string[], int>(lines, out_maxWidth);
        }
        public void setLineHeight(float h)
        {
            Love2dDll.wrap_love_dll_type_Font_setLineHeight(p, h);
            return;
        }
        public float getLineHeight()
        {
            float out_h = 0;
            Love2dDll.wrap_love_dll_type_Font_getLineHeight(p, out out_h);
            return out_h;
        }
        public void setFilter(Texture.FilterMode min_type, Texture.FilterMode mag_type, float anisotropy)
        {
            Love2dDll.wrap_love_dll_type_Font_setFilter(p, (int)min_type, (int)mag_type, anisotropy);
            return;
        }
        public Texture.Filter getFilter()
        {
            int out_min_type, out_mag_type; float out_anisotropy;
            Love2dDll.wrap_love_dll_type_Font_getFilter(p, out out_min_type, out out_mag_type, out out_anisotropy);
            return new Texture.Filter((Texture.FilterMode)out_min_type, (Texture.FilterMode)out_mag_type, out_anisotropy);
        }
        public int getAscent()
        {
            int out_ascent = 0;
            Love2dDll.wrap_love_dll_type_Font_getAscent(p, out out_ascent);
            return out_ascent;
        }
        public int getDescent()
        {
            int out_descent = 0;
            Love2dDll.wrap_love_dll_type_Font_getDescent(p, out out_descent);
            return out_descent;
        }
        public float getBaseline()
        {
            float out_baseline = 0;
            Love2dDll.wrap_love_dll_type_Font_getBaseline(p, out out_baseline);
            return out_baseline;
        }
        public bool hasGlyphs(uint chr)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Font_hasGlyphs_uint32(p, chr, out out_result);
            return out_result;
        }
        public bool hasGlyphs(byte[] str)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Font_hasGlyphs_string(p, str, out out_result);
            return out_result;
        }
        public void setFallbacks(Font[] fallback)
        {
            IntPtr[] fallbackarray = new IntPtr[fallback.Length];
            for (int i = 0; i < fallbackarray.Length; i++)
            {
                fallbackarray[i] = fallback[i].p;
            }

            Love2dDll.wrap_love_dll_type_Font_setFallbacks(p, fallbackarray, fallbackarray.Length);
            return;
        }
    }

    public partial class Image : Texture
    {
        public void setMipmapFilter(FilterMode mipmap_type, float sharpness)
        {
            Love2dDll.wrap_love_dll_type_Image_setMipmapFilter(p, (int)mipmap_type, sharpness);
        }
        public void getMipmapFilter(out FilterMode out_mipmap_type, out float out_sharpness)
        {
            int out_mipmap_type_int;
            Love2dDll.wrap_love_dll_type_Image_getMipmapFilter(p, out out_mipmap_type_int, out out_sharpness);
            out_mipmap_type = (FilterMode)out_mipmap_type_int;
        }
        public bool isCompressed()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Image_isCompressed(p, out out_result);
            return out_result;
        }
        public void refresh(int xoffset, int yoffset, int w, int h)
        {
            Love2dDll.wrap_love_dll_type_Image_refresh(p, xoffset, yoffset, w, h);
        }
        public Data[] getData()
        {
            IntPtr out_datas = IntPtr.Zero;
            int out_datas_lenght = 0;
            Love2dDll.wrap_love_dll_type_Image_getData(p, out out_datas, out out_datas_lenght);

            var list = DllTool.readIntPtrsAndRelease(out_datas, out_datas_lenght);
            Data[] buffer = new Data[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                buffer[i] = newObject<Data>(list[i]);
            }

            return buffer;
        }
        public bool getFlags(out bool out_mipmaps, out bool out_linear)
        {
            Love2dDll.wrap_love_dll_type_Image_getFlags(p, out out_mipmaps, out out_linear);
            return out_mipmaps;
        }
    }

    public partial class Mesh : Drawable
    {
        // The expected usage pattern of the Mesh's vertex data.
        public enum Usage : int
        {
            USAGE_STREAM,
            USAGE_DYNAMIC,
            USAGE_STATIC,
            USAGE_MAX_ENUM
        };

        // How the Mesh's vertices are used when drawing.
        // http://escience.anu.edu.au/lecture/cg/surfaceModeling/image/surfaceModeling015.png
        public enum DrawMode : int
        {
            DRAWMODE_FAN,
            DRAWMODE_STRIP,
            DRAWMODE_TRIANGLES,
            DRAWMODE_POINTS,
            DRAWMODE_MAX_ENUM
        };

        // The type of data a vertex attribute can store.
        public enum DataType
        {
            DATA_BYTE,
            DATA_FLOAT,
            DATA_MAX_ENUM
        };

        public struct AttribFormat
        {
            public string name;
            public DataType type;
            public int components;
        }

        public void setVertices_data(Data data, uint vertoffset)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertices_data(p, data.p, vertoffset);
            return;
        }
        public void setVertices(uint vertoffset, byte[] srcData, uint nvertices)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertices(p, vertoffset, srcData, nvertices);
        }
        public void setVertex(uint index, byte[] data)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertex(p, index, data, data.Length);
        }
        public void getVertex(uint index, out byte[] out_datas, out int out_count)
        {
            IntPtr out_data = IntPtr.Zero;
            int out_data_length = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getVertex(p, index, out out_data, out out_data_length, out out_count);
            out_datas = DllTool.readBytesAndRelease(out_data, out_data_length);
        }
        public void setVertexAttribute(uint vertindex, int attribindex, uint data0, uint data1, uint data2, uint data3)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertexAttribute(p, vertindex, attribindex, data0, data1, data2, data3);
        }
        public void getVertexAttribute(uint vertindex, int attribindex, out DataType out_datatype_type, out int out_components, out uint out_data0, out uint out_data1, out uint out_data2, out uint out_data3)
        {
            int out_datatype = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getVertexAttribute(p, vertindex, attribindex, out out_datatype, out out_components, out out_data0, out out_data1, out out_data2, out out_data3);
            out_datatype_type = (DataType)out_datatype;
        }
        public int getVertexCount()
        {
            int out_result = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getVertexCount(p, out out_result);
            return out_result;
        }
        public AttribFormat[] getVertexFormat()
        {
            IntPtr out_names = IntPtr.Zero, out_datatype = IntPtr.Zero, out_components = IntPtr.Zero;
            int out_length = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getVertexFormat(p, out out_names, out out_datatype, out out_components, out out_length);

            var names = DllTool.WSSToStringListAndRelease(out_names);
            var datatypes = DllTool.readInt32sAndRelease(out_datatype, out_length);
            var components = DllTool.readInt32sAndRelease(out_components, out_length);

            AttribFormat[] buffer = new AttribFormat[out_length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i].name = names[i];
                buffer[i].type = (DataType)(datatypes[i]);
                buffer[i].components = components[i];
            }

            return buffer;
        }
        public void setAttributeEnabled(byte[] name, bool enable)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setAttributeEnabled(p, name, enable);
        }
        public bool isAttributeEnabled(byte[] name)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Mesh_isAttributeEnabled(p, name, out out_result);
            return out_result;
        }
        public void attachAttribute(byte[] name, Mesh otherMesh)
        {
            Love2dDll.wrap_love_dll_type_Mesh_attachAttribute(p, name, otherMesh.p);
        }
        public void flush()
        {
            Love2dDll.wrap_love_dll_type_Mesh_flush(p);
        }
        public void setVertexMap()
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertexMap_nil(p);
        }
        public void setVertexMap(uint[] vertexmaps)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setVertexMap(p, vertexmaps, vertexmaps.Length);
        }
        public uint[] getVertexMap()
        {
            bool out_has_vertex_map = false;
            IntPtr out_vertexmaps = IntPtr.Zero;
            int out_vertexmaps_length = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getVertexMap(p, out out_has_vertex_map, out out_vertexmaps, out out_vertexmaps_length);

            if (out_has_vertex_map == false)
                return null;

            return DllTool.readUInt32sAndRelease(out_vertexmaps, out_vertexmaps_length);
        }
        public void setTexture()
        {
            Love2dDll.wrap_love_dll_type_Mesh_setTexture_nil(p);
            return;
        }
        public void setTexture(Texture tex)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setTexture_Texture(p, tex.p);
            return;
        }
        public Texture getTexture()
        {
            IntPtr out_result = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Mesh_getTexture(p, out out_result);
            return newObject<Texture>(out_result);
        }
        public void setDrawMode(DrawMode mode_type)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setDrawMode(p, (int)mode_type);
        }
        public DrawMode getDrawMode()
        {
            int out_mode_type = 0;
            Love2dDll.wrap_love_dll_type_Mesh_getDrawMode(p, out out_mode_type);
            return (DrawMode)out_mode_type;
        }
        public void setDrawRange()
        {
            Love2dDll.wrap_love_dll_type_Mesh_setDrawRange(p);
        }
        public void setDrawRange_minmax(int rangemin, int rangemax)
        {
            Love2dDll.wrap_love_dll_type_Mesh_setDrawRange_minmax(p, rangemin, rangemax);
        }
        public void getDrawRange(out int out_rangemin, out int out_rangemax)
        {
            Love2dDll.wrap_love_dll_type_Mesh_getDrawRange(p, out out_rangemin, out out_rangemax);
        }
    }

    public partial class ParticleSystem : Drawable
    {
        // Type of distribution new particles are drawn from: None, uniform, normal, ellipse.
        public enum AreaSpreadDistribution
        {
            DISTRIBUTION_NONE,
            DISTRIBUTION_UNIFORM,
            DISTRIBUTION_NORMAL,
            DISTRIBUTION_ELLIPSE,
            DISTRIBUTION_MAX_ENUM
        };

        // Insertion modes of new particles in the list: top, bottom, random.
        public enum InsertMode
        {
            INSERT_MODE_TOP,
            INSERT_MODE_BOTTOM,
            INSERT_MODE_RANDOM,
            INSERT_MODE_MAX_ENUM
        };

        public ParticleSystem clone()
        {
            IntPtr out_clone = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_ParticleSystem_clone(p, out out_clone);
            return newObject<ParticleSystem>(out_clone);
        }
        public void setTexture(Texture tex)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setTexture(p, tex.p);
        }
        public Texture getTexture()
        {
            IntPtr out_texture = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getTexture(p, out out_texture);
            return newObject<Texture>(out_texture);
        }
        public void setBufferSize(uint buffersize)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setBufferSize(p, buffersize);
        }
        public uint getBufferSize()
        {
            uint out_buffersize = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getBufferSize(p, out out_buffersize);
            return out_buffersize;
        }
        public void setInsertMode(InsertMode mode_type)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setInsertMode(p, (int)mode_type);
        }
        public InsertMode getInsertMode()
        {
            int out_mode_type = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getInsertMode(p, out out_mode_type);
            return (InsertMode)out_mode_type;
        }
        public void setEmissionRate(float rate)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setEmissionRate(p, rate);
            return;
        }
        public float getEmissionRate()
        {
            float out_rate = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getEmissionRate(p, out out_rate);
            return out_rate;
        }
        public void setEmitterLifetime(float lifetime)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setEmitterLifetime(p, lifetime);
        }
        public float getEmitterLifetime()
        {
            float out_lifetime = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getEmitterLifetime(p, out out_lifetime);
            return out_lifetime;
        }
        public void setParticleLifetime(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setParticleLifetime(p, min, max);
            return;
        }
        public void getParticleLifetime(out int out_min, out int out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getParticleLifetime(p, out out_min, out out_max);
        }
        public void setPosition(float x, float y)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setPosition(p, x, y);
        }
        public Float2 getPosition()
        {
            float out_x = 0, out_y = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getPosition(p, out out_x, out out_y);
            return new Float2(out_x, out_y);
        }
        public void moveTo(float x, float y)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_moveTo(p, x, y);
        }
        public void setAreaSpread(AreaSpreadDistribution distribution_type, float x, float y)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setAreaSpread(p, (int)distribution_type, x, y);
        }
        public void getAreaSpread(out AreaSpreadDistribution out_distribution_type, out float out_x, out float out_y)
        {
            int out_distribution = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getAreaSpread(p, out out_distribution, out out_x, out out_y);
            out_distribution_type = (AreaSpreadDistribution)out_distribution;
        }
        public void setDirection(float direction)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setDirection(p, direction);
            return;
        }
        public float getDirection()
        {
            float out_direction = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getDirection(p, out out_direction);
            return out_direction;
        }
        public void setSpread(float spread)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSpread(p, spread);
            return;
        }
        public float getSpread()
        {
            float out_spread = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSpread(p, out out_spread);
            return out_spread;
        }
        public void setSpeed(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSpeed(p, min, max);
            return;
        }
        public void getSpeed(out float out_min, out float out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSpeed(p, out out_min, out out_max);
        }
        public void setLinearAcceleration(float xmin, float ymin, float xmax, float ymax)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setLinearAcceleration(p, xmin, ymin, xmax, ymax);
        }
        public void getLinearAcceleration(out float out_xmin, out float out_ymin, out float out_xmax, out float out_ymax)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getLinearAcceleration(p, out out_xmin, out out_ymin, out out_xmax, out out_ymax);
        }
        public void setRadialAcceleration(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setRadialAcceleration(p, min, max);
        }
        public void getRadialAcceleration(out int out_min, out int out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getRadialAcceleration(p, out out_min, out out_max);
        }
        public void setTangentialAcceleration(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setTangentialAcceleration(p, min, max);
        }
        public void getTangentialAcceleration(out int out_min, out int out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getTangentialAcceleration(p, out out_min, out out_max);
        }
        public void setLinearDamping(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setLinearDamping(p, min, max);
        }
        public void getLinearDamping(out int out_min, out int out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getLinearDamping(p, out out_min, out out_max);
        }
        public void setSizes(float[] sizearray)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSizes(p, sizearray, sizearray.Length);
        }
        public float[] getSizes()
        {
            IntPtr out_sizearray = IntPtr.Zero;
            int out_sizearray_length = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSizes(p, out out_sizearray, out out_sizearray_length);
            return DllTool.readFloatsAndRelease(out_sizearray, out_sizearray_length);
        }
        public void setSizeVariation(float variation)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSizeVariation(p, variation);
            return;
        }
        public float getSizeVariation()
        {
            float out_variation = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSizeVariation(p, out out_variation);
            return out_variation;
        }
        public void setRotation(float min, float max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setRotation(p, min, max);
            return;
        }
        public void getRotation(out int out_min, out int out_max)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getRotation(p, out out_min, out out_max);
        }
        public void setSpin(float start, float end)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSpin(p, start, end);
            return;
        }
        public void getSpin(out float out_start, out float out_end)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSpin(p, out out_start, out out_end);
        }
        public void setSpinVariation(float variation)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setSpinVariation(p, variation);
            return;
        }
        public float getSpinVariation()
        {
            float out_variation = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getSpinVariation(p, out out_variation);
            return out_variation;
        }
        public void setOffset(float x, float y)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setOffset(p, x, y);
            return;
        }
        public Float2 getOffset()
        {
            float out_x = 0, out_y = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getOffset(p, out out_x, out out_y);
            return new Float2(out_x, out_y);
        }
        public void setColors(Int4[] colorarray)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setColors(p, colorarray, colorarray.Length);
        }
        public Int4[] getColors()
        {
            IntPtr out_colorarray = IntPtr.Zero;
            int out_colorarray_length = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getColors(p, out out_colorarray, out out_colorarray_length);
            return DllTool.readInt4sAndRelease(out_colorarray, out_colorarray_length);
        }
        public void setQuads(Quad[] quads)
        {
            IntPtr[] quadsarray = new IntPtr[quads.Length];
            for (int i = 0; i < quads.Length; i++)
            {
                quadsarray[i] = quads[i].p;
            }

            Love2dDll.wrap_love_dll_type_ParticleSystem_setQuads(p, quadsarray, quadsarray.Length);
        }
        public Quad[] getQuads()
        {
            IntPtr out_quadsarray = IntPtr.Zero;
            int out_quadsarray_length = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getQuads(p, out out_quadsarray, out out_quadsarray_length);
            return DllTool.readIntPtrsWithConvertAndRelease<Quad>(out_quadsarray, out_quadsarray_length);
        }
        public void setRelativeRotation(bool enable)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_setRelativeRotation(p, enable);
        }
        public bool hasRelativeRotation()
        {
            bool out_enable = false;
            Love2dDll.wrap_love_dll_type_ParticleSystem_hasRelativeRotation(p, out out_enable);
            return out_enable;
        }
        public uint getCount()
        {
            uint out_count = 0;
            Love2dDll.wrap_love_dll_type_ParticleSystem_getCount(p, out out_count);
            return out_count;
        }
        public void start()
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_start(p);
        }
        public void stop()
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_stop(p);
        }
        public void pause()
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_pause(p);
        }
        public void reset()
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_reset(p);
        }
        public void emit(int num)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_emit(p, num);
        }
        public bool isActive()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_ParticleSystem_isActive(p, out out_result);
            return out_result;
        }
        public bool isPaused()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_ParticleSystem_isPaused(p, out out_result);
            return out_result;
        }
        public bool isStopped()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_ParticleSystem_isStopped(p, out out_result);
            return out_result;
        }
        public void update(float dt)
        {
            Love2dDll.wrap_love_dll_type_ParticleSystem_update(p, dt);
            return;
        }
    }

    public partial class Quad : LoveObject
    {
        public void setViewport(float x, float y, float w, float h)
        {
            Love2dDll.wrap_love_dll_type_Quad_setViewport(p, x, y, w, h);
        }
        public Float4 getViewport()
        {
            float out_x, out_y, out_w, out_h;
            Love2dDll.wrap_love_dll_type_Quad_getViewport(p, out out_x, out out_y, out out_w, out out_h);
            return new Float4(out_x, out_y, out_w, out_h);
        }
        public Float2 getTextureDimensions()
        {
            double out_sw, out_sh;
            Love2dDll.wrap_love_dll_type_Quad_getTextureDimensions(p, out out_sw, out out_sh);
            return new Float2((float)out_sw, (float)out_sh);
        }
    }

    public partial class Shader : LoveObject
    {
        // Types of potential uniform (extern) variables used in love's shaders.
        public enum UniformType
        {
            UNIFORM_FLOAT,
            UNIFORM_MATRIX,
            UNIFORM_INT,
            UNIFORM_BOOL,
            UNIFORM_SAMPLER,
            UNIFORM_UNKNOWN,
            UNIFORM_MAX_ENUM
        };

        public string getWarnings()
        {
            IntPtr out_str = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Shader_getWarnings(p, out out_str);
            return DllTool.WSToStringAndRelease(out_str);
        }
        public void sendColors(byte[] name, params Int4[] valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendColors(p, name, valuearray, valuearray.Length);
        }
        public void sendFloats(byte[] name, params float[] valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendFloats(p, name, valuearray, valuearray.Length);
        }
        public void sendInts(byte[] name, params int[] valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendInts(p, name, valuearray, valuearray.Length);
        }
        public void sendBooleans(byte[] name, params bool[] valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendBooleans(p, name, valuearray, valuearray.Length);
        }
        public void sendMatrix(byte[] name, float[] valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendMatrices(p, name, valuearray, valuearray.Length);
        }
        public void sendMatrix(byte[] name, Matrix22 valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendMatrices(p, name, valuearray.data, valuearray.data.Length);
        }
        public void sendMatrix(byte[] name, Matrix33 valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendMatrices(p, name, valuearray.data, valuearray.data.Length);
        }
        public void sendMatrix(byte[] name, Matrix44 valuearray)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendMatrices(p, name, valuearray.data, valuearray.data.Length);
        }
        public void sendTexture(byte[] name, Texture texture)
        {
            Love2dDll.wrap_love_dll_type_Shader_sendTexture(p, name, texture.p);
        }

        // return Tuple<UniformType, int, int>:
        // UniformType : The base type of the variable.
        // int components : The number of components in the variable(e.g. 2 for a vec2 or mat2.)
        // int arrayelements : The number of elements in the array if the variable is an array, or 1 if not.
        public Tuple<UniformType, int, int> getExternVariable(byte[] name)
        {
            bool out_variableExists = false;
            int out_uniform_type = 0, out_components = 0, out_arrayelements = 0;
            Love2dDll.wrap_love_dll_type_Shader_getExternVariable(p, name, out out_variableExists, out out_uniform_type, out out_components, out out_arrayelements);
            if (out_variableExists == false)
            {
                return null;
            }

            return new Tuple<UniformType, int, int>((UniformType)out_uniform_type, out_components, out_arrayelements);
        }
    }

    public partial class SpriteBatch : Drawable
    {
        public int add(float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            int out_index = 0;
            Love2dDll.wrap_love_dll_type_SpriteBatch_add(p, x, y, angle, sx, sy, ox, oy, kx, ky, out out_index);
            return out_index;
        }
        public int add(Quad quad, float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            int out_index = 0;
            Love2dDll.wrap_love_dll_type_SpriteBatch_add_Quad(p, quad.p, x, y, angle, sx, sy, ox, oy, kx, ky, out out_index);
            return out_index;
        }
        public void set(int index, float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_set(p, index, x, y, angle, sx, sy, ox, oy, kx, ky);
        }
        public void set(int index, Quad quad, float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_set_Quad(p, index, quad.p, x, y, angle, sx, sy, ox, oy, kx, ky);
        }
        public void clear()
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_clear(p);
        }
        public void flush()
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_flush(p);
        }
        public void setTexture(Text texture)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_setTexture(p, texture.p);
        }
        public Texture getTexture()
        {
            IntPtr out_texture = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_SpriteBatch_getTexture(p, out out_texture);
            return newObject<Texture>(out_texture);
        }
        public void setColor()
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_setColor_nil(p);
        }
        public void setColor(int r, int g, int b, int a = 255)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_setColor(p, r, g, b, a);
        }

        // If no color has been set with SpriteBatch:setColor or the current SpriteBatch color has been cleared, this method will return false.
        public Tuple<bool, Int4> getColor()
        {
            bool out_exist = false;
            int out_r, out_g, out_b, out_a;
            Love2dDll.wrap_love_dll_type_SpriteBatch_getColor(p, out out_exist, out out_r, out out_g, out out_b, out out_a);
            return new Tuple<bool, Int4>(out_exist, new Int4(out_r, out_g, out_b, out_a));
        }
        public int getCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_SpriteBatch_getCount(p, out out_count);
            return out_count;
        }
        public void setBufferSize(int size)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_setBufferSize(p, size);
        }
        public int getBufferSize()
        {
            int out_buffersize = 0;
            Love2dDll.wrap_love_dll_type_SpriteBatch_getBufferSize(p, out out_buffersize);
            return out_buffersize;
        }
        public void attachAttribute(byte[] name, Mesh mesh)
        {
            Love2dDll.wrap_love_dll_type_SpriteBatch_attachAttribute(p, name, mesh.p);
        }
    }

    public partial class Text : Drawable
    {
        public void set()
        {
            Love2dDll.wrap_love_dll_type_Text_set_nil(p);
            return;
        }
        public void set(ColoredString coloredString)
        {
            var buffer = coloredString.ToPart();
            Love2dDll.wrap_love_dll_type_Text_set_coloredstring(p, buffer.Item1, buffer.Item2, coloredString.Length);
        }
        public void setf(ColoredString coloredString, float wraplimit, Font.AlignMode align_type)
        {
            var buffer = coloredString.ToPart();
            Love2dDll.wrap_love_dll_type_Text_setf(p, buffer.Item1, buffer.Item2, coloredString.Length, wraplimit, (int)align_type);
            return;
        }
        public int add(ColoredString coloredString, float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            int out_index = 0;
            var buffer = coloredString.ToPart();
            Love2dDll.wrap_love_dll_type_Text_add(p, buffer.Item1, buffer.Item2, coloredString.Length, x, y, angle, sx, sy, ox, oy, kx, ky, out out_index);
            return out_index;
        }
        public int add(ColoredString coloredString, float wraplimit, Font.AlignMode align_type, float x, float y, float angle = 0, float sx = 1, float sy = 1, float ox = 0, float oy = 0, float kx = 0, float ky = 0)
        {
            int out_index = 0;
            var buffer = coloredString.ToPart();
            Love2dDll.wrap_love_dll_type_Text_addf(p, buffer.Item1, buffer.Item2, coloredString.Length, x, y, angle, sx, sy, ox, oy, kx, ky, wraplimit, (int)align_type, out out_index);
            return out_index;
        }
        public void clear()
        {
            Love2dDll.wrap_love_dll_type_Text_clear(p);
            return;
        }
        public void setFont(Font f)
        {
            Love2dDll.wrap_love_dll_type_Text_setFont(p, f.p);
            return;
        }
        public Font getFont()
        {
            IntPtr font = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Text_getFont(p, out font);
            return newObject<Font>(font);
        }
        public int getWidth(int index)
        {
            int out_w = 0;
            Love2dDll.wrap_love_dll_type_Text_getWidth(p, index, out out_w);
            return out_w;
        }
        public int getHeight(int index)
        {
            int out_h = 0;
            Love2dDll.wrap_love_dll_type_Text_getHeight(p, index, out out_h);
            return out_h;
        }
    }

    public partial class Texture : Drawable
    {
        public enum WrapMode
        {
            WRAP_CLAMP,
            WRAP_CLAMP_ZERO,
            WRAP_REPEAT,
            WRAP_MIRRORED_REPEAT,
            WRAP_MAX_ENUM
        };

        public enum FilterMode
        {
            FILTER_NONE,
            FILTER_LINEAR,
            FILTER_NEAREST,
            FILTER_MAX_ENUM
        };

        public class Filter
        {
            public readonly FilterMode min = FilterMode.FILTER_LINEAR;
            public readonly FilterMode mag = FilterMode.FILTER_LINEAR;
            public readonly float anisotropy = 1.0f;
            public Filter(FilterMode min, FilterMode mag, float anisotropy)
            {
                this.min = min;
                this.mag = mag;
                this.anisotropy = anisotropy;
            }
        };

        public int getWidth()
        {
            int out_w;
            Love2dDll.wrap_love_dll_type_Texture_getWidth(p, out out_w);
            return out_w;
        }
        public int getHeight()
        {
            int out_h;
            Love2dDll.wrap_love_dll_type_Texture_getHeight(p, out out_h);
            return out_h;
        }
        public void setFilter(FilterMode filtermin_type, FilterMode filtermag_type, float anisotropy)
        {
            Love2dDll.wrap_love_dll_type_Texture_setFilter(p, (int)filtermin_type, (int)filtermag_type, anisotropy);
        }
        public void getFilter(out FilterMode out_filtermin_type, out FilterMode out_filtermag_type, out float out_anisotropy)
        {
            int out_filtermin = 0, out_filtermag = 0;
            Love2dDll.wrap_love_dll_type_Texture_getFilter(p, out out_filtermin, out out_filtermag, out out_anisotropy);

            out_filtermag_type = (FilterMode)out_filtermag;
            out_filtermin_type = (FilterMode)out_filtermin;
        }
        public void setWrap(WrapMode wraphoriz_type, WrapMode wrapvert_type)
        {
            Love2dDll.wrap_love_dll_type_Texture_setWrap(p, (int)wraphoriz_type, (int)wrapvert_type);
        }
        public void getWrap(out WrapMode out_wraphoriz_type, out WrapMode out_wrapvert_type)
        {
            int out_wraphoriz = 0, out_wrapvert = 0;
            Love2dDll.wrap_love_dll_type_Texture_getWrap(p, out out_wraphoriz, out out_wrapvert);
            out_wraphoriz_type = (WrapMode)out_wraphoriz;
            out_wrapvert_type = (WrapMode)out_wrapvert;
        }
    }

    public partial class Video : Drawable
    {
        public VideoStream getStream()
        {
            IntPtr out_videsStream = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Video_getStream(p, out out_videsStream);
            return newObject<VideoStream>(out_videsStream);
        }
        public Source getSource()
        {
            IntPtr out_source = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Video_getSource(p, out out_source);
            return newObject<Source>(out_source);
        }
        public void setSource()
        {
            Love2dDll.wrap_love_dll_type_Video_setSource_nil(p);
        }
        public void setSource(Source source)
        {
            Love2dDll.wrap_love_dll_type_Video_setSource(p, source.p);
        }
        public int getWidth()
        {
            int out_w = 0;
            Love2dDll.wrap_love_dll_type_Video_getWidth(p, out out_w);
            return out_w;
        }
        public int getHeight()
        {
            int out_h = 0;
            Love2dDll.wrap_love_dll_type_Video_getHeight(p, out out_h);
            return out_h;
        }
        public void setFilter(Texture.FilterMode filtermin_type, Texture.FilterMode filtermag_type, float anisotropy)
        {
            Love2dDll.wrap_love_dll_type_Video_setFilter(p, (int)filtermin_type, (int)filtermag_type, anisotropy);
        }
        public void getFilter(out Texture.FilterMode out_filtermin_type, out Texture.FilterMode out_filtermag_type, out float out_anisotropy)
        {
            int out_filtermin = 0, out_filtermag = 0;
            Love2dDll.wrap_love_dll_type_Video_getFilter(p, out out_filtermin, out out_filtermag, out out_anisotropy);
            out_filtermin_type = (Texture.FilterMode)out_filtermin;
            out_filtermag_type = (Texture.FilterMode)out_filtermag;
        }
    }

    public partial class CompressedImageData : Data
    {
        // Recognized compressed image data formats.
        public enum Format
        {
            FORMAT_UNKNOWN,
            FORMAT_DXT1,
            FORMAT_DXT3,
            FORMAT_DXT5,
            FORMAT_BC4,
            FORMAT_BC4s,
            FORMAT_BC5,
            FORMAT_BC5s,
            FORMAT_BC6H,
            FORMAT_BC6Hs,
            FORMAT_BC7,
            FORMAT_PVR1_RGB2,
            FORMAT_PVR1_RGB4,
            FORMAT_PVR1_RGBA2,
            FORMAT_PVR1_RGBA4,
            FORMAT_ETC1,
            FORMAT_ETC2_RGB,
            FORMAT_ETC2_RGBA,
            FORMAT_ETC2_RGBA1,
            FORMAT_EAC_R,
            FORMAT_EAC_Rs,
            FORMAT_EAC_RG,
            FORMAT_EAC_RGs,
            FORMAT_ASTC_4x4,
            FORMAT_ASTC_5x4,
            FORMAT_ASTC_5x5,
            FORMAT_ASTC_6x5,
            FORMAT_ASTC_6x6,
            FORMAT_ASTC_8x5,
            FORMAT_ASTC_8x6,
            FORMAT_ASTC_8x8,
            FORMAT_ASTC_10x5,
            FORMAT_ASTC_10x6,
            FORMAT_ASTC_10x8,
            FORMAT_ASTC_10x10,
            FORMAT_ASTC_12x10,
            FORMAT_ASTC_12x12,
            FORMAT_MAX_ENUM
        };

        public int getWidth(int miplevel)
        {
            int out_w = 0;
            Love2dDll.wrap_love_dll_type_CompressedImageData_getWidth(p, miplevel, out out_w);
            return out_w;
        }
        public int getHeight(int miplevel)
        {
            int out_h = 0;
            Love2dDll.wrap_love_dll_type_CompressedImageData_getHeight(p, miplevel, out out_h);
            return out_h;
        }
        public int getMipmapCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_CompressedImageData_getMipmapCount(p, out out_count);
            return out_count;
        }
        public Format getFormat()
        {
            int out_format_type = 0;
            Love2dDll.wrap_love_dll_type_CompressedImageData_getFormat(p, out out_format_type);
            return (Format)out_format_type;
        }
    }

    public partial class ImageData : Data
    {
        public enum EncodedFormat
        {
            ENCODED_TGA,
            ENCODED_PNG,
            ENCODED_MAX_ENUM
        };

        public int getWidth()
        {
            int out_w = 0;
            Love2dDll.wrap_love_dll_type_ImageData_getWidth(p, out out_w);
            return out_w;
        }
        public int getHeight()
        {
            int out_h = 0;
            Love2dDll.wrap_love_dll_type_ImageData_getHeight(p, out out_h);
            return out_h;
        }
        public Int4 getPixel(int x, int y)
        {
            byte out_r, out_g, out_b, out_a;
            Love2dDll.wrap_love_dll_type_ImageData_getPixel(p, x, y, out out_r, out out_g, out out_b, out out_a);
            return new Int4(out_r, out_g, out_b, out_a);
        }
        public void setPixel(int x, int y, byte r, byte g, byte b, byte a)
        {
            Love2dDll.wrap_love_dll_type_ImageData_setPixel(p, x, y, r, g, b, a);
            return;
        }
        public void paste(ImageData src_imageData, int dx, int dy, int sx, int sy, int sw, int sh)
        {
            Love2dDll.wrap_love_dll_type_ImageData_paste(p, src_imageData.p, dx, dy, sx, sy, sw, sh);
            return;
        }
        public void encode(EncodedFormat format_type, byte[] filename)
        {
            Love2dDll.wrap_love_dll_type_ImageData_encode(p, (int)format_type, filename);
        }

        public delegate void MapPixelDelegate(byte r, byte g, byte b, byte a, out byte out_r, out byte out_g, out byte out_b, out byte out_a);
        public void mapPixel(MapPixelDelegate mpd, int startX, int startY, int width, int height)
        {
            IntPtr ptrLock = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_ImageData_ext_mutexLock(p, out ptrLock);

            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    byte out_r = 0, out_g = 0, out_b = 0, out_a = 0;
                    Love2dDll.wrap_love_dll_type_ImageData_ext_getPixelUnsafe(p, x, y, out out_r, out out_g, out out_b, out out_a);
                    mpd.Invoke(out_r, out_g, out_b, out_a, out out_r, out out_g, out out_b, out out_a);
                    Love2dDll.wrap_love_dll_type_ImageData_ext_setPixelUnsafe(p, x, y, out_r, out_g, out_b, out_a);
                }
            }

            Love2dDll.wrap_love_dll_type_ImageData_ext_mutexUnlock(p, ptrLock);
        }

    }

    public partial class Cursor : LoveObject
    {
        // Types of system cursors.
        public enum SystemCursor
        {
            CURSOR_ARROW,
            CURSOR_IBEAM,
            CURSOR_WAIT,
            CURSOR_CROSSHAIR,
            CURSOR_WAITARROW,
            CURSOR_SIZENWSE,
            CURSOR_SIZENESW,
            CURSOR_SIZEWE,
            CURSOR_SIZENS,
            CURSOR_SIZEALL,
            CURSOR_NO,
            CURSOR_HAND,
            CURSOR_MAX_ENUM
        };

        public enum CursorType
        {
            CURSORTYPE_SYSTEM,
            CURSORTYPE_IMAGE,
            CURSORTYPE_MAX_ENUM
        };

        // What is the type of Curor is ? System type or Custom-Image type ?
        public CursorType getType()
        {
            int out_cursortype_type = 0;
            Love2dDll.wrap_love_dll_type_Cursor_getType(p, out out_cursortype_type);
            return (CursorType)out_cursortype_type;
        }

        // If type of Curor is System type, which System type of the cursor is ?
        public SystemCursor getSystemType()
        {
            int out_systype_type = 0;
            Love2dDll.wrap_love_dll_type_Cursor_getSystemType(p, out out_systype_type);
            return (SystemCursor)out_systype_type;
        }
    }

    public partial class Decoder : LoveObject
    {
        // Indicates how many bytes of raw data should be generated at each call to Decode.
        public const int DEFAULT_BUFFER_SIZE = 16384;

        // Indicates the quality of the sound.
        public const int DEFAULT_SAMPLE_RATE = 44100;

        // Default is stereo.
        public const int DEFAULT_CHANNELS = 2;

        // 16 bit audio is the default.
        public const int DEFAULT_BIT_DEPTH = 16;


        public int getChannels()
        {
            int out_channels = 0;
            Love2dDll.wrap_love_dll_type_Decoder_getChannels(p, out out_channels);
            return out_channels;
        }
        public int getBitDepth()
        {
            int out_bitDepth = 0;
            Love2dDll.wrap_love_dll_type_Decoder_getBitDepth(p, out out_bitDepth);
            return out_bitDepth;
        }
        public int getSampleRate()
        {
            int out_sampleRate = 0;
            Love2dDll.wrap_love_dll_type_Decoder_getSampleRate(p, out out_sampleRate);
            return out_sampleRate;
        }
        public double getDuration()
        {
            double out_duration = 0;
            Love2dDll.wrap_love_dll_type_Decoder_getDuration(p, out out_duration);
            return out_duration;
        }
    }

    public partial class SoundData : Data
    {
        public int getChannels()
        {
            int out_channels = 0;
            Love2dDll.wrap_love_dll_SoundData_getChannels(p, out out_channels);
            return out_channels;
        }
        public int getBitDepth()
        {
            int out_bitDepth = 0;
            Love2dDll.wrap_love_dll_SoundData_getBitDepth(p, out out_bitDepth);
            return out_bitDepth;
        }
        public int getSampleRate()
        {
            int out_sampleRate = 0;
            Love2dDll.wrap_love_dll_SoundData_getSampleRate(p, out out_sampleRate);
            return out_sampleRate;
        }
        public int getSampleCount()
        {
            int out_sampleCount = 0;
            Love2dDll.wrap_love_dll_SoundData_getSampleCount(p, out out_sampleCount);
            return out_sampleCount;
        }
        public double getDuration()
        {
            double out_duration = 0;
            Love2dDll.wrap_love_dll_SoundData_getDuration(p, out out_duration);
            return out_duration;
        }
        public void setSample(int i, float sample)
        {
            Love2dDll.wrap_love_dll_SoundData_setSample(p, i, sample);
            return;
        }
        public float getSample(int i)
        {
            float out_sample = 0;
            Love2dDll.wrap_love_dll_SoundData_getSample(p, i, out out_sample);
            return out_sample;
        }
    }

    public partial class VideoStream : Stream
    {
        public string getFilename()
        {
            IntPtr out_filename = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_VideoStream_getFilename(p, out out_filename);
            return DllTool.WSToStringAndRelease(out_filename);
        }
        public void play()
        {
            Love2dDll.wrap_love_dll_type_VideoStream_play(p);
        }
        public void pause()
        {
            Love2dDll.wrap_love_dll_type_VideoStream_pause(p);
        }
        public void seek(double offset)
        {
            Love2dDll.wrap_love_dll_type_VideoStream_seek(p, offset);
        }
        public void rewind()
        {
            Love2dDll.wrap_love_dll_type_VideoStream_rewind(p);
        }
        public double tell()
        {
            double out_position = 0;
            Love2dDll.wrap_love_dll_type_VideoStream_tell(p, out out_position);
            return out_position;
        }
        public bool isPlaying()
        {
            bool out_isplaying = false;
            Love2dDll.wrap_love_dll_type_VideoStream_isPlaying(p, out out_isplaying);
            return out_isplaying;
        }
    }

    public partial class BezierCurve : LoveObject
    {
        public int getDegree()
        {
            int out_degree = 0;
            Love2dDll.wrap_love_dll_type_BezierCurve_getDegree(p, out out_degree);
            return out_degree;
        }
        public BezierCurve getDerivative()
        {
            IntPtr out_deriv = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_BezierCurve_getDerivative(p, out out_deriv);
            return newObject<BezierCurve>(out_deriv);
        }
        public Float2 getControlPoint(int idx)
        {
            float out_x, out_y;
            Love2dDll.wrap_love_dll_type_BezierCurve_getControlPoint(p, idx, out out_x, out out_y);
            return new Float2(out_x, out_y);
        }
        public void setControlPoint(int idx, float x, float y)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_setControlPoint(p, idx, x, y);
        }
        public void insertControlPoint(int idx, float x, float y)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_insertControlPoint(p, idx, x, y);
        }
        public void removeControlPoint(int idx)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_removeControlPoint(p, idx);
        }
        public int getControlPointCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_BezierCurve_getControlPointCount(p, out out_count);
            return out_count;
        }
        public void translate(float dx, float dy)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_translate(p, dx, dy);
        }
        public void rotate(double phi, float ox, float oy)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_rotate(p, phi, ox, oy);
        }
        public void scale(double s, float ox, float oy)
        {
            Love2dDll.wrap_love_dll_type_BezierCurve_scale(p, s, ox, oy);
        }
        public Float2 evaluate(double t)
        {
            float out_x, out_y;
            Love2dDll.wrap_love_dll_type_BezierCurve_evaluate(p, t, out out_x, out out_y);
            return new Float2(out_x, out_y);
        }
        public BezierCurve getSegment(double t1, double t2)
        {
            IntPtr out_segment = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_BezierCurve_getSegment(p, t1, t2, out out_segment);
            return newObject<BezierCurve>(out_segment);
        }
        public Float2[] render(int accuracy)
        {
            IntPtr out_points;
            int out_points_lenght;
            Love2dDll.wrap_love_dll_type_BezierCurve_render(p, accuracy, out out_points, out out_points_lenght);
            return DllTool.readFloat2sAndRelease(out_points, out_points_lenght);
        }
        public Float2[] renderSegment(double start, double end, int accuracy)
        {
            IntPtr out_points;
            int out_points_lenght;
            Love2dDll.wrap_love_dll_type_BezierCurve_renderSegment(p, start, end, accuracy, out out_points, out out_points_lenght);
            return DllTool.readFloat2sAndRelease(out_points, out_points_lenght);
        }
    }

    public partial class RandomGenerator : LoveObject
    {
        public double random()
        {
            double out_result = 0;
            Love2dDll.wrap_love_dll_type_RandomGenerator_random(p, out out_result);
            return out_result;
        }
        public double randomNormal(double stddev, double mean)
        {
            double out_result = 0;
            Love2dDll.wrap_love_dll_type_RandomGenerator_randomNormal(p, stddev, mean, out out_result);
            return out_result;
        }
        public void setSeed(uint low, uint high)
        {
            Love2dDll.wrap_love_dll_type_RandomGenerator_setSeed(p, low, high);
        }
        public void getSeed(out uint out_low, out uint out_high)
        {
            Love2dDll.wrap_love_dll_type_RandomGenerator_getSeed(p, out out_low, out out_high);
        }
        public void setState(byte[] state)
        {
            Love2dDll.wrap_love_dll_type_RandomGenerator_setState(p, state);
        }
        public string getState()
        {
            IntPtr out_str;
            Love2dDll.wrap_love_dll_type_RandomGenerator_getState(p, out out_str);
            return DllTool.WSToStringAndRelease(out_str);
        }
    }

    public partial class Compressor
    {
        public enum Format
        {
            FORMAT_LZ4,
            FORMAT_ZLIB,
            FORMAT_GZIP,
            FORMAT_MAX_ENUM
        };
    }

    public partial class Joystick : LoveObject
    {
	    // Joystick hat values.
	    public enum Hat
        {
            HAT_INVALID,
            HAT_CENTERED,
            HAT_UP,
            HAT_RIGHT,
            HAT_DOWN,
            HAT_LEFT,
            HAT_RIGHTUP,
            HAT_RIGHTDOWN,
            HAT_LEFTUP,
            HAT_LEFTDOWN,
            HAT_MAX_ENUM = 16
        };

        // Valid Gamepad axes.
        public enum GamepadAxis
        {
            GAMEPAD_AXIS_INVALID,
            GAMEPAD_AXIS_LEFTX,
            GAMEPAD_AXIS_LEFTY,
            GAMEPAD_AXIS_RIGHTX,
            GAMEPAD_AXIS_RIGHTY,
            GAMEPAD_AXIS_TRIGGERLEFT,
            GAMEPAD_AXIS_TRIGGERRIGHT,
            GAMEPAD_AXIS_MAX_ENUM
        };

        // Valid Gamepad buttons.
        public enum GamepadButton
        {
            GAMEPAD_BUTTON_INVALID,
            GAMEPAD_BUTTON_A,
            GAMEPAD_BUTTON_B,
            GAMEPAD_BUTTON_X,
            GAMEPAD_BUTTON_Y,
            GAMEPAD_BUTTON_BACK,
            GAMEPAD_BUTTON_GUIDE,
            GAMEPAD_BUTTON_START,
            GAMEPAD_BUTTON_LEFTSTICK,
            GAMEPAD_BUTTON_RIGHTSTICK,
            GAMEPAD_BUTTON_LEFTSHOULDER,
            GAMEPAD_BUTTON_RIGHTSHOULDER,
            GAMEPAD_BUTTON_DPAD_UP,
            GAMEPAD_BUTTON_DPAD_DOWN,
            GAMEPAD_BUTTON_DPAD_LEFT,
            GAMEPAD_BUTTON_DPAD_RIGHT,
            GAMEPAD_BUTTON_MAX_ENUM
        };

        // Different types of inputs for a joystick.
        public enum InputType
        {
            INPUT_TYPE_AXIS,
            INPUT_TYPE_BUTTON,
            INPUT_TYPE_HAT,
            INPUT_TYPE_MAX_ENUM
        };



        public bool isConnected()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Joystick_isConnected(p, out out_result);
            return out_result;
        }
        public string getName()
        {
            IntPtr out_str = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Joystick_getName(p, out out_str);
            return DllTool.WSToStringAndRelease(out_str);
        }
        public int getID()
        {
            int out_id = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getID(p, out out_id);
            return out_id;
        }
        public int getInstanceID()
        {
            int out_instanceid = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getInstanceID(p, out out_instanceid);
            return out_instanceid;
        }
        public string getGUID()
        {
            IntPtr out_str = IntPtr.Zero;
            Love2dDll.wrap_love_dll_type_Joystick_getGUID(p, out out_str);
            return DllTool.WSToStringAndRelease(out_str);
        }
        public int getAxisCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getAxisCount(p, out out_count);
            return out_count;
        }
        public int getButtonCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getButtonCount(p, out out_count);
            return out_count;
        }
        public int getHatCount()
        {
            int out_count = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getHatCount(p, out out_count);
            return out_count;
        }
        public float getAxis(int axisindex)
        {
            float out_axis = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getAxis(p, axisindex, out out_axis);
            return out_axis;
        }
        public float[] getAxes()
        {
            IntPtr out_axes;
            int out_axes_length;
            Love2dDll.wrap_love_dll_type_Joystick_getAxes(p, out out_axes, out out_axes_length);
            return DllTool.readFloatsAndRelease(out_axes, out_axes_length);
        }
        public Hat getHat(int hatindex)
        {
            int out_hat_type = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getHat(p, hatindex, out out_hat_type);
            return (Hat)out_hat_type;
        }
        public bool isDown(int button)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Joystick_isDown(p, button, out out_result);
            return out_result;
        }
        public bool isGamepad()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Joystick_isGamepad(p, out out_result);
            return out_result;
        }
        public float getGamepadAxis(GamepadAxis axis_type)
        {
            float out_gamepadaxis = 0;
            Love2dDll.wrap_love_dll_type_Joystick_getGamepadAxis(p, (int)axis_type, out out_gamepadaxis);
            return out_gamepadaxis;
        }
        public bool isGamepadDown(GamepadButton gamepadButton_type)
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Joystick_isGamepadDown(p, (int)gamepadButton_type, out out_result);
            return out_result;
        }
        public bool isVibrationSupported()
        {
            bool out_result = false;
            Love2dDll.wrap_love_dll_type_Joystick_isVibrationSupported(p, out out_result);
            return out_result;
        }
        public bool setVibration_nil()
        {
            bool out_success = false;
            Love2dDll.wrap_love_dll_type_Joystick_setVibration_nil(p, out out_success);
            return out_success;
        }
        public bool setVibration(float left, float right, float duration)
        {
            bool out_success = false;
            Love2dDll.wrap_love_dll_type_Joystick_setVibration(p, left, right, duration, out out_success);
            return out_success;
        }
        public void getVibration(out float out_left, out float out_right)
        {
            Love2dDll.wrap_love_dll_type_Joystick_getVibration(p, out out_left, out out_right);
        }
    }


    public partial class Data : LoveObject
    {
        public uint getSize()
        {
            uint datasize;
            Love2dDll.wrap_love_dll_type_Data_getSize(p, out datasize);
            return datasize;
        }
    }

    public partial class TrueTypeRasterizer : LoveObject
    {
	    // Types of hinting for TrueType font glyphs.
	    public enum Hinting
        {
            HINTING_NORMAL,
            HINTING_LIGHT,
            HINTING_MONO,
            HINTING_NONE,
            HINTING_MAX_ENUM
        };
    }
    public partial class Drawable : LoveObject
    {
    }
    public partial class DroppedFile : File
    {

    }
    public partial class Stream : LoveObject
    {

    }
}


namespace Love2d
{
    public struct Triangle
    {
        public Float2 a, b, c;
    }

    public class Matrix22
    {
        float m00 { set { data[0] = value; } get { return data[0]; } }
        float m01 { set { data[1] = value; } get { return data[1]; } }
        float m10 { set { data[2] = value; } get { return data[2]; } }
        float m11 { set { data[3] = value; } get { return data[3]; } }
        internal readonly float[] data = new float[4];
    }

    public class Matrix33
    {
        float m00 { set { data[0] = value; } get { return data[0]; } }
        float m01 { set { data[1] = value; } get { return data[1]; } }
        float m02 { set { data[2] = value; } get { return data[2]; } }
        float m10 { set { data[3] = value; } get { return data[3]; } }
        float m11 { set { data[4] = value; } get { return data[4]; } }
        float m12 { set { data[5] = value; } get { return data[5]; } }
        float m20 { set { data[6] = value; } get { return data[6]; } }
        float m21 { set { data[7] = value; } get { return data[7]; } }
        float m22 { set { data[8] = value; } get { return data[8]; } }
        internal readonly float[] data = new float[9];
    }

    public class Matrix44
    {
        float m00 { set { data[0] = value; } get { return data[0]; } }
        float m01 { set { data[1] = value; } get { return data[1]; } }
        float m02 { set { data[2] = value; } get { return data[2]; } }
        float m03 { set { data[3] = value; } get { return data[3]; } }
        float m10 { set { data[4] = value; } get { return data[4]; } }
        float m11 { set { data[5] = value; } get { return data[5]; } }
        float m12 { set { data[6] = value; } get { return data[6]; } }
        float m13 { set { data[7] = value; } get { return data[7]; } }
        float m20 { set { data[8] = value; } get { return data[8]; } }
        float m21 { set { data[9] = value; } get { return data[9]; } }
        float m22 { set { data[10] = value; } get { return data[10]; } }
        float m23 { set { data[11] = value; } get { return data[11]; } }
        float m30 { set { data[12] = value; } get { return data[12]; } }
        float m31 { set { data[13] = value; } get { return data[13]; } }
        float m32 { set { data[14] = value; } get { return data[14]; } }
        float m33 { set { data[15] = value; } get { return data[15]; } }
        internal readonly float[] data = new float[16];
    }

    public struct ColoredString
    {
        public class Item
        {
            public readonly string text;
            public readonly Int4 color;
            public Item(string text, Int4 color)
            {
                this.text = text;
                this.color = color;
            }
        }
        public readonly Item[] items;

        public int Length
        {
            get { return items.Length; }
        }

        public ColoredString(string[] texts, Int4[] colors)
        {
            if (texts.Length != colors.Length)
            {
                throw new Exception("lenght of texts and colors must be same");
            }

            items = new Item[texts.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item(texts[i], colors[i]);
            }
        }

        public Tuple<Int4[], byte[][]> ToPart()
        {
            var colors = new Int4[Length];
            var texts = new byte[Length][];
            for (int i = 0; i < Length; i++)
            {
                colors[i] = items[i].color;
                texts[i] = DllTool.ToUTF8Bytes(items[i].text);
            }

            return new Tuple<Int4[], byte[][]>(colors, texts);
        }
    }
}