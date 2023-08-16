// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable RedundantAttributeSuffix

using System.Runtime.InteropServices;
using System.Text;

namespace Engine.OpenGL.Vendor.OpenGL.Core;

internal partial class Gl
{
    internal static partial class NativeMethods
    {
        [DllImport(Library, EntryPoint = "glActiveShaderProgram", ExactSpelling = true)]
        internal static extern void ActiveShaderProgram(UInt32 pipeline, UInt32 program);

        [DllImport(Library, EntryPoint = "glActiveTexture", ExactSpelling = true)]
        internal static extern void ActiveTexture(Int32 texture);

        [DllImport(Library, EntryPoint = "glAttachShader", ExactSpelling = true)]
        internal static extern void AttachShader(UInt32 program, UInt32 shader);

        [DllImport(Library, EntryPoint = "glBeginConditionalRender", ExactSpelling = true)]
        internal static extern void BeginConditionalRender(UInt32 id, ConditionalRenderType mode);

        [DllImport(Library, EntryPoint = "glEndConditionalRender", ExactSpelling = true)]
        internal static extern void EndConditionalRender();

        [DllImport(Library, EntryPoint = "glBeginQuery", ExactSpelling = true)]
        internal static extern void BeginQuery(QueryTarget target, UInt32 id);

        [DllImport(Library, EntryPoint = "glEndQuery", ExactSpelling = true)]
        internal static extern void EndQuery(QueryTarget target);

        [DllImport(Library, EntryPoint = "glBeginQueryIndexed", ExactSpelling = true)]
        internal static extern void BeginQueryIndexed(QueryTarget target, UInt32 index, UInt32 id);

        [DllImport(Library, EntryPoint = "glEndQueryIndexed", ExactSpelling = true)]
        internal static extern void EndQueryIndexed(QueryTarget target, UInt32 index);

        [DllImport(Library, EntryPoint = "glBeginTransformFeedback", ExactSpelling = true)]
        internal static extern void BeginTransformFeedback(BeginFeedbackMode primitiveMode);

        [DllImport(Library, EntryPoint = "glEndTransformFeedback", ExactSpelling = true)]
        internal static extern void EndTransformFeedback();

        [DllImport(Library, EntryPoint = "glBindAttribLocation", ExactSpelling = true)]
        internal static extern void BindAttribLocation(UInt32 program, UInt32 index, String name);

        [DllImport(Library, EntryPoint = "glBindBuffer", ExactSpelling = true)]
        internal static extern void BindBuffer(BufferTarget target, UInt32 buffer);

        [DllImport(Library, EntryPoint = "glBindBufferBase", ExactSpelling = true)]
        internal static extern void BindBufferBase(BufferTarget target, UInt32 index, UInt32 buffer);

        [DllImport(Library, EntryPoint = "glBindBufferRange", ExactSpelling = true)]
        internal static extern void BindBufferRange(BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset,
            IntPtr size);

        [DllImport(Library, EntryPoint = "glBindBuffersBase", ExactSpelling = true)]
        internal static extern void BindBuffersBase(BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers);

        [DllImport(Library, EntryPoint = "glBindBuffersRange", ExactSpelling = true)]
        internal static extern void BindBuffersRange(BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers,
            IntPtr[] offsets, IntPtr[] sizes);

        [DllImport(Library, EntryPoint = "glBindFragDataLocation", ExactSpelling = true)]
        internal static extern void BindFragDataLocation(UInt32 program, UInt32 colorNumber, String name);

        [DllImport(Library, EntryPoint = "glBindFragDataLocationIndexed", ExactSpelling = true)]
        internal static extern void BindFragDataLocationIndexed(UInt32 program, UInt32 colorNumber, UInt32 index,
            String name);

        [DllImport(Library, EntryPoint = "glBindFramebuffer", ExactSpelling = true)]
        internal static extern void BindFramebuffer(FramebufferTarget target, UInt32 framebuffer);

        [DllImport(Library, EntryPoint = "glBindImageTexture", ExactSpelling = true)]
        internal static extern void BindImageTexture(UInt32 unit, UInt32 texture, Int32 level, Boolean layered,
            Int32 layer, BufferAccess access, PixelInternalFormat format);

        [DllImport(Library, EntryPoint = "glBindImageTextures", ExactSpelling = true)]
        internal static extern void BindImageTextures(UInt32 first, Int32 count, UInt32[] textures);

        [DllImport(Library, EntryPoint = "glBindProgramPipeline", ExactSpelling = true)]
        internal static extern void BindProgramPipeline(UInt32 pipeline);

        [DllImport(Library, EntryPoint = "glBindRenderbuffer", ExactSpelling = true)]
        internal static extern void BindRenderbuffer(RenderbufferTarget target, UInt32 renderbuffer);

        [DllImport(Library, EntryPoint = "glBindSampler", ExactSpelling = true)]
        internal static extern void BindSampler(UInt32 unit, UInt32 sampler);

        [DllImport(Library, EntryPoint = "glBindSamplers", ExactSpelling = true)]
        internal static extern void BindSamplers(UInt32 first, Int32 count, UInt32[] samplers);

        [DllImport(Library, EntryPoint = "glBindTexture", ExactSpelling = true)]
        internal static extern void BindTexture(TextureTarget target, UInt32 texture);

        [DllImport(Library, EntryPoint = "glBindTextures", ExactSpelling = true)]
        internal static extern void BindTextures(UInt32 first, Int32 count, UInt32[] textures);

        [DllImport(Library, EntryPoint = "glBindTextureUnit", ExactSpelling = true)]
        internal static extern void BindTextureUnit(UInt32 unit, UInt32 texture);

        [DllImport(Library, EntryPoint = "glBindTransformFeedback", ExactSpelling = true)]
        internal static extern void BindTransformFeedback(NvTransformFeedback2 target, UInt32 id);

        [DllImport(Library, EntryPoint = "glBindVertexArray", ExactSpelling = true)]
        internal static extern void BindVertexArray(UInt32 array);

        [DllImport(Library, EntryPoint = "glBindVertexBuffer", ExactSpelling = true)]
        internal static extern void BindVertexBuffer(UInt32 bindingindex, UInt32 buffer, IntPtr offset, IntPtr stride);

        [DllImport(Library, EntryPoint = "glVertexArrayVertexBuffer", ExactSpelling = true)]
        internal static extern void VertexArrayVertexBuffer(UInt32 vaobj, UInt32 bindingindex, UInt32 buffer,
            IntPtr offset, Int32 stride);

        [DllImport(Library, EntryPoint = "glBindVertexBuffers", ExactSpelling = true)]
        internal static extern void BindVertexBuffers(UInt32 first, Int32 count, UInt32[] buffers, IntPtr[] offsets,
            Int32[] strides);

        [DllImport(Library, EntryPoint = "glVertexArrayVertexBuffers", ExactSpelling = true)]
        internal static extern void VertexArrayVertexBuffers(UInt32 vaobj, UInt32 first, Int32 count, UInt32[] buffers,
            IntPtr[] offsets, Int32[] strides);

        [DllImport(Library, EntryPoint = "glBlendColor", ExactSpelling = true)]
        internal static extern void BlendColor(Single red, Single green, Single blue, Single alpha);

        [DllImport(Library, EntryPoint = "glBlendEquation", ExactSpelling = true)]
        internal static extern void BlendEquation(BlendEquationMode mode);

        [DllImport(Library, EntryPoint = "glBlendEquationi", ExactSpelling = true)]
        internal static extern void BlendEquationi(UInt32 buf, BlendEquationMode mode);

        [DllImport(Library, EntryPoint = "glBlendEquationSeparate", ExactSpelling = true)]
        internal static extern void BlendEquationSeparate(BlendEquationMode modeRgb, BlendEquationMode modeAlpha);

        [DllImport(Library, EntryPoint = "glBlendEquationSeparatei", ExactSpelling = true)]
        internal static extern void BlendEquationSeparatei(UInt32 buf, BlendEquationMode modeRgb,
            BlendEquationMode modeAlpha);

        [DllImport(Library, EntryPoint = "glBlendFunc", ExactSpelling = true)]
        internal static extern void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

        [DllImport(Library, EntryPoint = "glBlendFunci", ExactSpelling = true)]
        internal static extern void BlendFunci(UInt32 buf, BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

        [DllImport(Library, EntryPoint = "glBlendFuncSeparate", ExactSpelling = true)]
        internal static extern void BlendFuncSeparate(BlendingFactorSrc srcRgb, BlendingFactorDest dstRgb,
            BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha);

        [DllImport(Library, EntryPoint = "glBlendFuncSeparatei", ExactSpelling = true)]
        internal static extern void BlendFuncSeparatei(UInt32 buf, BlendingFactorSrc srcRgb, BlendingFactorDest dstRgb,
            BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha);

        [DllImport(Library, EntryPoint = "glBlitFramebuffer", ExactSpelling = true)]
        internal static extern void BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0,
            Int32 dstY0, Int32 dstX1, Int32 dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);

        [DllImport(Library, EntryPoint = "glBlitNamedFramebuffer", ExactSpelling = true)]
        internal static extern void BlitNamedFramebuffer(UInt32 readFramebuffer, UInt32 drawFramebuffer, Int32 srcX0,
            Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1,
            ClearBufferMask mask, BlitFramebufferFilter filter);

        [DllImport(Library, EntryPoint = "glBufferData", ExactSpelling = true)]
        internal static extern void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage);

        [DllImport(Library, EntryPoint = "glNamedBufferData", ExactSpelling = true)]
        internal static extern void NamedBufferData(UInt32 buffer, Int32 size, IntPtr data, BufferUsageHint usage);

        [DllImport(Library, EntryPoint = "glBufferStorage", ExactSpelling = true)]
        internal static extern void BufferStorage(BufferTarget target, IntPtr size, IntPtr data, UInt32 flags);

        [DllImport(Library, EntryPoint = "glNamedBufferStorage", ExactSpelling = true)]
        internal static extern void NamedBufferStorage(UInt32 buffer, Int32 size, IntPtr data, UInt32 flags);

        [DllImport(Library, EntryPoint = "glBufferSubData", ExactSpelling = true)]
        internal static extern void BufferSubData(BufferTarget target, IntPtr offset, IntPtr size, IntPtr data);

        [DllImport(Library, EntryPoint = "glNamedBufferSubData", ExactSpelling = true)]
        internal static extern void NamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size, IntPtr data);

        [DllImport(Library, EntryPoint = "glCheckFramebufferStatus", ExactSpelling = true)]
        internal static extern FramebufferErrorCode CheckFramebufferStatus(FramebufferTarget target);

        [DllImport(Library, EntryPoint = "glCheckNamedFramebufferStatus", ExactSpelling = true)]
        internal static extern FramebufferErrorCode CheckNamedFramebufferStatus(UInt32 framebuffer,
            FramebufferTarget target);

        [DllImport(Library, EntryPoint = "glClampColor", ExactSpelling = true)]
        internal static extern void ClampColor(ClampColorTarget target, ClampColorMode clamp);

        [DllImport(Library, EntryPoint = "glClear", ExactSpelling = true)]
        internal static extern void Clear(ClearBufferMask mask);

        [DllImport(Library, EntryPoint = "glClearBufferiv", ExactSpelling = true)]
        internal static extern void ClearBufferiv(ClearBuffer buffer, Int32 drawbuffer, Int32[] value);

        [DllImport(Library, EntryPoint = "glClearBufferuiv", ExactSpelling = true)]
        internal static extern void ClearBufferuiv(ClearBuffer buffer, Int32 drawbuffer, UInt32[] value);

        [DllImport(Library, EntryPoint = "glClearBufferfv", ExactSpelling = true)]
        internal static extern void ClearBufferfv(ClearBuffer buffer, Int32 drawbuffer, Single[] value);

        [DllImport(Library, EntryPoint = "glClearBufferfi", ExactSpelling = true)]
        internal static extern void ClearBufferfi(ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil);

        [DllImport(Library, EntryPoint = "glClearNamedFramebufferiv", ExactSpelling = true)]
        internal static extern void ClearNamedFramebufferiv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
            Int32[] value);

        [DllImport(Library, EntryPoint = "glClearNamedFramebufferuiv", ExactSpelling = true)]
        internal static extern void ClearNamedFramebufferuiv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
            UInt32[] value);

        [DllImport(Library, EntryPoint = "glClearNamedFramebufferfv", ExactSpelling = true)]
        internal static extern void ClearNamedFramebufferfv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
            Single[] value);

        [DllImport(Library, EntryPoint = "glClearNamedFramebufferfi", ExactSpelling = true)]
        internal static extern void ClearNamedFramebufferfi(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
            Single depth, Int32 stencil);

        [DllImport(Library, EntryPoint = "glClearBufferData", ExactSpelling = true)]
        internal static extern void ClearBufferData(BufferTarget target, SizedInternalFormat internalFormat,
            PixelInternalFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glClearNamedBufferData", ExactSpelling = true)]
        internal static extern void ClearNamedBufferData(UInt32 buffer, SizedInternalFormat internalFormat,
            PixelInternalFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glClearBufferSubData", ExactSpelling = true)]
        internal static extern void ClearBufferSubData(BufferTarget target, SizedInternalFormat internalFormat,
            IntPtr offset, IntPtr size, PixelInternalFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glClearNamedBufferSubData", ExactSpelling = true)]
        internal static extern void ClearNamedBufferSubData(UInt32 buffer, SizedInternalFormat internalFormat,
            IntPtr offset, Int32 size, PixelInternalFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glClearColor", ExactSpelling = true)]
        internal static extern void ClearColor(Single red, Single green, Single blue, Single alpha);

        [DllImport(Library, EntryPoint = "glClearDepth", ExactSpelling = true)]
        internal static extern void ClearDepth(Double depth);

        [DllImport(Library, EntryPoint = "glClearDepthf", ExactSpelling = true)]
        internal static extern void ClearDepthf(Single depth);

        [DllImport(Library, EntryPoint = "glClearStencil", ExactSpelling = true)]
        internal static extern void ClearStencil(Int32 s);

        [DllImport(Library, EntryPoint = "glClearTexImage", ExactSpelling = true)]
        internal static extern void ClearTexImage(UInt32 texture, Int32 level, PixelInternalFormat format,
            PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glClearTexSubImage", ExactSpelling = true)]
        internal static extern void ClearTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelInternalFormat format, PixelType type,
            IntPtr data);

        [DllImport(Library, EntryPoint = "glClientWaitSync", ExactSpelling = true)]
        internal static extern ArbSync ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);

        [DllImport(Library, EntryPoint = "glClipControl", ExactSpelling = true)]
        internal static extern void ClipControl(ClipControlOrigin origin, ClipControlDepth depth);

        [DllImport(Library, EntryPoint = "glColorMask", ExactSpelling = true)]
        internal static extern void ColorMask(Boolean red, Boolean green, Boolean blue, Boolean alpha);

        [DllImport(Library, EntryPoint = "glColorMaski", ExactSpelling = true)]
        internal static extern void ColorMaski(UInt32 buf, Boolean red, Boolean green, Boolean blue, Boolean alpha);

        [DllImport(Library, EntryPoint = "glCompileShader", ExactSpelling = true)]
        internal static extern void CompileShader(UInt32 shader);

        [DllImport(Library, EntryPoint = "glCompressedTexImage1D", ExactSpelling = true)]
        internal static extern void CompressedTexImage1D(TextureTarget target, Int32 level,
            PixelInternalFormat internalFormat, Int32 width, Int32 border, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTexImage2D", ExactSpelling = true)]
        internal static extern void CompressedTexImage2D(TextureTarget target, Int32 level,
            PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTexImage3D", ExactSpelling = true)]
        internal static extern void CompressedTexImage3D(TextureTarget target, Int32 level,
            PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize,
            IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTexSubImage1D", ExactSpelling = true)]
        internal static extern void CompressedTexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset,
            Int32 width, PixelFormat format, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTextureSubImage1D", ExactSpelling = true)]
        internal static extern void CompressedTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width,
            PixelInternalFormat format, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTexSubImage2D", ExactSpelling = true)]
        internal static extern void CompressedTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset,
            Int32 yoffset, Int32 width, Int32 height, PixelFormat format, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTextureSubImage2D", ExactSpelling = true)]
        internal static extern void CompressedTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset,
            Int32 yoffset, Int32 width, Int32 height, PixelInternalFormat format, Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTexSubImage3D", ExactSpelling = true)]
        internal static extern void CompressedTexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset,
            Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, Int32 imageSize,
            IntPtr data);

        [DllImport(Library, EntryPoint = "glCompressedTextureSubImage3D", ExactSpelling = true)]
        internal static extern void CompressedTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset,
            Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelInternalFormat format,
            Int32 imageSize, IntPtr data);

        [DllImport(Library, EntryPoint = "glCopyBufferSubData", ExactSpelling = true)]
        internal static extern void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget,
            IntPtr readOffset, IntPtr writeOffset, IntPtr size);

        [DllImport(Library, EntryPoint = "glCopyNamedBufferSubData", ExactSpelling = true)]
        internal static extern void CopyNamedBufferSubData(UInt32 readBuffer, UInt32 writeBuffer, IntPtr readOffset,
            IntPtr writeOffset, Int32 size);

        [DllImport(Library, EntryPoint = "glCopyImageSubData", ExactSpelling = true)]
        internal static extern void CopyImageSubData(UInt32 srcName, BufferTarget srcTarget, Int32 srcLevel, Int32 srcX,
            Int32 srcY, Int32 srcZ, UInt32 dstName, BufferTarget dstTarget, Int32 dstLevel, Int32 dstX, Int32 dstY,
            Int32 dstZ, Int32 srcWidth, Int32 srcHeight, Int32 srcDepth);

        [DllImport(Library, EntryPoint = "glCopyTexImage1D", ExactSpelling = true)]
        internal static extern void CopyTexImage1D(TextureTarget target, Int32 level,
            PixelInternalFormat internalFormat, Int32 x, Int32 y, Int32 width, Int32 border);

        [DllImport(Library, EntryPoint = "glCopyTexImage2D", ExactSpelling = true)]
        internal static extern void CopyTexImage2D(TextureTarget target, Int32 level,
            PixelInternalFormat internalFormat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border);

        [DllImport(Library, EntryPoint = "glCopyTexSubImage1D", ExactSpelling = true)]
        internal static extern void CopyTexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset, Int32 x,
            Int32 y, Int32 width);

        [DllImport(Library, EntryPoint = "glCopyTextureSubImage1D", ExactSpelling = true)]
        internal static extern void CopyTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 x, Int32 y,
            Int32 width);

        [DllImport(Library, EntryPoint = "glCopyTexSubImage2D", ExactSpelling = true)]
        internal static extern void CopyTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glCopyTextureSubImage2D", ExactSpelling = true)]
        internal static extern void CopyTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glCopyTexSubImage3D", ExactSpelling = true)]
        internal static extern void CopyTexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glCopyTextureSubImage3D", ExactSpelling = true)]
        internal static extern void CopyTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glCreateBuffers", ExactSpelling = true)]
        internal static extern void CreateBuffers(Int32 n, UInt32[] buffers);

        [DllImport(Library, EntryPoint = "glCreateFramebuffers", ExactSpelling = true)]
        internal static extern void CreateFramebuffers(Int32 n, UInt32[] ids);

        [DllImport(Library, EntryPoint = "glCreateProgram", ExactSpelling = true)]
        internal static extern UInt32 CreateProgram();

        [DllImport(Library, EntryPoint = "glCreateProgramPipelines", ExactSpelling = true)]
        internal static extern void CreateProgramPipelines(Int32 n, UInt32[] pipelines);

        [DllImport(Library, EntryPoint = "glCreateQueries", ExactSpelling = true)]
        internal static extern void CreateQueries(QueryTarget target, Int32 n, UInt32[] ids);

        [DllImport(Library, EntryPoint = "glCreateRenderbuffers", ExactSpelling = true)]
        internal static extern void CreateRenderbuffers(Int32 n, UInt32[] renderbuffers);

        [DllImport(Library, EntryPoint = "glCreateSamplers", ExactSpelling = true)]
        internal static extern void CreateSamplers(Int32 n, UInt32[] samplers);

        [DllImport(Library, EntryPoint = "glCreateShader", ExactSpelling = true)]
        internal static extern UInt32 CreateShader(ShaderType shaderType);

        [DllImport(Library, EntryPoint = "glCreateShaderProgramv", ExactSpelling = true)]
        internal static extern UInt32 CreateShaderProgramv(ShaderType type, Int32 count, String strings);

        [DllImport(Library, EntryPoint = "glCreateTextures", ExactSpelling = true)]
        internal static extern void CreateTextures(TextureTarget target, Int32 n, UInt32[] textures);

        [DllImport(Library, EntryPoint = "glCreateTransformFeedbacks", ExactSpelling = true)]
        internal static extern void CreateTransformFeedbacks(Int32 n, UInt32[] ids);

        [DllImport(Library, EntryPoint = "glCreateVertexArrays", ExactSpelling = true)]
        internal static extern void CreateVertexArrays(Int32 n, UInt32[] arrays);

        [DllImport(Library, EntryPoint = "glCullFace", ExactSpelling = true)]
        internal static extern void CullFace(CullFaceMode mode);

        [DllImport(Library, EntryPoint = "glDeleteBuffers", ExactSpelling = true)]
        internal static extern void DeleteBuffers(Int32 n, UInt32[] buffers);

        [DllImport(Library, EntryPoint = "glDeleteFramebuffers", ExactSpelling = true)]
        internal static extern void DeleteFramebuffers(Int32 n, UInt32[] framebuffers);

        [DllImport(Library, EntryPoint = "glDeleteProgram", ExactSpelling = true)]
        internal static extern void DeleteProgram(UInt32 program);

        [DllImport(Library, EntryPoint = "glDeleteProgramPipelines", ExactSpelling = true)]
        internal static extern void DeleteProgramPipelines(Int32 n, UInt32[] pipelines);

        [DllImport(Library, EntryPoint = "glDeleteQueries", ExactSpelling = true)]
        internal static extern void DeleteQueries(Int32 n, UInt32[] ids);

        [DllImport(Library, EntryPoint = "glDeleteRenderbuffers", ExactSpelling = true)]
        internal static extern void DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers);

        [DllImport(Library, EntryPoint = "glDeleteSamplers", ExactSpelling = true)]
        internal static extern void DeleteSamplers(Int32 n, UInt32[] samplers);

        [DllImport(Library, EntryPoint = "glDeleteShader", ExactSpelling = true)]
        internal static extern void DeleteShader(UInt32 shader);

        [DllImport(Library, EntryPoint = "glDeleteSync", ExactSpelling = true)]
        internal static extern void DeleteSync(IntPtr sync);

        [DllImport(Library, EntryPoint = "glDeleteTextures", ExactSpelling = true)]
        internal static extern void DeleteTextures(Int32 n, UInt32[] textures);

        [DllImport(Library, EntryPoint = "glDeleteTransformFeedbacks", ExactSpelling = true)]
        internal static extern void DeleteTransformFeedbacks(Int32 n, UInt32[] ids);

        [DllImport(Library, EntryPoint = "glDeleteVertexArrays", ExactSpelling = true)]
        internal static extern void DeleteVertexArrays(Int32 n, UInt32[] arrays);

        [DllImport(Library, EntryPoint = "glDepthFunc", ExactSpelling = true)]
        internal static extern void DepthFunc(DepthFunction func);

        [DllImport(Library, EntryPoint = "glDepthMask", ExactSpelling = true)]
        internal static extern void DepthMask(Boolean flag);

        [DllImport(Library, EntryPoint = "glDepthRange", ExactSpelling = true)]
        internal static extern void DepthRange(Double nearVal, Double farVal);

        [DllImport(Library, EntryPoint = "glDepthRangef", ExactSpelling = true)]
        internal static extern void DepthRangef(Single nearVal, Single farVal);

        [DllImport(Library, EntryPoint = "glDepthRangeArrayv", ExactSpelling = true)]
        internal static extern void DepthRangeArrayv(UInt32 first, Int32 count, Double[] v);

        [DllImport(Library, EntryPoint = "glDepthRangeIndexed", ExactSpelling = true)]
        internal static extern void DepthRangeIndexed(UInt32 index, Double nearVal, Double farVal);

        [DllImport(Library, EntryPoint = "glDetachShader", ExactSpelling = true)]
        internal static extern void DetachShader(UInt32 program, UInt32 shader);

        [DllImport(Library, EntryPoint = "glDispatchCompute", ExactSpelling = true)]
        internal static extern void DispatchCompute(UInt32 numGroupsX, UInt32 numGroupsY, UInt32 numGroupsZ);

        [DllImport(Library, EntryPoint = "glDispatchComputeIndirect", ExactSpelling = true)]
        internal static extern void DispatchComputeIndirect(IntPtr indirect);

        [DllImport(Library, EntryPoint = "glDrawArrays", ExactSpelling = true)]
        internal static extern void DrawArrays(BeginMode mode, Int32 first, Int32 count);

        [DllImport(Library, EntryPoint = "glDrawArraysIndirect", ExactSpelling = true)]
        internal static extern void DrawArraysIndirect(BeginMode mode, IntPtr indirect);

        [DllImport(Library, EntryPoint = "glDrawArraysInstanced", ExactSpelling = true)]
        internal static extern void DrawArraysInstanced(BeginMode mode, Int32 first, Int32 count, Int32 primcount);

        [DllImport(Library, EntryPoint = "glDrawArraysInstancedBaseInstance", ExactSpelling = true)]
        internal static extern void DrawArraysInstancedBaseInstance(BeginMode mode, Int32 first, Int32 count,
            Int32 primcount, UInt32 baseinstance);

        [DllImport(Library, EntryPoint = "glDrawBuffer", ExactSpelling = true)]
        internal static extern void DrawBuffer(DrawBufferMode buf);

        [DllImport(Library, EntryPoint = "glNamedFramebufferDrawBuffer", ExactSpelling = true)]
        internal static extern void NamedFramebufferDrawBuffer(UInt32 framebuffer, DrawBufferMode buf);

        [DllImport(Library, EntryPoint = "glDrawBuffers", ExactSpelling = true)]
        internal static extern void DrawBuffers(Int32 n, DrawBuffersEnum[] bufs);

        [DllImport(Library, EntryPoint = "glNamedFramebufferDrawBuffers", ExactSpelling = true)]
        internal static extern void NamedFramebufferDrawBuffers(UInt32 framebuffer, Int32 n, DrawBufferMode[] bufs);

        [DllImport(Library, EntryPoint = "glDrawElements", ExactSpelling = true)]
        internal static extern void DrawElements(BeginMode mode, Int32 count, DrawElementsType type, IntPtr indices);

        [DllImport(Library, EntryPoint = "glDrawElementsBaseVertex", ExactSpelling = true)]
        internal static extern void DrawElementsBaseVertex(BeginMode mode, Int32 count, DrawElementsType type,
            IntPtr indices, Int32 basevertex);

        [DllImport(Library, EntryPoint = "glDrawElementsIndirect", ExactSpelling = true)]
        internal static extern void DrawElementsIndirect(BeginMode mode, DrawElementsType type, IntPtr indirect);

        [DllImport(Library, EntryPoint = "glDrawElementsInstanced", ExactSpelling = true)]
        internal static extern void DrawElementsInstanced(BeginMode mode, Int32 count, DrawElementsType type,
            IntPtr indices, Int32 primcount);

        [DllImport(Library, EntryPoint = "glDrawElementsInstancedBaseInstance", ExactSpelling = true)]
        internal static extern void DrawElementsInstancedBaseInstance(BeginMode mode, Int32 count,
            DrawElementsType type, IntPtr indices, Int32 primcount, UInt32 baseinstance);

        [DllImport(Library, EntryPoint = "glDrawElementsInstancedBaseVertex", ExactSpelling = true)]
        internal static extern void DrawElementsInstancedBaseVertex(BeginMode mode, Int32 count, DrawElementsType type,
            IntPtr indices, Int32 primcount, Int32 basevertex);

        [DllImport(Library, EntryPoint = "glDrawElementsInstancedBaseVertexBaseInstance", ExactSpelling = true)]
        internal static extern void DrawElementsInstancedBaseVertexBaseInstance(BeginMode mode, Int32 count,
            DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex, UInt32 baseinstance);

        [DllImport(Library, EntryPoint = "glDrawRangeElements", ExactSpelling = true)]
        internal static extern void DrawRangeElements(BeginMode mode, UInt32 start, UInt32 end, Int32 count,
            DrawElementsType type, IntPtr indices);

        [DllImport(Library, EntryPoint = "glDrawRangeElementsBaseVertex", ExactSpelling = true)]
        internal static extern void DrawRangeElementsBaseVertex(BeginMode mode, UInt32 start, UInt32 end, Int32 count,
            DrawElementsType type, IntPtr indices, Int32 basevertex);

        [DllImport(Library, EntryPoint = "glDrawTransformFeedback", ExactSpelling = true)]
        internal static extern void DrawTransformFeedback(NvTransformFeedback2 mode, UInt32 id);

        [DllImport(Library, EntryPoint = "glDrawTransformFeedbackInstanced", ExactSpelling = true)]
        internal static extern void DrawTransformFeedbackInstanced(BeginMode mode, UInt32 id, Int32 primcount);

        [DllImport(Library, EntryPoint = "glDrawTransformFeedbackStream", ExactSpelling = true)]
        internal static extern void DrawTransformFeedbackStream(NvTransformFeedback2 mode, UInt32 id, UInt32 stream);

        [DllImport(Library, EntryPoint = "glDrawTransformFeedbackStreamInstanced", ExactSpelling = true)]
        internal static extern void DrawTransformFeedbackStreamInstanced(BeginMode mode, UInt32 id, UInt32 stream,
            Int32 primcount);

        [DllImport(Library, EntryPoint = "glEnable", ExactSpelling = true)]
        internal static extern void Enable(EnableCap cap);

        [DllImport(Library, EntryPoint = "glDisable", ExactSpelling = true)]
        internal static extern void Disable(EnableCap cap);

        [DllImport(Library, EntryPoint = "glEnablei", ExactSpelling = true)]
        internal static extern void Enablei(EnableCap cap, UInt32 index);

        [DllImport(Library, EntryPoint = "glDisablei", ExactSpelling = true)]
        internal static extern void Disablei(EnableCap cap, UInt32 index);

        [DllImport(Library, EntryPoint = "glEnableVertexAttribArray", ExactSpelling = true)]
        internal static extern void EnableVertexAttribArray(UInt32 index);

        [DllImport(Library, EntryPoint = "glDisableVertexAttribArray", ExactSpelling = true)]
        internal static extern void DisableVertexAttribArray(UInt32 index);

        [DllImport(Library, EntryPoint = "glEnableVertexArrayAttrib", ExactSpelling = true)]
        internal static extern void EnableVertexArrayAttrib(UInt32 vaobj, UInt32 index);

        [DllImport(Library, EntryPoint = "glDisableVertexArrayAttrib", ExactSpelling = true)]
        internal static extern void DisableVertexArrayAttrib(UInt32 vaobj, UInt32 index);

        [DllImport(Library, EntryPoint = "glFenceSync", ExactSpelling = true)]
        internal static extern IntPtr FenceSync(ArbSync condition, UInt32 flags);

        [DllImport(Library, EntryPoint = "glFinish", ExactSpelling = true)]
        internal static extern void Finish();

        [DllImport(Library, EntryPoint = "glFlush", ExactSpelling = true)]
        internal static extern void Flush();

        [DllImport(Library, EntryPoint = "glFlushMappedBufferRange", ExactSpelling = true)]
        internal static extern void FlushMappedBufferRange(BufferTarget target, IntPtr offset, IntPtr length);

        [DllImport(Library, EntryPoint = "glFlushMappedNamedBufferRange", ExactSpelling = true)]
        internal static extern void FlushMappedNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length);

        [DllImport(Library, EntryPoint = "glFramebufferParameteri", ExactSpelling = true)]
        internal static extern void
            FramebufferParameteri(FramebufferTarget target, FramebufferPName pname, Int32 param);

        [DllImport(Library, EntryPoint = "glNamedFramebufferParameteri", ExactSpelling = true)]
        internal static extern void NamedFramebufferParameteri(UInt32 framebuffer, FramebufferPName pname, Int32 param);

        [DllImport(Library, EntryPoint = "glFramebufferRenderbuffer", ExactSpelling = true)]
        internal static extern void FramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment,
            RenderbufferTarget renderbuffertarget, UInt32 renderbuffer);

        [DllImport(Library, EntryPoint = "glNamedFramebufferRenderbuffer", ExactSpelling = true)]
        internal static extern void NamedFramebufferRenderbuffer(UInt32 framebuffer, FramebufferAttachment attachment,
            RenderbufferTarget renderbuffertarget, UInt32 renderbuffer);

        [DllImport(Library, EntryPoint = "glFramebufferTexture", ExactSpelling = true)]
        internal static extern void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment,
            UInt32 texture, Int32 level);

        [DllImport(Library, EntryPoint = "glFramebufferTexture1D", ExactSpelling = true)]
        internal static extern void FramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment,
            TextureTarget textarget, UInt32 texture, Int32 level);

        [DllImport(Library, EntryPoint = "glFramebufferTexture2D", ExactSpelling = true)]
        internal static extern void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment,
            TextureTarget textarget, UInt32 texture, Int32 level);

        [DllImport(Library, EntryPoint = "glFramebufferTexture3D", ExactSpelling = true)]
        internal static extern void FramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment,
            TextureTarget textarget, UInt32 texture, Int32 level, Int32 layer);

        [DllImport(Library, EntryPoint = "glNamedFramebufferTexture", ExactSpelling = true)]
        internal static extern void NamedFramebufferTexture(UInt32 framebuffer, FramebufferAttachment attachment,
            UInt32 texture, Int32 level);

        [DllImport(Library, EntryPoint = "glFramebufferTextureLayer", ExactSpelling = true)]
        internal static extern void FramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment,
            UInt32 texture, Int32 level, Int32 layer);

        [DllImport(Library, EntryPoint = "glNamedFramebufferTextureLayer", ExactSpelling = true)]
        internal static extern void NamedFramebufferTextureLayer(UInt32 framebuffer, FramebufferAttachment attachment,
            UInt32 texture, Int32 level, Int32 layer);

        [DllImport(Library, EntryPoint = "glFrontFace", ExactSpelling = true)]
        internal static extern void FrontFace(FrontFaceDirection mode);

        [DllImport(Library, EntryPoint = "glGenBuffers", ExactSpelling = true)]
        internal static extern void GenBuffers(Int32 n, [Out] UInt32[] buffers);

        [DllImport(Library, EntryPoint = "glGenerateMipmap", ExactSpelling = true)]
        internal static extern void GenerateMipmap(GenerateMipmapTarget target);

        [DllImport(Library, EntryPoint = "glGenerateTextureMipmap", ExactSpelling = true)]
        internal static extern void GenerateTextureMipmap(UInt32 texture);

        [DllImport(Library, EntryPoint = "glGenFramebuffers", ExactSpelling = true)]
        internal static extern void GenFramebuffers(Int32 n, [Out] UInt32[] ids);

        [DllImport(Library, EntryPoint = "glGenProgramPipelines", ExactSpelling = true)]
        internal static extern void GenProgramPipelines(Int32 n, [Out] UInt32[] pipelines);

        [DllImport(Library, EntryPoint = "glGenQueries", ExactSpelling = true)]
        internal static extern void GenQueries(Int32 n, [Out] UInt32[] ids);

        [DllImport(Library, EntryPoint = "glGenRenderbuffers", ExactSpelling = true)]
        internal static extern void GenRenderbuffers(Int32 n, [Out] UInt32[] renderbuffers);

        [DllImport(Library, EntryPoint = "glGenSamplers", ExactSpelling = true)]
        internal static extern void GenSamplers(Int32 n, [Out] UInt32[] samplers);

        [DllImport(Library, EntryPoint = "glGenTextures", ExactSpelling = true)]
        internal static extern void GenTextures(Int32 n, [Out] UInt32[] textures);

        [DllImport(Library, EntryPoint = "glGenTransformFeedbacks", ExactSpelling = true)]
        internal static extern void GenTransformFeedbacks(Int32 n, [Out] UInt32[] ids);

        [DllImport(Library, EntryPoint = "glGenVertexArrays", ExactSpelling = true)]
        internal static extern void GenVertexArrays(Int32 n, [Out] UInt32[] arrays);

        [DllImport(Library, EntryPoint = "glGetBooleanv", ExactSpelling = true)]
        internal static extern void GetBooleanv(GetPName pname, [Out] Boolean[] data);

        [DllImport(Library, EntryPoint = "glGetDoublev", ExactSpelling = true)]
        internal static extern void GetDoublev(GetPName pname, [Out] Double[] data);

        [DllImport(Library, EntryPoint = "glGetFloatv", ExactSpelling = true)]
        internal static extern void GetFloatv(GetPName pname, [Out] Single[] data);

        [DllImport(Library, EntryPoint = "glGetIntegerv", ExactSpelling = true)]
        internal static extern void GetIntegerv(GetPName pname, [Out] Int32[] data);

        [DllImport(Library, EntryPoint = "glGetInteger64v", ExactSpelling = true)]
        internal static extern void GetInteger64v(ArbSync pname, [Out] Int64[] data);

        [DllImport(Library, EntryPoint = "glGetBooleani_v", ExactSpelling = true)]
        internal static extern void GetBooleani_v(GetPName target, UInt32 index, [Out] Boolean[] data);

        [DllImport(Library, EntryPoint = "glGetIntegeri_v", ExactSpelling = true)]
        internal static extern void GetIntegeri_v(GetPName target, UInt32 index, [Out] Int32[] data);

        [DllImport(Library, EntryPoint = "glGetFloati_v", ExactSpelling = true)]
        internal static extern void GetFloati_v(GetPName target, UInt32 index, [Out] Single[] data);

        [DllImport(Library, EntryPoint = "glGetDoublei_v", ExactSpelling = true)]
        internal static extern void GetDoublei_v(GetPName target, UInt32 index, [Out] Double[] data);

        [DllImport(Library, EntryPoint = "glGetInteger64i_v", ExactSpelling = true)]
        internal static extern void GetInteger64i_v(GetPName target, UInt32 index, [Out] Int64[] data);

        [DllImport(Library, EntryPoint = "glGetActiveAtomicCounterBufferiv", ExactSpelling = true)]
        internal static extern void GetActiveAtomicCounterBufferiv(UInt32 program, UInt32 bufferIndex,
            AtomicCounterParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetActiveAttrib", ExactSpelling = true)]
        internal static extern void GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, [Out] Int32[] length,
            [Out] Int32[] size, [Out] ActiveAttribType[] type, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetActiveSubroutineName", ExactSpelling = true)]
        internal static extern void GetActiveSubroutineName(UInt32 program, ShaderType shadertype, UInt32 index,
            Int32 bufsize, [Out] Int32[] length, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetActiveSubroutineUniformiv", ExactSpelling = true)]
        internal static extern void GetActiveSubroutineUniformiv(UInt32 program, ShaderType shadertype, UInt32 index,
            SubroutineParameterName pname, [Out] Int32[] values);

        [DllImport(Library, EntryPoint = "glGetActiveSubroutineUniformName", ExactSpelling = true)]
        internal static extern void GetActiveSubroutineUniformName(UInt32 program, ShaderType shadertype, UInt32 index,
            Int32 bufsize, [Out] Int32[] length, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetActiveUniform", ExactSpelling = true)]
        internal static extern void GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, [Out] Int32[] length,
            [Out] Int32[] size, [Out] ActiveUniformType[] type, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetActiveUniformBlockiv", ExactSpelling = true)]
        internal static extern void GetActiveUniformBlockiv(UInt32 program, UInt32 uniformBlockIndex,
            ActiveUniformBlockParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetActiveUniformBlockName", ExactSpelling = true)]
        internal static extern void GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize,
            [Out] Int32[] length, [Out] StringBuilder uniformBlockName);

        [DllImport(Library, EntryPoint = "glGetActiveUniformName", ExactSpelling = true)]
        internal static extern void GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize,
            [Out] Int32[] length, [Out] StringBuilder uniformName);

        [DllImport(Library, EntryPoint = "glGetActiveUniformsiv", ExactSpelling = true)]
        internal static extern void GetActiveUniformsiv(UInt32 program, Int32 uniformCount,
            [Out] UInt32[] uniformIndices, ActiveUniformType pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetAttachedShaders", ExactSpelling = true)]
        internal static extern void GetAttachedShaders(UInt32 program, Int32 maxCount, [Out] Int32[] count,
            [Out] UInt32[] shaders);

        [DllImport(Library, EntryPoint = "glGetAttribLocation", ExactSpelling = true)]
        internal static extern Int32 GetAttribLocation(UInt32 program, String name);

        [DllImport(Library, EntryPoint = "glGetBufferParameteriv", ExactSpelling = true)]
        internal static extern void GetBufferParameteriv(BufferTarget target, BufferParameterName value,
            [Out] Int32[] data);

        [DllImport(Library, EntryPoint = "glGetBufferParameteri64v", ExactSpelling = true)]
        internal static extern void GetBufferParameteri64v(BufferTarget target, BufferParameterName value,
            [Out] Int64[] data);

        [DllImport(Library, EntryPoint = "glGetNamedBufferParameteriv", ExactSpelling = true)]
        internal static extern void GetNamedBufferParameteriv(UInt32 buffer, BufferParameterName pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetNamedBufferParameteri64v", ExactSpelling = true)]
        internal static extern void GetNamedBufferParameteri64v(UInt32 buffer, BufferParameterName pname,
            [Out] Int64[] @params);

        [DllImport(Library, EntryPoint = "glGetBufferPointerv", ExactSpelling = true)]
        internal static extern void GetBufferPointerv(BufferTarget target, BufferPointer pname, [Out] IntPtr @params);

        [DllImport(Library, EntryPoint = "glGetNamedBufferPointerv", ExactSpelling = true)]
        internal static extern void GetNamedBufferPointerv(UInt32 buffer, BufferPointer pname, [Out] IntPtr @params);

        [DllImport(Library, EntryPoint = "glGetBufferSubData", ExactSpelling = true)]
        internal static extern void
            GetBufferSubData(BufferTarget target, IntPtr offset, IntPtr size, [Out] IntPtr data);

        [DllImport(Library, EntryPoint = "glGetNamedBufferSubData", ExactSpelling = true)]
        internal static extern void GetNamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size, [Out] IntPtr data);

        [DllImport(Library, EntryPoint = "glGetCompressedTexImage", ExactSpelling = true)]
        internal static extern void GetCompressedTexImage(TextureTarget target, Int32 level, [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetnCompressedTexImage", ExactSpelling = true)]
        internal static extern void GetnCompressedTexImage(TextureTarget target, Int32 level, Int32 bufSize,
            [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetCompressedTextureImage", ExactSpelling = true)]
        internal static extern void GetCompressedTextureImage(UInt32 texture, Int32 level, Int32 bufSize,
            [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetCompressedTextureSubImage", ExactSpelling = true)]
        internal static extern void GetCompressedTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset,
            Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, Int32 bufSize, [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetError", ExactSpelling = true)]
        internal static extern ErrorCode GetError();

        [DllImport(Library, EntryPoint = "glGetFragDataIndex", ExactSpelling = true)]
        internal static extern Int32 GetFragDataIndex(UInt32 program, String name);

        [DllImport(Library, EntryPoint = "glGetFragDataLocation", ExactSpelling = true)]
        internal static extern Int32 GetFragDataLocation(UInt32 program, String name);

        [DllImport(Library, EntryPoint = "glGetFramebufferAttachmentParameteriv", ExactSpelling = true)]
        internal static extern void GetFramebufferAttachmentParameteriv(FramebufferTarget target,
            FramebufferAttachment attachment, FramebufferParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetNamedFramebufferAttachmentParameteriv", ExactSpelling = true)]
        internal static extern void GetNamedFramebufferAttachmentParameteriv(UInt32 framebuffer,
            FramebufferAttachment attachment, FramebufferParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetFramebufferParameteriv", ExactSpelling = true)]
        internal static extern void GetFramebufferParameteriv(FramebufferTarget target, FramebufferPName pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetNamedFramebufferParameteriv", ExactSpelling = true)]
        internal static extern void GetNamedFramebufferParameteriv(UInt32 framebuffer, FramebufferPName pname,
            [Out] Int32[] param);

        [DllImport(Library, EntryPoint = "glGetGraphicsResetStatus", ExactSpelling = true)]
        internal static extern GraphicResetStatus GetGraphicsResetStatus();

        [DllImport(Library, EntryPoint = "glGetInternalformativ", ExactSpelling = true)]
        internal static extern void GetInternalformativ(TextureTarget target, PixelInternalFormat internalFormat,
            GetPName pname, Int32 bufSize, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetInternalformati64v", ExactSpelling = true)]
        internal static extern void GetInternalformati64v(TextureTarget target, PixelInternalFormat internalFormat,
            GetPName pname, Int32 bufSize, [Out] Int64[] @params);

        [DllImport(Library, EntryPoint = "glGetMultisamplefv", ExactSpelling = true)]
        internal static extern void GetMultisamplefv(GetMultisamplePName pname, UInt32 index, [Out] Single[] val);

        [DllImport(Library, EntryPoint = "glGetObjectLabel", ExactSpelling = true)]
        internal static extern void GetObjectLabel(ObjectLabel identifier, UInt32 name, Int32 bufSize,
            [Out] Int32[] length, [Out] StringBuilder label);

        [DllImport(Library, EntryPoint = "glGetObjectPtrLabel", ExactSpelling = true)]
        internal static extern void GetObjectPtrLabel([Out] IntPtr ptr, Int32 bufSize, [Out] Int32[] length,
            [Out] StringBuilder label);

        [DllImport(Library, EntryPoint = "glGetPointerv", ExactSpelling = true)]
        internal static extern void GetPointerv(GetPointerParameter pname, [Out] IntPtr @params);

        [DllImport(Library, EntryPoint = "glGetProgramiv", ExactSpelling = true)]
        internal static extern void GetProgramiv(UInt32 program, ProgramParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetProgramBinary", ExactSpelling = true)]
        internal static extern void GetProgramBinary(UInt32 program, Int32 bufsize, [Out] Int32[] length,
            [Out] Int32[] binaryFormat, [Out] IntPtr binary);

        [DllImport(Library, EntryPoint = "glGetProgramInfoLog", ExactSpelling = true)]
        internal static extern void GetProgramInfoLog(UInt32 program, Int32 maxLength, [Out] Int32[] length,
            [Out] StringBuilder infoLog);

        [DllImport(Library, EntryPoint = "glGetProgramInterfaceiv", ExactSpelling = true)]
        internal static extern void GetProgramInterfaceiv(UInt32 program, ProgramInterface programInterface,
            ProgramInterfaceParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetProgramPipelineiv", ExactSpelling = true)]
        internal static extern void GetProgramPipelineiv(UInt32 pipeline, Int32 pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetProgramPipelineInfoLog", ExactSpelling = true)]
        internal static extern void GetProgramPipelineInfoLog(UInt32 pipeline, Int32 bufSize, [Out] Int32[] length,
            [Out] StringBuilder infoLog);

        [DllImport(Library, EntryPoint = "glGetProgramResourceiv", ExactSpelling = true)]
        internal static extern void GetProgramResourceiv(UInt32 program, ProgramInterface programInterface,
            UInt32 index, Int32 propCount, [Out] ProgramResourceParameterName[] props, Int32 bufSize,
            [Out] Int32[] length, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetProgramResourceIndex", ExactSpelling = true)]
        internal static extern UInt32 GetProgramResourceIndex(UInt32 program, ProgramInterface programInterface,
            String name);

        [DllImport(Library, EntryPoint = "glGetProgramResourceLocation", ExactSpelling = true)]
        internal static extern Int32 GetProgramResourceLocation(UInt32 program, ProgramInterface programInterface,
            String name);

        [DllImport(Library, EntryPoint = "glGetProgramResourceLocationIndex", ExactSpelling = true)]
        internal static extern Int32 GetProgramResourceLocationIndex(UInt32 program, ProgramInterface programInterface,
            String name);

        [DllImport(Library, EntryPoint = "glGetProgramResourceName", ExactSpelling = true)]
        internal static extern void GetProgramResourceName(UInt32 program, ProgramInterface programInterface,
            UInt32 index, Int32 bufSize, [Out] Int32[] length, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetProgramStageiv", ExactSpelling = true)]
        internal static extern void GetProgramStageiv(UInt32 program, ShaderType shadertype,
            ProgramStageParameterName pname, [Out] Int32[] values);

        [DllImport(Library, EntryPoint = "glGetQueryIndexediv", ExactSpelling = true)]
        internal static extern void GetQueryIndexediv(QueryTarget target, UInt32 index, GetQueryParam pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetQueryiv", ExactSpelling = true)]
        internal static extern void GetQueryiv(QueryTarget target, GetQueryParam pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetQueryObjectiv", ExactSpelling = true)]
        internal static extern void GetQueryObjectiv(UInt32 id, GetQueryObjectParam pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetQueryObjectuiv", ExactSpelling = true)]
        internal static extern void GetQueryObjectuiv(UInt32 id, GetQueryObjectParam pname, [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetQueryObjecti64v", ExactSpelling = true)]
        internal static extern void GetQueryObjecti64v(UInt32 id, GetQueryObjectParam pname, [Out] Int64[] @params);

        [DllImport(Library, EntryPoint = "glGetQueryObjectui64v", ExactSpelling = true)]
        internal static extern void GetQueryObjectui64v(UInt32 id, GetQueryObjectParam pname, [Out] UInt64[] @params);

        [DllImport(Library, EntryPoint = "glGetRenderbufferParameteriv", ExactSpelling = true)]
        internal static extern void GetRenderbufferParameteriv(RenderbufferTarget target,
            RenderbufferParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetNamedRenderbufferParameteriv", ExactSpelling = true)]
        internal static extern void GetNamedRenderbufferParameteriv(UInt32 renderbuffer,
            RenderbufferParameterName pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetSamplerParameterfv", ExactSpelling = true)]
        internal static extern void GetSamplerParameterfv(UInt32 sampler, TextureParameterName pname,
            [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetSamplerParameteriv", ExactSpelling = true)]
        internal static extern void GetSamplerParameteriv(UInt32 sampler, TextureParameterName pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetSamplerParameterIiv", ExactSpelling = true)]
        internal static extern void GetSamplerParameterIiv(UInt32 sampler, TextureParameterName pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetSamplerParameterIuiv", ExactSpelling = true)]
        internal static extern void GetSamplerParameterIuiv(UInt32 sampler, TextureParameterName pname,
            [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetShaderiv", ExactSpelling = true)]
        internal static extern void GetShaderiv(UInt32 shader, ShaderParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetShaderInfoLog", ExactSpelling = true)]
        internal static extern void GetShaderInfoLog(UInt32 shader, Int32 maxLength, [Out] Int32[] length,
            [Out] StringBuilder infoLog);

        [DllImport(Library, EntryPoint = "glGetShaderPrecisionFormat", ExactSpelling = true)]
        internal static extern void GetShaderPrecisionFormat(ShaderType shaderType, Int32 precisionType,
            [Out] Int32[] range, [Out] Int32[] precision);

        [DllImport(Library, EntryPoint = "glGetShaderSource", ExactSpelling = true)]
        internal static extern void GetShaderSource(UInt32 shader, Int32 bufSize, [Out] Int32[] length,
            [Out] StringBuilder source);

        [DllImport(Library, EntryPoint = "glGetString", ExactSpelling = true)]
        internal static extern IntPtr GetString(StringName name);

        [DllImport(Library, EntryPoint = "glGetStringi", ExactSpelling = true)]
        internal static extern IntPtr GetStringi(StringName name, UInt32 index);

        [DllImport(Library, EntryPoint = "glGetSubroutineIndex", ExactSpelling = true)]
        internal static extern UInt32 GetSubroutineIndex(UInt32 program, ShaderType shadertype, String name);

        [DllImport(Library, EntryPoint = "glGetSubroutineUniformLocation", ExactSpelling = true)]
        internal static extern Int32 GetSubroutineUniformLocation(UInt32 program, ShaderType shadertype, String name);

        [DllImport(Library, EntryPoint = "glGetSynciv", ExactSpelling = true)]
        internal static extern void GetSynciv(IntPtr sync, ArbSync pname, Int32 bufSize, [Out] Int32[] length,
            [Out] Int32[] values);

        [DllImport(Library, EntryPoint = "glGetTexImage", ExactSpelling = true)]
        internal static extern void GetTexImage(TextureTarget target, Int32 level, PixelFormat format, PixelType type,
            [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetnTexImage", ExactSpelling = true)]
        internal static extern void GetnTexImage(TextureTarget target, Int32 level, PixelFormat format, PixelType type,
            Int32 bufSize, [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetTextureImage", ExactSpelling = true)]
        internal static extern void GetTextureImage(UInt32 texture, Int32 level, PixelFormat format, PixelType type,
            Int32 bufSize, [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetTexLevelParameterfv", ExactSpelling = true)]
        internal static extern void GetTexLevelParameterfv(GetPName target, Int32 level, GetTextureLevelParameter pname,
            [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetTexLevelParameteriv", ExactSpelling = true)]
        internal static extern void GetTexLevelParameteriv(GetPName target, Int32 level, GetTextureLevelParameter pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureLevelParameterfv", ExactSpelling = true)]
        internal static extern void GetTextureLevelParameterfv(UInt32 texture, Int32 level,
            GetTextureLevelParameter pname, [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureLevelParameteriv", ExactSpelling = true)]
        internal static extern void GetTextureLevelParameteriv(UInt32 texture, Int32 level,
            GetTextureLevelParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTexParameterfv", ExactSpelling = true)]
        internal static extern void GetTexParameterfv(TextureTarget target, GetTextureParameter pname,
            [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetTexParameteriv", ExactSpelling = true)]
        internal static extern void GetTexParameteriv(TextureTarget target, GetTextureParameter pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTexParameterIiv", ExactSpelling = true)]
        internal static extern void GetTexParameterIiv(TextureTarget target, GetTextureParameter pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTexParameterIuiv", ExactSpelling = true)]
        internal static extern void GetTexParameterIuiv(TextureTarget target, GetTextureParameter pname,
            [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureParameterfv", ExactSpelling = true)]
        internal static extern void GetTextureParameterfv(UInt32 texture, GetTextureParameter pname,
            [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureParameteriv", ExactSpelling = true)]
        internal static extern void GetTextureParameteriv(UInt32 texture, GetTextureParameter pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureParameterIiv", ExactSpelling = true)]
        internal static extern void GetTextureParameterIiv(UInt32 texture, GetTextureParameter pname,
            [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureParameterIuiv", ExactSpelling = true)]
        internal static extern void GetTextureParameterIuiv(UInt32 texture, GetTextureParameter pname,
            [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetTextureSubImage", ExactSpelling = true)]
        internal static extern void GetTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type, Int32 bufSize,
            [Out] IntPtr pixels);

        [DllImport(Library, EntryPoint = "glGetTransformFeedbackiv", ExactSpelling = true)]
        internal static extern void GetTransformFeedbackiv(UInt32 xfb, TransformFeedbackParameterName pname,
            [Out] Int32[] param);

        [DllImport(Library, EntryPoint = "glGetTransformFeedbacki_v", ExactSpelling = true)]
        internal static extern void GetTransformFeedbacki_v(UInt32 xfb, TransformFeedbackParameterName pname,
            UInt32 index, [Out] Int32[] param);

        [DllImport(Library, EntryPoint = "glGetTransformFeedbacki64_v", ExactSpelling = true)]
        internal static extern void GetTransformFeedbacki64_v(UInt32 xfb, TransformFeedbackParameterName pname,
            UInt32 index, [Out] Int64[] param);

        [DllImport(Library, EntryPoint = "glGetTransformFeedbackVarying", ExactSpelling = true)]
        internal static extern void GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize,
            [Out] Int32[] length, [Out] Int32[] size, [Out] ActiveAttribType[] type, [Out] StringBuilder name);

        [DllImport(Library, EntryPoint = "glGetUniformfv", ExactSpelling = true)]
        internal static extern void GetUniformfv(UInt32 program, Int32 location, [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetUniformiv", ExactSpelling = true)]
        internal static extern void GetUniformiv(UInt32 program, Int32 location, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetUniformuiv", ExactSpelling = true)]
        internal static extern void GetUniformuiv(UInt32 program, Int32 location, [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetUniformdv", ExactSpelling = true)]
        internal static extern void GetUniformdv(UInt32 program, Int32 location, [Out] Double[] @params);

        [DllImport(Library, EntryPoint = "glGetnUniformfv", ExactSpelling = true)]
        internal static extern void GetnUniformfv(UInt32 program, Int32 location, Int32 bufSize,
            [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetnUniformiv", ExactSpelling = true)]
        internal static extern void GetnUniformiv(UInt32 program, Int32 location, Int32 bufSize, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetnUniformuiv", ExactSpelling = true)]
        internal static extern void GetnUniformuiv(UInt32 program, Int32 location, Int32 bufSize,
            [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetnUniformdv", ExactSpelling = true)]
        internal static extern void GetnUniformdv(UInt32 program, Int32 location, Int32 bufSize,
            [Out] Double[] @params);

        [DllImport(Library, EntryPoint = "glGetUniformBlockIndex", ExactSpelling = true)]
        internal static extern UInt32 GetUniformBlockIndex(UInt32 program, String uniformBlockName);

        [DllImport(Library, EntryPoint = "glGetUniformIndices", ExactSpelling = true)]
        internal static extern void GetUniformIndices(UInt32 program, Int32 uniformCount, String uniformNames,
            [Out] UInt32[] uniformIndices);

        [DllImport(Library, EntryPoint = "glGetUniformLocation", ExactSpelling = true)]
        internal static extern Int32 GetUniformLocation(UInt32 program, String name);

        [DllImport(Library, EntryPoint = "glGetUniformSubroutineuiv", ExactSpelling = true)]
        internal static extern void GetUniformSubroutineuiv(ShaderType shadertype, Int32 location,
            [Out] UInt32[] values);

        [DllImport(Library, EntryPoint = "glGetVertexArrayIndexed64iv", ExactSpelling = true)]
        internal static extern void GetVertexArrayIndexed64iv(UInt32 vaobj, UInt32 index, VertexAttribParameter pname,
            [Out] Int64[] param);

        [DllImport(Library, EntryPoint = "glGetVertexArrayIndexediv", ExactSpelling = true)]
        internal static extern void GetVertexArrayIndexediv(UInt32 vaobj, UInt32 index, VertexAttribParameter pname,
            [Out] Int32[] param);

        [DllImport(Library, EntryPoint = "glGetVertexArrayiv", ExactSpelling = true)]
        internal static extern void GetVertexArrayiv(UInt32 vaobj, VertexAttribParameter pname, [Out] Int32[] param);

        [DllImport(Library, EntryPoint = "glGetVertexAttribdv", ExactSpelling = true)]
        internal static extern void
            GetVertexAttribdv(UInt32 index, VertexAttribParameter pname, [Out] Double[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribfv", ExactSpelling = true)]
        internal static extern void
            GetVertexAttribfv(UInt32 index, VertexAttribParameter pname, [Out] Single[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribiv", ExactSpelling = true)]
        internal static extern void GetVertexAttribiv(UInt32 index, VertexAttribParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribIiv", ExactSpelling = true)]
        internal static extern void
            GetVertexAttribIiv(UInt32 index, VertexAttribParameter pname, [Out] Int32[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribIuiv", ExactSpelling = true)]
        internal static extern void GetVertexAttribIuiv(UInt32 index, VertexAttribParameter pname,
            [Out] UInt32[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribLdv", ExactSpelling = true)]
        internal static extern void GetVertexAttribLdv(UInt32 index, VertexAttribParameter pname,
            [Out] Double[] @params);

        [DllImport(Library, EntryPoint = "glGetVertexAttribPointerv", ExactSpelling = true)]
        internal static extern void GetVertexAttribPointerv(UInt32 index, VertexAttribPointerParameter pname,
            [Out] IntPtr pointer);

        [DllImport(Library, EntryPoint = "glHint", ExactSpelling = true)]
        internal static extern void Hint(HintTarget target, HintMode mode);

        [DllImport(Library, EntryPoint = "glInvalidateBufferData", ExactSpelling = true)]
        internal static extern void InvalidateBufferData(UInt32 buffer);

        [DllImport(Library, EntryPoint = "glInvalidateBufferSubData", ExactSpelling = true)]
        internal static extern void InvalidateBufferSubData(UInt32 buffer, IntPtr offset, IntPtr length);

        [DllImport(Library, EntryPoint = "glInvalidateFramebuffer", ExactSpelling = true)]
        internal static extern void InvalidateFramebuffer(FramebufferTarget target, Int32 numAttachments,
            FramebufferAttachment[] attachments);

        [DllImport(Library, EntryPoint = "glInvalidateNamedFramebufferData", ExactSpelling = true)]
        internal static extern void InvalidateNamedFramebufferData(UInt32 framebuffer, Int32 numAttachments,
            FramebufferAttachment[] attachments);

        [DllImport(Library, EntryPoint = "glInvalidateSubFramebuffer", ExactSpelling = true)]
        internal static extern void InvalidateSubFramebuffer(FramebufferTarget target, Int32 numAttachments,
            FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glInvalidateNamedFramebufferSubData", ExactSpelling = true)]
        internal static extern void InvalidateNamedFramebufferSubData(UInt32 framebuffer, Int32 numAttachments,
            FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glInvalidateTexImage", ExactSpelling = true)]
        internal static extern void InvalidateTexImage(UInt32 texture, Int32 level);

        [DllImport(Library, EntryPoint = "glInvalidateTexSubImage", ExactSpelling = true)]
        internal static extern void InvalidateTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 width, Int32 height, Int32 depth);

        [DllImport(Library, EntryPoint = "glIsBuffer", ExactSpelling = true)]
        internal static extern Boolean IsBuffer(UInt32 buffer);

        [DllImport(Library, EntryPoint = "glIsEnabled", ExactSpelling = true)]
        internal static extern Boolean IsEnabled(EnableCap cap);

        [DllImport(Library, EntryPoint = "glIsEnabledi", ExactSpelling = true)]
        internal static extern Boolean IsEnabledi(EnableCap cap, UInt32 index);

        [DllImport(Library, EntryPoint = "glIsFramebuffer", ExactSpelling = true)]
        internal static extern Boolean IsFramebuffer(UInt32 framebuffer);

        [DllImport(Library, EntryPoint = "glIsProgram", ExactSpelling = true)]
        internal static extern Boolean IsProgram(UInt32 program);

        [DllImport(Library, EntryPoint = "glIsProgramPipeline", ExactSpelling = true)]
        internal static extern Boolean IsProgramPipeline(UInt32 pipeline);

        [DllImport(Library, EntryPoint = "glIsQuery", ExactSpelling = true)]
        internal static extern Boolean IsQuery(UInt32 id);

        [DllImport(Library, EntryPoint = "glIsRenderbuffer", ExactSpelling = true)]
        internal static extern Boolean IsRenderbuffer(UInt32 renderbuffer);

        [DllImport(Library, EntryPoint = "glIsSampler", ExactSpelling = true)]
        internal static extern Boolean IsSampler(UInt32 id);

        [DllImport(Library, EntryPoint = "glIsShader", ExactSpelling = true)]
        internal static extern Boolean IsShader(UInt32 shader);

        [DllImport(Library, EntryPoint = "glIsSync", ExactSpelling = true)]
        internal static extern Boolean IsSync(IntPtr sync);

        [DllImport(Library, EntryPoint = "glIsTexture", ExactSpelling = true)]
        internal static extern Boolean IsTexture(UInt32 texture);

        [DllImport(Library, EntryPoint = "glIsTransformFeedback", ExactSpelling = true)]
        internal static extern Boolean IsTransformFeedback(UInt32 id);

        [DllImport(Library, EntryPoint = "glIsVertexArray", ExactSpelling = true)]
        internal static extern Boolean IsVertexArray(UInt32 array);

        [DllImport(Library, EntryPoint = "glLineWidth", ExactSpelling = true)]
        internal static extern void LineWidth(Single width);

        [DllImport(Library, EntryPoint = "glLinkProgram", ExactSpelling = true)]
        internal static extern void LinkProgram(UInt32 program);

        [DllImport(Library, EntryPoint = "glLogicOp", ExactSpelling = true)]
        internal static extern void LogicOp(LogicOp opcode);

        [DllImport(Library, EntryPoint = "glMapBuffer", ExactSpelling = true)]
        internal static extern IntPtr MapBuffer(BufferTarget target, BufferAccess access);

        [DllImport(Library, EntryPoint = "glMapNamedBuffer", ExactSpelling = true)]
        internal static extern IntPtr MapNamedBuffer(UInt32 buffer, BufferAccess access);

        [DllImport(Library, EntryPoint = "glMapBufferRange", ExactSpelling = true)]
        internal static extern IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length,
            BufferAccessMask access);

        [DllImport(Library, EntryPoint = "glMapNamedBufferRange", ExactSpelling = true)]
        internal static extern IntPtr MapNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length, UInt32 access);

        [DllImport(Library, EntryPoint = "glMemoryBarrier", ExactSpelling = true)]
        internal static extern void MemoryBarrier(UInt32 barriers);

        [DllImport(Library, EntryPoint = "glMemoryBarrierByRegion", ExactSpelling = true)]
        internal static extern void MemoryBarrierByRegion(UInt32 barriers);

        [DllImport(Library, EntryPoint = "glMinSampleShading", ExactSpelling = true)]
        internal static extern void MinSampleShading(Single value);

        [DllImport(Library, EntryPoint = "glMultiDrawArrays", ExactSpelling = true)]
        internal static extern void MultiDrawArrays(BeginMode mode, Int32[] first, Int32[] count, Int32 drawcount);

        [DllImport(Library, EntryPoint = "glMultiDrawArraysIndirect", ExactSpelling = true)]
        internal static extern void MultiDrawArraysIndirect(BeginMode mode, IntPtr indirect, Int32 drawcount,
            Int32 stride);

        [DllImport(Library, EntryPoint = "glMultiDrawElements", ExactSpelling = true)]
        internal static extern void MultiDrawElements(BeginMode mode, Int32[] count, DrawElementsType type,
            IntPtr indices, Int32 drawcount);

        [DllImport(Library, EntryPoint = "glMultiDrawElementsBaseVertex", ExactSpelling = true)]
        internal static extern void MultiDrawElementsBaseVertex(BeginMode mode, Int32[] count, DrawElementsType type,
            IntPtr indices, Int32 drawcount, Int32[] basevertex);

        [DllImport(Library, EntryPoint = "glMultiDrawElementsIndirect", ExactSpelling = true)]
        internal static extern void MultiDrawElementsIndirect(BeginMode mode, DrawElementsType type, IntPtr indirect,
            Int32 drawcount, Int32 stride);

        [DllImport(Library, EntryPoint = "glObjectLabel", ExactSpelling = true)]
        internal static extern void ObjectLabel(ObjectLabel identifier, UInt32 name, Int32 length, String label);

        [DllImport(Library, EntryPoint = "glObjectPtrLabel", ExactSpelling = true)]
        internal static extern void ObjectPtrLabel(IntPtr ptr, Int32 length, String label);

        [DllImport(Library, EntryPoint = "glPatchParameteri", ExactSpelling = true)]
        internal static extern void PatchParameteri(Int32 pname, Int32 value);

        [DllImport(Library, EntryPoint = "glPatchParameterfv", ExactSpelling = true)]
        internal static extern void PatchParameterfv(Int32 pname, Single[] values);

        [DllImport(Library, EntryPoint = "glPixelStoref", ExactSpelling = true)]
        internal static extern void PixelStoref(PixelStoreParameter pname, Single param);

        [DllImport(Library, EntryPoint = "glPixelStorei", ExactSpelling = true)]
        internal static extern void PixelStorei(PixelStoreParameter pname, Int32 param);

        [DllImport(Library, EntryPoint = "glPointParameterf", ExactSpelling = true)]
        internal static extern void PointParameterf(PointParameterName pname, Single param);

        [DllImport(Library, EntryPoint = "glPointParameteri", ExactSpelling = true)]
        internal static extern void PointParameteri(PointParameterName pname, Int32 param);

        [DllImport(Library, EntryPoint = "glPointParameterfv", ExactSpelling = true)]
        internal static extern void PointParameterfv(PointParameterName pname, Single[] @params);

        [DllImport(Library, EntryPoint = "glPointParameteriv", ExactSpelling = true)]
        internal static extern void PointParameteriv(PointParameterName pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glPointSize", ExactSpelling = true)]
        internal static extern void PointSize(Single size);

        [DllImport(Library, EntryPoint = "glPolygonMode", ExactSpelling = true)]
        internal static extern void PolygonMode(MaterialFace face, PolygonMode mode);

        [DllImport(Library, EntryPoint = "glPolygonOffset", ExactSpelling = true)]
        internal static extern void PolygonOffset(Single factor, Single units);

        [DllImport(Library, EntryPoint = "glPrimitiveRestartIndex", ExactSpelling = true)]
        internal static extern void PrimitiveRestartIndex(UInt32 index);

        [DllImport(Library, EntryPoint = "glProgramBinary", ExactSpelling = true)]
        internal static extern void ProgramBinary(UInt32 program, Int32 binaryFormat, IntPtr binary, Int32 length);

        [DllImport(Library, EntryPoint = "glProgramParameteri", ExactSpelling = true)]
        internal static extern void ProgramParameteri(UInt32 program, Version32 pname, Int32 value);

        [DllImport(Library, EntryPoint = "glProgramUniform1f", ExactSpelling = true)]
        internal static extern void ProgramUniform1f(UInt32 program, Int32 location, Single v0);

        [DllImport(Library, EntryPoint = "glProgramUniform2f", ExactSpelling = true)]
        internal static extern void ProgramUniform2f(UInt32 program, Int32 location, Single v0, Single v1);

        [DllImport(Library, EntryPoint = "glProgramUniform3f", ExactSpelling = true)]
        internal static extern void ProgramUniform3f(UInt32 program, Int32 location, Single v0, Single v1, Single v2);

        [DllImport(Library, EntryPoint = "glProgramUniform4f", ExactSpelling = true)]
        internal static extern void ProgramUniform4f(UInt32 program, Int32 location, Single v0, Single v1, Single v2,
            Single v3);

        [DllImport(Library, EntryPoint = "glProgramUniform1i", ExactSpelling = true)]
        internal static extern void ProgramUniform1i(UInt32 program, Int32 location, Int32 v0);

        [DllImport(Library, EntryPoint = "glProgramUniform2i", ExactSpelling = true)]
        internal static extern void ProgramUniform2i(UInt32 program, Int32 location, Int32 v0, Int32 v1);

        [DllImport(Library, EntryPoint = "glProgramUniform3i", ExactSpelling = true)]
        internal static extern void ProgramUniform3i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2);

        [DllImport(Library, EntryPoint = "glProgramUniform4i", ExactSpelling = true)]
        internal static extern void ProgramUniform4i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2,
            Int32 v3);

        [DllImport(Library, EntryPoint = "glProgramUniform1ui", ExactSpelling = true)]
        internal static extern void ProgramUniform1ui(UInt32 program, Int32 location, UInt32 v0);

        [DllImport(Library, EntryPoint = "glProgramUniform2ui", ExactSpelling = true)]
        internal static extern void ProgramUniform2ui(UInt32 program, Int32 location, Int32 v0, UInt32 v1);

        [DllImport(Library, EntryPoint = "glProgramUniform3ui", ExactSpelling = true)]
        internal static extern void ProgramUniform3ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, UInt32 v2);

        [DllImport(Library, EntryPoint = "glProgramUniform4ui", ExactSpelling = true)]
        internal static extern void ProgramUniform4ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2,
            UInt32 v3);

        [DllImport(Library, EntryPoint = "glProgramUniform1fv", ExactSpelling = true)]
        internal static extern void ProgramUniform1fv(UInt32 program, Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform2fv", ExactSpelling = true)]
        internal static extern void ProgramUniform2fv(UInt32 program, Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform3fv", ExactSpelling = true)]
        internal static extern void ProgramUniform3fv(UInt32 program, Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform4fv", ExactSpelling = true)]
        internal static extern void ProgramUniform4fv(UInt32 program, Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform1iv", ExactSpelling = true)]
        internal static extern void ProgramUniform1iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform2iv", ExactSpelling = true)]
        internal static extern void ProgramUniform2iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform3iv", ExactSpelling = true)]
        internal static extern void ProgramUniform3iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform4iv", ExactSpelling = true)]
        internal static extern void ProgramUniform4iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform1uiv", ExactSpelling = true)]
        internal static extern void ProgramUniform1uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform2uiv", ExactSpelling = true)]
        internal static extern void ProgramUniform2uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform3uiv", ExactSpelling = true)]
        internal static extern void ProgramUniform3uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniform4uiv", ExactSpelling = true)]
        internal static extern void ProgramUniform4uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix2fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix2fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix3fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix3fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix4fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix4fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix2x3fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix2x3fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix3x2fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix3x2fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix2x4fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix2x4fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix4x2fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix4x2fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix3x4fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix3x4fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProgramUniformMatrix4x3fv", ExactSpelling = true)]
        internal static extern void ProgramUniformMatrix4x3fv(UInt32 program, Int32 location, Int32 count,
            Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glProvokingVertex", ExactSpelling = true)]
        internal static extern void ProvokingVertex(ProvokingVertexMode provokeMode);

        [DllImport(Library, EntryPoint = "glQueryCounter", ExactSpelling = true)]
        internal static extern void QueryCounter(UInt32 id, QueryTarget target);

        [DllImport(Library, EntryPoint = "glReadBuffer", ExactSpelling = true)]
        internal static extern void ReadBuffer(ReadBufferMode mode);

        [DllImport(Library, EntryPoint = "glNamedFramebufferReadBuffer", ExactSpelling = true)]
        internal static extern void NamedFramebufferReadBuffer(ReadBufferMode framebuffer, BeginMode mode);

        [DllImport(Library, EntryPoint = "glReadPixels", ExactSpelling = true)]
        internal static extern void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format,
            PixelType type, Int32[] data);

        [DllImport(Library, EntryPoint = "glReadnPixels", ExactSpelling = true)]
        internal static extern void ReadnPixels(Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format,
            PixelType type, Int32 bufSize, Int32[] data);

        [DllImport(Library, EntryPoint = "glRenderbufferStorage", ExactSpelling = true)]
        internal static extern void RenderbufferStorage(RenderbufferTarget target, RenderbufferStorage internalFormat,
            Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glNamedRenderbufferStorage", ExactSpelling = true)]
        internal static extern void NamedRenderbufferStorage(UInt32 renderbuffer, RenderbufferStorage internalFormat,
            Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glRenderbufferStorageMultisample", ExactSpelling = true)]
        internal static extern void RenderbufferStorageMultisample(RenderbufferTarget target, Int32 samples,
            RenderbufferStorage internalFormat, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glNamedRenderbufferStorageMultisample", ExactSpelling = true)]
        internal static extern void NamedRenderbufferStorageMultisample(UInt32 renderbuffer, Int32 samples,
            RenderbufferStorage internalFormat, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glSampleCoverage", ExactSpelling = true)]
        internal static extern void SampleCoverage(Single value, Boolean invert);

        [DllImport(Library, EntryPoint = "glSampleMaski", ExactSpelling = true)]
        internal static extern void SampleMaski(UInt32 maskNumber, UInt32 mask);

        [DllImport(Library, EntryPoint = "glSamplerParameterf", ExactSpelling = true)]
        internal static extern void SamplerParameterf(UInt32 sampler, TextureParameterName pname, Single param);

        [DllImport(Library, EntryPoint = "glSamplerParameteri", ExactSpelling = true)]
        internal static extern void SamplerParameteri(UInt32 sampler, TextureParameterName pname, Int32 param);

        [DllImport(Library, EntryPoint = "glSamplerParameterfv", ExactSpelling = true)]
        internal static extern void SamplerParameterfv(UInt32 sampler, TextureParameterName pname, Single[] @params);

        [DllImport(Library, EntryPoint = "glSamplerParameteriv", ExactSpelling = true)]
        internal static extern void SamplerParameteriv(UInt32 sampler, TextureParameterName pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glSamplerParameterIiv", ExactSpelling = true)]
        internal static extern void SamplerParameterIiv(UInt32 sampler, TextureParameterName pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glSamplerParameterIuiv", ExactSpelling = true)]
        internal static extern void SamplerParameterIuiv(UInt32 sampler, TextureParameterName pname, UInt32[] @params);

        [DllImport(Library, EntryPoint = "glScissor", ExactSpelling = true)]
        internal static extern void Scissor(Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glScissorArrayv", ExactSpelling = true)]
        internal static extern void ScissorArrayv(UInt32 first, Int32 count, Int32[] v);

        [DllImport(Library, EntryPoint = "glScissorIndexed", ExactSpelling = true)]
        internal static extern void ScissorIndexed(UInt32 index, Int32 left, Int32 bottom, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glScissorIndexedv", ExactSpelling = true)]
        internal static extern void ScissorIndexedv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glShaderBinary", ExactSpelling = true)]
        internal static extern void ShaderBinary(Int32 count, UInt32[] shaders, Int32 binaryFormat, IntPtr binary,
            Int32 length);

        [DllImport(Library, EntryPoint = "glShaderSource", ExactSpelling = true)]
        internal static extern void ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32[] length);

        [DllImport(Library, EntryPoint = "glShaderStorageBlockBinding", ExactSpelling = true)]
        internal static extern void ShaderStorageBlockBinding(UInt32 program, UInt32 storageBlockIndex,
            UInt32 storageBlockBinding);

        [DllImport(Library, EntryPoint = "glStencilFunc", ExactSpelling = true)]
        internal static extern void StencilFunc(StencilFunction func, Int32 @ref, UInt32 mask);

        [DllImport(Library, EntryPoint = "glStencilFuncSeparate", ExactSpelling = true)]
        internal static extern void
            StencilFuncSeparate(StencilFace face, StencilFunction func, Int32 @ref, UInt32 mask);

        [DllImport(Library, EntryPoint = "glStencilMask", ExactSpelling = true)]
        internal static extern void StencilMask(UInt32 mask);

        [DllImport(Library, EntryPoint = "glStencilMaskSeparate", ExactSpelling = true)]
        internal static extern void StencilMaskSeparate(StencilFace face, UInt32 mask);

        [DllImport(Library, EntryPoint = "glStencilOp", ExactSpelling = true)]
        internal static extern void StencilOp(StencilOp sfail, StencilOp dpfail, StencilOp dppass);

        [DllImport(Library, EntryPoint = "glStencilOpSeparate", ExactSpelling = true)]
        internal static extern void StencilOpSeparate(StencilFace face, StencilOp sfail, StencilOp dpfail,
            StencilOp dppass);

        [DllImport(Library, EntryPoint = "glTexBuffer", ExactSpelling = true)]
        internal static extern void TexBuffer(TextureBufferTarget target, SizedInternalFormat internalFormat,
            UInt32 buffer);

        [DllImport(Library, EntryPoint = "glTextureBuffer", ExactSpelling = true)]
        internal static extern void TextureBuffer(UInt32 texture, SizedInternalFormat internalFormat, UInt32 buffer);

        [DllImport(Library, EntryPoint = "glTexBufferRange", ExactSpelling = true)]
        internal static extern void TexBufferRange(BufferTarget target, SizedInternalFormat internalFormat,
            UInt32 buffer, IntPtr offset, IntPtr size);

        [DllImport(Library, EntryPoint = "glTextureBufferRange", ExactSpelling = true)]
        internal static extern void TextureBufferRange(UInt32 texture, SizedInternalFormat internalFormat,
            UInt32 buffer, IntPtr offset, Int32 size);

        [DllImport(Library, EntryPoint = "glTexImage1D", ExactSpelling = true)]
        internal static extern void TexImage1D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
            Int32 width, Int32 border, PixelFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glTexImage2D", ExactSpelling = true)]
        internal static extern void TexImage2D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
            Int32 width, Int32 height, Int32 border, PixelFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glTexImage2DMultisample", ExactSpelling = true)]
        internal static extern void TexImage2DMultisample(TextureTargetMultisample target, Int32 samples,
            PixelInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTexImage3D", ExactSpelling = true)]
        internal static extern void TexImage3D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
            Int32 width, Int32 height, Int32 depth, Int32 border, PixelFormat format, PixelType type, IntPtr data);

        [DllImport(Library, EntryPoint = "glTexImage3DMultisample", ExactSpelling = true)]
        internal static extern void TexImage3DMultisample(TextureTargetMultisample target, Int32 samples,
            PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTexParameterf", ExactSpelling = true)]
        internal static extern void TexParameterf(TextureTarget target, TextureParameterName pname, Single param);

        [DllImport(Library, EntryPoint = "glTexParameteri", ExactSpelling = true)]
        internal static extern void TexParameteri(TextureTarget target, TextureParameterName pname, Int32 param);

        [DllImport(Library, EntryPoint = "glTextureParameterf", ExactSpelling = true)]
        internal static extern void TextureParameterf(UInt32 texture, TextureParameter pname, Single param);

        [DllImport(Library, EntryPoint = "glTextureParameteri", ExactSpelling = true)]
        internal static extern void TextureParameteri(UInt32 texture, TextureParameter pname, Int32 param);

        [DllImport(Library, EntryPoint = "glTexParameterfv", ExactSpelling = true)]
        internal static extern void TexParameterfv(TextureTarget target, TextureParameterName pname, Single[] @params);

        [DllImport(Library, EntryPoint = "glTexParameteriv", ExactSpelling = true)]
        internal static extern void TexParameteriv(TextureTarget target, TextureParameterName pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glTexParameterIiv", ExactSpelling = true)]
        internal static extern void TexParameterIiv(TextureTarget target, TextureParameterName pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glTexParameterIuiv", ExactSpelling = true)]
        internal static extern void
            TexParameterIuiv(TextureTarget target, TextureParameterName pname, UInt32[] @params);

        [DllImport(Library, EntryPoint = "glTextureParameterfv", ExactSpelling = true)]
        internal static extern void TextureParameterfv(UInt32 texture, TextureParameter pname, Single[] paramtexture);

        [DllImport(Library, EntryPoint = "glTextureParameteriv", ExactSpelling = true)]
        internal static extern void TextureParameteriv(UInt32 texture, TextureParameter pname, Int32[] param);

        [DllImport(Library, EntryPoint = "glTextureParameterIiv", ExactSpelling = true)]
        internal static extern void TextureParameterIiv(UInt32 texture, TextureParameter pname, Int32[] @params);

        [DllImport(Library, EntryPoint = "glTextureParameterIuiv", ExactSpelling = true)]
        internal static extern void TextureParameterIuiv(UInt32 texture, TextureParameter pname, UInt32[] @params);

        [DllImport(Library, EntryPoint = "glTexStorage1D", ExactSpelling = true)]
        internal static extern void TexStorage1D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width);

        [DllImport(Library, EntryPoint = "glTextureStorage1D", ExactSpelling = true)]
        internal static extern void TextureStorage1D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width);

        [DllImport(Library, EntryPoint = "glTexStorage2D", ExactSpelling = true)]
        internal static extern void TexStorage2D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glTextureStorage2D", ExactSpelling = true)]
        internal static extern void TextureStorage2D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glTexStorage2DMultisample", ExactSpelling = true)]
        internal static extern void TexStorage2DMultisample(TextureTarget target, Int32 samples,
            SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTextureStorage2DMultisample", ExactSpelling = true)]
        internal static extern void TextureStorage2DMultisample(UInt32 texture, Int32 samples,
            SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTexStorage3D", ExactSpelling = true)]
        internal static extern void TexStorage3D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width, Int32 height, Int32 depth);

        [DllImport(Library, EntryPoint = "glTextureStorage3D", ExactSpelling = true)]
        internal static extern void TextureStorage3D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
            Int32 width, Int32 height, Int32 depth);

        [DllImport(Library, EntryPoint = "glTexStorage3DMultisample", ExactSpelling = true)]
        internal static extern void TexStorage3DMultisample(TextureTarget target, Int32 samples,
            SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTextureStorage3DMultisample", ExactSpelling = true)]
        internal static extern void TextureStorage3DMultisample(UInt32 texture, Int32 samples,
            SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Boolean fixedsamplelocations);

        [DllImport(Library, EntryPoint = "glTexSubImage1D", ExactSpelling = true)]
        internal static extern void TexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset, Int32 width,
            PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTextureSubImage1D", ExactSpelling = true)]
        internal static extern void TextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width,
            PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTexSubImage2D", ExactSpelling = true)]
        internal static extern void TexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 width, Int32 height, PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTextureSubImage2D", ExactSpelling = true)]
        internal static extern void TextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 width, Int32 height, PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTexSubImage3D", ExactSpelling = true)]
        internal static extern void TexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTextureSubImage3D", ExactSpelling = true)]
        internal static extern void TextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
            Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type, IntPtr pixels);

        [DllImport(Library, EntryPoint = "glTextureBarrier", ExactSpelling = true)]
        internal static extern void TextureBarrier();

        [DllImport(Library, EntryPoint = "glTextureView", ExactSpelling = true)]
        internal static extern void TextureView(UInt32 texture, TextureTarget target, UInt32 origtexture,
            PixelInternalFormat internalFormat, UInt32 minlevel, UInt32 numlevels, UInt32 minlayer, UInt32 numlayers);

        [DllImport(Library, EntryPoint = "glTransformFeedbackBufferBase", ExactSpelling = true)]
        internal static extern void TransformFeedbackBufferBase(UInt32 xfb, UInt32 index, UInt32 buffer);

        [DllImport(Library, EntryPoint = "glTransformFeedbackBufferRange", ExactSpelling = true)]
        internal static extern void TransformFeedbackBufferRange(UInt32 xfb, UInt32 index, UInt32 buffer, IntPtr offset,
            Int32 size);

        [DllImport(Library, EntryPoint = "glTransformFeedbackVaryings", ExactSpelling = true)]
        internal static extern void TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings,
            TransformFeedbackMode bufferMode);

        [DllImport(Library, EntryPoint = "glUniform1f", ExactSpelling = true)]
        internal static extern void Uniform1f(Int32 location, Single v0);

        [DllImport(Library, EntryPoint = "glUniform2f", ExactSpelling = true)]
        internal static extern void Uniform2f(Int32 location, Single v0, Single v1);

        [DllImport(Library, EntryPoint = "glUniform3f", ExactSpelling = true)]
        internal static extern void Uniform3f(Int32 location, Single v0, Single v1, Single v2);

        [DllImport(Library, EntryPoint = "glUniform4f", ExactSpelling = true)]
        internal static extern void Uniform4f(Int32 location, Single v0, Single v1, Single v2, Single v3);

        [DllImport(Library, EntryPoint = "glUniform1i", ExactSpelling = true)]
        internal static extern void Uniform1i(Int32 location, Int32 v0);

        [DllImport(Library, EntryPoint = "glUniform2i", ExactSpelling = true)]
        internal static extern void Uniform2i(Int32 location, Int32 v0, Int32 v1);

        [DllImport(Library, EntryPoint = "glUniform3i", ExactSpelling = true)]
        internal static extern void Uniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2);

        [DllImport(Library, EntryPoint = "glUniform4i", ExactSpelling = true)]
        internal static extern void Uniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3);

        [DllImport(Library, EntryPoint = "glUniform1ui", ExactSpelling = true)]
        internal static extern void Uniform1ui(Int32 location, UInt32 v0);

        [DllImport(Library, EntryPoint = "glUniform2ui", ExactSpelling = true)]
        internal static extern void Uniform2ui(Int32 location, UInt32 v0, UInt32 v1);

        [DllImport(Library, EntryPoint = "glUniform3ui", ExactSpelling = true)]
        internal static extern void Uniform3ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2);

        [DllImport(Library, EntryPoint = "glUniform4ui", ExactSpelling = true)]
        internal static extern void Uniform4ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);

        [DllImport(Library, EntryPoint = "glUniform1fv", ExactSpelling = true)]
        internal static extern void Uniform1fv(Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glUniform2fv", ExactSpelling = true)]
        internal static extern void Uniform2fv(Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glUniform3fv", ExactSpelling = true)]
        internal static extern void Uniform3fv(Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glUniform4fv", ExactSpelling = true)]
        internal static extern void Uniform4fv(Int32 location, Int32 count, Single[] value);

        [DllImport(Library, EntryPoint = "glUniform1iv", ExactSpelling = true)]
        internal static extern void Uniform1iv(Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glUniform2iv", ExactSpelling = true)]
        internal static extern void Uniform2iv(Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glUniform3iv", ExactSpelling = true)]
        internal static extern void Uniform3iv(Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glUniform4iv", ExactSpelling = true)]
        internal static extern void Uniform4iv(Int32 location, Int32 count, Int32[] value);

        [DllImport(Library, EntryPoint = "glUniform1uiv", ExactSpelling = true)]
        internal static extern void Uniform1uiv(Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glUniform2uiv", ExactSpelling = true)]
        internal static extern void Uniform2uiv(Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glUniform3uiv", ExactSpelling = true)]
        internal static extern void Uniform3uiv(Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glUniform4uiv", ExactSpelling = true)]
        internal static extern void Uniform4uiv(Int32 location, Int32 count, UInt32[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix2fv", ExactSpelling = true)]
        internal static extern void UniformMatrix2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix3fv", ExactSpelling = true)]
        internal static extern void UniformMatrix3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix4fv", ExactSpelling = true)]
        internal static extern void UniformMatrix4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix2x3fv", ExactSpelling = true)]
        internal static extern void UniformMatrix2x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix3x2fv", ExactSpelling = true)]
        internal static extern void UniformMatrix3x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix2x4fv", ExactSpelling = true)]
        internal static extern void UniformMatrix2x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix4x2fv", ExactSpelling = true)]
        internal static extern void UniformMatrix4x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix3x4fv", ExactSpelling = true)]
        internal static extern void UniformMatrix3x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformMatrix4x3fv", ExactSpelling = true)]
        internal static extern void UniformMatrix4x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

        [DllImport(Library, EntryPoint = "glUniformBlockBinding", ExactSpelling = true)]
        internal static extern void UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex,
            UInt32 uniformBlockBinding);

        [DllImport(Library, EntryPoint = "glUniformSubroutinesuiv", ExactSpelling = true)]
        internal static extern void UniformSubroutinesuiv(ShaderType shadertype, Int32 count, UInt32[] indices);

        [DllImport(Library, EntryPoint = "glUnmapBuffer", ExactSpelling = true)]
        internal static extern Boolean UnmapBuffer(BufferTarget target);

        [DllImport(Library, EntryPoint = "glUnmapNamedBuffer", ExactSpelling = true)]
        internal static extern Boolean UnmapNamedBuffer(UInt32 buffer);

        [DllImport(Library, EntryPoint = "glUseProgram", ExactSpelling = true)]
        internal static extern void UseProgram(UInt32 program);

        [DllImport(Library, EntryPoint = "glUseProgramStages", ExactSpelling = true)]
        internal static extern void UseProgramStages(UInt32 pipeline, UInt32 stages, UInt32 program);

        [DllImport(Library, EntryPoint = "glValidateProgram", ExactSpelling = true)]
        internal static extern void ValidateProgram(UInt32 program);

        [DllImport(Library, EntryPoint = "glValidateProgramPipeline", ExactSpelling = true)]
        internal static extern void ValidateProgramPipeline(UInt32 pipeline);

        [DllImport(Library, EntryPoint = "glVertexArrayElementBuffer", ExactSpelling = true)]
        internal static extern void VertexArrayElementBuffer(UInt32 vaobj, UInt32 buffer);

        [DllImport(Library, EntryPoint = "glVertexAttrib1f", ExactSpelling = true)]
        internal static extern void VertexAttrib1f(UInt32 index, Single v0);

        [DllImport(Library, EntryPoint = "glVertexAttrib1s", ExactSpelling = true)]
        internal static extern void VertexAttrib1s(UInt32 index, Int16 v0);

        [DllImport(Library, EntryPoint = "glVertexAttrib1d", ExactSpelling = true)]
        internal static extern void VertexAttrib1d(UInt32 index, Double v0);

        [DllImport(Library, EntryPoint = "glVertexAttribI1i", ExactSpelling = true)]
        internal static extern void VertexAttribI1i(UInt32 index, Int32 v0);

        [DllImport(Library, EntryPoint = "glVertexAttribI1ui", ExactSpelling = true)]
        internal static extern void VertexAttribI1ui(UInt32 index, UInt32 v0);

        [DllImport(Library, EntryPoint = "glVertexAttrib2f", ExactSpelling = true)]
        internal static extern void VertexAttrib2f(UInt32 index, Single v0, Single v1);

        [DllImport(Library, EntryPoint = "glVertexAttrib2s", ExactSpelling = true)]
        internal static extern void VertexAttrib2s(UInt32 index, Int16 v0, Int16 v1);

        [DllImport(Library, EntryPoint = "glVertexAttrib2d", ExactSpelling = true)]
        internal static extern void VertexAttrib2d(UInt32 index, Double v0, Double v1);

        [DllImport(Library, EntryPoint = "glVertexAttribI2i", ExactSpelling = true)]
        internal static extern void VertexAttribI2i(UInt32 index, Int32 v0, Int32 v1);

        [DllImport(Library, EntryPoint = "glVertexAttribI2ui", ExactSpelling = true)]
        internal static extern void VertexAttribI2ui(UInt32 index, UInt32 v0, UInt32 v1);

        [DllImport(Library, EntryPoint = "glVertexAttrib3f", ExactSpelling = true)]
        internal static extern void VertexAttrib3f(UInt32 index, Single v0, Single v1, Single v2);

        [DllImport(Library, EntryPoint = "glVertexAttrib3s", ExactSpelling = true)]
        internal static extern void VertexAttrib3s(UInt32 index, Int16 v0, Int16 v1, Int16 v2);

        [DllImport(Library, EntryPoint = "glVertexAttrib3d", ExactSpelling = true)]
        internal static extern void VertexAttrib3d(UInt32 index, Double v0, Double v1, Double v2);

        [DllImport(Library, EntryPoint = "glVertexAttribI3i", ExactSpelling = true)]
        internal static extern void VertexAttribI3i(UInt32 index, Int32 v0, Int32 v1, Int32 v2);

        [DllImport(Library, EntryPoint = "glVertexAttribI3ui", ExactSpelling = true)]
        internal static extern void VertexAttribI3ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2);

        [DllImport(Library, EntryPoint = "glVertexAttrib4f", ExactSpelling = true)]
        internal static extern void VertexAttrib4f(UInt32 index, Single v0, Single v1, Single v2, Single v3);

        [DllImport(Library, EntryPoint = "glVertexAttrib4s", ExactSpelling = true)]
        internal static extern void VertexAttrib4s(UInt32 index, Int16 v0, Int16 v1, Int16 v2, Int16 v3);

        [DllImport(Library, EntryPoint = "glVertexAttrib4d", ExactSpelling = true)]
        internal static extern void VertexAttrib4d(UInt32 index, Double v0, Double v1, Double v2, Double v3);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nub", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nub(UInt32 index, Byte v0, Byte v1, Byte v2, Byte v3);

        [DllImport(Library, EntryPoint = "glVertexAttribI4i", ExactSpelling = true)]
        internal static extern void VertexAttribI4i(UInt32 index, Int32 v0, Int32 v1, Int32 v2, Int32 v3);

        [DllImport(Library, EntryPoint = "glVertexAttribI4ui", ExactSpelling = true)]
        internal static extern void VertexAttribI4ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);

        [DllImport(Library, EntryPoint = "glVertexAttribL1d", ExactSpelling = true)]
        internal static extern void VertexAttribL1d(UInt32 index, Double v0);

        [DllImport(Library, EntryPoint = "glVertexAttribL2d", ExactSpelling = true)]
        internal static extern void VertexAttribL2d(UInt32 index, Double v0, Double v1);

        [DllImport(Library, EntryPoint = "glVertexAttribL3d", ExactSpelling = true)]
        internal static extern void VertexAttribL3d(UInt32 index, Double v0, Double v1, Double v2);

        [DllImport(Library, EntryPoint = "glVertexAttribL4d", ExactSpelling = true)]
        internal static extern void VertexAttribL4d(UInt32 index, Double v0, Double v1, Double v2, Double v3);

        [DllImport(Library, EntryPoint = "glVertexAttrib1fv", ExactSpelling = true)]
        internal static extern void VertexAttrib1fv(UInt32 index, Single[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib1sv", ExactSpelling = true)]
        internal static extern void VertexAttrib1sv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib1dv", ExactSpelling = true)]
        internal static extern void VertexAttrib1dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI1iv", ExactSpelling = true)]
        internal static extern void VertexAttribI1iv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI1uiv", ExactSpelling = true)]
        internal static extern void VertexAttribI1uiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib2fv", ExactSpelling = true)]
        internal static extern void VertexAttrib2fv(UInt32 index, Single[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib2sv", ExactSpelling = true)]
        internal static extern void VertexAttrib2sv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib2dv", ExactSpelling = true)]
        internal static extern void VertexAttrib2dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI2iv", ExactSpelling = true)]
        internal static extern void VertexAttribI2iv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI2uiv", ExactSpelling = true)]
        internal static extern void VertexAttribI2uiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib3fv", ExactSpelling = true)]
        internal static extern void VertexAttrib3fv(UInt32 index, Single[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib3sv", ExactSpelling = true)]
        internal static extern void VertexAttrib3sv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib3dv", ExactSpelling = true)]
        internal static extern void VertexAttrib3dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI3iv", ExactSpelling = true)]
        internal static extern void VertexAttribI3iv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI3uiv", ExactSpelling = true)]
        internal static extern void VertexAttribI3uiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4fv", ExactSpelling = true)]
        internal static extern void VertexAttrib4fv(UInt32 index, Single[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4sv", ExactSpelling = true)]
        internal static extern void VertexAttrib4sv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4dv", ExactSpelling = true)]
        internal static extern void VertexAttrib4dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4iv", ExactSpelling = true)]
        internal static extern void VertexAttrib4iv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4bv", ExactSpelling = true)]
        internal static extern void VertexAttrib4bv(UInt32 index, SByte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4ubv", ExactSpelling = true)]
        internal static extern void VertexAttrib4ubv(UInt32 index, Byte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4usv", ExactSpelling = true)]
        internal static extern void VertexAttrib4usv(UInt32 index, UInt16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4uiv", ExactSpelling = true)]
        internal static extern void VertexAttrib4uiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nbv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nbv(UInt32 index, SByte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nsv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nsv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Niv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Niv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nubv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nubv(UInt32 index, Byte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nusv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nusv(UInt32 index, UInt16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttrib4Nuiv", ExactSpelling = true)]
        internal static extern void VertexAttrib4Nuiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4bv", ExactSpelling = true)]
        internal static extern void VertexAttribI4bv(UInt32 index, SByte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4ubv", ExactSpelling = true)]
        internal static extern void VertexAttribI4ubv(UInt32 index, Byte[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4sv", ExactSpelling = true)]
        internal static extern void VertexAttribI4sv(UInt32 index, Int16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4usv", ExactSpelling = true)]
        internal static extern void VertexAttribI4usv(UInt32 index, UInt16[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4iv", ExactSpelling = true)]
        internal static extern void VertexAttribI4iv(UInt32 index, Int32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribI4uiv", ExactSpelling = true)]
        internal static extern void VertexAttribI4uiv(UInt32 index, UInt32[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribL1dv", ExactSpelling = true)]
        internal static extern void VertexAttribL1dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribL2dv", ExactSpelling = true)]
        internal static extern void VertexAttribL2dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribL3dv", ExactSpelling = true)]
        internal static extern void VertexAttribL3dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribL4dv", ExactSpelling = true)]
        internal static extern void VertexAttribL4dv(UInt32 index, Double[] v);

        [DllImport(Library, EntryPoint = "glVertexAttribP1ui", ExactSpelling = true)]
        internal static extern void VertexAttribP1ui(UInt32 index, VertexAttribPType type, Boolean normalized,
            UInt32 value);

        [DllImport(Library, EntryPoint = "glVertexAttribP2ui", ExactSpelling = true)]
        internal static extern void VertexAttribP2ui(UInt32 index, VertexAttribPType type, Boolean normalized,
            UInt32 value);

        [DllImport(Library, EntryPoint = "glVertexAttribP3ui", ExactSpelling = true)]
        internal static extern void VertexAttribP3ui(UInt32 index, VertexAttribPType type, Boolean normalized,
            UInt32 value);

        [DllImport(Library, EntryPoint = "glVertexAttribP4ui", ExactSpelling = true)]
        internal static extern void VertexAttribP4ui(UInt32 index, VertexAttribPType type, Boolean normalized,
            UInt32 value);

        [DllImport(Library, EntryPoint = "glVertexAttribBinding", ExactSpelling = true)]
        internal static extern void VertexAttribBinding(UInt32 attribindex, UInt32 bindingindex);

        [DllImport(Library, EntryPoint = "glVertexArrayAttribBinding", ExactSpelling = true)]
        internal static extern void VertexArrayAttribBinding(UInt32 vaobj, UInt32 attribindex, UInt32 bindingindex);

        [DllImport(Library, EntryPoint = "glVertexAttribDivisor", ExactSpelling = true)]
        internal static extern void VertexAttribDivisor(UInt32 index, UInt32 divisor);

        [DllImport(Library, EntryPoint = "glVertexAttribFormat", ExactSpelling = true)]
        internal static extern void VertexAttribFormat(UInt32 attribindex, Int32 size, VertexAttribFormat type,
            Boolean normalized, UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexAttribIFormat", ExactSpelling = true)]
        internal static extern void VertexAttribIFormat(UInt32 attribindex, Int32 size, VertexAttribFormat type,
            UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexAttribLFormat", ExactSpelling = true)]
        internal static extern void VertexAttribLFormat(UInt32 attribindex, Int32 size, VertexAttribFormat type,
            UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexArrayAttribFormat", ExactSpelling = true)]
        internal static extern void VertexArrayAttribFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
            VertexAttribFormat type, Boolean normalized, UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexArrayAttribIFormat", ExactSpelling = true)]
        internal static extern void VertexArrayAttribIFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
            VertexAttribFormat type, UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexArrayAttribLFormat", ExactSpelling = true)]
        internal static extern void VertexArrayAttribLFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
            VertexAttribFormat type, UInt32 relativeoffset);

        [DllImport(Library, EntryPoint = "glVertexAttribPointer", ExactSpelling = true)]
        internal static extern void VertexAttribPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
            Boolean normalized, Int32 stride, IntPtr pointer);

        [DllImport(Library, EntryPoint = "glVertexAttribIPointer", ExactSpelling = true)]
        internal static extern void VertexAttribIPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
            Int32 stride, IntPtr pointer);

        [DllImport(Library, EntryPoint = "glVertexAttribLPointer", ExactSpelling = true)]
        internal static extern void VertexAttribLPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
            Int32 stride, IntPtr pointer);

        [DllImport(Library, EntryPoint = "glVertexBindingDivisor", ExactSpelling = true)]
        internal static extern void VertexBindingDivisor(UInt32 bindingindex, UInt32 divisor);

        [DllImport(Library, EntryPoint = "glVertexArrayBindingDivisor", ExactSpelling = true)]
        internal static extern void VertexArrayBindingDivisor(UInt32 vaobj, UInt32 bindingindex, UInt32 divisor);

        [DllImport(Library, EntryPoint = "glViewport", ExactSpelling = true)]
        internal static extern void Viewport(Int32 x, Int32 y, Int32 width, Int32 height);

        [DllImport(Library, EntryPoint = "glViewportArrayv", ExactSpelling = true)]
        internal static extern void ViewportArrayv(UInt32 first, Int32 count, Single[] v);

        [DllImport(Library, EntryPoint = "glViewportIndexedf", ExactSpelling = true)]
        internal static extern void ViewportIndexedf(UInt32 index, Single x, Single y, Single w, Single h);

        [DllImport(Library, EntryPoint = "glViewportIndexedfv", ExactSpelling = true)]
        internal static extern void ViewportIndexedfv(UInt32 index, Single[] v);

        [DllImport(Library, EntryPoint = "glWaitSync", ExactSpelling = true)]
        internal static extern void WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);
    }
}
