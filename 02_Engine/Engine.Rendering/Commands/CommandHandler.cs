using Engine.Core.Driver;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.Core.Rendering.Commands;
using Engine.Rendering.Commands.RenderCommands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Rendering.Commands;

public class CommandHandler : CommandHandlerBase
{
    public CommandHandler()
    {
        RegisterHandler(CommandType.BindShaderProgram, BindShaderProgramHandler);
        RegisterHandler(CommandType.BindTexture, BindTextureHandler);
        RegisterHandler(CommandType.BindBufferArray, BindBufferArrayHandler);
        RegisterHandler(CommandType.BindUniformBuffer, BindUniformBufferHandler);
        RegisterHandler(CommandType.SetPrimitiveType, SetPrimitiveTypeHandler);
        RegisterHandler(CommandType.RenderElement, RenderElementHandler);
        RegisterHandler(CommandType.SetIndexCount, SetIndexCountHandler);
        RegisterHandler(CommandType.SetShaderUniform, SetShaderUniformHandler);
    }

    private void BindShaderProgramHandler(IContext context, ICommand command)
    {
        if (command is BindShaderProgramCommand bindCommand)
        {
            bindCommand.ShaderProgram.Bind();
        }
    }

    private void SetShaderUniformHandler(IContext context, ICommand command)
    {
        if (command is not SetShaderUniformCommandBase bindCommand)
        {
            return;
        }

        if (bindCommand.ValueType == typeof(int) && command is SetShaderUniformCommand<int> intCommand)
        {
            context.SetShaderUniformI(intCommand.UniformName, intCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(float) && command is SetShaderUniformCommand<float> floatCommand)
        {
            context.SetShaderUniformF(floatCommand.UniformName, floatCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(float[]) && command is SetShaderUniformCommand<float[]> floatArrayCommand)
        {
            context.SetShaderUniformF(floatArrayCommand.UniformName, floatArrayCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector2) && command is SetShaderUniformCommand<Vector2> vector2Command)
        {
            context.SetShaderUniformVec2(vector2Command.UniformName, vector2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector3) && command is SetShaderUniformCommand<Vector3> vector3Command)
        {
            context.SetShaderUniformVec3(vector3Command.UniformName, vector3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector4) && command is SetShaderUniformCommand<Vector4> vector4Command)
        {
            context.SetShaderUniformVec4(vector4Command.UniformName, vector4Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix2) && command is SetShaderUniformCommand<Matrix2> matrix2Command)
        {
            context.SetShaderUniformMat2(matrix2Command.UniformName, matrix2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix3) && command is SetShaderUniformCommand<Matrix3> matrix3Command)
        {
            context.SetShaderUniformMat3(matrix3Command.UniformName, matrix3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix4) && command is SetShaderUniformCommand<Matrix4> matrix4Command)
        {
            context.SetShaderUniformMat4(matrix4Command.UniformName, matrix4Command.Value);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private void BindTextureHandler(IContext context, ICommand command)
    {
        if (command is BindTextureCommand bindCommand)
        {
            bindCommand.Texture.Bind(bindCommand.TextureUnit);
        }
    }

    private void BindBufferArrayHandler(IContext context, ICommand command)
    {
        if (command is BindBufferArrayCommand bindCommand)
        {
            bindCommand.BufferArray.Bind();
        }
    }

    private void BindUniformBufferHandler(IContext context, ICommand command) =>
        throw

            // if (command is BindUniformBufferCommand bindCommand)
            // {
            //     bindCommand.UniformBuffer.Bind(bindCommand.BindingPoint);
            // }
            new NotImplementedException();

    private void SetPrimitiveTypeHandler(IContext context, ICommand command)
    {
        if (command is SetPrimitiveTypeCommand bindCommand)
        {
            context.SetPrimitiveType(bindCommand.PrimitiveType);
        }
    }

    private void RenderElementHandler(IContext context, ICommand command)
    {
        if (command is RenderElementCommand bindCommand)
        {
            context.RenderElement();
        }
    }

    private void SetIndexCountHandler(IContext context, ICommand command)
    {
        if (command is SetIndexCountCommand bindCommand)
        {
            context.SetIndexCount(bindCommand.IndexCount);
        }
    }
}
