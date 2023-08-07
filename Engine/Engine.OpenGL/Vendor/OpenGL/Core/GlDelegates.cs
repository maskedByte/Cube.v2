// ReSharper disable All

using System.Text;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS8618
#pragma warning disable 0649

namespace OpenGL
{
    using System;
    using System.Runtime.InteropServices;

    // Automatically generated from GlCore.cs using BuildGl
    internal partial class Gl
    {
        internal static partial class Delegates
        {
            internal static ActiveShaderProgram glActiveShaderProgram;
            internal static ActiveTexture glActiveTexture;
            internal static AttachShader glAttachShader;
            internal static BeginConditionalRender glBeginConditionalRender;
            internal static EndConditionalRender glEndConditionalRender;
            internal static BeginQuery glBeginQuery;
            internal static EndQuery glEndQuery;
            internal static BeginQueryIndexed glBeginQueryIndexed;
            internal static EndQueryIndexed glEndQueryIndexed;
            internal static BeginTransformFeedback glBeginTransformFeedback;
            internal static EndTransformFeedback glEndTransformFeedback;
            internal static BindAttribLocation glBindAttribLocation;
            internal static BindBuffer glBindBuffer;
            internal static BindBufferBase glBindBufferBase;
            internal static BindBufferRange glBindBufferRange;
            internal static BindBuffersBase glBindBuffersBase;
            internal static BindBuffersRange glBindBuffersRange;
            internal static BindFragDataLocation glBindFragDataLocation;
            internal static BindFragDataLocationIndexed glBindFragDataLocationIndexed;
            internal static BindFramebuffer glBindFramebuffer;
            internal static BindImageTexture glBindImageTexture;
            internal static BindImageTextures glBindImageTextures;
            internal static BindProgramPipeline glBindProgramPipeline;
            internal static BindRenderbuffer glBindRenderbuffer;
            internal static BindSampler glBindSampler;
            internal static BindSamplers glBindSamplers;
            internal static BindTexture glBindTexture;
            internal static BindTextures glBindTextures;
            internal static BindTextureUnit glBindTextureUnit;
            internal static BindTransformFeedback glBindTransformFeedback;
            internal static BindVertexArray glBindVertexArray;
            internal static BindVertexBuffer glBindVertexBuffer;
            internal static VertexArrayVertexBuffer glVertexArrayVertexBuffer;
            internal static BindVertexBuffers glBindVertexBuffers;
            internal static VertexArrayVertexBuffers glVertexArrayVertexBuffers;
            internal static BlendColor glBlendColor;
            internal static BlendEquation glBlendEquation;
            internal static BlendEquationi glBlendEquationi;
            internal static BlendEquationSeparate glBlendEquationSeparate;
            internal static BlendEquationSeparatei glBlendEquationSeparatei;
            internal static BlendFunc glBlendFunc;
            internal static BlendFunci glBlendFunci;
            internal static BlendFuncSeparate glBlendFuncSeparate;
            internal static BlendFuncSeparatei glBlendFuncSeparatei;
            internal static BlitFramebuffer glBlitFramebuffer;
            internal static BlitNamedFramebuffer glBlitNamedFramebuffer;
            internal static BufferData glBufferData;
            internal static NamedBufferData glNamedBufferData;
            internal static BufferStorage glBufferStorage;
            internal static NamedBufferStorage glNamedBufferStorage;
            internal static BufferSubData glBufferSubData;
            internal static NamedBufferSubData glNamedBufferSubData;
            internal static CheckFramebufferStatus glCheckFramebufferStatus;
            internal static CheckNamedFramebufferStatus glCheckNamedFramebufferStatus;
            internal static ClampColor glClampColor;
            internal static Clear glClear;
            internal static ClearBufferiv glClearBufferiv;
            internal static ClearBufferuiv glClearBufferuiv;
            internal static ClearBufferfv glClearBufferfv;
            internal static ClearBufferfi glClearBufferfi;
            internal static ClearNamedFramebufferiv glClearNamedFramebufferiv;
            internal static ClearNamedFramebufferuiv glClearNamedFramebufferuiv;
            internal static ClearNamedFramebufferfv glClearNamedFramebufferfv;
            internal static ClearNamedFramebufferfi glClearNamedFramebufferfi;
            internal static ClearBufferData glClearBufferData;
            internal static ClearNamedBufferData glClearNamedBufferData;
            internal static ClearBufferSubData glClearBufferSubData;
            internal static ClearNamedBufferSubData glClearNamedBufferSubData;
            internal static ClearColor glClearColor;
            internal static ClearDepth glClearDepth;
            internal static ClearDepthf glClearDepthf;
            internal static ClearStencil glClearStencil;
            internal static ClearTexImage glClearTexImage;
            internal static ClearTexSubImage glClearTexSubImage;
            internal static ClientWaitSync glClientWaitSync;
            internal static ClipControl glClipControl;
            internal static ColorMask glColorMask;
            internal static ColorMaski glColorMaski;
            internal static CompileShader glCompileShader;
            internal static CompressedTexImage1D glCompressedTexImage1D;
            internal static CompressedTexImage2D glCompressedTexImage2D;
            internal static CompressedTexImage3D glCompressedTexImage3D;
            internal static CompressedTexSubImage1D glCompressedTexSubImage1D;
            internal static CompressedTextureSubImage1D glCompressedTextureSubImage1D;
            internal static CompressedTexSubImage2D glCompressedTexSubImage2D;
            internal static CompressedTextureSubImage2D glCompressedTextureSubImage2D;
            internal static CompressedTexSubImage3D glCompressedTexSubImage3D;
            internal static CompressedTextureSubImage3D glCompressedTextureSubImage3D;
            internal static CopyBufferSubData glCopyBufferSubData;
            internal static CopyNamedBufferSubData glCopyNamedBufferSubData;
            internal static CopyImageSubData glCopyImageSubData;
            internal static CopyTexImage1D glCopyTexImage1D;
            internal static CopyTexImage2D glCopyTexImage2D;
            internal static CopyTexSubImage1D glCopyTexSubImage1D;
            internal static CopyTextureSubImage1D glCopyTextureSubImage1D;
            internal static CopyTexSubImage2D glCopyTexSubImage2D;
            internal static CopyTextureSubImage2D glCopyTextureSubImage2D;
            internal static CopyTexSubImage3D glCopyTexSubImage3D;
            internal static CopyTextureSubImage3D glCopyTextureSubImage3D;
            internal static CreateBuffers glCreateBuffers;
            internal static CreateFramebuffers glCreateFramebuffers;
            internal static CreateProgram glCreateProgram;
            internal static CreateProgramPipelines glCreateProgramPipelines;
            internal static CreateQueries glCreateQueries;
            internal static CreateRenderbuffers glCreateRenderbuffers;
            internal static CreateSamplers glCreateSamplers;
            internal static CreateShader glCreateShader;
            internal static CreateShaderProgramv glCreateShaderProgramv;
            internal static CreateTextures glCreateTextures;
            internal static CreateTransformFeedbacks glCreateTransformFeedbacks;
            internal static CreateVertexArrays glCreateVertexArrays;
            internal static CullFace glCullFace;
            internal static DeleteBuffers glDeleteBuffers;
            internal static DeleteFramebuffers glDeleteFramebuffers;
            internal static DeleteProgram glDeleteProgram;
            internal static DeleteProgramPipelines glDeleteProgramPipelines;
            internal static DeleteQueries glDeleteQueries;
            internal static DeleteRenderbuffers glDeleteRenderbuffers;
            internal static DeleteSamplers glDeleteSamplers;
            internal static DeleteShader glDeleteShader;
            internal static DeleteSync glDeleteSync;
            internal static DeleteTextures glDeleteTextures;
            internal static DeleteTransformFeedbacks glDeleteTransformFeedbacks;
            internal static DeleteVertexArrays glDeleteVertexArrays;
            internal static DepthFunc glDepthFunc;
            internal static DepthMask glDepthMask;
            internal static DepthRange glDepthRange;
            internal static DepthRangef glDepthRangef;
            internal static DepthRangeArrayv glDepthRangeArrayv;
            internal static DepthRangeIndexed glDepthRangeIndexed;
            internal static DetachShader glDetachShader;
            internal static DispatchCompute glDispatchCompute;
            internal static DispatchComputeIndirect glDispatchComputeIndirect;
            internal static DrawArrays glDrawArrays;
            internal static DrawArraysIndirect glDrawArraysIndirect;
            internal static DrawArraysInstanced glDrawArraysInstanced;
            internal static DrawArraysInstancedBaseInstance glDrawArraysInstancedBaseInstance;
            internal static DrawBuffer glDrawBuffer;
            internal static NamedFramebufferDrawBuffer glNamedFramebufferDrawBuffer;
            internal static DrawBuffers glDrawBuffers;
            internal static NamedFramebufferDrawBuffers glNamedFramebufferDrawBuffers;
            internal static DrawElements glDrawElements;
            internal static DrawElementsBaseVertex glDrawElementsBaseVertex;
            internal static DrawElementsIndirect glDrawElementsIndirect;
            internal static DrawElementsInstanced glDrawElementsInstanced;
            internal static DrawElementsInstancedBaseInstance glDrawElementsInstancedBaseInstance;
            internal static DrawElementsInstancedBaseVertex glDrawElementsInstancedBaseVertex;
            internal static DrawElementsInstancedBaseVertexBaseInstance glDrawElementsInstancedBaseVertexBaseInstance;
            internal static DrawRangeElements glDrawRangeElements;
            internal static DrawRangeElementsBaseVertex glDrawRangeElementsBaseVertex;
            internal static DrawTransformFeedback glDrawTransformFeedback;
            internal static DrawTransformFeedbackInstanced glDrawTransformFeedbackInstanced;
            internal static DrawTransformFeedbackStream glDrawTransformFeedbackStream;
            internal static DrawTransformFeedbackStreamInstanced glDrawTransformFeedbackStreamInstanced;
            internal static Enable glEnable;
            internal static Disable glDisable;
            internal static Enablei glEnablei;
            internal static Disablei glDisablei;
            internal static EnableVertexAttribArray glEnableVertexAttribArray;
            internal static DisableVertexAttribArray glDisableVertexAttribArray;
            internal static EnableVertexArrayAttrib glEnableVertexArrayAttrib;
            internal static DisableVertexArrayAttrib glDisableVertexArrayAttrib;
            internal static FenceSync glFenceSync;
            internal static Finish glFinish;
            internal static Flush glFlush;
            internal static FlushMappedBufferRange glFlushMappedBufferRange;
            internal static FlushMappedNamedBufferRange glFlushMappedNamedBufferRange;
            internal static FramebufferParameteri glFramebufferParameteri;
            internal static NamedFramebufferParameteri glNamedFramebufferParameteri;
            internal static FramebufferRenderbuffer glFramebufferRenderbuffer;
            internal static NamedFramebufferRenderbuffer glNamedFramebufferRenderbuffer;
            internal static FramebufferTexture glFramebufferTexture;
            internal static FramebufferTexture1D glFramebufferTexture1D;
            internal static FramebufferTexture2D glFramebufferTexture2D;
            internal static FramebufferTexture3D glFramebufferTexture3D;
            internal static NamedFramebufferTexture glNamedFramebufferTexture;
            internal static FramebufferTextureLayer glFramebufferTextureLayer;
            internal static NamedFramebufferTextureLayer glNamedFramebufferTextureLayer;
            internal static FrontFace glFrontFace;
            internal static GenBuffers glGenBuffers;
            internal static GenerateMipmap glGenerateMipmap;
            internal static GenerateTextureMipmap glGenerateTextureMipmap;
            internal static GenFramebuffers glGenFramebuffers;
            internal static GenProgramPipelines glGenProgramPipelines;
            internal static GenQueries glGenQueries;
            internal static GenRenderbuffers glGenRenderbuffers;
            internal static GenSamplers glGenSamplers;
            internal static GenTextures glGenTextures;
            internal static GenTransformFeedbacks glGenTransformFeedbacks;
            internal static GenVertexArrays glGenVertexArrays;
            internal static GetBooleanv glGetBooleanv;
            internal static GetDoublev glGetDoublev;
            internal static GetFloatv glGetFloatv;
            internal static GetIntegerv glGetIntegerv;
            internal static GetInteger64v glGetInteger64v;
            internal static GetBooleani_v glGetBooleani_v;
            internal static GetIntegeri_v glGetIntegeri_v;
            internal static GetFloati_v glGetFloati_v;
            internal static GetDoublei_v glGetDoublei_v;
            internal static GetInteger64i_v glGetInteger64i_v;
            internal static GetActiveAtomicCounterBufferiv glGetActiveAtomicCounterBufferiv;
            internal static GetActiveAttrib glGetActiveAttrib;
            internal static GetActiveSubroutineName glGetActiveSubroutineName;
            internal static GetActiveSubroutineUniformiv glGetActiveSubroutineUniformiv;
            internal static GetActiveSubroutineUniformName glGetActiveSubroutineUniformName;
            internal static GetActiveUniform glGetActiveUniform;
            internal static GetActiveUniformBlockiv glGetActiveUniformBlockiv;
            internal static GetActiveUniformBlockName glGetActiveUniformBlockName;
            internal static GetActiveUniformName glGetActiveUniformName;
            internal static GetActiveUniformsiv glGetActiveUniformsiv;
            internal static GetAttachedShaders glGetAttachedShaders;
            internal static GetAttribLocation glGetAttribLocation;
            internal static GetBufferParameteriv glGetBufferParameteriv;
            internal static GetBufferParameteri64v glGetBufferParameteri64v;
            internal static GetNamedBufferParameteriv glGetNamedBufferParameteriv;
            internal static GetNamedBufferParameteri64v glGetNamedBufferParameteri64v;
            internal static GetBufferPointerv glGetBufferPointerv;
            internal static GetNamedBufferPointerv glGetNamedBufferPointerv;
            internal static GetBufferSubData glGetBufferSubData;
            internal static GetNamedBufferSubData glGetNamedBufferSubData;
            internal static GetCompressedTexImage glGetCompressedTexImage;
            internal static GetnCompressedTexImage glGetnCompressedTexImage;
            internal static GetCompressedTextureImage glGetCompressedTextureImage;
            internal static GetCompressedTextureSubImage glGetCompressedTextureSubImage;
            internal static GetError glGetError;
            internal static GetFragDataIndex glGetFragDataIndex;
            internal static GetFragDataLocation glGetFragDataLocation;
            internal static GetFramebufferAttachmentParameteriv glGetFramebufferAttachmentParameteriv;
            internal static GetNamedFramebufferAttachmentParameteriv glGetNamedFramebufferAttachmentParameteriv;
            internal static GetFramebufferParameteriv glGetFramebufferParameteriv;
            internal static GetNamedFramebufferParameteriv glGetNamedFramebufferParameteriv;
            internal static GetGraphicsResetStatus glGetGraphicsResetStatus;
            internal static GetInternalformativ glGetInternalformativ;
            internal static GetInternalformati64v glGetInternalformati64v;
            internal static GetMultisamplefv glGetMultisamplefv;
            internal static GetObjectLabel glGetObjectLabel;
            internal static GetObjectPtrLabel glGetObjectPtrLabel;
            internal static GetPointerv glGetPointerv;
            internal static GetProgramiv glGetProgramiv;
            internal static GetProgramBinary glGetProgramBinary;
            internal static GetProgramInfoLog glGetProgramInfoLog;
            internal static GetProgramInterfaceiv glGetProgramInterfaceiv;
            internal static GetProgramPipelineiv glGetProgramPipelineiv;
            internal static GetProgramPipelineInfoLog glGetProgramPipelineInfoLog;
            internal static GetProgramResourceiv glGetProgramResourceiv;
            internal static GetProgramResourceIndex glGetProgramResourceIndex;
            internal static GetProgramResourceLocation glGetProgramResourceLocation;
            internal static GetProgramResourceLocationIndex glGetProgramResourceLocationIndex;
            internal static GetProgramResourceName glGetProgramResourceName;
            internal static GetProgramStageiv glGetProgramStageiv;
            internal static GetQueryIndexediv glGetQueryIndexediv;
            internal static GetQueryiv glGetQueryiv;
            internal static GetQueryObjectiv glGetQueryObjectiv;
            internal static GetQueryObjectuiv glGetQueryObjectuiv;
            internal static GetQueryObjecti64v glGetQueryObjecti64v;
            internal static GetQueryObjectui64v glGetQueryObjectui64v;
            internal static GetRenderbufferParameteriv glGetRenderbufferParameteriv;
            internal static GetNamedRenderbufferParameteriv glGetNamedRenderbufferParameteriv;
            internal static GetSamplerParameterfv glGetSamplerParameterfv;
            internal static GetSamplerParameteriv glGetSamplerParameteriv;
            internal static GetSamplerParameterIiv glGetSamplerParameterIiv;
            internal static GetSamplerParameterIuiv glGetSamplerParameterIuiv;
            internal static GetShaderiv glGetShaderiv;
            internal static GetShaderInfoLog glGetShaderInfoLog;
            internal static GetShaderPrecisionFormat glGetShaderPrecisionFormat;
            internal static GetShaderSource glGetShaderSource;
            internal static GetString glGetString;
            internal static GetStringi glGetStringi;
            internal static GetSubroutineIndex glGetSubroutineIndex;
            internal static GetSubroutineUniformLocation glGetSubroutineUniformLocation;
            internal static GetSynciv glGetSynciv;
            internal static GetTexImage glGetTexImage;
            internal static GetnTexImage glGetnTexImage;
            internal static GetTextureImage glGetTextureImage;
            internal static GetTexLevelParameterfv glGetTexLevelParameterfv;
            internal static GetTexLevelParameteriv glGetTexLevelParameteriv;
            internal static GetTextureLevelParameterfv glGetTextureLevelParameterfv;
            internal static GetTextureLevelParameteriv glGetTextureLevelParameteriv;
            internal static GetTexParameterfv glGetTexParameterfv;
            internal static GetTexParameteriv glGetTexParameteriv;
            internal static GetTexParameterIiv glGetTexParameterIiv;
            internal static GetTexParameterIuiv glGetTexParameterIuiv;
            internal static GetTextureParameterfv glGetTextureParameterfv;
            internal static GetTextureParameteriv glGetTextureParameteriv;
            internal static GetTextureParameterIiv glGetTextureParameterIiv;
            internal static GetTextureParameterIuiv glGetTextureParameterIuiv;
            internal static GetTextureSubImage glGetTextureSubImage;
            internal static GetTransformFeedbackiv glGetTransformFeedbackiv;
            internal static GetTransformFeedbacki_v glGetTransformFeedbacki_v;
            internal static GetTransformFeedbacki64_v glGetTransformFeedbacki64_v;
            internal static GetTransformFeedbackVarying glGetTransformFeedbackVarying;
            internal static GetUniformfv glGetUniformfv;
            internal static GetUniformiv glGetUniformiv;
            internal static GetUniformuiv glGetUniformuiv;
            internal static GetUniformdv glGetUniformdv;
            internal static GetnUniformfv glGetnUniformfv;
            internal static GetnUniformiv glGetnUniformiv;
            internal static GetnUniformuiv glGetnUniformuiv;
            internal static GetnUniformdv glGetnUniformdv;
            internal static GetUniformBlockIndex glGetUniformBlockIndex;
            internal static GetUniformIndices glGetUniformIndices;
            internal static GetUniformLocation glGetUniformLocation;
            internal static GetUniformSubroutineuiv glGetUniformSubroutineuiv;
            internal static GetVertexArrayIndexed64iv glGetVertexArrayIndexed64iv;
            internal static GetVertexArrayIndexediv glGetVertexArrayIndexediv;
            internal static GetVertexArrayiv glGetVertexArrayiv;
            internal static GetVertexAttribdv glGetVertexAttribdv;
            internal static GetVertexAttribfv glGetVertexAttribfv;
            internal static GetVertexAttribiv glGetVertexAttribiv;
            internal static GetVertexAttribIiv glGetVertexAttribIiv;
            internal static GetVertexAttribIuiv glGetVertexAttribIuiv;
            internal static GetVertexAttribLdv glGetVertexAttribLdv;
            internal static GetVertexAttribPointerv glGetVertexAttribPointerv;
            internal static Hint glHint;
            internal static InvalidateBufferData glInvalidateBufferData;
            internal static InvalidateBufferSubData glInvalidateBufferSubData;
            internal static InvalidateFramebuffer glInvalidateFramebuffer;
            internal static InvalidateNamedFramebufferData glInvalidateNamedFramebufferData;
            internal static InvalidateSubFramebuffer glInvalidateSubFramebuffer;
            internal static InvalidateNamedFramebufferSubData glInvalidateNamedFramebufferSubData;
            internal static InvalidateTexImage glInvalidateTexImage;
            internal static InvalidateTexSubImage glInvalidateTexSubImage;
            internal static IsBuffer glIsBuffer;
            internal static IsEnabled glIsEnabled;
            internal static IsEnabledi glIsEnabledi;
            internal static IsFramebuffer glIsFramebuffer;
            internal static IsProgram glIsProgram;
            internal static IsProgramPipeline glIsProgramPipeline;
            internal static IsQuery glIsQuery;
            internal static IsRenderbuffer glIsRenderbuffer;
            internal static IsSampler glIsSampler;
            internal static IsShader glIsShader;
            internal static IsSync glIsSync;
            internal static IsTexture glIsTexture;
            internal static IsTransformFeedback glIsTransformFeedback;
            internal static IsVertexArray glIsVertexArray;
            internal static LineWidth glLineWidth;
            internal static LinkProgram glLinkProgram;
            internal static LogicOp glLogicOp;
            internal static MapBuffer glMapBuffer;
            internal static MapNamedBuffer glMapNamedBuffer;
            internal static MapBufferRange glMapBufferRange;
            internal static MapNamedBufferRange glMapNamedBufferRange;
            internal static MemoryBarrier glMemoryBarrier;
            internal static MemoryBarrierByRegion glMemoryBarrierByRegion;
            internal static MinSampleShading glMinSampleShading;
            internal static MultiDrawArrays glMultiDrawArrays;
            internal static MultiDrawArraysIndirect glMultiDrawArraysIndirect;
            internal static MultiDrawElements glMultiDrawElements;
            internal static MultiDrawElementsBaseVertex glMultiDrawElementsBaseVertex;
            internal static MultiDrawElementsIndirect glMultiDrawElementsIndirect;
            internal static ObjectLabel glObjectLabel;
            internal static ObjectPtrLabel glObjectPtrLabel;
            internal static PatchParameteri glPatchParameteri;
            internal static PatchParameterfv glPatchParameterfv;
            internal static PixelStoref glPixelStoref;
            internal static PixelStorei glPixelStorei;
            internal static PointParameterf glPointParameterf;
            internal static PointParameteri glPointParameteri;
            internal static PointParameterfv glPointParameterfv;
            internal static PointParameteriv glPointParameteriv;
            internal static PointSize glPointSize;
            internal static PolygonMode glPolygonMode;
            internal static PolygonOffset glPolygonOffset;
            internal static PrimitiveRestartIndex glPrimitiveRestartIndex;
            internal static ProgramBinary glProgramBinary;
            internal static ProgramParameteri glProgramParameteri;
            internal static ProgramUniform1f glProgramUniform1f;
            internal static ProgramUniform2f glProgramUniform2f;
            internal static ProgramUniform3f glProgramUniform3f;
            internal static ProgramUniform4f glProgramUniform4f;
            internal static ProgramUniform1i glProgramUniform1i;
            internal static ProgramUniform2i glProgramUniform2i;
            internal static ProgramUniform3i glProgramUniform3i;
            internal static ProgramUniform4i glProgramUniform4i;
            internal static ProgramUniform1ui glProgramUniform1ui;
            internal static ProgramUniform2ui glProgramUniform2ui;
            internal static ProgramUniform3ui glProgramUniform3ui;
            internal static ProgramUniform4ui glProgramUniform4ui;
            internal static ProgramUniform1fv glProgramUniform1fv;
            internal static ProgramUniform2fv glProgramUniform2fv;
            internal static ProgramUniform3fv glProgramUniform3fv;
            internal static ProgramUniform4fv glProgramUniform4fv;
            internal static ProgramUniform1iv glProgramUniform1iv;
            internal static ProgramUniform2iv glProgramUniform2iv;
            internal static ProgramUniform3iv glProgramUniform3iv;
            internal static ProgramUniform4iv glProgramUniform4iv;
            internal static ProgramUniform1uiv glProgramUniform1uiv;
            internal static ProgramUniform2uiv glProgramUniform2uiv;
            internal static ProgramUniform3uiv glProgramUniform3uiv;
            internal static ProgramUniform4uiv glProgramUniform4uiv;
            internal static ProgramUniformMatrix2fv glProgramUniformMatrix2fv;
            internal static ProgramUniformMatrix3fv glProgramUniformMatrix3fv;
            internal static ProgramUniformMatrix4fv glProgramUniformMatrix4fv;
            internal static ProgramUniformMatrix2x3fv glProgramUniformMatrix2x3fv;
            internal static ProgramUniformMatrix3x2fv glProgramUniformMatrix3x2fv;
            internal static ProgramUniformMatrix2x4fv glProgramUniformMatrix2x4fv;
            internal static ProgramUniformMatrix4x2fv glProgramUniformMatrix4x2fv;
            internal static ProgramUniformMatrix3x4fv glProgramUniformMatrix3x4fv;
            internal static ProgramUniformMatrix4x3fv glProgramUniformMatrix4x3fv;
            internal static ProvokingVertex glProvokingVertex;
            internal static QueryCounter glQueryCounter;
            internal static ReadBuffer glReadBuffer;
            internal static NamedFramebufferReadBuffer glNamedFramebufferReadBuffer;
            internal static ReadPixels glReadPixels;
            internal static ReadnPixels glReadnPixels;
            internal static RenderbufferStorage glRenderbufferStorage;
            internal static NamedRenderbufferStorage glNamedRenderbufferStorage;
            internal static RenderbufferStorageMultisample glRenderbufferStorageMultisample;
            internal static NamedRenderbufferStorageMultisample glNamedRenderbufferStorageMultisample;
            internal static SampleCoverage glSampleCoverage;
            internal static SampleMaski glSampleMaski;
            internal static SamplerParameterf glSamplerParameterf;
            internal static SamplerParameteri glSamplerParameteri;
            internal static SamplerParameterfv glSamplerParameterfv;
            internal static SamplerParameteriv glSamplerParameteriv;
            internal static SamplerParameterIiv glSamplerParameterIiv;
            internal static SamplerParameterIuiv glSamplerParameterIuiv;
            internal static Scissor glScissor;
            internal static ScissorArrayv glScissorArrayv;
            internal static ScissorIndexed glScissorIndexed;
            internal static ScissorIndexedv glScissorIndexedv;
            internal static ShaderBinary glShaderBinary;
            internal static ShaderSource glShaderSource;
            internal static ShaderStorageBlockBinding glShaderStorageBlockBinding;
            internal static StencilFunc glStencilFunc;
            internal static StencilFuncSeparate glStencilFuncSeparate;
            internal static StencilMask glStencilMask;
            internal static StencilMaskSeparate glStencilMaskSeparate;
            internal static StencilOp glStencilOp;
            internal static StencilOpSeparate glStencilOpSeparate;
            internal static TexBuffer glTexBuffer;
            internal static TextureBuffer glTextureBuffer;
            internal static TexBufferRange glTexBufferRange;
            internal static TextureBufferRange glTextureBufferRange;
            internal static TexImage1D glTexImage1D;
            internal static TexImage2D glTexImage2D;
            internal static TexImage2DMultisample glTexImage2DMultisample;
            internal static TexImage3D glTexImage3D;
            internal static TexImage3DMultisample glTexImage3DMultisample;
            internal static TexParameterf glTexParameterf;
            internal static TexParameteri glTexParameteri;
            internal static TextureParameterf glTextureParameterf;
            internal static TextureParameteri glTextureParameteri;
            internal static TexParameterfv glTexParameterfv;
            internal static TexParameteriv glTexParameteriv;
            internal static TexParameterIiv glTexParameterIiv;
            internal static TexParameterIuiv glTexParameterIuiv;
            internal static TextureParameterfv glTextureParameterfv;
            internal static TextureParameteriv glTextureParameteriv;
            internal static TextureParameterIiv glTextureParameterIiv;
            internal static TextureParameterIuiv glTextureParameterIuiv;
            internal static TexStorage1D glTexStorage1D;
            internal static TextureStorage1D glTextureStorage1D;
            internal static TexStorage2D glTexStorage2D;
            internal static TextureStorage2D glTextureStorage2D;
            internal static TexStorage2DMultisample glTexStorage2DMultisample;
            internal static TextureStorage2DMultisample glTextureStorage2DMultisample;
            internal static TexStorage3D glTexStorage3D;
            internal static TextureStorage3D glTextureStorage3D;
            internal static TexStorage3DMultisample glTexStorage3DMultisample;
            internal static TextureStorage3DMultisample glTextureStorage3DMultisample;
            internal static TexSubImage1D glTexSubImage1D;
            internal static TextureSubImage1D glTextureSubImage1D;
            internal static TexSubImage2D glTexSubImage2D;
            internal static TextureSubImage2D glTextureSubImage2D;
            internal static TexSubImage3D glTexSubImage3D;
            internal static TextureSubImage3D glTextureSubImage3D;
            internal static TextureBarrier glTextureBarrier;
            internal static TextureView glTextureView;
            internal static TransformFeedbackBufferBase glTransformFeedbackBufferBase;
            internal static TransformFeedbackBufferRange glTransformFeedbackBufferRange;
            internal static TransformFeedbackVaryings glTransformFeedbackVaryings;
            internal static Uniform1f glUniform1f;
            internal static Uniform2f glUniform2f;
            internal static Uniform3f glUniform3f;
            internal static Uniform4f glUniform4f;
            internal static Uniform1i glUniform1i;
            internal static Uniform2i glUniform2i;
            internal static Uniform3i glUniform3i;
            internal static Uniform4i glUniform4i;
            internal static Uniform1ui glUniform1ui;
            internal static Uniform2ui glUniform2ui;
            internal static Uniform3ui glUniform3ui;
            internal static Uniform4ui glUniform4ui;
            internal static Uniform1fv glUniform1fv;
            internal static Uniform2fv glUniform2fv;
            internal static Uniform3fv glUniform3fv;
            internal static Uniform4fv glUniform4fv;
            internal static Uniform1iv glUniform1iv;
            internal static Uniform2iv glUniform2iv;
            internal static Uniform3iv glUniform3iv;
            internal static Uniform4iv glUniform4iv;
            internal static Uniform1uiv glUniform1uiv;
            internal static Uniform2uiv glUniform2uiv;
            internal static Uniform3uiv glUniform3uiv;
            internal static Uniform4uiv glUniform4uiv;
            internal static UniformMatrix2fv glUniformMatrix2fv;
            internal static UniformMatrix3fv glUniformMatrix3fv;
            internal static UniformMatrix4fv glUniformMatrix4fv;
            internal static UniformMatrix2x3fv glUniformMatrix2x3fv;
            internal static UniformMatrix3x2fv glUniformMatrix3x2fv;
            internal static UniformMatrix2x4fv glUniformMatrix2x4fv;
            internal static UniformMatrix4x2fv glUniformMatrix4x2fv;
            internal static UniformMatrix3x4fv glUniformMatrix3x4fv;
            internal static UniformMatrix4x3fv glUniformMatrix4x3fv;
            internal static UniformBlockBinding glUniformBlockBinding;
            internal static UniformSubroutinesuiv glUniformSubroutinesuiv;
            internal static UnmapBuffer glUnmapBuffer;
            internal static UnmapNamedBuffer glUnmapNamedBuffer;
            internal static UseProgram glUseProgram;
            internal static UseProgramStages glUseProgramStages;
            internal static ValidateProgram glValidateProgram;
            internal static ValidateProgramPipeline glValidateProgramPipeline;
            internal static VertexArrayElementBuffer glVertexArrayElementBuffer;
            internal static VertexAttrib1f glVertexAttrib1f;
            internal static VertexAttrib1s glVertexAttrib1s;
            internal static VertexAttrib1d glVertexAttrib1d;
            internal static VertexAttribI1i glVertexAttribI1i;
            internal static VertexAttribI1ui glVertexAttribI1ui;
            internal static VertexAttrib2f glVertexAttrib2f;
            internal static VertexAttrib2s glVertexAttrib2s;
            internal static VertexAttrib2d glVertexAttrib2d;
            internal static VertexAttribI2i glVertexAttribI2i;
            internal static VertexAttribI2ui glVertexAttribI2ui;
            internal static VertexAttrib3f glVertexAttrib3f;
            internal static VertexAttrib3s glVertexAttrib3s;
            internal static VertexAttrib3d glVertexAttrib3d;
            internal static VertexAttribI3i glVertexAttribI3i;
            internal static VertexAttribI3ui glVertexAttribI3ui;
            internal static VertexAttrib4f glVertexAttrib4f;
            internal static VertexAttrib4s glVertexAttrib4s;
            internal static VertexAttrib4d glVertexAttrib4d;
            internal static VertexAttrib4Nub glVertexAttrib4Nub;
            internal static VertexAttribI4i glVertexAttribI4i;
            internal static VertexAttribI4ui glVertexAttribI4ui;
            internal static VertexAttribL1d glVertexAttribL1d;
            internal static VertexAttribL2d glVertexAttribL2d;
            internal static VertexAttribL3d glVertexAttribL3d;
            internal static VertexAttribL4d glVertexAttribL4d;
            internal static VertexAttrib1fv glVertexAttrib1fv;
            internal static VertexAttrib1sv glVertexAttrib1sv;
            internal static VertexAttrib1dv glVertexAttrib1dv;
            internal static VertexAttribI1iv glVertexAttribI1iv;
            internal static VertexAttribI1uiv glVertexAttribI1uiv;
            internal static VertexAttrib2fv glVertexAttrib2fv;
            internal static VertexAttrib2sv glVertexAttrib2sv;
            internal static VertexAttrib2dv glVertexAttrib2dv;
            internal static VertexAttribI2iv glVertexAttribI2iv;
            internal static VertexAttribI2uiv glVertexAttribI2uiv;
            internal static VertexAttrib3fv glVertexAttrib3fv;
            internal static VertexAttrib3sv glVertexAttrib3sv;
            internal static VertexAttrib3dv glVertexAttrib3dv;
            internal static VertexAttribI3iv glVertexAttribI3iv;
            internal static VertexAttribI3uiv glVertexAttribI3uiv;
            internal static VertexAttrib4fv glVertexAttrib4fv;
            internal static VertexAttrib4sv glVertexAttrib4sv;
            internal static VertexAttrib4dv glVertexAttrib4dv;
            internal static VertexAttrib4iv glVertexAttrib4iv;
            internal static VertexAttrib4bv glVertexAttrib4bv;
            internal static VertexAttrib4ubv glVertexAttrib4ubv;
            internal static VertexAttrib4usv glVertexAttrib4usv;
            internal static VertexAttrib4uiv glVertexAttrib4uiv;
            internal static VertexAttrib4Nbv glVertexAttrib4Nbv;
            internal static VertexAttrib4Nsv glVertexAttrib4Nsv;
            internal static VertexAttrib4Niv glVertexAttrib4Niv;
            internal static VertexAttrib4Nubv glVertexAttrib4Nubv;
            internal static VertexAttrib4Nusv glVertexAttrib4Nusv;
            internal static VertexAttrib4Nuiv glVertexAttrib4Nuiv;
            internal static VertexAttribI4bv glVertexAttribI4bv;
            internal static VertexAttribI4ubv glVertexAttribI4ubv;
            internal static VertexAttribI4sv glVertexAttribI4sv;
            internal static VertexAttribI4usv glVertexAttribI4usv;
            internal static VertexAttribI4iv glVertexAttribI4iv;
            internal static VertexAttribI4uiv glVertexAttribI4uiv;
            internal static VertexAttribL1dv glVertexAttribL1dv;
            internal static VertexAttribL2dv glVertexAttribL2dv;
            internal static VertexAttribL3dv glVertexAttribL3dv;
            internal static VertexAttribL4dv glVertexAttribL4dv;
            internal static VertexAttribP1ui glVertexAttribP1ui;
            internal static VertexAttribP2ui glVertexAttribP2ui;
            internal static VertexAttribP3ui glVertexAttribP3ui;
            internal static VertexAttribP4ui glVertexAttribP4ui;
            internal static VertexAttribBinding glVertexAttribBinding;
            internal static VertexArrayAttribBinding glVertexArrayAttribBinding;
            internal static VertexAttribDivisor glVertexAttribDivisor;
            internal static VertexAttribFormat glVertexAttribFormat;
            internal static VertexAttribIFormat glVertexAttribIFormat;
            internal static VertexAttribLFormat glVertexAttribLFormat;
            internal static VertexArrayAttribFormat glVertexArrayAttribFormat;
            internal static VertexArrayAttribIFormat glVertexArrayAttribIFormat;
            internal static VertexArrayAttribLFormat glVertexArrayAttribLFormat;
            internal static VertexAttribPointer glVertexAttribPointer;
            internal static VertexAttribIPointer glVertexAttribIPointer;
            internal static VertexAttribLPointer glVertexAttribLPointer;
            internal static VertexBindingDivisor glVertexBindingDivisor;
            internal static VertexArrayBindingDivisor glVertexArrayBindingDivisor;
            internal static Viewport glViewport;
            internal static ViewportArrayv glViewportArrayv;
            internal static ViewportIndexedf glViewportIndexedf;
            internal static ViewportIndexedfv glViewportIndexedfv;
            internal static WaitSync glWaitSync;

            internal delegate void ActiveShaderProgram(UInt32 pipeline, UInt32 program);

            internal delegate void ActiveTexture(Int32 texture);

            internal delegate void AttachShader(UInt32 program, UInt32 shader);

            internal delegate void BeginConditionalRender(UInt32 id, ConditionalRenderType mode);

            internal delegate void EndConditionalRender();

            internal delegate void BeginQuery(QueryTarget target, UInt32 id);

            internal delegate void EndQuery(QueryTarget target);

            internal delegate void BeginQueryIndexed(QueryTarget target, UInt32 index, UInt32 id);

            internal delegate void EndQueryIndexed(QueryTarget target, UInt32 index);

            internal delegate void BeginTransformFeedback(BeginFeedbackMode primitiveMode);

            internal delegate void EndTransformFeedback();

            internal delegate void BindAttribLocation(UInt32 program, UInt32 index, String name);

            internal delegate void BindBuffer(BufferTarget target, UInt32 buffer);

            internal delegate void BindBufferBase(BufferTarget target, UInt32 index, UInt32 buffer);

            internal delegate void BindBufferRange(BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset,
                IntPtr size);

            internal delegate void BindBuffersBase(BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers);

            internal delegate void BindBuffersRange(BufferTarget target, UInt32 first, Int32 count, UInt32[] buffers,
                IntPtr[] offsets, IntPtr[] sizes);

            internal delegate void BindFragDataLocation(UInt32 program, UInt32 colorNumber, String name);

            internal delegate void BindFragDataLocationIndexed(UInt32 program, UInt32 colorNumber, UInt32 index,
                String name);

            internal delegate void BindFramebuffer(FramebufferTarget target, UInt32 framebuffer);

            internal delegate void BindImageTexture(UInt32 unit, UInt32 texture, Int32 level, Boolean layered,
                Int32 layer, BufferAccess access, PixelInternalFormat format);

            internal delegate void BindImageTextures(UInt32 first, Int32 count, UInt32[] textures);

            internal delegate void BindProgramPipeline(UInt32 pipeline);

            internal delegate void BindRenderbuffer(RenderbufferTarget target, UInt32 renderbuffer);

            internal delegate void BindSampler(UInt32 unit, UInt32 sampler);

            internal delegate void BindSamplers(UInt32 first, Int32 count, UInt32[] samplers);

            internal delegate void BindTexture(TextureTarget target, UInt32 texture);

            internal delegate void BindTextures(UInt32 first, Int32 count, UInt32[] textures);

            internal delegate void BindTextureUnit(UInt32 unit, UInt32 texture);

            internal delegate void BindTransformFeedback(NvTransformFeedback2 target, UInt32 id);

            internal delegate void BindVertexArray(UInt32 array);

            internal delegate void BindVertexBuffer(UInt32 bindingindex, UInt32 buffer, IntPtr offset, IntPtr stride);

            internal delegate void VertexArrayVertexBuffer(UInt32 vaobj, UInt32 bindingindex, UInt32 buffer,
                IntPtr offset, Int32 stride);

            internal delegate void BindVertexBuffers(UInt32 first, Int32 count, UInt32[] buffers, IntPtr[] offsets,
                Int32[] strides);

            internal delegate void VertexArrayVertexBuffers(UInt32 vaobj, UInt32 first, Int32 count, UInt32[] buffers,
                IntPtr[] offsets, Int32[] strides);

            internal delegate void BlendColor(Single red, Single green, Single blue, Single alpha);

            internal delegate void BlendEquation(BlendEquationMode mode);

            internal delegate void BlendEquationi(UInt32 buf, BlendEquationMode mode);

            internal delegate void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha);

            internal delegate void BlendEquationSeparatei(UInt32 buf, BlendEquationMode modeRGB,
                BlendEquationMode modeAlpha);

            internal delegate void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

            internal delegate void BlendFunci(UInt32 buf, BlendingFactorSrc sfactor, BlendingFactorDest dfactor);

            internal delegate void BlendFuncSeparate(BlendingFactorSrc srcRGB, BlendingFactorDest dstRGB,
                BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha);

            internal delegate void BlendFuncSeparatei(UInt32 buf, BlendingFactorSrc srcRGB, BlendingFactorDest dstRGB,
                BlendingFactorSrc srcAlpha, BlendingFactorDest dstAlpha);

            internal delegate void BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0,
                Int32 dstY0, Int32 dstX1, Int32 dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);

            internal delegate void BlitNamedFramebuffer(UInt32 readFramebuffer, UInt32 drawFramebuffer, Int32 srcX0,
                Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1,
                ClearBufferMask mask, BlitFramebufferFilter filter);

            internal delegate void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage);

            internal delegate void NamedBufferData(UInt32 buffer, Int32 size, IntPtr data, BufferUsageHint usage);

            internal delegate void BufferStorage(BufferTarget target, IntPtr size, IntPtr data, UInt32 flags);

            internal delegate void NamedBufferStorage(UInt32 buffer, Int32 size, IntPtr data, UInt32 flags);

            internal delegate void BufferSubData(BufferTarget target, IntPtr offset, IntPtr size, IntPtr data);

            internal delegate void NamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size, IntPtr data);

            internal delegate FramebufferErrorCode CheckFramebufferStatus(FramebufferTarget target);

            internal delegate FramebufferErrorCode CheckNamedFramebufferStatus(UInt32 framebuffer,
                FramebufferTarget target);

            internal delegate void ClampColor(ClampColorTarget target, ClampColorMode clamp);

            internal delegate void Clear(ClearBufferMask mask);

            internal delegate void ClearBufferiv(ClearBuffer buffer, Int32 drawbuffer, Int32[] value);

            internal delegate void ClearBufferuiv(ClearBuffer buffer, Int32 drawbuffer, UInt32[] value);

            internal delegate void ClearBufferfv(ClearBuffer buffer, Int32 drawbuffer, Single[] value);

            internal delegate void ClearBufferfi(ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil);

            internal delegate void ClearNamedFramebufferiv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
                Int32[] value);

            internal delegate void ClearNamedFramebufferuiv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
                UInt32[] value);

            internal delegate void ClearNamedFramebufferfv(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
                Single[] value);

            internal delegate void ClearNamedFramebufferfi(UInt32 framebuffer, ClearBuffer buffer, Int32 drawbuffer,
                Single depth, Int32 stencil);

            internal delegate void ClearBufferData(BufferTarget target, SizedInternalFormat internalFormat,
                PixelInternalFormat format, PixelType type, IntPtr data);

            internal delegate void ClearNamedBufferData(UInt32 buffer, SizedInternalFormat internalFormat,
                PixelInternalFormat format, PixelType type, IntPtr data);

            internal delegate void ClearBufferSubData(BufferTarget target, SizedInternalFormat internalFormat,
                IntPtr offset, IntPtr size, PixelInternalFormat format, PixelType type, IntPtr data);

            internal delegate void ClearNamedBufferSubData(UInt32 buffer, SizedInternalFormat internalFormat,
                IntPtr offset, Int32 size, PixelInternalFormat format, PixelType type, IntPtr data);

            internal delegate void ClearColor(Single red, Single green, Single blue, Single alpha);

            internal delegate void ClearDepth(Double depth);

            internal delegate void ClearDepthf(Single depth);

            internal delegate void ClearStencil(Int32 s);

            internal delegate void ClearTexImage(UInt32 texture, Int32 level, PixelInternalFormat format,
                PixelType type, IntPtr data);

            internal delegate void ClearTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelInternalFormat format, PixelType type,
                IntPtr data);

            internal delegate ArbSync ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);

            internal delegate void ClipControl(ClipControlOrigin origin, ClipControlDepth depth);

            internal delegate void ColorMask(Boolean red, Boolean green, Boolean blue, Boolean alpha);

            internal delegate void ColorMaski(UInt32 buf, Boolean red, Boolean green, Boolean blue, Boolean alpha);

            internal delegate void CompileShader(UInt32 shader);

            internal delegate void CompressedTexImage1D(TextureTarget target, Int32 level,
                PixelInternalFormat internalFormat, Int32 width, Int32 border, Int32 imageSize, IntPtr data);

            internal delegate void CompressedTexImage2D(TextureTarget target, Int32 level,
                PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 border, Int32 imageSize,
                IntPtr data);

            internal delegate void CompressedTexImage3D(TextureTarget target, Int32 level,
                PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth, Int32 border,
                Int32 imageSize, IntPtr data);

            internal delegate void CompressedTexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset,
                Int32 width, PixelFormat format, Int32 imageSize, IntPtr data);

            internal delegate void CompressedTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width,
                PixelInternalFormat format, Int32 imageSize, IntPtr data);

            internal delegate void CompressedTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset,
                Int32 yoffset, Int32 width, Int32 height, PixelFormat format, Int32 imageSize, IntPtr data);

            internal delegate void CompressedTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset,
                Int32 yoffset, Int32 width, Int32 height, PixelInternalFormat format, Int32 imageSize, IntPtr data);

            internal delegate void CompressedTexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset,
                Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format,
                Int32 imageSize, IntPtr data);

            internal delegate void CompressedTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset,
                Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelInternalFormat format,
                Int32 imageSize, IntPtr data);

            internal delegate void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget,
                IntPtr readOffset, IntPtr writeOffset, IntPtr size);

            internal delegate void CopyNamedBufferSubData(UInt32 readBuffer, UInt32 writeBuffer, IntPtr readOffset,
                IntPtr writeOffset, Int32 size);

            internal delegate void CopyImageSubData(UInt32 srcName, BufferTarget srcTarget, Int32 srcLevel, Int32 srcX,
                Int32 srcY, Int32 srcZ, UInt32 dstName, BufferTarget dstTarget, Int32 dstLevel, Int32 dstX, Int32 dstY,
                Int32 dstZ, Int32 srcWidth, Int32 srcHeight, Int32 srcDepth);

            internal delegate void CopyTexImage1D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
                Int32 x, Int32 y, Int32 width, Int32 border);

            internal delegate void CopyTexImage2D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
                Int32 x, Int32 y, Int32 width, Int32 height, Int32 border);

            internal delegate void CopyTexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y,
                Int32 width);

            internal delegate void CopyTextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 x, Int32 y,
                Int32 width);

            internal delegate void CopyTexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void CopyTextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void CopyTexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void CopyTextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void CreateBuffers(Int32 n, UInt32[] buffers);

            internal delegate void CreateFramebuffers(Int32 n, UInt32[] ids);

            internal delegate UInt32 CreateProgram();

            internal delegate void CreateProgramPipelines(Int32 n, UInt32[] pipelines);

            internal delegate void CreateQueries(QueryTarget target, Int32 n, UInt32[] ids);

            internal delegate void CreateRenderbuffers(Int32 n, UInt32[] renderbuffers);

            internal delegate void CreateSamplers(Int32 n, UInt32[] samplers);

            internal delegate UInt32 CreateShader(ShaderType shaderType);

            internal delegate UInt32 CreateShaderProgramv(ShaderType type, Int32 count, String strings);

            internal delegate void CreateTextures(TextureTarget target, Int32 n, UInt32[] textures);

            internal delegate void CreateTransformFeedbacks(Int32 n, UInt32[] ids);

            internal delegate void CreateVertexArrays(Int32 n, UInt32[] arrays);

            internal delegate void CullFace(CullFaceMode mode);

            internal delegate void DeleteBuffers(Int32 n, UInt32[] buffers);

            internal delegate void DeleteFramebuffers(Int32 n, UInt32[] framebuffers);

            internal delegate void DeleteProgram(UInt32 program);

            internal delegate void DeleteProgramPipelines(Int32 n, UInt32[] pipelines);

            internal delegate void DeleteQueries(Int32 n, UInt32[] ids);

            internal delegate void DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers);

            internal delegate void DeleteSamplers(Int32 n, UInt32[] samplers);

            internal delegate void DeleteShader(UInt32 shader);

            internal delegate void DeleteSync(IntPtr sync);

            internal delegate void DeleteTextures(Int32 n, UInt32[] textures);

            internal delegate void DeleteTransformFeedbacks(Int32 n, UInt32[] ids);

            internal delegate void DeleteVertexArrays(Int32 n, UInt32[] arrays);

            internal delegate void DepthFunc(DepthFunction func);

            internal delegate void DepthMask(Boolean flag);

            internal delegate void DepthRange(Double nearVal, Double farVal);

            internal delegate void DepthRangef(Single nearVal, Single farVal);

            internal delegate void DepthRangeArrayv(UInt32 first, Int32 count, Double[] v);

            internal delegate void DepthRangeIndexed(UInt32 index, Double nearVal, Double farVal);

            internal delegate void DetachShader(UInt32 program, UInt32 shader);

            internal delegate void DispatchCompute(UInt32 num_groups_x, UInt32 num_groups_y, UInt32 num_groups_z);

            internal delegate void DispatchComputeIndirect(IntPtr indirect);

            internal delegate void DrawArrays(BeginMode mode, Int32 first, Int32 count);

            internal delegate void DrawArraysIndirect(BeginMode mode, IntPtr indirect);

            internal delegate void DrawArraysInstanced(BeginMode mode, Int32 first, Int32 count, Int32 primcount);

            internal delegate void DrawArraysInstancedBaseInstance(BeginMode mode, Int32 first, Int32 count,
                Int32 primcount, UInt32 baseinstance);

            internal delegate void DrawBuffer(DrawBufferMode buf);

            internal delegate void NamedFramebufferDrawBuffer(UInt32 framebuffer, DrawBufferMode buf);

            internal delegate void DrawBuffers(Int32 n, DrawBuffersEnum[] bufs);

            internal delegate void NamedFramebufferDrawBuffers(UInt32 framebuffer, Int32 n, DrawBufferMode[] bufs);

            internal delegate void DrawElements(BeginMode mode, Int32 count, DrawElementsType type, IntPtr indices);

            internal delegate void DrawElementsBaseVertex(BeginMode mode, Int32 count, DrawElementsType type,
                IntPtr indices, Int32 basevertex);

            internal delegate void DrawElementsIndirect(BeginMode mode, DrawElementsType type, IntPtr indirect);

            internal delegate void DrawElementsInstanced(BeginMode mode, Int32 count, DrawElementsType type,
                IntPtr indices, Int32 primcount);

            internal delegate void DrawElementsInstancedBaseInstance(BeginMode mode, Int32 count, DrawElementsType type,
                IntPtr indices, Int32 primcount, UInt32 baseinstance);

            internal delegate void DrawElementsInstancedBaseVertex(BeginMode mode, Int32 count, DrawElementsType type,
                IntPtr indices, Int32 primcount, Int32 basevertex);

            internal delegate void DrawElementsInstancedBaseVertexBaseInstance(BeginMode mode, Int32 count,
                DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex, UInt32 baseinstance);

            internal delegate void DrawRangeElements(BeginMode mode, UInt32 start, UInt32 end, Int32 count,
                DrawElementsType type, IntPtr indices);

            internal delegate void DrawRangeElementsBaseVertex(BeginMode mode, UInt32 start, UInt32 end, Int32 count,
                DrawElementsType type, IntPtr indices, Int32 basevertex);

            internal delegate void DrawTransformFeedback(NvTransformFeedback2 mode, UInt32 id);

            internal delegate void DrawTransformFeedbackInstanced(BeginMode mode, UInt32 id, Int32 primcount);

            internal delegate void DrawTransformFeedbackStream(NvTransformFeedback2 mode, UInt32 id, UInt32 stream);

            internal delegate void DrawTransformFeedbackStreamInstanced(BeginMode mode, UInt32 id, UInt32 stream,
                Int32 primcount);

            internal delegate void Enable(EnableCap cap);

            internal delegate void Disable(EnableCap cap);

            internal delegate void Enablei(EnableCap cap, UInt32 index);

            internal delegate void Disablei(EnableCap cap, UInt32 index);

            internal delegate void EnableVertexAttribArray(UInt32 index);

            internal delegate void DisableVertexAttribArray(UInt32 index);

            internal delegate void EnableVertexArrayAttrib(UInt32 vaobj, UInt32 index);

            internal delegate void DisableVertexArrayAttrib(UInt32 vaobj, UInt32 index);

            internal delegate IntPtr FenceSync(ArbSync condition, UInt32 flags);

            internal delegate void Finish();

            internal delegate void Flush();

            internal delegate void FlushMappedBufferRange(BufferTarget target, IntPtr offset, IntPtr length);

            internal delegate void FlushMappedNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length);

            internal delegate void FramebufferParameteri(FramebufferTarget target, FramebufferPName pname, Int32 param);

            internal delegate void NamedFramebufferParameteri(UInt32 framebuffer, FramebufferPName pname, Int32 param);

            internal delegate void FramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment,
                RenderbufferTarget renderbuffertarget, UInt32 renderbuffer);

            internal delegate void NamedFramebufferRenderbuffer(UInt32 framebuffer, FramebufferAttachment attachment,
                RenderbufferTarget renderbuffertarget, UInt32 renderbuffer);

            internal delegate void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment,
                UInt32 texture, Int32 level);

            internal delegate void FramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment,
                TextureTarget textarget, UInt32 texture, Int32 level);

            internal delegate void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment,
                TextureTarget textarget, UInt32 texture, Int32 level);

            internal delegate void FramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment,
                TextureTarget textarget, UInt32 texture, Int32 level, Int32 layer);

            internal delegate void NamedFramebufferTexture(UInt32 framebuffer, FramebufferAttachment attachment,
                UInt32 texture, Int32 level);

            internal delegate void FramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment,
                UInt32 texture, Int32 level, Int32 layer);

            internal delegate void NamedFramebufferTextureLayer(UInt32 framebuffer, FramebufferAttachment attachment,
                UInt32 texture, Int32 level, Int32 layer);

            internal delegate void FrontFace(FrontFaceDirection mode);

            internal delegate void GenBuffers(Int32 n, [OutAttribute] UInt32[] buffers);

            internal delegate void GenerateMipmap(GenerateMipmapTarget target);

            internal delegate void GenerateTextureMipmap(UInt32 texture);

            internal delegate void GenFramebuffers(Int32 n, [OutAttribute] UInt32[] ids);

            internal delegate void GenProgramPipelines(Int32 n, [OutAttribute] UInt32[] pipelines);

            internal delegate void GenQueries(Int32 n, [OutAttribute] UInt32[] ids);

            internal delegate void GenRenderbuffers(Int32 n, [OutAttribute] UInt32[] renderbuffers);

            internal delegate void GenSamplers(Int32 n, [OutAttribute] UInt32[] samplers);

            internal delegate void GenTextures(Int32 n, [OutAttribute] UInt32[] textures);

            internal delegate void GenTransformFeedbacks(Int32 n, [OutAttribute] UInt32[] ids);

            internal delegate void GenVertexArrays(Int32 n, [OutAttribute] UInt32[] arrays);

            internal delegate void GetBooleanv(GetPName pname, [OutAttribute] Boolean[] data);

            internal delegate void GetDoublev(GetPName pname, [OutAttribute] Double[] data);

            internal delegate void GetFloatv(GetPName pname, [OutAttribute] Single[] data);

            internal delegate void GetIntegerv(GetPName pname, [OutAttribute] Int32[] data);

            internal delegate void GetInteger64v(ArbSync pname, [OutAttribute] Int64[] data);

            internal delegate void GetBooleani_v(GetPName target, UInt32 index, [OutAttribute] Boolean[] data);

            internal delegate void GetIntegeri_v(GetPName target, UInt32 index, [OutAttribute] Int32[] data);

            internal delegate void GetFloati_v(GetPName target, UInt32 index, [OutAttribute] Single[] data);

            internal delegate void GetDoublei_v(GetPName target, UInt32 index, [OutAttribute] Double[] data);

            internal delegate void GetInteger64i_v(GetPName target, UInt32 index, [OutAttribute] Int64[] data);

            internal delegate void GetActiveAtomicCounterBufferiv(UInt32 program, UInt32 bufferIndex,
                AtomicCounterParameterName pname, [OutAttribute] Int32[] @params);

            internal delegate void GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] ActiveAttribType[] type,
                [OutAttribute] StringBuilder name);

            internal delegate void GetActiveSubroutineName(UInt32 program, ShaderType shadertype, UInt32 index,
                Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] StringBuilder name);

            internal delegate void GetActiveSubroutineUniformiv(UInt32 program, ShaderType shadertype, UInt32 index,
                SubroutineParameterName pname, [OutAttribute] Int32[] values);

            internal delegate void GetActiveSubroutineUniformName(UInt32 program, ShaderType shadertype, UInt32 index,
                Int32 bufsize, [OutAttribute] Int32[] length, [OutAttribute] StringBuilder name);

            internal delegate void GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] ActiveUniformType[] type,
                [OutAttribute] StringBuilder name);

            internal delegate void GetActiveUniformBlockiv(UInt32 program, UInt32 uniformBlockIndex,
                ActiveUniformBlockParameter pname, [OutAttribute] Int32[] @params);

            internal delegate void GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] StringBuilder uniformBlockName);

            internal delegate void GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] StringBuilder uniformName);

            internal delegate void GetActiveUniformsiv(UInt32 program, Int32 uniformCount,
                [OutAttribute] UInt32[] uniformIndices, ActiveUniformType pname, [OutAttribute] Int32[] @params);

            internal delegate void GetAttachedShaders(UInt32 program, Int32 maxCount, [OutAttribute] Int32[] count,
                [OutAttribute] UInt32[] shaders);

            internal delegate Int32 GetAttribLocation(UInt32 program, String name);

            internal delegate void GetBufferParameteriv(BufferTarget target, BufferParameterName value,
                [OutAttribute] Int32[] data);

            internal delegate void GetBufferParameteri64v(BufferTarget target, BufferParameterName value,
                [OutAttribute] Int64[] data);

            internal delegate void GetNamedBufferParameteriv(UInt32 buffer, BufferParameterName pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetNamedBufferParameteri64v(UInt32 buffer, BufferParameterName pname,
                [OutAttribute] Int64[] @params);

            internal delegate void GetBufferPointerv(BufferTarget target, BufferPointer pname,
                [OutAttribute] IntPtr @params);

            internal delegate void GetNamedBufferPointerv(UInt32 buffer, BufferPointer pname,
                [OutAttribute] IntPtr @params);

            internal delegate void GetBufferSubData(BufferTarget target, IntPtr offset, IntPtr size,
                [OutAttribute] IntPtr data);

            internal delegate void GetNamedBufferSubData(UInt32 buffer, IntPtr offset, Int32 size,
                [OutAttribute] IntPtr data);

            internal delegate void GetCompressedTexImage(TextureTarget target, Int32 level,
                [OutAttribute] IntPtr pixels);

            internal delegate void GetnCompressedTexImage(TextureTarget target, Int32 level, Int32 bufSize,
                [OutAttribute] IntPtr pixels);

            internal delegate void GetCompressedTextureImage(UInt32 texture, Int32 level, Int32 bufSize,
                [OutAttribute] IntPtr pixels);

            internal delegate void GetCompressedTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset,
                Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, Int32 bufSize,
                [OutAttribute] IntPtr pixels);

            internal delegate ErrorCode GetError();

            internal delegate Int32 GetFragDataIndex(UInt32 program, String name);

            internal delegate Int32 GetFragDataLocation(UInt32 program, String name);

            internal delegate void GetFramebufferAttachmentParameteriv(FramebufferTarget target,
                FramebufferAttachment attachment, FramebufferParameterName pname, [OutAttribute] Int32[] @params);

            internal delegate void GetNamedFramebufferAttachmentParameteriv(UInt32 framebuffer,
                FramebufferAttachment attachment, FramebufferParameterName pname, [OutAttribute] Int32[] @params);

            internal delegate void GetFramebufferParameteriv(FramebufferTarget target, FramebufferPName pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetNamedFramebufferParameteriv(UInt32 framebuffer, FramebufferPName pname,
                [OutAttribute] Int32[] param);

            internal delegate GraphicResetStatus GetGraphicsResetStatus();

            internal delegate void GetInternalformativ(TextureTarget target, PixelInternalFormat internalFormat,
                GetPName pname, Int32 bufSize, [OutAttribute] Int32[] @params);

            internal delegate void GetInternalformati64v(TextureTarget target, PixelInternalFormat internalFormat,
                GetPName pname, Int32 bufSize, [OutAttribute] Int64[] @params);

            internal delegate void GetMultisamplefv(GetMultisamplePName pname, UInt32 index,
                [OutAttribute] Single[] val);

            internal delegate void GetObjectLabel(Engine.OpenGL.Vendor.OpenGL.Core.ObjectLabel identifier, UInt32 name,
                Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] StringBuilder label);

            internal delegate void GetObjectPtrLabel([OutAttribute] IntPtr ptr, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] StringBuilder label);

            internal delegate void GetPointerv(GetPointerParameter pname, [OutAttribute] IntPtr @params);

            internal delegate void GetProgramiv(UInt32 program, ProgramParameter pname, [OutAttribute] Int32[] @params);

            internal delegate void GetProgramBinary(UInt32 program, Int32 bufsize, [OutAttribute] Int32[] length,
                [OutAttribute] Int32[] binaryFormat, [OutAttribute] IntPtr binary);

            internal delegate void GetProgramInfoLog(UInt32 program, Int32 maxLength, [OutAttribute] Int32[] length,
                [OutAttribute] StringBuilder infoLog);

            internal delegate void GetProgramInterfaceiv(UInt32 program, ProgramInterface programInterface,
                ProgramInterfaceParameterName pname, [OutAttribute] Int32[] @params);

            internal delegate void GetProgramPipelineiv(UInt32 pipeline, Int32 pname, [OutAttribute] Int32[] @params);

            internal delegate void GetProgramPipelineInfoLog(UInt32 pipeline, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] StringBuilder infoLog);

            internal delegate void GetProgramResourceiv(UInt32 program, ProgramInterface programInterface, UInt32 index,
                Int32 propCount, [OutAttribute] ProgramResourceParameterName[] props, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] Int32[] @params);

            internal delegate UInt32 GetProgramResourceIndex(UInt32 program, ProgramInterface programInterface,
                String name);

            internal delegate Int32 GetProgramResourceLocation(UInt32 program, ProgramInterface programInterface,
                String name);

            internal delegate Int32 GetProgramResourceLocationIndex(UInt32 program, ProgramInterface programInterface,
                String name);

            internal delegate void GetProgramResourceName(UInt32 program, ProgramInterface programInterface,
                UInt32 index, Int32 bufSize, [OutAttribute] Int32[] length, [OutAttribute] StringBuilder name);

            internal delegate void GetProgramStageiv(UInt32 program, ShaderType shadertype,
                ProgramStageParameterName pname, [OutAttribute] Int32[] values);

            internal delegate void GetQueryIndexediv(QueryTarget target, UInt32 index, GetQueryParam pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetQueryiv(QueryTarget target, GetQueryParam pname, [OutAttribute] Int32[] @params);

            internal delegate void GetQueryObjectiv(UInt32 id, GetQueryObjectParam pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetQueryObjectuiv(UInt32 id, GetQueryObjectParam pname,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetQueryObjecti64v(UInt32 id, GetQueryObjectParam pname,
                [OutAttribute] Int64[] @params);

            internal delegate void GetQueryObjectui64v(UInt32 id, GetQueryObjectParam pname,
                [OutAttribute] UInt64[] @params);

            internal delegate void GetRenderbufferParameteriv(RenderbufferTarget target,
                RenderbufferParameterName pname, [OutAttribute] Int32[] @params);

            internal delegate void GetNamedRenderbufferParameteriv(UInt32 renderbuffer, RenderbufferParameterName pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetSamplerParameterfv(UInt32 sampler, TextureParameterName pname,
                [OutAttribute] Single[] @params);

            internal delegate void GetSamplerParameteriv(UInt32 sampler, TextureParameterName pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetSamplerParameterIiv(UInt32 sampler, TextureParameterName pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetSamplerParameterIuiv(UInt32 sampler, TextureParameterName pname,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetShaderiv(UInt32 shader, ShaderParameter pname, [OutAttribute] Int32[] @params);

            internal delegate void GetShaderInfoLog(UInt32 shader, Int32 maxLength, [OutAttribute] Int32[] length,
                [OutAttribute] StringBuilder infoLog);

            internal delegate void GetShaderPrecisionFormat(ShaderType shaderType, Int32 precisionType,
                [OutAttribute] Int32[] range, [OutAttribute] Int32[] precision);

            internal delegate void GetShaderSource(UInt32 shader, Int32 bufSize, [OutAttribute] Int32[] length,
                [OutAttribute] StringBuilder source);

            internal delegate IntPtr GetString(StringName name);

            internal delegate IntPtr GetStringi(StringName name, UInt32 index);

            internal delegate UInt32 GetSubroutineIndex(UInt32 program, ShaderType shadertype, String name);

            internal delegate Int32 GetSubroutineUniformLocation(UInt32 program, ShaderType shadertype, String name);

            internal delegate void GetSynciv(IntPtr sync, ArbSync pname, Int32 bufSize, [OutAttribute] Int32[] length,
                [OutAttribute] Int32[] values);

            internal delegate void GetTexImage(TextureTarget target, Int32 level, PixelFormat format, PixelType type,
                [OutAttribute] IntPtr pixels);

            internal delegate void GetnTexImage(TextureTarget target, Int32 level, PixelFormat format, PixelType type,
                Int32 bufSize, [OutAttribute] IntPtr pixels);

            internal delegate void GetTextureImage(UInt32 texture, Int32 level, PixelFormat format, PixelType type,
                Int32 bufSize, [OutAttribute] IntPtr pixels);

            internal delegate void GetTexLevelParameterfv(GetPName target, Int32 level, GetTextureLevelParameter pname,
                [OutAttribute] Single[] @params);

            internal delegate void GetTexLevelParameteriv(GetPName target, Int32 level, GetTextureLevelParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetTextureLevelParameterfv(UInt32 texture, Int32 level,
                GetTextureLevelParameter pname, [OutAttribute] Single[] @params);

            internal delegate void GetTextureLevelParameteriv(UInt32 texture, Int32 level,
                GetTextureLevelParameter pname, [OutAttribute] Int32[] @params);

            internal delegate void GetTexParameterfv(TextureTarget target, GetTextureParameter pname,
                [OutAttribute] Single[] @params);

            internal delegate void GetTexParameteriv(TextureTarget target, GetTextureParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetTexParameterIiv(TextureTarget target, GetTextureParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetTexParameterIuiv(TextureTarget target, GetTextureParameter pname,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetTextureParameterfv(UInt32 texture, GetTextureParameter pname,
                [OutAttribute] Single[] @params);

            internal delegate void GetTextureParameteriv(UInt32 texture, GetTextureParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetTextureParameterIiv(UInt32 texture, GetTextureParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetTextureParameterIuiv(UInt32 texture, GetTextureParameter pname,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetTextureSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type,
                Int32 bufSize, [OutAttribute] IntPtr pixels);

            internal delegate void GetTransformFeedbackiv(UInt32 xfb, TransformFeedbackParameterName pname,
                [OutAttribute] Int32[] param);

            internal delegate void GetTransformFeedbacki_v(UInt32 xfb, TransformFeedbackParameterName pname,
                UInt32 index, [OutAttribute] Int32[] param);

            internal delegate void GetTransformFeedbacki64_v(UInt32 xfb, TransformFeedbackParameterName pname,
                UInt32 index, [OutAttribute] Int64[] param);

            internal delegate void GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize,
                [OutAttribute] Int32[] length, [OutAttribute] Int32[] size, [OutAttribute] ActiveAttribType[] type,
                [OutAttribute] StringBuilder name);

            internal delegate void GetUniformfv(UInt32 program, Int32 location, [OutAttribute] Single[] @params);

            internal delegate void GetUniformiv(UInt32 program, Int32 location, [OutAttribute] Int32[] @params);

            internal delegate void GetUniformuiv(UInt32 program, Int32 location, [OutAttribute] UInt32[] @params);

            internal delegate void GetUniformdv(UInt32 program, Int32 location, [OutAttribute] Double[] @params);

            internal delegate void GetnUniformfv(UInt32 program, Int32 location, Int32 bufSize,
                [OutAttribute] Single[] @params);

            internal delegate void GetnUniformiv(UInt32 program, Int32 location, Int32 bufSize,
                [OutAttribute] Int32[] @params);

            internal delegate void GetnUniformuiv(UInt32 program, Int32 location, Int32 bufSize,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetnUniformdv(UInt32 program, Int32 location, Int32 bufSize,
                [OutAttribute] Double[] @params);

            internal delegate UInt32 GetUniformBlockIndex(UInt32 program, String uniformBlockName);

            internal delegate void GetUniformIndices(UInt32 program, Int32 uniformCount, String uniformNames,
                [OutAttribute] UInt32[] uniformIndices);

            internal delegate Int32 GetUniformLocation(UInt32 program, String name);

            internal delegate void GetUniformSubroutineuiv(ShaderType shadertype, Int32 location,
                [OutAttribute] UInt32[] values);

            internal delegate void GetVertexArrayIndexed64iv(UInt32 vaobj, UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Int64[] param);

            internal delegate void GetVertexArrayIndexediv(UInt32 vaobj, UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Int32[] param);

            internal delegate void GetVertexArrayiv(UInt32 vaobj, VertexAttribParameter pname,
                [OutAttribute] Int32[] param);

            internal delegate void GetVertexAttribdv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Double[] @params);

            internal delegate void GetVertexAttribfv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Single[] @params);

            internal delegate void GetVertexAttribiv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetVertexAttribIiv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Int32[] @params);

            internal delegate void GetVertexAttribIuiv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] UInt32[] @params);

            internal delegate void GetVertexAttribLdv(UInt32 index, VertexAttribParameter pname,
                [OutAttribute] Double[] @params);

            internal delegate void GetVertexAttribPointerv(UInt32 index, VertexAttribPointerParameter pname,
                [OutAttribute] IntPtr pointer);

            internal delegate void Hint(HintTarget target, HintMode mode);

            internal delegate void InvalidateBufferData(UInt32 buffer);

            internal delegate void InvalidateBufferSubData(UInt32 buffer, IntPtr offset, IntPtr length);

            internal delegate void InvalidateFramebuffer(FramebufferTarget target, Int32 numAttachments,
                FramebufferAttachment[] attachments);

            internal delegate void InvalidateNamedFramebufferData(UInt32 framebuffer, Int32 numAttachments,
                FramebufferAttachment[] attachments);

            internal delegate void InvalidateSubFramebuffer(FramebufferTarget target, Int32 numAttachments,
                FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void InvalidateNamedFramebufferSubData(UInt32 framebuffer, Int32 numAttachments,
                FramebufferAttachment[] attachments, Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void InvalidateTexImage(UInt32 texture, Int32 level);

            internal delegate void InvalidateTexSubImage(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 width, Int32 height, Int32 depth);

            internal delegate Boolean IsBuffer(UInt32 buffer);

            internal delegate Boolean IsEnabled(EnableCap cap);

            internal delegate Boolean IsEnabledi(EnableCap cap, UInt32 index);

            internal delegate Boolean IsFramebuffer(UInt32 framebuffer);

            internal delegate Boolean IsProgram(UInt32 program);

            internal delegate Boolean IsProgramPipeline(UInt32 pipeline);

            internal delegate Boolean IsQuery(UInt32 id);

            internal delegate Boolean IsRenderbuffer(UInt32 renderbuffer);

            internal delegate Boolean IsSampler(UInt32 id);

            internal delegate Boolean IsShader(UInt32 shader);

            internal delegate Boolean IsSync(IntPtr sync);

            internal delegate Boolean IsTexture(UInt32 texture);

            internal delegate Boolean IsTransformFeedback(UInt32 id);

            internal delegate Boolean IsVertexArray(UInt32 array);

            internal delegate void LineWidth(Single width);

            internal delegate void LinkProgram(UInt32 program);

            internal delegate void LogicOp(Engine.OpenGL.Vendor.OpenGL.Core.LogicOp opcode);

            internal delegate IntPtr MapBuffer(BufferTarget target, BufferAccess access);

            internal delegate IntPtr MapNamedBuffer(UInt32 buffer, BufferAccess access);

            internal delegate IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length,
                BufferAccessMask access);

            internal delegate IntPtr MapNamedBufferRange(UInt32 buffer, IntPtr offset, Int32 length, UInt32 access);

            internal delegate void MemoryBarrier(UInt32 barriers);

            internal delegate void MemoryBarrierByRegion(UInt32 barriers);

            internal delegate void MinSampleShading(Single value);

            internal delegate void MultiDrawArrays(BeginMode mode, Int32[] first, Int32[] count, Int32 drawcount);

            internal delegate void MultiDrawArraysIndirect(BeginMode mode, IntPtr indirect, Int32 drawcount,
                Int32 stride);

            internal delegate void MultiDrawElements(BeginMode mode, Int32[] count, DrawElementsType type,
                IntPtr indices, Int32 drawcount);

            internal delegate void MultiDrawElementsBaseVertex(BeginMode mode, Int32[] count, DrawElementsType type,
                IntPtr indices, Int32 drawcount, Int32[] basevertex);

            internal delegate void MultiDrawElementsIndirect(BeginMode mode, DrawElementsType type, IntPtr indirect,
                Int32 drawcount, Int32 stride);

            internal delegate void ObjectLabel(Engine.OpenGL.Vendor.OpenGL.Core.ObjectLabel identifier, UInt32 name,
                Int32 length, String label);

            internal delegate void ObjectPtrLabel(IntPtr ptr, Int32 length, String label);

            internal delegate void PatchParameteri(Int32 pname, Int32 value);

            internal delegate void PatchParameterfv(Int32 pname, Single[] values);

            internal delegate void PixelStoref(PixelStoreParameter pname, Single param);

            internal delegate void PixelStorei(PixelStoreParameter pname, Int32 param);

            internal delegate void PointParameterf(PointParameterName pname, Single param);

            internal delegate void PointParameteri(PointParameterName pname, Int32 param);

            internal delegate void PointParameterfv(PointParameterName pname, Single[] @params);

            internal delegate void PointParameteriv(PointParameterName pname, Int32[] @params);

            internal delegate void PointSize(Single size);

            internal delegate void PolygonMode(MaterialFace face, Engine.OpenGL.Vendor.OpenGL.Core.PolygonMode mode);

            internal delegate void PolygonOffset(Single factor, Single units);

            internal delegate void PrimitiveRestartIndex(UInt32 index);

            internal delegate void ProgramBinary(UInt32 program, Int32 binaryFormat, IntPtr binary, Int32 length);

            internal delegate void ProgramParameteri(UInt32 program, Version32 pname, Int32 value);

            internal delegate void ProgramUniform1f(UInt32 program, Int32 location, Single v0);

            internal delegate void ProgramUniform2f(UInt32 program, Int32 location, Single v0, Single v1);

            internal delegate void ProgramUniform3f(UInt32 program, Int32 location, Single v0, Single v1, Single v2);

            internal delegate void ProgramUniform4f(UInt32 program, Int32 location, Single v0, Single v1, Single v2,
                Single v3);

            internal delegate void ProgramUniform1i(UInt32 program, Int32 location, Int32 v0);

            internal delegate void ProgramUniform2i(UInt32 program, Int32 location, Int32 v0, Int32 v1);

            internal delegate void ProgramUniform3i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2);

            internal delegate void ProgramUniform4i(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2,
                Int32 v3);

            internal delegate void ProgramUniform1ui(UInt32 program, Int32 location, UInt32 v0);

            internal delegate void ProgramUniform2ui(UInt32 program, Int32 location, Int32 v0, UInt32 v1);

            internal delegate void ProgramUniform3ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, UInt32 v2);

            internal delegate void ProgramUniform4ui(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2,
                UInt32 v3);

            internal delegate void ProgramUniform1fv(UInt32 program, Int32 location, Int32 count, Single[] value);

            internal delegate void ProgramUniform2fv(UInt32 program, Int32 location, Int32 count, Single[] value);

            internal delegate void ProgramUniform3fv(UInt32 program, Int32 location, Int32 count, Single[] value);

            internal delegate void ProgramUniform4fv(UInt32 program, Int32 location, Int32 count, Single[] value);

            internal delegate void ProgramUniform1iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

            internal delegate void ProgramUniform2iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

            internal delegate void ProgramUniform3iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

            internal delegate void ProgramUniform4iv(UInt32 program, Int32 location, Int32 count, Int32[] value);

            internal delegate void ProgramUniform1uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

            internal delegate void ProgramUniform2uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

            internal delegate void ProgramUniform3uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

            internal delegate void ProgramUniform4uiv(UInt32 program, Int32 location, Int32 count, UInt32[] value);

            internal delegate void ProgramUniformMatrix2fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix3fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix4fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix2x3fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix3x2fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix2x4fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix4x2fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix3x4fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProgramUniformMatrix4x3fv(UInt32 program, Int32 location, Int32 count,
                Boolean transpose, Single[] value);

            internal delegate void ProvokingVertex(ProvokingVertexMode provokeMode);

            internal delegate void QueryCounter(UInt32 id, QueryTarget target);

            internal delegate void ReadBuffer(ReadBufferMode mode);

            internal delegate void NamedFramebufferReadBuffer(ReadBufferMode framebuffer, BeginMode mode);

            internal delegate void ReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format,
                PixelType type, Int32[] data);

            internal delegate void ReadnPixels(Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format,
                PixelType type, Int32 bufSize, Int32[] data);

            internal delegate void RenderbufferStorage(RenderbufferTarget target,
                Engine.OpenGL.Vendor.OpenGL.Core.RenderbufferStorage internalFormat, Int32 width, Int32 height);

            internal delegate void NamedRenderbufferStorage(UInt32 renderbuffer,
                Engine.OpenGL.Vendor.OpenGL.Core.RenderbufferStorage internalFormat, Int32 width, Int32 height);

            internal delegate void RenderbufferStorageMultisample(RenderbufferTarget target, Int32 samples,
                Engine.OpenGL.Vendor.OpenGL.Core.RenderbufferStorage internalFormat, Int32 width, Int32 height);

            internal delegate void NamedRenderbufferStorageMultisample(UInt32 renderbuffer, Int32 samples,
                Engine.OpenGL.Vendor.OpenGL.Core.RenderbufferStorage internalFormat, Int32 width, Int32 height);

            internal delegate void SampleCoverage(Single value, Boolean invert);

            internal delegate void SampleMaski(UInt32 maskNumber, UInt32 mask);

            internal delegate void SamplerParameterf(UInt32 sampler, TextureParameterName pname, Single param);

            internal delegate void SamplerParameteri(UInt32 sampler, TextureParameterName pname, Int32 param);

            internal delegate void SamplerParameterfv(UInt32 sampler, TextureParameterName pname, Single[] @params);

            internal delegate void SamplerParameteriv(UInt32 sampler, TextureParameterName pname, Int32[] @params);

            internal delegate void SamplerParameterIiv(UInt32 sampler, TextureParameterName pname, Int32[] @params);

            internal delegate void SamplerParameterIuiv(UInt32 sampler, TextureParameterName pname, UInt32[] @params);

            internal delegate void Scissor(Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void ScissorArrayv(UInt32 first, Int32 count, Int32[] v);

            internal delegate void ScissorIndexed(UInt32 index, Int32 left, Int32 bottom, Int32 width, Int32 height);

            internal delegate void ScissorIndexedv(UInt32 index, Int32[] v);

            internal delegate void ShaderBinary(Int32 count, UInt32[] shaders, Int32 binaryFormat, IntPtr binary,
                Int32 length);

            internal delegate void ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32[] length);

            internal delegate void ShaderStorageBlockBinding(UInt32 program, UInt32 storageBlockIndex,
                UInt32 storageBlockBinding);

            internal delegate void StencilFunc(StencilFunction func, Int32 @ref, UInt32 mask);

            internal delegate void StencilFuncSeparate(StencilFace face, StencilFunction func, Int32 @ref, UInt32 mask);

            internal delegate void StencilMask(UInt32 mask);

            internal delegate void StencilMaskSeparate(StencilFace face, UInt32 mask);

            internal delegate void StencilOp(Engine.OpenGL.Vendor.OpenGL.Core.StencilOp sfail,
                Engine.OpenGL.Vendor.OpenGL.Core.StencilOp dpfail, Engine.OpenGL.Vendor.OpenGL.Core.StencilOp dppass);

            internal delegate void StencilOpSeparate(StencilFace face, Engine.OpenGL.Vendor.OpenGL.Core.StencilOp sfail,
                Engine.OpenGL.Vendor.OpenGL.Core.StencilOp dpfail, Engine.OpenGL.Vendor.OpenGL.Core.StencilOp dppass);

            internal delegate void TexBuffer(TextureBufferTarget target, SizedInternalFormat internalFormat,
                UInt32 buffer);

            internal delegate void TextureBuffer(UInt32 texture, SizedInternalFormat internalFormat, UInt32 buffer);

            internal delegate void TexBufferRange(BufferTarget target, SizedInternalFormat internalFormat,
                UInt32 buffer, IntPtr offset, IntPtr size);

            internal delegate void TextureBufferRange(UInt32 texture, SizedInternalFormat internalFormat, UInt32 buffer,
                IntPtr offset, Int32 size);

            internal delegate void TexImage1D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
                Int32 width, Int32 border, PixelFormat format, PixelType type, IntPtr data);

            internal delegate void TexImage2D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
                Int32 width, Int32 height, Int32 border, PixelFormat format, PixelType type, IntPtr data);

            internal delegate void TexImage2DMultisample(TextureTargetMultisample target, Int32 samples,
                PixelInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

            internal delegate void TexImage3D(TextureTarget target, Int32 level, PixelInternalFormat internalFormat,
                Int32 width, Int32 height, Int32 depth, Int32 border, PixelFormat format, PixelType type, IntPtr data);

            internal delegate void TexImage3DMultisample(TextureTargetMultisample target, Int32 samples,
                PixelInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth,
                Boolean fixedsamplelocations);

            internal delegate void TexParameterf(TextureTarget target, TextureParameterName pname, Single param);

            internal delegate void TexParameteri(TextureTarget target, TextureParameterName pname, Int32 param);

            internal delegate void TextureParameterf(UInt32 texture, TextureParameterName pname, Single param);

            internal delegate void TextureParameteri(UInt32 texture, TextureParameterName pname, Int32 param);

            internal delegate void TexParameterfv(TextureTarget target, TextureParameterName pname, Single[] @params);

            internal delegate void TexParameteriv(TextureTarget target, TextureParameterName pname, Int32[] @params);

            internal delegate void TexParameterIiv(TextureTarget target, TextureParameterName pname, Int32[] @params);

            internal delegate void TexParameterIuiv(TextureTarget target, TextureParameterName pname, UInt32[] @params);

            internal delegate void TextureParameterfv(UInt32 texture, TextureParameter pname, Single[] paramtexture);

            internal delegate void TextureParameteriv(UInt32 texture, TextureParameter pname, Int32[] param);

            internal delegate void TextureParameterIiv(UInt32 texture, TextureParameter pname, Int32[] @params);

            internal delegate void TextureParameterIuiv(UInt32 texture, TextureParameter pname, UInt32[] @params);

            internal delegate void TexStorage1D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width);

            internal delegate void TextureStorage1D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width);

            internal delegate void TexStorage2D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width, Int32 height);

            internal delegate void TextureStorage2D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width, Int32 height);

            internal delegate void TexStorage2DMultisample(TextureTarget target, Int32 samples,
                SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

            internal delegate void TextureStorage2DMultisample(UInt32 texture, Int32 samples,
                SizedInternalFormat internalFormat, Int32 width, Int32 height, Boolean fixedsamplelocations);

            internal delegate void TexStorage3D(TextureTarget target, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width, Int32 height, Int32 depth);

            internal delegate void TextureStorage3D(UInt32 texture, Int32 levels, SizedInternalFormat internalFormat,
                Int32 width, Int32 height, Int32 depth);

            internal delegate void TexStorage3DMultisample(TextureTarget target, Int32 samples,
                SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth,
                Boolean fixedsamplelocations);

            internal delegate void TextureStorage3DMultisample(UInt32 texture, Int32 samples,
                SizedInternalFormat internalFormat, Int32 width, Int32 height, Int32 depth,
                Boolean fixedsamplelocations);

            internal delegate void TexSubImage1D(TextureTarget target, Int32 level, Int32 xoffset, Int32 width,
                PixelFormat format, PixelType type, IntPtr pixels);

            internal delegate void TextureSubImage1D(UInt32 texture, Int32 level, Int32 xoffset, Int32 width,
                PixelFormat format, PixelType type, IntPtr pixels);

            internal delegate void TexSubImage2D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 width, Int32 height, PixelFormat format, PixelType type, IntPtr pixels);

            internal delegate void TextureSubImage2D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 width, Int32 height, PixelFormat format, PixelType type, IntPtr pixels);

            internal delegate void TexSubImage3D(TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type,
                IntPtr pixels);

            internal delegate void TextureSubImage3D(UInt32 texture, Int32 level, Int32 xoffset, Int32 yoffset,
                Int32 zoffset, Int32 width, Int32 height, Int32 depth, PixelFormat format, PixelType type,
                IntPtr pixels);

            internal delegate void TextureBarrier();

            internal delegate void TextureView(UInt32 texture, TextureTarget target, UInt32 origtexture,
                PixelInternalFormat internalFormat, UInt32 minlevel, UInt32 numlevels, UInt32 minlayer,
                UInt32 numlayers);

            internal delegate void TransformFeedbackBufferBase(UInt32 xfb, UInt32 index, UInt32 buffer);

            internal delegate void TransformFeedbackBufferRange(UInt32 xfb, UInt32 index, UInt32 buffer, IntPtr offset,
                Int32 size);

            internal delegate void TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings,
                TransformFeedbackMode bufferMode);

            internal delegate void Uniform1f(Int32 location, Single v0);

            internal delegate void Uniform2f(Int32 location, Single v0, Single v1);

            internal delegate void Uniform3f(Int32 location, Single v0, Single v1, Single v2);

            internal delegate void Uniform4f(Int32 location, Single v0, Single v1, Single v2, Single v3);

            internal delegate void Uniform1i(Int32 location, Int32 v0);

            internal delegate void Uniform2i(Int32 location, Int32 v0, Int32 v1);

            internal delegate void Uniform3i(Int32 location, Int32 v0, Int32 v1, Int32 v2);

            internal delegate void Uniform4i(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3);

            internal delegate void Uniform1ui(Int32 location, UInt32 v0);

            internal delegate void Uniform2ui(Int32 location, UInt32 v0, UInt32 v1);

            internal delegate void Uniform3ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2);

            internal delegate void Uniform4ui(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);

            internal delegate void Uniform1fv(Int32 location, Int32 count, Single[] value);

            internal delegate void Uniform2fv(Int32 location, Int32 count, Single[] value);

            internal delegate void Uniform3fv(Int32 location, Int32 count, Single[] value);

            internal delegate void Uniform4fv(Int32 location, Int32 count, Single[] value);

            internal delegate void Uniform1iv(Int32 location, Int32 count, Int32[] value);

            internal delegate void Uniform2iv(Int32 location, Int32 count, Int32[] value);

            internal delegate void Uniform3iv(Int32 location, Int32 count, Int32[] value);

            internal delegate void Uniform4iv(Int32 location, Int32 count, Int32[] value);

            internal delegate void Uniform1uiv(Int32 location, Int32 count, UInt32[] value);

            internal delegate void Uniform2uiv(Int32 location, Int32 count, UInt32[] value);

            internal delegate void Uniform3uiv(Int32 location, Int32 count, UInt32[] value);

            internal delegate void Uniform4uiv(Int32 location, Int32 count, UInt32[] value);

            internal delegate void UniformMatrix2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix2x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix3x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix2x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix4x2fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix3x4fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformMatrix4x3fv(Int32 location, Int32 count, Boolean transpose, Single[] value);

            internal delegate void UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex,
                UInt32 uniformBlockBinding);

            internal delegate void UniformSubroutinesuiv(ShaderType shadertype, Int32 count, UInt32[] indices);

            internal delegate Boolean UnmapBuffer(BufferTarget target);

            internal delegate Boolean UnmapNamedBuffer(UInt32 buffer);

            internal delegate void UseProgram(UInt32 program);

            internal delegate void UseProgramStages(UInt32 pipeline, UInt32 stages, UInt32 program);

            internal delegate void ValidateProgram(UInt32 program);

            internal delegate void ValidateProgramPipeline(UInt32 pipeline);

            internal delegate void VertexArrayElementBuffer(UInt32 vaobj, UInt32 buffer);

            internal delegate void VertexAttrib1f(UInt32 index, Single v0);

            internal delegate void VertexAttrib1s(UInt32 index, Int16 v0);

            internal delegate void VertexAttrib1d(UInt32 index, Double v0);

            internal delegate void VertexAttribI1i(UInt32 index, Int32 v0);

            internal delegate void VertexAttribI1ui(UInt32 index, UInt32 v0);

            internal delegate void VertexAttrib2f(UInt32 index, Single v0, Single v1);

            internal delegate void VertexAttrib2s(UInt32 index, Int16 v0, Int16 v1);

            internal delegate void VertexAttrib2d(UInt32 index, Double v0, Double v1);

            internal delegate void VertexAttribI2i(UInt32 index, Int32 v0, Int32 v1);

            internal delegate void VertexAttribI2ui(UInt32 index, UInt32 v0, UInt32 v1);

            internal delegate void VertexAttrib3f(UInt32 index, Single v0, Single v1, Single v2);

            internal delegate void VertexAttrib3s(UInt32 index, Int16 v0, Int16 v1, Int16 v2);

            internal delegate void VertexAttrib3d(UInt32 index, Double v0, Double v1, Double v2);

            internal delegate void VertexAttribI3i(UInt32 index, Int32 v0, Int32 v1, Int32 v2);

            internal delegate void VertexAttribI3ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2);

            internal delegate void VertexAttrib4f(UInt32 index, Single v0, Single v1, Single v2, Single v3);

            internal delegate void VertexAttrib4s(UInt32 index, Int16 v0, Int16 v1, Int16 v2, Int16 v3);

            internal delegate void VertexAttrib4d(UInt32 index, Double v0, Double v1, Double v2, Double v3);

            internal delegate void VertexAttrib4Nub(UInt32 index, Byte v0, Byte v1, Byte v2, Byte v3);

            internal delegate void VertexAttribI4i(UInt32 index, Int32 v0, Int32 v1, Int32 v2, Int32 v3);

            internal delegate void VertexAttribI4ui(UInt32 index, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3);

            internal delegate void VertexAttribL1d(UInt32 index, Double v0);

            internal delegate void VertexAttribL2d(UInt32 index, Double v0, Double v1);

            internal delegate void VertexAttribL3d(UInt32 index, Double v0, Double v1, Double v2);

            internal delegate void VertexAttribL4d(UInt32 index, Double v0, Double v1, Double v2, Double v3);

            internal delegate void VertexAttrib1fv(UInt32 index, Single[] v);

            internal delegate void VertexAttrib1sv(UInt32 index, Int16[] v);

            internal delegate void VertexAttrib1dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribI1iv(UInt32 index, Int32[] v);

            internal delegate void VertexAttribI1uiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttrib2fv(UInt32 index, Single[] v);

            internal delegate void VertexAttrib2sv(UInt32 index, Int16[] v);

            internal delegate void VertexAttrib2dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribI2iv(UInt32 index, Int32[] v);

            internal delegate void VertexAttribI2uiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttrib3fv(UInt32 index, Single[] v);

            internal delegate void VertexAttrib3sv(UInt32 index, Int16[] v);

            internal delegate void VertexAttrib3dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribI3iv(UInt32 index, Int32[] v);

            internal delegate void VertexAttribI3uiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttrib4fv(UInt32 index, Single[] v);

            internal delegate void VertexAttrib4sv(UInt32 index, Int16[] v);

            internal delegate void VertexAttrib4dv(UInt32 index, Double[] v);

            internal delegate void VertexAttrib4iv(UInt32 index, Int32[] v);

            internal delegate void VertexAttrib4bv(UInt32 index, SByte[] v);

            internal delegate void VertexAttrib4ubv(UInt32 index, Byte[] v);

            internal delegate void VertexAttrib4usv(UInt32 index, UInt16[] v);

            internal delegate void VertexAttrib4uiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttrib4Nbv(UInt32 index, SByte[] v);

            internal delegate void VertexAttrib4Nsv(UInt32 index, Int16[] v);

            internal delegate void VertexAttrib4Niv(UInt32 index, Int32[] v);

            internal delegate void VertexAttrib4Nubv(UInt32 index, Byte[] v);

            internal delegate void VertexAttrib4Nusv(UInt32 index, UInt16[] v);

            internal delegate void VertexAttrib4Nuiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttribI4bv(UInt32 index, SByte[] v);

            internal delegate void VertexAttribI4ubv(UInt32 index, Byte[] v);

            internal delegate void VertexAttribI4sv(UInt32 index, Int16[] v);

            internal delegate void VertexAttribI4usv(UInt32 index, UInt16[] v);

            internal delegate void VertexAttribI4iv(UInt32 index, Int32[] v);

            internal delegate void VertexAttribI4uiv(UInt32 index, UInt32[] v);

            internal delegate void VertexAttribL1dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribL2dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribL3dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribL4dv(UInt32 index, Double[] v);

            internal delegate void VertexAttribP1ui(UInt32 index, VertexAttribPType type, Boolean normalized,
                UInt32 value);

            internal delegate void VertexAttribP2ui(UInt32 index, VertexAttribPType type, Boolean normalized,
                UInt32 value);

            internal delegate void VertexAttribP3ui(UInt32 index, VertexAttribPType type, Boolean normalized,
                UInt32 value);

            internal delegate void VertexAttribP4ui(UInt32 index, VertexAttribPType type, Boolean normalized,
                UInt32 value);

            internal delegate void VertexAttribBinding(UInt32 attribindex, UInt32 bindingindex);

            internal delegate void VertexArrayAttribBinding(UInt32 vaobj, UInt32 attribindex, UInt32 bindingindex);

            internal delegate void VertexAttribDivisor(UInt32 index, UInt32 divisor);

            internal delegate void VertexAttribFormat(UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, Boolean normalized, UInt32 relativeoffset);

            internal delegate void VertexAttribIFormat(UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, UInt32 relativeoffset);

            internal delegate void VertexAttribLFormat(UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, UInt32 relativeoffset);

            internal delegate void VertexArrayAttribFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, Boolean normalized, UInt32 relativeoffset);

            internal delegate void VertexArrayAttribIFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, UInt32 relativeoffset);

            internal delegate void VertexArrayAttribLFormat(UInt32 vaobj, UInt32 attribindex, Int32 size,
                Engine.OpenGL.Vendor.OpenGL.Core.VertexAttribFormat type, UInt32 relativeoffset);

            internal delegate void VertexAttribPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
                Boolean normalized, Int32 stride, IntPtr pointer);

            internal delegate void VertexAttribIPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
                Int32 stride, IntPtr pointer);

            internal delegate void VertexAttribLPointer(UInt32 index, Int32 size, VertexAttribPointerType type,
                Int32 stride, IntPtr pointer);

            internal delegate void VertexBindingDivisor(UInt32 bindingindex, UInt32 divisor);

            internal delegate void VertexArrayBindingDivisor(UInt32 vaobj, UInt32 bindingindex, UInt32 divisor);

            internal delegate void Viewport(Int32 x, Int32 y, Int32 width, Int32 height);

            internal delegate void ViewportArrayv(UInt32 first, Int32 count, Single[] v);

            internal delegate void ViewportIndexedf(UInt32 index, Single x, Single y, Single w, Single h);

            internal delegate void ViewportIndexedfv(UInt32 index, Single[] v);

            internal delegate void WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout);
        }
    }
}
