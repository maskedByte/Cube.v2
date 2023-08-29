using Engine.Core.Driver;
using Engine.Core.Logging;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.Rendering.Commands.ProcessCommands;
using Engine.Rendering.Commands.RenderCommands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Rendering.Commands;

public class CommandHandler : CommandHandlerBase
{
    public CommandHandler()
    {
        RegisterCommandTypeHandler(CommandType.ProcessCommand, ProcessCommandHandler);
        RegisterCommandTypeHandler(CommandType.BindShaderProgram, BindShaderProgramHandler);
        RegisterCommandTypeHandler(CommandType.BindTexture, BindTextureHandler);
        RegisterCommandTypeHandler(CommandType.BindBufferArray, BindBufferArrayHandler);
        RegisterCommandTypeHandler(CommandType.BindUniformBuffer, BindUniformBufferHandler);
        RegisterCommandTypeHandler(CommandType.SetPrimitiveType, SetPrimitiveTypeHandler);
        RegisterCommandTypeHandler(CommandType.RenderElement, RenderElementHandler);
        RegisterCommandTypeHandler(CommandType.SetIndexCount, SetIndexCountHandler);
        RegisterCommandTypeHandler(CommandType.SetShaderUniform, SetShaderUniformHandler);
        RegisterCommandTypeHandler(CommandType.SetUniformBufferValue, SetUniformBufferValueHandler);
    }

    private void ProcessCommandHandler(IContext context, ICommand command)
    {
        if (command is not ProcessCommand bindCommand)
        {
            return;
        }

        var resultCommand = bindCommand.CommandFunc(context);
        if (resultCommand != null)
        {
            Handle(context, resultCommand);
        }
    }

    private void SetUniformBufferValueHandler(IContext context, ICommand command)
    {
        if (command is not SetUniformBufferValueCommandBase bindCommand)
        {
            return;
        }

        var activeUniformBuffer = context.GetActiveUniformBuffer();
        if (activeUniformBuffer == null)
        {
            Log.LogMessageAsync("No active uniform buffer bound.", LogLevel.Warning, this);
            return;
        }

        if (bindCommand.ValueType == typeof(Vector2) && command is SetUniformBufferValueCommand<Vector2> vector2Command)
        {
            activeUniformBuffer.SetUniformData(vector2Command.UniformName, vector2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector3) && command is SetUniformBufferValueCommand<Vector3> vector3Command)
        {
            activeUniformBuffer.SetUniformData(vector3Command.UniformName, vector3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector4) && command is SetUniformBufferValueCommand<Vector4> vector4Command)
        {
            activeUniformBuffer.SetUniformData(vector4Command.UniformName, vector4Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix4) && command is SetUniformBufferValueCommand<Matrix4> matrix4Command)
        {
            activeUniformBuffer.SetUniformData(matrix4Command.UniformName, matrix4Command.Value);
        }
        else if (bindCommand.ValueType == typeof(int) && command is SetUniformBufferValueCommand<int> intCommand)
        {
            activeUniformBuffer.SetUniformData(intCommand.UniformName, intCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(float) && command is SetUniformBufferValueCommand<float> floatCommand)
        {
            activeUniformBuffer.SetUniformData(floatCommand.UniformName, floatCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix2) && command is SetUniformBufferValueCommand<Matrix2> matrix2Command)
        {
            activeUniformBuffer.SetUniformData(matrix2Command.UniformName, matrix2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix3) && command is SetUniformBufferValueCommand<Matrix3> matrix3Command)
        {
            activeUniformBuffer.SetUniformData(matrix3Command.UniformName, matrix3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Color) && command is SetUniformBufferValueCommand<Color> colorCommand)
        {
            activeUniformBuffer.SetUniformData(colorCommand.UniformName, colorCommand.Value);
        }
    }

    private void BindShaderProgramHandler(IContext context, ICommand command)
    {
        if (command is BindShaderProgramCommand bindCommand)
        {
            context.BindShaderProgram(bindCommand.ShaderProgram);
        }
    }

    private void SetShaderUniformHandler(IContext context, ICommand command)
    {
        if (command is not SetUniformValueCommandBase bindCommand)
        {
            return;
        }

        if (bindCommand.ValueType == typeof(Vector2) && command is SetUniformValueCommand<Vector2> vector2Command)
        {
            context.SetShaderUniformVec2(vector2Command.UniformName, vector2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector3) && command is SetUniformValueCommand<Vector3> vector3Command)
        {
            context.SetShaderUniformVec3(vector3Command.UniformName, vector3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Vector4) && command is SetUniformValueCommand<Vector4> vector4Command)
        {
            context.SetShaderUniformVec4(vector4Command.UniformName, vector4Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix4) && command is SetUniformValueCommand<Matrix4> matrix4Command)
        {
            context.SetShaderUniformMat4(matrix4Command.UniformName, matrix4Command.Value);
        }
        else if (bindCommand.ValueType == typeof(int) && command is SetUniformValueCommand<int> intCommand)
        {
            context.SetShaderUniformI(intCommand.UniformName, intCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(float) && command is SetUniformValueCommand<float> floatCommand)
        {
            context.SetShaderUniformF(floatCommand.UniformName, floatCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(float[]) && command is SetUniformValueCommand<float[]> floatArrayCommand)
        {
            context.SetShaderUniformF(floatArrayCommand.UniformName, floatArrayCommand.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix2) && command is SetUniformValueCommand<Matrix2> matrix2Command)
        {
            context.SetShaderUniformMat2(matrix2Command.UniformName, matrix2Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Matrix3) && command is SetUniformValueCommand<Matrix3> matrix3Command)
        {
            context.SetShaderUniformMat3(matrix3Command.UniformName, matrix3Command.Value);
        }
        else if (bindCommand.ValueType == typeof(Color) && command is SetUniformBufferValueCommand<Color> colorCommand)
        {
            context.SetShaderUniformVec4(colorCommand.UniformName, colorCommand.Value.ToVector4());
        }
    }

    private void BindTextureHandler(IContext context, ICommand command)
    {
        if (command is BindTextureCommand bindCommand)
        {
            context.BindTexture(bindCommand.Texture, bindCommand.TextureUnit);
        }
    }

    private void BindBufferArrayHandler(IContext context, ICommand command)
    {
        if (command is BindBufferArrayCommand bindCommand)
        {
            context.BindBufferArray(bindCommand.BufferArray);
        }
    }

    private void BindUniformBufferHandler(IContext context, ICommand command)
    {
        if (command is BindUniformBufferCommand bindCommand)
        {
            context.BindUniformBuffer(bindCommand.UniformBuffer);
        }
    }

    private void SetPrimitiveTypeHandler(IContext context, ICommand command)
    {
        if (command is SetPrimitiveTypeCommand bindCommand)
        {
            context.SetPrimitiveType(bindCommand.PrimitiveType);
        }
    }

    private void RenderElementHandler(IContext context, ICommand command)
    {
        if (command is DrawElementsCommand bindCommand)
        {
            context.DrawElements();
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
